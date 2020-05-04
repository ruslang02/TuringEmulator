using System;
using System.Runtime.Serialization;

namespace TuringEmulator
{
    [Serializable]
    [DataContract]
    public class Operation
    {
        [DataMember(Name = "OldChar")]
        public char OldChar { get; set; }
        [DataMember(Name = "NewChar")]
        public char NewChar { get; set; }
        [DataMember(Name = "Direction")]
        public Direction Direction { get; set; } = Direction.NONE;
        [DataMember(Name = "NextInstruction")]
        public string NextInstruction { get; set; }
        [DataMember(Name = "Stop")]
        public bool IsStop { get; set; } = false;
        public Operation() { }
        public Operation(Operation reference)
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
            return $"{newChar} {dir} {NextInstruction}";
        }
    }
}
