using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Collections.Generic;

namespace TuringEmulator
{
    public partial class Main : Form
    {
        const int MAX_STEPS = 99;

        DataSet program;
        DataTable programInstructions;
        State state;
        public Main()
        {
            InitializeComponent();
            program = new DataSet("Program");
            programInstructions = program.Tables.Add("Instructions");
            Table.DataSource = program;
            Table.AutoGenerateColumns = true;
            Table.DataMember = "Instructions";
            Table.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridViewTextBoxCell template = new DataGridViewTextBoxCell();
            EmptyLaunch();
        }

        private void EmptyLaunch()
        {
            char[] chars = new char[] { '\0', '0', '1' };
            Instruction Inst_A = new Instruction() { Name = "A", Start = true };
            Instruction Inst_B = new Instruction() { Name = "B" };
            Inst_A.Items.AddRange(new InstructionItem[] {
                new InstructionItem
                {
                    OldChar = '\0',
                    Direction = Direction.LEFT,
                    NewChar = '\0',
                    NextInstruction = Inst_B
                },
                new InstructionItem
                {
                    OldChar = '0',
                    Direction = Direction.RIGHT,
                    NewChar = '0',
                    NextInstruction = Inst_A
                },
                new InstructionItem
                {
                    OldChar = '1',
                    Direction = Direction.RIGHT,
                    NewChar = '1',
                    NextInstruction = Inst_A
                },
            });

            Inst_B.Items.AddRange(new InstructionItem[] {
                new InstructionItem
                {
                    OldChar = '\0',
                    IsStop = true
                },
                new InstructionItem
                {
                    OldChar = '0',
                    Direction = Direction.LEFT,
                    NewChar = '1',
                    NextInstruction = Inst_B
                },
                new InstructionItem
                {
                    OldChar = '1',
                    Direction = Direction.LEFT,
                    NewChar = '0',
                    NextInstruction = Inst_B
                },
            });
            LoadTable(chars, new[] { Inst_A, Inst_B }, new DataArray("1100"));
        }

