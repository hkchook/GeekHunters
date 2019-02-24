using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using GeekHunters.App.Models;
using GeekHunters.App.Services;
using GeekHunters.App.Services.Interfaces;

namespace GeekHunters.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICandidateService _candidateService;

        public HomeController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        public async Task<IActionResult> Index(string filter)
        {
            int skillId = 0;
            int.TryParse(filter, out skillId);            
            var candidates = await _candidateService.GetCandidatesBySkillId(skillId);

            List<Skill> Skills = new List<Skill>();
            Skills.Add(new Skill { Id = 0, Name = "All" });
            Skills.AddRange(await _candidateService.GetSkills());
            ViewBag.Skill = new SelectList(Skills, "Id", "Name");

            return View(candidates);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidate = await _candidateService.GetCandidate((int)id);

            if (candidate == null)
            {
                return NotFound();
            }

            return View(candidate);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidate = await _candidateService.GetCandidate((int)id);

            if (candidate == null)
            {
                return NotFound();
            }

            ViewData["SkillId"] = new SelectList(await _candidateService.GetSkills(), "Id", "Name", candidate.Skill?.Id);
            return View(candidate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Candidate candidate)
        {
            if (ModelState.IsValid)
            {
                if (await _candidateService.UpdateCandidate(candidate))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", string.Format("Update Candidate (Id={0}) Failed !! Please Try Again Later.", candidate.Id));
                }
            }

            ViewData["SkillId"] = new SelectList(await _candidateService.GetSkills(), "Id", "Name", candidate.Skill?.Id);
            return View(candidate);
        }

        public async Task<IActionResult> Create()
        {
            ViewData["SkillId"] = new SelectList(await _candidateService.GetSkills(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Candidate candidate)
        {
            if (ModelState.IsValid)
            {
                if (await _candidateService.AddCandidate(candidate) > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", string.Format("Create Candidate Failed !! Please Try Again Later."));
                }
            }

            ViewData["SkillId"] = new SelectList(await _candidateService.GetSkills(), "Id", "Name", candidate.Skill?.Id);
            return View(candidate);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidate = await _candidateService.GetCandidate((int)id);

            if (candidate == null)
            {
                return NotFound();
            }

            return View(candidate);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _candidateService.DeleteCandidate(id);
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
