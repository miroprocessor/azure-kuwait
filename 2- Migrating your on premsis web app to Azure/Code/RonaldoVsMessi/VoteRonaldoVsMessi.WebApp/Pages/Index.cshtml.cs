using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VoteRonaldoVsMessi.Infrastructure.Models;
using VoteRonaldoVsMessi.Services;

namespace VoteRonaldoVsMessi.WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IVotingServices votingServices;

        public IndexModel(IVotingServices votingServices)
        {
            this.votingServices = votingServices;
        }

        [BindProperty]
        public string SelectedCandidate { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var voterId = Request.Cookies["VoterId"];

            if (string.IsNullOrEmpty(voterId))
            {
                var option = new CookieOptions();
                option.Expires = DateTime.Now.AddDays(10);
                Response.Cookies.Append("VoterId", Guid.NewGuid().ToString(), option);
            }
            else
            {
                var vote = await votingServices.GetVoteAsync(voterId);
                if (vote !=null)
                {
                    SelectedCandidate = vote.VotedFor;
                }                
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var voterId = Request.Cookies["VoterId"];
                var vote = new Vote()
                {
                    VoterId = Guid.Parse(voterId),
                    VotedFor = SelectedCandidate
                };

                await votingServices.VoteAsync(vote);
                return RedirectToPage();
            }
            catch (Exception)
            {

                return Page();
            }
        }
    }
}
