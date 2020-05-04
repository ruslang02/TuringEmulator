using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace TuringEmulator
{
    public partial class MainForm : Form
    {
        MemoryStream StateBuffer { get; set; }
        readonly BinaryFormatter fileFormat = new BinaryFormatter();
        /// <summary>
        /// Predicts steps of an algorithm.
        /// </summary>
        private void Predict()
        {
            if (StateBuffer != null)
                StateBuffer.Dispose();
            StateBuffer = new MemoryStream();
            currentState.Data = new DataArray(currentState.StartData.ToString());
            currentState.Step = 0;
            foreach (Instruction j in currentState.Instructions)
                j.Active = false;
            fileFormat.Serialize(StateBuffer, currentState);

            bool continueExec = true;
            int i = 1;
            AlgorithmPreviewPanel.Controls.Clear();
            AlgorithmPreviewPanel.SuspendLayout();
            TableLayoutPanel inputWordPanel = new TableLayoutPanel()
            {
                ColumnCount = 2,
                RowCount = 1,
                Margin = new Padding(0, 0, 0, 10),
                AutoSize = true
            };

            Button inputWordIcon = new Button()
            {
                Image = Properties.Resources.textbox_password,
                Width = 40,
                Height = 40,
                FlatStyle = FlatStyle.Popup
            };

            Label inputWordLabel = new Label()
            {
                Text = "Входное слово:",
                Font = new Font(this.Font.FontFamily, 10),
                AutoSize = true
            };
            Label inputWordValue = new Label()
            {
                Text = currentState.Data.ToString(),
                Margin = new Padding(0, 3, 0, 0),
                Font = new Font(this.Font.FontFamily, 12, FontStyle.Bold),
                AutoSize = true
            };

            FlowLayoutPanel inputWordInfoPanel = new FlowLayoutPanel()
            {
                FlowDirection = FlowDirection.TopDown,
                Dock = DockStyle.Fill,
                AutoSize = true
            };
            inputWordInfoPanel.Controls.AddRange(new[] { inputWordLabel, inputWordValue });

            inputWordPanel.Controls.Add(inputWordIcon, 0, 0);
            inputWordPanel.Controls.Add(inputWordInfoPanel, 1, 0);
            AlgorithmPreviewPanel.Controls.Add(inputWordPanel);
            try
            {
                for (i = 1; continueExec; i++)
                {
                    if (i > MAX_STEPS)
                    {
                        MessageBox.Show($"Возможно, произошло зацикливание алгоритма (программа имеет более чем {MAX_STEPS} шагов).\r\nПопробуйте запустить её с другими входными данными или исправьте место зацикливания.", "Ошибка расчёта шагов алгоритма", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        CurrentStateLabel.Text = "Программа возможно зацикливается.";
                        break;
                    }
                    char displaySym = currentState.Data.Current;
                    string prevData = currentState.Data.ToString();
                    char sym = currentState.Data.Current == '_' ? '\0' : currentState.Data.Current;
                    Instruction activeInstruction = GetActiveInstruction();
                    Operation activeItem = activeInstruction.Operations.Single(item => item.OldChar == sym);
                    if (activeItem.IsStop)
                        continueExec = false;
                    else
                    {
                        Instruction newInstruction = currentState.Instructions.Single(inst => inst.Name == activeItem.NextInstruction);
                        activeInstruction.Active = false;
                        newInstruction.Active = true;
                        currentState.Data.Current = activeItem.NewChar;
                        currentState.Data.CurrentPosition += (int)activeItem.Direction;
                    }
                    currentState.Step = i;
                    fileFormat.Serialize(StateBuffer, currentState);
                    TableLayoutPanel predictionTable = new TableLayoutPanel()
                    {
                        ColumnCount = 2,
                        RowCount = 1,
                        AutoSize = true,
                        Margin = new Padding(0)
                    };

                    Button stepButton = new Button()
                    {
                        Text = i.ToString(),
                        Font = new Font(this.Font.FontFamily, 10, FontStyle.Bold),
                        Width = 40,
                        Height = 40,
                        FlatStyle = FlatStyle.Popup
                    };

                    predictionTable.Controls.Add(stepButton, 0, 0);
                    FlowLayoutPanel infoPanel = new FlowLayoutPanel()
                    {
                        FlowDirection = FlowDirection.TopDown,
                        Dock = DockStyle.Fill,
                        AutoSize = true
                    };
                    Label instructionLabel = new Label
                    {
                        Text = activeItem.ToString(),
                        Font = new Font(this.Font.FontFamily, 12, FontStyle.Bold),
                        AutoSize = true
                    };

                    Label previousDataLabel = new Label
                    {
                        ForeColor = Color.DarkRed,
                        Text = prevData,
                        AutoSize = true
                    };

                    Label nextDataLabel = new Label
                    {
                        ForeColor = Color.DarkGreen,
                        Text = currentState.Data.ToString(),
                        AutoSize = true
                    };

                    infoPanel.Controls.AddRange(new[] { instructionLabel, previousDataLabel, nextDataLabel });
                    predictionTable.Controls.Add(infoPanel, 1, 0);
                    AlgorithmPreviewPanel.Controls.Add(predictionTable);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Программа не работает правильно при данных входных данных. Расчёт шагов невозможен.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            AlgorithmPreviewPanel.ResumeLayout();
            SetTotalSteps(i - 1);
            StateBuffer.Seek(0, SeekOrigin.Begin);
            currentState = (State)fileFormat.Deserialize(StateBuffer);
            CurrentStepLabel.Text = $"Шаг: 0/{i - 1}";

            UpdateTable();
            InputUpdate();
            HighlightCurrentStep();
        }
        /// <summary>
        /// Sets up total steps counter on the States.
        /// </summary>
        /// <param name="totalSteps">Total steps</param>
        private void SetTotalSteps(int totalSteps)
        {
            MemoryStream newBuffer = new MemoryStream();
            StateBuffer.Seek(0, SeekOrigin.Begin);
            while (true)
            {
                try
                {
                    State s = (State)fileFormat.Deserialize(StateBuffer);
                    s.TotalSteps = totalSteps;
                    fileFormat.Serialize(newBuffer, s);
                }
                catch (Exception)
                {
                    StateBuffer.Dispose();
                    StateBuffer = newBuffer;
                    StateBuffer.Seek(0, SeekOrigin.Begin);
                    return;
                }
            }
        }
    }
}