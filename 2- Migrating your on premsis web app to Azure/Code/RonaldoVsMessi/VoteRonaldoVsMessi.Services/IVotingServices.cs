using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoteRonaldoVsMessi.Infrastructure.Models;

namespace VoteRonaldoVsMessi.Services
{
    public interface IVotingServices
    {
        Task<Vote> GetVoteAsync(Guid id);
        Task<Vote> GetVoteAsync(string id);
        Task<IList<Vote>> GetVotesAsync();
        Task<bool> IsVoteExistsAsync(Guid id);
        Task<bool> IsVoteExistsAsync(string id);
        Task VoteAsync(Vote vote);
    }
}
