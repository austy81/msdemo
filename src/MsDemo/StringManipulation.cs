using System.Text;

namespace msdemo
{
    public class StringManipulation
    {
        string _inputString;
        public StringManipulation(string inputString)
        {
            _inputString = inputString;
        }

        public static string operator >> (StringManipulation input, int shift)
        {
            if(input.ToString() == null) return null;
            return Shift(input.ToString(),shift);
        } 

        public static string operator << (StringManipulation input, int shift)
        {
            if(input.ToString() == null) return null;
            return Shift(input.ToString(),-shift);
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

            return s.ToString() == s2.ToString();
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
            return _inputString;
        }

        public override bool Equals (object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            
            StringManipulation sm = (StringManipulation)obj;
            if(sm == null) return false;

            return this.ToString().Equals(sm.ToString());
        }
        
        public override int GetHashCode()
        {
            if(this == null) return 0;
            return this.ToString().GetHashCode();
        }

        private static string Shift(string inputString, int shift)
        {
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
    }
}