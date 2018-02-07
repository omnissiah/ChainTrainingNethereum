using Nethereum.ABI.FunctionEncoding.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainTrainingNethereum
{
    [FunctionOutput]
    public class Proposal
    {
        public long Index { get; set; }

        [Parameter("address", 1)]
        public string Recipient { get; set; }

        [Parameter("uint256", 2)]
        public UInt32 Amount { get; set; }

        [Parameter("string", 3)]
        public string Description { get; set; }

        [Parameter("uint256", 4)]
        public long VotingDeadline { get; set; }

        [Parameter("bool", 5)]
        public bool Executed { get; set; }

        [Parameter("bool", 6)]
        public bool ProposalPassed { get; set; }

        [Parameter("bool", 7)]
        public bool ProposalCanRun { get; set; }

        [Parameter("uint256", 8)]
        public UInt32 NumberOfVotes { get; set; }

        [Parameter("int", 9)]
        public int RemainingVotesToPass { get; set; }

        [Parameter("int", 10)]
        public int CurrentResult { get; set; }

        [Parameter("bytes32", 11)]
        public byte[] ProposalHash { get; set; }


        //[Parameter("Vote[]", 12)]
        //public Vote[] Votes { get; set; } 

        [Parameter("bool", 12)]
        public bool voted { get; set; }
    }
}
