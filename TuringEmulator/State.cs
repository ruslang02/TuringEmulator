using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace TuringEmulator
{
    [Serializable]
    [DataContract]
    public class State
    {
        [DataMember(Name = "Alphabet")]
        public char[] Alphabet;
        [DataMember(Name = "Instructions")]
        public Instruction[] Instructions;
        [DataMember(Name = "CurrentTape")]
        public DataArray Data;
        [DataMember(Name = "StartTape")]
        public DataArray StartData;
        [DataMember]
        public int Step { get; set; } = 0;
        [DataMember]
        public int TotalSteps { get; set; } = 0;

        public void SaveToFile(string file)
        {
            using (FileStream fs = new FileStream(file, FileMode.Create))
            {
                BinaryFormatter format = new BinaryFormatter();
                format.Serialize(fs, this);
            }
        }
        public void LoadFromFile(string file)
        {
            using (FileStream fs = new FileStream(file, FileMode.Open))
            {
                BinaryFormatter format = new BinaryFormatter();
                State dreamstate = (State)format.Deserialize(fs);
                this.Data = dreamstate.Data;
                this.StartData = dreamstate.StartData;
                this.Step = dreamstate.Step;
                this.TotalSteps = dreamstate.TotalSteps;
                this.Alphabet = dreamstate.Alphabet;
                this.Instructions = dreamstate.Instructions;
            }
        }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"State. Data = {Data}, StartData = {StartData}, Steps = {Step}/{TotalSteps}, Instructions =");
            foreach (Instruction i in Instructions)
                builder.AppendLine(i.ToString());
            return builder.ToString();
        }
    }
}
