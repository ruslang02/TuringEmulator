using System;
using System.Runtime.Serialization;

namespace TuringEmulator
{
    /// <summary>
    /// Operation, a part of Instruction, a certain action that has to be done when current symbol becomes equal OldChar.
    /// </summary>
    [Serializable]
    [DataContract]
    public class Operation
    {
        /// <summary>
        /// The character that should be replaced.
        /// </summary>
        [DataMember(Name = "OldChar")]
        public char OldChar { get; set; }
        /// <summary>
        /// The character that will replace the OldChar.
        /// </summary>
        [DataMember(Name = "NewChar")]
        public char NewChar { get; set; }
        /// <summary>
        /// Direction to move cursor to after symbol change.
        /// </summary>
        [DataMember(Name = "Direction")]
        public Direction Direction { get; set; } = Direction.NONE;
        /// <summary>
        /// Instruction to execute after the cursor moves.
        /// </summary>
        [DataMember(Name = "NextInstruction")]
        public string NextInstruction { get; set; }
        /// <summary>
        /// Whether this operation should terminate the program.
        /// </summary>
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
