using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VoteRonaldoVsMessi.WebApp.ViewModel
{
    public class VotingResults
    {
        public CandidateResult Ronaldo { get; set; }
        public CandidateResult Messi { get; set; }
    }

    public class CandidateResult
    {
        public string Name { get; set; }
        public int Count { get; set; }
    }
}
