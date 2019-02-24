using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GeekHunters.Entities;
using GeekHunters.Services;
using GeekHunters.Services.Interfaces;
using GeekHunters.Api.ViewModels;

namespace GeekHunters.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly ICandidateService _candidateService;
        private readonly IMapper _mapper;

        public CandidatesController(ICandidateService candidateService, IMapper mapper)
        {
            _candidateService = candidateService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get All Candidates (api/Candidates)
        /// </summary>
        /// <returns>Candidates</returns>
        [HttpGet]
        public async Task<IEnumerable<CandidateVm>> GetCandidate()
        {
            var candidates = await _candidateService.GetCandidates();

            return _mapper.Map<List<CandidateVm>>(candidates);
        }

        /// <summary>
        /// Get Candidate By Id (api/Candidates/5)
        /// </summary>
        /// <param name="id">Candidate Id</param>
        /// <returns>Candidate</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCandidate([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var candidate = await _candidateService.GetCandidate(id);

            if (candidate == null)
            {
                return NotFound(false);
            }

            return Ok(_mapper.Map<CandidateVm>(candidate));
        }

        /// <summary>
        /// Get Candidates By Skill Id (api/Candidates/skills/1), otherwise return all candidates
        /// </summary>
        /// <param name="id">Skill Id</param>
        /// <returns>Candidates according to Skill Id</returns>
        [HttpGet("skills/{id}")]
        public async Task<IActionResult> GetCandidatesBySkillId([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var candidates = await _candidateService.GetCandidatesBySkillId(id);

            if (candidates == null)
            {
                return NotFound(false);
            }

            return Ok(_mapper.Map<List<CandidateVm>>(candidates));
        }

        /// <summary>
        /// Get All Skills (api/Candidates/Skills)
        /// </summary>
        /// <returns>Skills</returns>
        [HttpGet("skills")]
        public async Task<IEnumerable<SkillVm>> GetSkills()
        {
            var makes = await _candidateService.GetSkills();

            return _mapper.Map<List<SkillVm>>(makes);
        }

        /// <summary>
        /// Put Candidate, Update a Candidate (api/Candidates/5)
        /// </summary>
        /// <param name="id">Candidate Id</param>
        /// <param name="candidate">Candidate</param>
        /// <returns>OK/Fail</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCandidate([FromRoute] int id, [FromBody] Candidate candidate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != candidate.Id)
            {
                return BadRequest();
            }

            var result = await _candidateService.UpdateCandidate(candidate);

            if (!result)
            {
                return NotFound(false);
            }

            return Ok(true);
        }

        /// <summary>
        /// Post Candidate, Create a new Candidate (api/Candidates)
        /// </summary>
        /// <param name="candidate">Candidate</param>
        /// <returns>OK/Fail</returns>
        [HttpPost]
        public async Task<IActionResult> PostCandidate([FromBody] Candidate candidate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _candidateService.AddCandidate(candidate);

            if (result <= 0)
            {
                return NotFound(0);
            }

            return Ok(result);
        }

        /// <summary>
        /// Delete Candidate (api/Candidates/5)
        /// </summary>
        /// <param name="id">Candidate Id</param>
        /// <returns>OK/Fail</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCandidate([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _candidateService.DeleteCandidate(id);

            if (!result)
            {
                return NotFound(false);
            }

            return Ok(true);
        }
    }
}