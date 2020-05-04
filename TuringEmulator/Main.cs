using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Windows.Forms;

namespace TuringEmulator
{
    public partial class MainForm : Form
    {
        const int MAX_STEPS = 99;
        State currentState;

        DataTable InstructionsTable { get; } = new DataTable("Instructions");

        public MainForm()
        {
            InitializeComponent();
            Table.DataSource = InstructionsTable;
        }

        /// <summary>
        /// Launches the app with some default data.
        /// </summary>
        private void EmptyLaunch()
        {
            char[] chars = new char[] { '\0', '0', '1' };
            Instruction Inst_A = new Instruction() { Name = "A", Start = true };
            Instruction Inst_B = new Instruction() { Name = "B" };
            Inst_A.Operations.AddRange(new Operation[] {
                new Operation
                {
                    OldChar = '\0',
                    Direction = Direction.LEFT,
                    NewChar = '\0',
                    NextInstruction = "B"
                },
                new Operation
                {
                    OldChar = '0',
                    Direction = Direction.RIGHT,
                    NewChar = '0',
                    NextInstruction = "A"
                },
                new Operation
                {
                    OldChar = '1',
                    Direction = Direction.RIGHT,
                    NewChar = '1',
                    NextInstruction = "A"
                },
            });

            Inst_B.Operations.AddRange(new Operation[] {
                new Operation
                {
                    OldChar = '\0',
                    IsStop = true
                },
                new Operation
                {
                    OldChar = '0',
                    Direction = Direction.LEFT,
                    NewChar = '1',
                    NextInstruction = "B"
                },
                new Operation
                {
                    OldChar = '1',
                    Direction = Direction.LEFT,
                    NewChar = '0',
                    NextInstruction = "B"
                },
            });
            LoadTable(chars, new[] { Inst_A, Inst_B }, new DataArray("1100"));
        }

        private void RunAlgorithmButton_Click(object sender, EventArgs e)
        {
            Button button = RunAlgorithmButton;
            if (button.Tag == null || button.Tag.ToString() == "play")
            {
                ExecTimer.Start();
                button.Image = Properties.Resources.pause;
                button.Tag = "pause";
            }
            else if (button.Tag.ToString() == "pause")
            {
                ExecTimer.Stop();
                button.Image = Properties.Resources.play;
                button.Tag = "play";
            }
            else if (button.Tag.ToString() == "restart")
            {
                ExecTimer.Stop();
                button.Image = Properties.Resources.play;
                StateBuffer.Seek(0, SeekOrigin.Begin);
                currentState = (State)fileFormat.Deserialize(StateBuffer);
                UpdateTable();
                InputUpdate();
                CurrentStepLabel.Text = $"Шаг: {currentState.Step}/{currentState.TotalSteps}";
                HighlightCurrentStep();
                button.Tag = "play";
            }
        }

