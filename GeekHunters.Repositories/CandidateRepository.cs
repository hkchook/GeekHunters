using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GeekHunters.Repositories.Interfaces;
using GeekHunters.Entities;

namespace GeekHunters.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly GeekHuntersContext _db;

        public CandidateRepository(GeekHuntersContext dbcontext)
        {
            _db = dbcontext;
        }

        public async Task<IEnumerable<Candidate>> GetCandidates()
        {
            return await _db.Candidate.ToListAsync();
        }

        public async Task<Candidate> GetCandidate(int Id)
        {
            return await _db.Candidate.FindAsync(Id);
        }

        public async Task<IEnumerable<Candidate>> GetCandidatesBySkillId(int Id)
        {
            var candidates = await _db.Candidate.ToListAsync();

            if (Id > 0)
            {
                candidates = candidates.Where(x => x.Skill?.Id == Id).ToList();
            }

            return candidates;
        }

        public async Task<bool> UpdateCandidate(Candidate candidate)
        {
            candidate.LastModifiedDate = DateTime.Now;
            _db.Entry(candidate).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }

            return true;
        }

        public async Task<IEnumerable<Skill>> GetSkills()
        {
            return await _db.Skill.ToListAsync();
        }

        public async Task<int> AddCandidate(Candidate candidate)
        {
            candidate.CreatedDate = DateTime.Now;
            candidate.LastModifiedDate = DateTime.Now;

            await _db.Candidate.AddAsync(candidate);

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return 0;
            }

            return candidate.Id;
        }

        public async Task<bool> DeleteCandidate(int id)
        {
            var candidate = await _db.Candidate.FindAsync(id);
            if (candidate == null)
            {
                return false;
            }

            _db.Candidate.Remove(candidate);
            await _db.SaveChangesAsync();

            return true;
        }
    }
}
