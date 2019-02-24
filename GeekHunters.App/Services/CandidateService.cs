using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeekHunters.App.Services.Interfaces;
using GeekHunters.App.Repositories.Interfaces;
using GeekHunters.App.Repositories;
using GeekHunters.App.Models;

namespace GeekHunters.App.Services
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

        public async Task<Candidate> GetCandidate(int id)
        {
            return await _candidateRepository.GetCandidate(id);
        }

        public async Task<IEnumerable<Candidate>> GetCandidatesBySkillId(int id)
        {
            return await _candidateRepository.GetCandidatesBySkillId(id);
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
