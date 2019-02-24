using System;

namespace GeekHunters.Entities
{
    public partial class Candidate
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? SkillId { get; set; }

        public virtual Skill Skill { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? LastModifiedDate { get; set; }
    }
}
