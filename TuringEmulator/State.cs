using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace TuringEmulator
{
    /// <summary>
    /// Represents app's current state.
    /// </summary>
    [Serializable]
    [DataContract]
    public class State
    {
        /// <summary>
        /// Alphabet a.k.a. symbols that the algorithm can handle.
        /// </summary>
        [DataMember(Name = "Alphabet")]
        public char[] Alphabet;
        /// <summary>
        /// Instructions (algorithm states) that are present.
        /// </summary>
        [DataMember(Name = "Instructions")]
        public Instruction[] Instructions;
        /// <summary>
        /// Symbols in the tape at the given moment.
        /// </summary>
        [DataMember(Name = "CurrentTape")]
        public DataArray Data;
        /// <summary>
        /// Symbols in the tape in the beginning.
        /// </summary>
        [DataMember(Name = "StartTape")]
        public DataArray StartData;
        /// <summary>
        /// Current step in algorithm execution.
        /// </summary>
        [DataMember]
        public int Step { get; set; } = 0;
        /// <summary>
        /// Total number of steps calculated.
        /// </summary>
        [DataMember]
        public int TotalSteps { get; set; } = 0;
        /// <summary>
        /// Saves the app's state into a binary file.
        /// </summary>
        /// <param name="file">File name</param>
        public void SaveToFile(string file)
        {
            using (FileStream fs = new FileStream(file, FileMode.Create))
            {
                BinaryFormatter format = new BinaryFormatter();
                format.Serialize(fs, this);
            }
        }
        /// <summary>
        /// Loads the app's state from a binary file.
        /// </summary>
        /// <param name="file">File name</param>
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
