using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    class NonLetterException : Exception
    {
        public NonLetterException(string entry) : base(Msg(entry))
        {
        }

        private static string Msg(string entry)
        {
            return " :" + entry + " is not an alphabet.";
        }
    }
}
