using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TuringEmulator
{
    /// <summary>
    /// Direction where the cursor should go after changing tape data.
    /// </summary>
    [Serializable]
    public enum Direction
    {
        LEFT = -1,
        NONE = 0,
        RIGHT = 1
    }
    /// <summary>
    /// Instruction of the algorithm, in other words, algorithm's state.
    /// </summary>
    [Serializable]
    [DataContract]
    public class Instruction
    {
        /// <summary>
        /// Name (ID) of the instruction.
        /// </summary>
        [DataMember(Name = "Name")]
        public string Name { get; set; }
        /// <summary>
        /// Operations in the state.
        /// </summary>
        [DataMember(Name = "Items")]
        public List<Operation> Operations { get; set; } = new List<Operation>();
        /// <summary>
        /// Whether this instruction is currently executing.
        /// </summary>
        [DataMember(Name = "IsActive")]
        public bool Active { get; set; } = false;
        /// <summary>
        /// Whether this is the starting instruction.
        /// </summary>
        [DataMember(Name = "IsStart")]
        public bool Start { get; set; } = false;
        public override string ToString()
        {
            string active = Active ? " (ACTIVE)" : "";
            string start = Start ? " (START)" : "";
            StringBuilder builder = new StringBuilder($"Instruction{active}{start}: \r\n");
            foreach (Operation item in Operations)
                builder.AppendLine(item.ToString());
            return builder.ToString();
        }
    }
}
