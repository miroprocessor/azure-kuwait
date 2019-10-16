using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VoteRonaldoVsMessi.Infrastructure.Models
{
    public class Vote
    {
        [Key]
        public Guid VoterId { get; set; }

        [Column("Vote")]
        public string VotedFor { get; set; }
    }
}
