using System.Collections.Generic;
using System.Threading.Tasks;
using GeekHunters.Entities;
using GeekHunters.Services.Interfaces;
using GeekHunters.Repositories;
using GeekHunters.Repositories.Interfaces;

namespace GeekHunters.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _candidateRepository;

        public CandidateService(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public async Task<IEnumerable<Candidate>> GetCandidates()
        {
            return await _candidateRepository.GetCandidates();
        }

        public async Task<Candidate> GetCandidate(int Id)
        {
            return await _candidateRepository.GetCandidate(Id);
        }

        public async Task<IEnumerable<Candidate>> GetCandidatesBySkillId(int Id)
        {
            return await _candidateRepository.GetCandidatesBySkillId(Id);
        }

        public async Task<bool> UpdateCandidate(Candidate candidate)
        {
            return await _candidateRepository.UpdateCandidate(candidate);
        }

        public async Task<IEnumerable<Skill>> GetSkills()
        {
            return await _candidateRepository.GetSkills();
        }

        public async Task<int> AddCandidate(Candidate candidate)
        {
            return await _candidateRepository.AddCandidate(candidate);
        }

        public async Task<bool> DeleteCandidate(int id)
        {
            return await _candidateRepository.DeleteCandidate(id);
        }
    }
}
