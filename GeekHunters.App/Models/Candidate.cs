using System;
using System.ComponentModel.DataAnnotations;

namespace GeekHunters.App.Models
{
    public partial class Candidate
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }

        [Required]
        public int? SkillId { get; set; }

        [Display(Name = "Created Date")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Last Modified Date")]
        public DateTime? LastModifiedDate { get; set; }

        [Display(Name = "Skill")]
        public Skill Skill { get; set; }
    }
}
