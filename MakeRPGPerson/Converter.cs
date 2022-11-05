using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeRPGPerson
{
    public class Converter
    {
        public static PersonClass? StringToPersonClassConverter(string value)
        {
            foreach (PersonClass c in (PersonClass[])Enum.GetValues(typeof(PersonClass)))
            {
                if (c.ToString() == value)
                {
                    return c;
                }
            }

            return null;
        }
    }
}
