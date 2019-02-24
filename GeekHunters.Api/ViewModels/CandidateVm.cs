using System;

namespace GeekHunters.Api.ViewModels
{
    public class CandidateVm
    {
        public int Id;

        public string FirstName;

        public string LastName;

        public int? SkillId;

        public SkillVm Skill;

        public DateTime? CreatedDate;

        public DateTime? LastModifiedDate;
    }
}
