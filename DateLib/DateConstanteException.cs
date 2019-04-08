/* Exception pour les dates non-modifiables. */
using System;

namespace Prog2
{
    public class DateConstanteException : ApplicationException
    {
        public DateConstanteException() : base("## Date constante non modifiable")
        {
        }
    }
}
