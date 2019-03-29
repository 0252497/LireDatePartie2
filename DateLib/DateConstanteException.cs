using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog2
{
    public class DateConstanteException : ApplicationException
    {
        public DateConstanteException() : base("## Date constante nom modifiable")
        {
        }
    }
}
