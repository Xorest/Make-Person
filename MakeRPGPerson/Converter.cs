using System;
using MakeRPGPerson.Models;

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
