using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegExample.Contracts
{
    public abstract class CommandContractBase
    {
        public abstract void Validate();
    }
}
