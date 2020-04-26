using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace TuringEmulator
{
    [Serializable]
    public class State
    {
        public char[] Chars;
        public Instruction[] Instructions;
        //public Instruction CurrentInstruction => Instructions.Single(i => i.Active);
        public DataArray Data;
        public DataArray StartData;
        public int Step { get; set; } = 0;
        public int TotalSteps { get; set; } = 0;

        public void SaveToFile(string file)
        {
            using (FileStream fs = new FileStream(file, FileMode.Create))
            {
                BinaryFormatter format = new BinaryFormatter();
                format.Serialize(fs, this);
            }
        }
        public State ShallowCopy()
        {
            State newState = new State();
            newState.Chars = Chars;
            newState.Instructions = new Instruction[Instructions.Length];
            Array.Copy(Instructions, 0, newState.Instructions, 0, Instructions.Length);
            newState.Data = new DataArray(Data.ToString());
            return newState;
        }
        public void LoadFromFile(string file)
        {
            using (FileStream fs = new FileStream(file, FileMode.Open))
            {
                BinaryFormatter format = new BinaryFormatter();
                State dreamstate = (State)format.Deserialize(fs);
                this.Data = dreamstate.Data;
                this.Chars = dreamstate.Chars;
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
