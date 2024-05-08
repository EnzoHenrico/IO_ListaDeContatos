using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquivoDeContatos
{
    internal class PhoneNumber
    {
        string number;

        public PhoneNumber(string number)
        {
            this.number = number;
        }

        public override string ToString()
        {
            return number;
        }
    }
}
