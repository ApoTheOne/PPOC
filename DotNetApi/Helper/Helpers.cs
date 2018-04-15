using System.Text;
namespace CorePOC.Helper
{
    public static class Helpers
    {
        public static string encodeString(string toEncodeString,int lengthToEncode)
        {
            if(!string.IsNullOrEmpty(toEncodeString))
            {
                StringBuilder sb = new StringBuilder();
                for(int counter =0;counter<toEncodeString.Length;counter++)
                {
                    char c =toEncodeString[counter];// .Chars(counter);
                    if(counter<lengthToEncode)
                    {
                        c = (char) (c - (char)toEncodeString.Length);	
                    }
                    sb.Append(c);
                }
                return sb.ToString() ;
            }
            else
            {
                return toEncodeString;
            }

        }
        public static string decodeString(string toEncodeString,  int lengthToEncode)
	    {
            if(!string.IsNullOrEmpty(toEncodeString))
            {
                StringBuilder sb = new StringBuilder();
                for(int counter =0;counter<toEncodeString.Length;counter++)
                {
                    char c =toEncodeString[counter];
                    if(counter<lengthToEncode)
                    {
                        c = (char) (c + (char)toEncodeString.Length);	
                    }
                    sb.Append(c);
                }
                return sb.ToString();
            }
            else
            {
                return toEncodeString;
            }            
	    }
    }
}