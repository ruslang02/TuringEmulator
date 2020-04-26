using System;
using System.Collections.Generic;
using System.Text;

namespace TuringEmulator
{
    [Serializable]
    public enum Direction
    {
        LEFT = -1,
        NONE = 0,
        RIGHT = 1
    }

    [Serializable]
    public class Instruction
    {
        public string Name { get; set; }
        public List<InstructionItem> Items { get; set; } = new List<InstructionItem>();
        public bool Active { get; set; } = false;
        public bool Start { get; set; } = false;

        public InstructionItem this[int index]
        {
            get
            {
                return Items[index];
            }
            set
            {
                Items[index] = value;
            }
        }
        public override string ToString()
        {
            string active = Active ? " (ACTIVE)" : "";
            string start = Start ? " (START)" : "";
            StringBuilder builder = new StringBuilder($"Instruction{active}{start}: \r\n");
            foreach (InstructionItem item in Items)
                builder.AppendLine(item.ToString());
            return builder.ToString();
        }
    }

    [Serializable]
    public class InstructionItem
    {
        public char OldChar { get; set; }
        public char NewChar { get; set; }
        public Direction Direction { get; set; } = Direction.NONE;
        public Instruction NextInstruction { get; set; }
        public bool IsStop { get; set; } = false;
        public InstructionItem() { }
        public InstructionItem(InstructionItem reference)
        {
            this.OldChar = reference.OldChar;
            this.NewChar = reference.NewChar;
            this.Direction = reference.Direction;
            this.NextInstruction = reference.NextInstruction;
            this.IsStop = reference.IsStop;
        }
        public override string ToString()
        {
            if (NextInstruction == null)
                return "STOP";
            char dir = '.';
            if (this.Direction == Direction.LEFT)
                dir = '<';
            if (this.Direction == Direction.RIGHT)
                dir = '>';

            char newChar = NewChar;
            if (newChar == '\0')
                newChar = '_';
            return $"{newChar} {dir} {NextInstruction.Name}";
        }
    }
}
