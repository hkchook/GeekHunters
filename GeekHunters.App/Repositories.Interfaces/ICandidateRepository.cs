using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeekHunters.App.Models;

namespace GeekHunters.App.Repositories.Interfaces
{
    public interface ICandidateRepository
    {
        Task<IEnumerable<Candidate>> GetCandidates();

        Task<Candidate> GetCandidate(int id);

        Task<IEnumerable<Candidate>> GetCandidatesBySkillId(int id);

        Task<bool> UpdateCandidate(Candidate candidate);

        Task<IEnumerable<Skill>> GetSkills();

        Task<int> AddCandidate(Candidate candidate);

        Task<bool> DeleteCandidate(int id);
    }
}
