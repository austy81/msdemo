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
            return Shift(input.ToString(),shift);
        } 

        public static string operator << (StringManipulation input, int shift)
        {
            return Shift(input.ToString(),-shift);
        }
        
        public static bool operator == (StringManipulation s, int j)
        {
            return true;
        }

        public static bool operator != (StringManipulation s, int j)
        {
            return false;
        }

        public override string ToString()
        {
            return _inputString;
        }

        public override bool Equals (object obj)
        {
            //
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //
            
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            
            // TODO: write your implementation of Equals() here
            throw new System.NotImplementedException();
            return base.Equals (obj);
        }
        
        // override object.GetHashCode
        public override int GetHashCode()
        {
            // TODO: write your implementation of GetHashCode() here
            throw new System.NotImplementedException();
            return base.GetHashCode();
        }

        private static string Shift(string inputString, int shift)
        {
            var output = new StringBuilder();
            for(int inputPosition = 0; inputPosition<inputString.Length; inputPosition++)
            {
                int targetPosition = inputPosition + shift;
                while(targetPosition > inputString.Length-1) targetPosition -= inputString.Length; //overfloated on the right should be moved to the left
                while(targetPosition < 0) targetPosition += inputString.Length; //overfloated on the left should be moved to the right
                output[targetPosition] = inputString[inputPosition];
            }
            return output.ToString();
        }
    }
}