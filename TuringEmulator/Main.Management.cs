using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TuringEmulator
{
    public partial class MainForm : Form
    {
        private string GenerateInstructionName()
        {
            int emptyNum = 1;
            while (currentState.Instructions.Any(i => i.Name == $"E{emptyNum}"))
                emptyNum++;
            return $"E{emptyNum}";
        }
        private char GenerateSymbolName()
        {
            char emptyChar = 'A';
            while (currentState.Instructions[0].Operations.Any(i => i.OldChar == emptyChar))
                emptyChar++;
            return emptyChar;
        }
        private void NewInstructionButton_Click(object sender, EventArgs e)
        {
            Instruction emptyInstruction = new Instruction() { Name = GenerateInstructionName() };
            List<Operation> emptyItems = new List<Operation>();
            foreach (char c in currentState.Alphabet)
                emptyItems.Add(new Operation() { IsStop = true, OldChar = c });
            emptyInstruction.Operations = emptyItems;

            currentState.Instructions = currentState.Instructions.Append(emptyInstruction).ToArray<Instruction>();
            Predict();
        }

        private void NewSymbolButton_Click(object sender, EventArgs e)
        {
            char newChar = GenerateSymbolName();
            foreach (Instruction i in currentState.Instructions)
                i.Operations.Add(new Operation() { IsStop = true, OldChar = newChar });
            currentState.Alphabet = currentState.Alphabet.Append(newChar).ToArray<char>();
            Predict();
        }
        private void DeleteInstructionButton_Click(object sender, EventArgs e)
        {
            int instId = Table.SelectedCells[0].RowIndex;
            string instName = Table.Rows[instId].Cells[0].Value.ToString();
            Instruction dInst = currentState.Instructions.Single(i => i.Name == instName);
            foreach (Instruction instruction in currentState.Instructions)
                foreach (Operation item in instruction.Operations)
                    if (item.NextInstruction == dInst.Name)
                    {
                        item.NextInstruction = null;
                        item.IsStop = true;
                    }
            currentState.Instructions = currentState.Instructions.Where(i => i.Name != instName).ToArray();
            Predict();
        }

        private void DeleteSymbolButton_Click(object sender, EventArgs e)
        {
            if (Table.SelectedCells.Count == 0)
                return;
            int charId = Table.SelectedCells[0].ColumnIndex;
            if (charId == 0)
                return;
            char chr = Table.Columns[charId].HeaderCell.Value.ToString()[0];
            chr = chr == '_' ? '\0' : chr;
            currentState.Alphabet = currentState.Alphabet.Where(c => c != chr).ToArray<char>();
            foreach (Instruction instruction in currentState.Instructions)
                for (int i = 0; i < instruction.Operations.Count; i++)
                {
                    Operation item = instruction.Operations[i];
                    if (item.OldChar == chr)
                        instruction.Operations.RemoveAt(i);
                }
            Predict();
        }
    }
}
