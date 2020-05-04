using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TuringEmulator
{
    public partial class MainForm : Form
    {
        private void LoadTable(char[] chars, Instruction[] instructions, DataArray data)
        {
            currentState = new State() { Alphabet = chars, Instructions = instructions, Data = data, StartData = data };
            Predict();
        }
        private bool isBuildingTable = false;
        private void UpdateTable(int prevRow = -1, int prevColumn = -1)
        {
            isBuildingTable = true;
            InstructionsTable.Columns.Clear();
            LaunchStateSelector.Items.Clear();
            InstructionsTable.Rows.Clear();
            InstructionsTable.Columns.Add("Имя", typeof(string));
            for (int i = 0; i < currentState.Alphabet.Length; i++)
            {
                char displayChr = currentState.Alphabet[i] == '\0' ? '_' : currentState.Alphabet[i];
                InstructionsTable.Columns.Add(displayChr.ToString(), typeof(string));
            }

            Table.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            try
            {
                for (int i = 0; i < currentState.Instructions.Length; i++)
                {
                    Instruction instruction = currentState.Instructions[i];
                    LaunchStateSelector.Items.Add(instruction.Name);
                    string[] row = new string[] { instruction.Name };
                    Array.Resize(ref row, instruction.Operations.Count + 1);
                    Array.Copy(instruction.Operations.ConvertAll(item => item.ToString()).ToArray(), 0, row, 1, instruction.Operations.Count);
                    InstructionsTable.Rows.Add(row);
                    if (instruction.Start)
                        LaunchStateSelector.SelectedIndex = i;
                    if (instruction.Active)
                    {
                        char sym = currentState.Data.Current == '_' ? '\0' : currentState.Data.Current;
                        Operation activeItem = instruction.Operations.Single(item => item.OldChar == sym);
                        int j = instruction.Operations.IndexOf(activeItem);
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
                RunAlgorithmButton.Tag = "restart";
                RunAlgorithmButton_Click(RunAlgorithmButton, EventArgs.Empty);
            }
            isBuildingTable = false;
        }
        private void Table_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string val = e.FormattedValue.ToString().Trim();
            if (e.ColumnIndex == 0)
            {
                if (val.Contains(' '))
                {
                    MessageBox.Show($"Идентификатор состояния не должен содержать пробелов.", "Входные данные неверны", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
                if(currentState.Instructions.Count(i => i.Name == val) != 0 && val != Table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString())
                {
                    MessageBox.Show($"Идентификатор состояния должен быть уникален.", "Входные данные неверны", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
                return;
            }
            string[] values = val.Split(' ');
            if (val == "STOP")
                return;
            if (values.Length != 3)
            {
                MessageBox.Show($"Неверный формат команды.", "Входные данные неверны", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void Table_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (ExecTimer.Enabled || isBuildingTable)
                return;
            string val = Table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            string[] values = val.Split(' ');
            Instruction instruction = currentState.Instructions[e.RowIndex];
            if (e.ColumnIndex == 0)
                instruction.Name = val;
            else
            {
                try
                {
                    bool stop = val == "STOP";
                    Operation newItem = new Operation(instruction.Operations[e.ColumnIndex - 1])
                    {
                        IsStop = stop,
                        NextInstruction = !stop ? currentState.Instructions.Single(i => i.Name == values[2]).Name : null,
                        NewChar = !stop ? values[0][0] : '\0',
                        Direction = !stop ? (values[1] == "<" ? Direction.LEFT : values[1] == ">" ? Direction.RIGHT : Direction.NONE) : Direction.NONE
                    };
                    instruction.Operations[e.ColumnIndex - 1] = newItem;
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show($"Инструкции `{values[2]}` не существует.\r\nСоздайте эту инструкцию и попробуйте ещё раз.");
                }
            }
            Predict();
        }
        private void InputDataTable_SizeChanged(object sender, EventArgs e)
        {
            InputUpdate(currentState.Data.CurrentPosition);
        }
        private void Table_ColumnHeaderClick(object sender, DataGridViewCellMouseEventArgs e)
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

                foreach (Instruction instruction in currentState.Instructions)
                    try
                    {
                        instruction.Operations.Single(i => i.OldChar == oldChar).OldChar = newChar;
                    }
                    catch (Exception) { }
                for (int i = 0; i < currentState.Alphabet.Length; i++)
                    if (currentState.Alphabet[i] == oldChar)
                        currentState.Alphabet[i] = newChar;
            }
            else
            {
                CurrentStateLabel.Text = "Не удалось изменить символ.";
            }
            this.Controls.Remove(box);
            box = null;
            Predict();
        }
        private void EditPanel_KeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                (sender as TextBox).LostFocus -= EditPanel_LostFocus;
                EditPanel_LostFocus(sender, EventArgs.Empty);
            }
        }

    }
}
