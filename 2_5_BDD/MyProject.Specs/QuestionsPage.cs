using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using NUnit.Framework;

namespace MyProject.Specs
{
    public class QuestionsPage
    {
        public string Question { get; set; }
        private Dictionary<string, int> votes;

        public QuestionsPage()
        {
            votes = new Dictionary<string, int>();
        }

        public string TopAnswer
        {
            get
            {
                if (this.Question == null)
                    return string.Empty;
                
                return votes.OrderByDescending(p => p.Value).First().Key;
            }
        }

        public void AddVote(string answer, int votes)
        {
            this.votes.Add(answer, votes);
        }

        public void VoteUpAnswer(string answer)
        {
            if (Question == null)
                return;
            var vote = this.votes.First(p => p.Key == answer);
            this.votes.Remove(vote.Key);
            this.votes.Add(vote.Key, vote.Value + 1);
        }
    }
}