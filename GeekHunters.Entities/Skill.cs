using System.Collections.Generic;

namespace GeekHunters.Entities
{
    public partial class Skill
    {
        public Skill()
        {
            Candidate = new HashSet<Candidate>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Candidate> Candidate { get; set; }
    }
}
