using System.Text;

namespace msdemo
{
    public class StringManipulation
    {
        private readonly string _inputString;
        private int _offset;
        public StringManipulation(string inputString)
        {
            _inputString = inputString;
            _offset = 0;
        }

        public static StringManipulation operator << (StringManipulation input, int shift)
        {
            if(input == null) return input;
            if(input.StringValue == null) return input;
            input.AddOffset(shift); 
            return input;
        } 

        public static StringManipulation operator >> (StringManipulation input, int shift)
        {
            if(input == null) return input;
            if(input.StringValue == null) return input;
            input.AddOffset(-shift); 
            return input;
        }
        
        public static bool operator == (StringManipulation s, StringManipulation s2)
        {
            if (System.Object.ReferenceEquals(s, s2))
            {
                return true;
            }

            if (((object)s == null) || ((object)s2 == null))
            {
                return false;
            }

            return s.StringValue == s2.StringValue;
        }

        // operator != has to be overloaded in pair with == operator
        // https://msdn.microsoft.com/en-us/library/8edha89s(v=vs.140).aspx
        public static bool operator != (StringManipulation s, StringManipulation s2) 
        {
            return !(s == s2);
        }

        // public static string operator = (StringManipulation s) // this operator can not be overloaded
        // https://msdn.microsoft.com/en-us/library/8edha89s(v=vs.140).aspx

        public override string ToString()
        {
            return StringValue;
        }

        public override bool Equals (object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            
            StringManipulation sm = (StringManipulation)obj;
            if(sm == null) return false;

            return this.StringValue == sm.StringValue;
        }
        
        public override int GetHashCode()
        {
            if(this == null) return 0;
            if(this.StringValue == null) return 0;
            return this.StringValue.GetHashCode();
        }
        private string StringValue
        {
            get { 
                return Shift(_inputString,_offset);
            }
        }
        private static string Shift(string inputString, int shift)
        {
            if(inputString == null) return null;
            var output = new StringBuilder();
            output.Append(inputString);
            for(int inputPosition = 0; inputPosition < inputString.Length; inputPosition++)
            {
                int targetPosition = inputPosition + shift;
                while(targetPosition > inputString.Length-1) targetPosition -= inputString.Length; //overfloated to the right should be moved to the left
                while(targetPosition < 0) targetPosition += inputString.Length; //overfloated to the left should be moved to the right
                output[targetPosition] = inputString[inputPosition];
            }
            return output.ToString();
        }
        private void AddOffset(int shift)
        {
            _offset += shift;
        }
    }
}