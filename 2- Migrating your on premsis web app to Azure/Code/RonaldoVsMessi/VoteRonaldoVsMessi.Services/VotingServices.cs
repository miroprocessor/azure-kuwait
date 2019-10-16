using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VoteRonaldoVsMessi.Infrastructure;
using VoteRonaldoVsMessi.Infrastructure.Models;

namespace VoteRonaldoVsMessi.Services
{
    public class VotingServices : IVotingServices
    {
        private readonly VoteContextDbApp voteContext;

        public VotingServices(VoteContextDbApp voteContext)
        {
            this.voteContext = voteContext;
        }

        public async Task<Vote> GetVoteAsync(Guid id)
        {
            var vote = await voteContext.Votes
                .FindAsync(id);
            return vote;
        }

        public async Task<Vote> GetVoteAsync(string id)
        {
            var voterId = Guid.Parse(id);
            var vote = await GetVoteAsync(voterId);
            return vote;
        }

        public async Task<IList<Vote>> GetVotesAsync()
        {
            var votes = await voteContext.Votes
                .AsNoTracking()
                .ToListAsync();
            return votes;
        }

        public async Task<bool> IsVoteExistsAsync(Guid id)
        {
            var isVoteFound = await voteContext.Votes
                .AnyAsync(v => v.VoterId == id);
            return isVoteFound;
        }

        public async Task<bool> IsVoteExistsAsync(string id)
        {
            var voterId = Guid.Parse(id);
            var isVoteFound = await IsVoteExistsAsync(voterId);
            return isVoteFound;
        }

        public async Task VoteAsync(Vote vote)
        {
            var isVoteExists = await IsVoteExistsAsync(vote.VoterId);

            if (isVoteExists)
            {
                voteContext.Entry(vote).State = EntityState.Modified;
            }
            else
            {
                await voteContext.Votes.AddAsync(vote);
            }
            
            await voteContext.SaveChangesAsync();
        }
    }
}
