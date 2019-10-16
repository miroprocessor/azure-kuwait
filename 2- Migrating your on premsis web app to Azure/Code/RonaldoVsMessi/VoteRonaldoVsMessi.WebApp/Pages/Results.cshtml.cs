using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VoteRonaldoVsMessi.Services;
using VoteRonaldoVsMessi.WebApp.ViewModel;

namespace VoteRonaldoVsMessi.WebApp.Pages
{
    public class ResultsModel : PageModel
    {
        private readonly IVotingServices votingServices;

        public ResultsModel(IVotingServices votingServices)
        {
            this.votingServices = votingServices;
        }

        public VotingResults VotingResults { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var votes = await votingServices
                .GetVotesAsync();

            var totalCount = votes.Count;

            var results = votes.GroupBy(v => v.VotedFor)
                               .Select(g => new CandidateResult { Name = g.Key, Count = g.Count() });

            VotingResults = new VotingResults();
            VotingResults.Ronaldo = results.FirstOrDefault(c => c.Name == "Ronaldo") ?? new CandidateResult();
            VotingResults.Messi = results.FirstOrDefault(c => c.Name == "Messi") ?? new CandidateResult();

            return Page();
        }
    }
}