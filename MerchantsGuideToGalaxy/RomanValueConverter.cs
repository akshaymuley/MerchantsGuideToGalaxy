using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantsGuideToGalaxy
{
    public class RomanValueConverter
    {
        private static Dictionary<char, long> romanNumberMapper = new Dictionary<char, long>()
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };


        public static long GetValue(string romanValue)
        {
            try
            {
                long value = 0;
                
                for (int i = 0; i < romanValue.Length; i++ )
                {
                    long number = romanNumberMapper[romanValue[i]];
                    if((i+1) < romanValue.Length && number < romanNumberMapper[romanValue[i+1]])
                    {
                        value += (romanNumberMapper[romanValue[i+1]] - number);
                        i++;
                    }
                    else
                    {
                        value += romanNumberMapper[romanValue[i]];
                    }
                }
                    return value;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static string GetRomanString(long number)
        {
            throw new NotImplementedException();
        }

    }
}
