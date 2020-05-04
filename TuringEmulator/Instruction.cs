using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
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
    [DataContract]
    public class Instruction
    {
        [DataMember(Name = "Name")]
        public string Name { get; set; }
        [DataMember(Name = "Items")]
        public List<Operation> Operations { get; set; } = new List<Operation>();
        [DataMember(Name = "IsActive")]
        public bool Active { get; set; } = false;
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
