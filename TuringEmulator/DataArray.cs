using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TuringEmulator
{
    [Serializable]
    [DataContract]
    public class DataArray
    {
        public DataArray(string s)
        {
            Symbols = s;
        }
        public DataArray() { }
        private int currentPos = 0;
        [DataMember(Name = "CurrentPosition")]
        public int CurrentPosition
        {
            get => currentPos;
            set
            {
                PreviousPosition = currentPos;
                currentPos = value;
            }
        }
        [DataMember(Name = "PreviousPosition")]
        public int PreviousPosition { get; set; }
        [DataMember(Name = "Alphabet")]
        public string Symbols
        {
            get
            {
                string result = "";
                foreach (char chr in Elements)
                    result += chr == '\0' ? '_' : chr;
                return result;
            }
            set
            {
                if (value.Contains("&"))
                {
                    CurrentPosition = value.IndexOf("&");
                    value = value.Replace("&", "");
                }
                else CurrentPosition = 0;
                positives = value.ToCharArray();
                if (positives.Length < 10)
                    Array.Resize(ref positives, 10);
            }
        }
        private char[] positives = new char[10];
        private char[] negatives = new char[10];
        public int Count
        {
            get => positives.Length + negatives.Length;
        }
        public int NegativeCount => negatives.Length;
        public int PositiveCount => positives.Length;
        public char[] Elements
        {
            get
            {
                char[] elements = (char[])negatives.Clone();
                Array.Reverse(elements);
                Array.Resize(ref elements, Count);
                Array.Copy(positives, 0, elements, NegativeCount - 1, positives.Length);
                return elements;
            }
        }

        public char Current
        {
            get
            {
                char res = this[currentPos];
                return res == '\0' ? '_' : res;
            }
            set
            {
                this[currentPos] = value == '_' ? '\0' : value;
            }
        }

        public override string ToString()
        {
            List<char> converted = new List<char>();
            for (int i = 0; i < Elements.Length; i++)
            {
                char chr = Elements[i];
                if (i == NegativeCount + CurrentPosition - 1)
                    converted.Add('&');
                if (chr != '\0')
                    converted.Add(chr);

            }
            return new string(converted.ToArray());
        }
        public char this[int index]
        {
            get
            {
                if (index < 0)
                {
                    if (-index > NegativeCount)
                        return '\0';
                    return negatives[-(index + 1)];
                }
                else
                {
                    if (index >= PositiveCount)
                        return '\0';
                    return positives[index];
                }
            }
            set
            {
                if (Math.Abs(index) >= PositiveCount)
                    Array.Resize(ref positives, Math.Abs(index) * 2);
                if (Math.Abs(index) >= NegativeCount)
                    Array.Resize(ref negatives, Math.Abs(index) * 2);

                if (index < 0)
                {
                    negatives[-(index + 1)] = value;
                }
                else
                {
                    positives[index] = value;
                }
            }
        }
    }
}