        private void NextStep()
        {
            int oldInstructionId, oldItemId;
            try
            {
                char oldSym = currentState.Data.Current == '_' ? '\0' : currentState.Data.Current;
                Instruction oldInstruction = GetActiveInstruction();
                oldInstructionId = Array.IndexOf(currentState.Instructions, oldInstruction);
                Operation oldItem = oldInstruction.Operations.Single(i => i.OldChar == oldSym);
                oldItemId = oldInstruction.Operations.IndexOf(oldItem);
                if (currentState.Step == currentState.TotalSteps)
                { }
                else
                {
                    string dir = oldItem.Direction == Direction.LEFT ? " и сдвинула курсор влево" : oldItem.Direction == Direction.RIGHT ? " и сдвинула курсор вправо" : "";
                    CurrentStateLabel.Text = $"Инструкция `{oldItem}` заменила символ `{oldSym}` на `{oldItem.NewChar}`{dir}.";
                }
                currentState = (State)fileFormat.Deserialize(StateBuffer);
            }
            catch (Exception)
            {
                ExecTimer.Stop();
                MessageBox.Show("Алгоритм завершился, перезапустите его.", "Невозможно продолжить", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RunAlgorithmButton.Image = Properties.Resources.restart;
                RunAlgorithmButton.Tag = "restart";
                return;
            }
            if (currentState.Step == currentState.TotalSteps)
            {
                CurrentStateLabel.Text = "Выполнение завершено, необходим перезапуск.";
                RunAlgorithmButton.Image = Properties.Resources.restart;
                RunAlgorithmButton.Tag = "restart";
                InputUpdate(currentState.Data.CurrentPosition);
                ExecTimer.Stop();
            }
            else
            {
                if (!ExecTimer.Enabled)
                {
                    RunAlgorithmButton.Image = Properties.Resources.play;
                    RunAlgorithmButton.Tag = "play";
                }
                try
                {
                    currentState.SaveToFile("saved.emt");
                }
                catch (Exception) { }
                InputUpdate(currentState.Data.PreviousPosition);
            }
            UpdateTable(oldInstructionId, oldItemId + 1);
            CurrentStepLabel.Text = $"Шаг: {currentState.Step}/{currentState.TotalSteps}";
            HighlightCurrentStep();
        }

        private void HighlightCurrentStep()
        {
            for (int i = 1; i < currentState.TotalSteps + 1; i++)
            {
                TableLayoutPanel predTable = (TableLayoutPanel)AlgorithmPreviewPanel.Controls[i];
                Button predButton = (Button)predTable.Controls[0];
                predButton.BackColor = i == currentState.Step ? Color.LightGreen : i == currentState.Step + 1 ? Color.LightBlue : Color.White;
                if (i == currentState.Step + 1)
                    AlgorithmPreviewPanel.ScrollControlIntoView(predTable);
            }
        }

        private void InputUpdate(int? prevPos = null)
        {
            Label activeLabel = null;
            if (!prevPos.HasValue)
                prevPos = currentState.Data.CurrentPosition;
            InputDataTable.SuspendLayout();
            InputDataTable.Controls.Clear();
            InputDataTable.ColumnCount = currentState.Data.Count;
            for (int i = -currentState.Data.NegativeCount; i < currentState.Data.PositiveCount; i++)
            {
                Label label = new Label()
                {
                    Font = new Font(this.Font.FontFamily, 18, i == currentState.Data.CurrentPosition || i == prevPos ? FontStyle.Bold : FontStyle.Regular),
                    ForeColor = i == prevPos ? Color.Brown : Color.Black,
                    BackColor = i == currentState.Data.CurrentPosition ? Color.LightGreen : Color.White,
                    AutoSize = false,
                    Width = 40,
                    Height = 40,
                    Text = (currentState.Data[i] == '\0' ? '_' : currentState.Data[i]).ToString(),
                    Margin = Padding.Empty,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                if (i == currentState.Data.CurrentPosition)
                    activeLabel = label;
                InputDataTable.Controls.Add(label, i + (currentState.Data.NegativeCount), 0);
            }
            InputDataTable.ResumeLayout();
            if (activeLabel == null)
                return;
            int a = panel2.Width / 2 - (2 * activeLabel.Location.X + activeLabel.Width) / 2;
            InputDataTable.Location = new Point(a, InputDataTable.Location.Y);
        }
        private void ExecTimer_Tick(object sender, EventArgs e) => NextStep();
        private void ChangeInputDataButton_Click(object sender, EventArgs e)
        {
            using (InputEditorForm form = new InputEditorForm())
            {
                DialogResult result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    currentState.StartData = new DataArray(form.ReturnInput);
                    Predict();
                }
            }
        }
        private void AboutApp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Обучающий эмулятор Машины Тьюринга.\r\n\r\nГарифуллин Руслан, Программная инженерия, ФКН НИУ ВШЭ.\r\n2020 год.");
        }
        private Instruction GetActiveInstruction()
        {
            Instruction start = null;
            foreach (Instruction i in currentState.Instructions)
            {
                if (i.Active)
                    return i;
                if (i.Start) start = i;
            }
            return start;
        }
        private void SaveStateButton_Click(object sender, EventArgs e) => SaveStateDialog.ShowDialog();
        private void LoadStateButton_Click(object sender, EventArgs e) => LoadStateDialog.ShowDialog();
        private void LaunchStateSelector_Change(object sender, EventArgs e)
        {
            if (ExecTimer.Enabled || isBuildingTable)
                return;
            ToolStripComboBox me = (ToolStripComboBox)sender;
            foreach (Instruction instruction in currentState.Instructions)
                instruction.Start = me.Text == instruction.Name;
            Predict();
        }
        private void PreviousStepButton_Click(object sender, EventArgs e)
        {
            StateBuffer.Seek(0, SeekOrigin.Begin);
            for (int i = 0; i < currentState.Step - 1; i++)
                fileFormat.Deserialize(StateBuffer);
            NextStep();
        }
        private void NextStepButton_Click(object sender, EventArgs e)
        {
            StateBuffer.Seek(0, SeekOrigin.Begin);
            for (int i = 0; i < currentState.Step + 1; i++)
                fileFormat.Deserialize(StateBuffer);
            NextStep();
        }
        private void ExportToJSONButton_Click(object sender, EventArgs e) => JSONSaveDialog.ShowDialog();
        private void LoadStateDialog_Select(object sender, System.ComponentModel.CancelEventArgs e)
            => LoadAppFile(LoadStateDialog.FileName);

        private void LoadAppFile(string filename)
        {
            if (currentState == null)
                try
                {
                    using (FileStream fs = new FileStream(filename, FileMode.Open))
                    {
                        BinaryFormatter format = new BinaryFormatter();
                        currentState = (State)format.Deserialize(fs);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Не удалось загрузить файл.");
                    EmptyLaunch();
                }
            else
                currentState.LoadFromFile(filename);
            int step = currentState.Step;
            Predict();
            StateBuffer.Seek(0, SeekOrigin.Begin);
            for (int i = 0; i < step; i++)
                fileFormat.Deserialize(StateBuffer);
            NextStep();
        }
        private void SaveStateDialog_Select(object sender, System.ComponentModel.CancelEventArgs e)
            => currentState.SaveToFile(SaveStateDialog.FileName);

        private void JSONSaveDialog_Select(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveFileDialog ofd = sender as SaveFileDialog;
            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(List<State>));
            List<State> states = new List<State>();
            StateBuffer.Seek(0, SeekOrigin.Begin);
            for (int i = 0; i < currentState.TotalSteps + 1; i++)
            {
                State fullState = fileFormat.Deserialize(StateBuffer) as State;
                if (i != 0)
                {
                    fullState.Instructions = null;
                    fullState.StartData = null;
                }
                states.Add(fullState);
            }
            try
            {
                using (FileStream fs = new FileStream(ofd.FileName, FileMode.Create))
                    json.WriteObject(fs, states);
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось сохранить файл.");
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            if (File.Exists("saved.emt"))
                if (MessageBox.Show("Загрузить сохраненное состояние?", "Найдено сохраненное состояние", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    LoadAppFile("saved.emt");
                    return;
                }
            EmptyLaunch();
            ExecTimerSelector.SelectedIndex = 1;
        }

        private void ExecTimerSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            int x = ExecTimerSelector.SelectedIndex;
            double delay = 500 + 1125 * x - 1187.5 * x * x + 625 * x * x * x - 62.5 * x * x * x * x;
            ExecTimer.Interval = (int)delay;
        }
    }
}
