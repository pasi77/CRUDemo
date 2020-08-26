 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRUDemo.Models;

namespace CRUDemo.Controllers
{
    public class CandidateController : Controller
    {
        CandidateDB candidateDB = new CandidateDB();
        public IActionResult Index()
        {
            List<CandidateInfo> canList = new List<CandidateInfo>();
            canList = candidateDB.GetAllCandidates().ToList();
            return View(canList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create([Bind] CandidateInfo objCan)
        {
            if (ModelState.IsValid)
            {
                candidateDB.AddCandidate(objCan);
                return RedirectToAction("Index");
            }
            return View(objCan);
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            CandidateInfo can = candidateDB.GetCandidateById(id);
            if(can == null)
            {
                return NotFound();
            }
            return View(can);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id,[Bind] CandidateInfo objCan)
        {
            if (id == null)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                candidateDB.UpdateCandidate(objCan);
                return RedirectToAction("Index");
            }
            return View(candidateDB);
        }
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            CandidateInfo can = candidateDB.GetCandidateById(id);
            if (can == null)
            {
                return NotFound();
            }
            return View(can);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            CandidateInfo can = candidateDB.GetCandidateById(id);
            if (can == null)
            {
                return NotFound();
            }
            return View(can);
        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCan(int? id)
        {
            candidateDB.DeleteCandidate(id);
            return RedirectToAction("Index");
        }
    }
}