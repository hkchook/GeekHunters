using System.Collections.Generic;

namespace GeekHunters.App.Models
{
    public partial class Skill
    {
        public Skill()
        {
            Candidate = new HashSet<Candidate>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Candidate> Candidate { get; set; }
    }
}
