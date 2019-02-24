using System.Collections.Generic;
using System.Threading.Tasks;
using GeekHunters.Entities;

namespace GeekHunters.Repositories.Interfaces
{
    public interface ICandidateRepository
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
