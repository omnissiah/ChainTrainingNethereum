using Nethereum.ABI.FunctionEncoding.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainTrainingNethereum
{
    public class DepositEvent
    { 
        [Parameter("address", "_from", 1, false)]
        public string From { get; set; }

        [Parameter("uint256", "_amount", 2, false)]
        public long Amount { get; set; }

    }
}
