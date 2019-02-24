using System.Collections.Generic;
using GeekHunters.Entities;
using System.Threading.Tasks;

namespace GeekHunters.Services.Interfaces
{
    public interface ICandidateService
    {
        Task<IEnumerable<Candidate>> GetCandidates();

        Task<Candidate> GetCandidate(int Id);

        Task<IEnumerable<Candidate>> GetCandidatesBySkillId(int Id);

        Task<bool> UpdateCandidate(Candidate candidate);

        Task<IEnumerable<Skill>> GetSkills();

        Task<int> AddCandidate(Candidate candidate);

        Task<bool> DeleteCandidate(int id);
    }
}