        private void LoadTable(char[] chars, Instruction[] instructions, DataArray data)
        {
            state = new State() { Chars = chars, Instructions = instructions, Data = data, StartData = data };
            Predict();
        }
        private bool isBuildingTable = false;
        private void UpdateTable(int prevRow = -1, int prevColumn = -1)
        {
            isBuildingTable = true;
            programInstructions.Columns.Clear();
            toolStripComboBox2.Items.Clear();
            programInstructions.Rows.Clear();
            programInstructions.Columns.Add("Имя", typeof(string));
            for (int i = 0; i < state.Chars.Length; i++)
            {
                char displayChr = state.Chars[i] == '\0' ? '_' : state.Chars[i];
                programInstructions.Columns.Add(displayChr.ToString(), typeof(string));
            }

            Table.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            try
            {
                for (int i = 0; i < state.Instructions.Length; i++)
                {
                    Instruction instruction = state.Instructions[i];
                    toolStripComboBox2.Items.Add(instruction.Name);
                    string[] row = new string[] { instruction.Name };
                    Array.Resize(ref row, instruction.Items.Count + 1);
                    Array.Copy(instruction.Items.ConvertAll(item => item.ToString()).ToArray(), 0, row, 1, instruction.Items.Count);
                    programInstructions.Rows.Add(row);
                    if (instruction.Start)
                        toolStripComboBox2.SelectedIndex = i;
                    if (instruction.Active)
                    {
                        char sym = state.Data.Current == '_' ? '\0' : state.Data.Current;
                        InstructionItem activeItem = instruction.Items.Single(item => item.OldChar == sym);
                        int j = instruction.Items.IndexOf(activeItem);
                        for (int k = 0; k < Table.Rows[i].Cells.Count; k++)
                        {
                            DataGridViewCell currentCell = Table.Rows[i].Cells[k];
                            if (i == prevRow && k == prevColumn)
                            {
                                currentCell.Style.Font = new Font(this.Font, FontStyle.Bold);
                                currentCell.Style.ForeColor = Color.DarkGreen;
                            }
                            if (k - 1 == j)
                            {
                                currentCell.Style.Font = new Font(this.Font, FontStyle.Bold);
                                currentCell.Style.ForeColor = Color.Black;
                            }
                            currentCell.Style.BackColor = Color.SkyBlue;
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Алгоритм не может продолжать работу, символ не найден.\r\nНажмите \"ОК\", чтобы возвратиться в исходное положение.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                button1.Tag = "restart";
                button1_Click(button1, EventArgs.Empty);
            }
            isBuildingTable = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button button = button1;
            if (button.Tag == null || button.Tag == "play")
            {
                timer1.Start();
                button.Image = Properties.Resources.pause;
                button.Tag = "pause";
            }
            else if (button.Tag == "pause")
            {
                timer1.Stop();
                button.Image = Properties.Resources.play;
                button.Tag = "play";
            }
            else if (button.Tag == "restart")
            {
                timer1.Stop();
                button.Image = Properties.Resources.play;
                stateBuffer.Seek(0, SeekOrigin.Begin);
                state = (State)format.Deserialize(stateBuffer);
                UpdateTable();
                InputUpdate();
                toolStripStatusLabel2.Text = $"Шаг: {state.Step}/{state.TotalSteps}";
                ActivatePredictItem();
                button.Tag = "play";
            }
        }

        private void NextStep()
        {
            int oldInstructionId, oldItemId;
            try
            {
                char oldSym = state.Data.Current == '_' ? '\0' : state.Data.Current;
                Instruction oldInstruction = GetActiveInstruction();
                oldInstructionId = Array.IndexOf(state.Instructions, oldInstruction);
                InstructionItem oldItem = oldInstruction.Items.Single(i => i.OldChar == oldSym);
                oldItemId = oldInstruction.Items.IndexOf(oldItem);
                if (state.Step == state.TotalSteps)
                { }
                else
                {
                    string dir = oldItem.Direction == Direction.LEFT ? " и сдвинула курсор влево" : oldItem.Direction == Direction.RIGHT ? " и сдвинула курсор вправо" : "";
                    toolStripStatusLabel1.Text = $"Инструкция `{oldItem}` заменила символ `{oldSym}` на `{oldItem.NewChar}`{dir}.";
                }
                state = (State)format.Deserialize(stateBuffer);
            }
            catch (Exception)
            {
                timer1.Stop();
                MessageBox.Show("Алгоритм завершился, перезапустите его.", "Невозможно продолжить", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button1.Image = Properties.Resources.restart;
                button1.Tag = "restart";
                return;
            }
            if (state.Step == state.TotalSteps)
            {
                toolStripStatusLabel1.Text = "Выполнение завершено, необходим перезапуск.";
                button1.Image = Properties.Resources.restart;
                button1.Tag = "restart";
                InputUpdate(state.Data.CurrentPosition);
                timer1.Stop();
            }
            else
            {
                if (!timer1.Enabled)
                {
                    button1.Image = Properties.Resources.play;
                    button1.Tag = "play";
                }
                InputUpdate(state.Data.PreviousPosition);
            }
            UpdateTable(oldInstructionId, oldItemId + 1);
            toolStripStatusLabel2.Text = $"Шаг: {state.Step}/{state.TotalSteps}";
            ActivatePredictItem();
        }

        private void ActivatePredictItem()
        {
            for (int i = 1; i < state.TotalSteps + 1; i++)
            {
                TableLayoutPanel predTable = (TableLayoutPanel)flowLayoutPanel1.Controls[i];
                Button predButton = (Button)predTable.Controls[0];
                predButton.BackColor = i == state.Step ? Color.LightGreen : i == state.Step + 1 ? Color.LightBlue : Color.White;
                if (i == state.Step + 1)
                    flowLayoutPanel1.ScrollControlIntoView(predTable);
            }
        }

        private void tableLayoutPanel2_SizeChanged(object sender, EventArgs e)
        {
            InputUpdate(state.Data.CurrentPosition);
        }
        private void InputUpdate(int? prevPos = null)
        {
            Label activeLabel = null;
            if (!prevPos.HasValue)
                prevPos = state.Data.CurrentPosition;
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel2.Controls.Clear();
            tableLayoutPanel2.ColumnCount = state.Data.Count;
            for (int i = -state.Data.NegativeCount; i < state.Data.PositiveCount; i++)
            {
                Label label = new Label()
                {
                    Font = new Font(this.Font.FontFamily, 18, i == state.Data.CurrentPosition || i == prevPos ? FontStyle.Bold : FontStyle.Regular),
                    ForeColor = i == prevPos ? Color.Brown : Color.Black,
                    BackColor = i == state.Data.CurrentPosition ? Color.LightGreen : Color.White,
                    AutoSize = false,
                    Width = 40,
                    Height = 40,
                    Text = (state.Data[i] == '\0' ? '_' : state.Data[i]).ToString(),
                    Margin = Padding.Empty,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                if (i == state.Data.CurrentPosition)
                    activeLabel = label;
                tableLayoutPanel2.Controls.Add(label, i + (state.Data.NegativeCount), 0);
            }
            tableLayoutPanel2.ResumeLayout();
            if (activeLabel == null)
                return;
            int a = panel2.Width / 2 - (2 * activeLabel.Location.X + activeLabel.Width) / 2;
            tableLayoutPanel2.Location = new Point(a, tableLayoutPanel2.Location.Y);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            NextStep();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (InputEditor form = new InputEditor())
            {
                DialogResult result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    state.StartData = new DataArray(form.ReturnInput);
                    Predict();
                }
            }
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Обучающий эмулятор Машины Тьюринга.\r\n\r\nГарифуллин Руслан, Программная инженерия, ФКН НИУ ВШЭ.\r\n2020 год.");
        }

        MemoryStream stateBuffer;
        BinaryFormatter format = new BinaryFormatter();
        private void Predict()
        {
            if (stateBuffer != null)
                stateBuffer.Dispose();
            stateBuffer = new MemoryStream();
            state.Data = new DataArray(state.StartData.ToString());
            state.Step = 0;
            foreach (Instruction j in state.Instructions)
                j.Active = false;
            format.Serialize(stateBuffer, state);

            bool continueExec = true;
            int i = 1;
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.SuspendLayout();
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
                Text = state.Data.ToString(),
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
            flowLayoutPanel1.Controls.Add(inputWordPanel);
            try
            {
                for (i = 1; continueExec; i++)
                {
                    if (i > MAX_STEPS)
                    {
                        MessageBox.Show($"Возможно, произошло зацикливание алгоритма (программа имеет больше чем {MAX_STEPS}).\r\nПопробуйте запустить её с другими входными данными или исправьте место зацикливания.");
                        toolStripStatusLabel1.Text = "Программа возможно зацикливается.";
                        break;
                    }
                    char displaySym = state.Data.Current;
                    string prevData = state.Data.ToString();
                    char sym = state.Data.Current == '_' ? '\0' : state.Data.Current;
                    Instruction activeInstruction = GetActiveInstruction();
                    InstructionItem activeItem = activeInstruction.Items.Single(item => item.OldChar == sym);
                    if (activeItem.IsStop)
                        continueExec = false;
                    else
                    {
                        activeInstruction.Active = false;
                        activeItem.NextInstruction.Active = true;
                        state.Data.Current = activeItem.NewChar;
                        state.Data.CurrentPosition += (int)activeItem.Direction;
                    }
                    state.Step = i;
                    format.Serialize(stateBuffer, state);
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
                    Label instructionLabel = new Label();
                    instructionLabel.Text = activeItem.ToString();
                    instructionLabel.Font = new Font(this.Font.FontFamily, 12, FontStyle.Bold);
                    instructionLabel.AutoSize = true;

                    Label previousDataLabel = new Label();
                    previousDataLabel.ForeColor = Color.DarkRed;
                    previousDataLabel.Text = prevData;
                    previousDataLabel.AutoSize = true;

                    Label nextDataLabel = new Label();
                    nextDataLabel.ForeColor = Color.DarkGreen;
                    nextDataLabel.Text = state.Data.ToString();
                    nextDataLabel.AutoSize = true;

                    infoPanel.Controls.AddRange(new[] { instructionLabel, previousDataLabel, nextDataLabel });
                    predictionTable.Controls.Add(infoPanel, 1, 0);
                    flowLayoutPanel1.Controls.Add(predictionTable);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Программа не работает правильно при данных входных данных. Расчёт шагов невозможен.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            flowLayoutPanel1.ResumeLayout();
            SetTotalSteps(i - 1);
            state = (State)format.Deserialize(stateBuffer);
            toolStripStatusLabel2.Text = $"Шаг: 0/{i - 1}";

            UpdateTable();
            InputUpdate();
            ActivatePredictItem();
        }
        private Instruction GetActiveInstruction()
        {
            Instruction start = null;
            foreach (Instruction i in state.Instructions)
            {
                if (i.Active)
                    return i;
                if (i.Start) start = i;
            }
            return start;
        }
        private void SetTotalSteps(int totalSteps)
        {
            MemoryStream newBuffer = new MemoryStream();
            stateBuffer.Seek(0, SeekOrigin.Begin);
            while (true)
            {
                try
                {
                    State s = (State)format.Deserialize(stateBuffer);
                    s.TotalSteps = totalSteps;
                    format.Serialize(newBuffer, s);
                }
                catch (Exception)
                {
                    stateBuffer.Dispose();
                    stateBuffer = newBuffer;
                    stateBuffer.Seek(0, SeekOrigin.Begin);
                    return;
                }
            }
        }

        private void Table_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridView view = sender as DataGridView;
            if (view.Rows[e.RowIndex].IsNewRow) { return; }
            if (e.ColumnIndex == 0)
                return;
            string val = e.FormattedValue.ToString();
            string[] values = val.Split(' ');
            if (val == "STOP")
                return;
            if (values.Length != 3)
            {
                MessageBox.Show($"Неверный формат команды. `{val}` `{values.Length}`");
                e.Cancel = true;
                return;
            }
            switch (values[1])
            {
                case "<":
                case ">":
                case ".":
                    break;
                default:
                    MessageBox.Show("Направление движения не было распознано.\r\nДопустимые значения:\r\n • > - движение вправо;\r\n • < - движение влево;\r\n • . - остаться на месте.", "Не удалось изменить состояние", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                    return;
            }
        }

        private void сохранитьXMLфайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            state.SaveToFile("lol.ser");
        }

        private void открытьXMLфайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            state.LoadFromFile("lol.ser");
            UpdateTable();
            InputUpdate();
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (timer1.Enabled || isBuildingTable)
                return;
            ToolStripComboBox me = (ToolStripComboBox)sender;
            foreach (Instruction instruction in state.Instructions)
                instruction.Start = me.Text == instruction.Name;
            Predict();
        }

        private void Table_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (timer1.Enabled || isBuildingTable)
                return;
            string val = Table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            string[] values = val.Split(' ');
            Instruction instruction = state.Instructions[e.RowIndex];
            if (e.ColumnIndex == 0)
                instruction.Name = val;
            else
            {
                try
                {
                    bool stop = val == "STOP";
                    InstructionItem newItem = new InstructionItem(instruction.Items[e.ColumnIndex - 1])
                    {
                        IsStop = stop,
                        NextInstruction = !stop ? state.Instructions.Single(i => i.Name == values[2]) : null,
                        NewChar = !stop ? values[0][0] : '\0',
                        Direction = !stop ? (values[1] == "<" ? Direction.LEFT : values[1] == ">" ? Direction.RIGHT : Direction.NONE) : Direction.NONE
                    };
                    instruction.Items[e.ColumnIndex - 1] = newItem;
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show($"Инструкции `{values[2]}` не существует.\r\nСоздайте эту инструкцию и попробуйте ещё раз.");
                }
            }
            Predict();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            stateBuffer.Seek(0, SeekOrigin.Begin);
            for (int i = 0; i < state.Step - 1; i++)
                format.Deserialize(stateBuffer);
            NextStep();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            stateBuffer.Seek(0, SeekOrigin.Begin);
            for (int i = 0; i < state.Step + 1; i++)
                format.Deserialize(stateBuffer);
            NextStep();
        }
        private string GiveInstructionName()
        {
            int emptyNum = 1;
            while (state.Instructions.Any(i => i.Name == $"E{emptyNum}"))
                emptyNum++;
            return $"E{emptyNum}";
        }
        private char GiveCharName()
        {
            char emptyChar = 'A';
            while (state.Instructions[0].Items.Any(i => i.OldChar == emptyChar))
                emptyChar++;
            return emptyChar;
        }
        private void добавитьИнструкциюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Instruction emptyInstruction = new Instruction();
            emptyInstruction.Name = GiveInstructionName();
            List<InstructionItem> emptyItems = new List<InstructionItem>();
            foreach (char c in state.Chars)
                emptyItems.Add(new InstructionItem() { IsStop = true, OldChar = c });
            emptyInstruction.Items = emptyItems;

            state.Instructions = state.Instructions.Append(emptyInstruction).ToArray<Instruction>();
            Predict();
        }

        private void добавитьСостояниеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            char newChar = GiveCharName();
            foreach (Instruction i in state.Instructions)
                i.Items.Add(new InstructionItem() { IsStop = true, OldChar = newChar });
            state.Chars = state.Chars.Append(newChar).ToArray<char>();
            Predict();
        }

        private void Table_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;
            DataGridView view = (sender as DataGridView);
            Point controlLoc = this.PointToScreen(Table.Location);
            Point relativeLoc = new Point(controlLoc.X - this.Location.X, controlLoc.Y - this.Location.Y);
            Rectangle r = view.GetColumnDisplayRectangle(e.ColumnIndex, false);
            r.X += controlLoc.X - this.Location.X - 8;
            r.Y += controlLoc.Y - this.Location.Y + 25;
            TextBox editPanel = new TextBox() { Location = r.Location, Size = r.Size };
            editPanel.TextAlign = HorizontalAlignment.Center;
            editPanel.Font = new Font(this.Font, FontStyle.Bold);
            editPanel.Tag = editPanel.Text = view.Columns[e.ColumnIndex].HeaderCell.Value.ToString();
            editPanel.LostFocus += EditPanel_LostFocus;
            editPanel.KeyDown += EditPanel_KeyPress;
            this.Controls.Add(editPanel);
            editPanel.Focus();
            editPanel.Show();
            editPanel.BringToFront();
        }

