using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaveVinsMrTerence.Exceptions
{
    public class UniqueEmailException : Exception
    {
        public UniqueEmailException() : base("L'email doit être unique")
        {

        }
    }
}