        private void EditPanel_KeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                (sender as TextBox).LostFocus -= EditPanel_LostFocus;
                EditPanel_LostFocus(sender, EventArgs.Empty);
            }
        }

        private void EditPanel_LostFocus(object sender, EventArgs e)
        {
            TextBox box = sender as TextBox;
            if (box.TextLength == 1)
            {
                char newChar = box.Text[0];
                char oldChar = box.Tag.ToString()[0];

                if (oldChar == '_')
                    oldChar = '\0';
                if (newChar == '_')
                    newChar = '\0';

                foreach (Instruction instruction in state.Instructions)
                    try
                    {
                        instruction.Items.Single(i => i.OldChar == oldChar).OldChar = newChar;
                    }
                    catch (Exception) { }
                for (int i = 0; i < state.Chars.Length; i++)
                    if (state.Chars[i] == oldChar)
                        state.Chars[i] = newChar;
            }
            else
            {
                toolStripStatusLabel1.Text = "Не удалось изменить символ.";
            }
            this.Controls.Remove(box);
            box = null;
            Predict();
        }

        private void удалитьИнструкциюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int instId = Table.SelectedCells[0].RowIndex;
            string instName = Table.Rows[instId].Cells[0].Value.ToString();
            Instruction dInst = state.Instructions.Single(i => i.Name == instName);
            foreach (Instruction instruction in state.Instructions)
                foreach (InstructionItem item in instruction.Items)
                    if (item.NextInstruction == dInst)
                    {
                        item.NextInstruction = null;
                        item.IsStop = true;
                    }
            state.Instructions = state.Instructions.Where(i => i.Name != instName).ToArray();
            Predict();
        }

        private void удалитьСимволToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int charId = Table.SelectedCells[0].ColumnIndex;
            if (charId == 0)
                return;
            char chr = Table.Columns[charId].HeaderCell.Value.ToString()[0];
            chr = chr == '_' ? '\0' : chr;
            state.Chars = state.Chars.Where(c => c != chr).ToArray<char>();
            foreach (Instruction instruction in state.Instructions)
                for (int i = 0; i < instruction.Items.Count; i++)
                {
                    InstructionItem item = instruction.Items[i];
                    if (item.OldChar == chr)
                        instruction.Items.RemoveAt(i);
                }
            Predict();
        }
    }
}
