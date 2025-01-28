using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FoodDelivery.Domain.DomainModels.PawPrintModels;
using FoodDelivery.Service.Interface;
using FoodDelivery.Service.Implementation;

namespace FoodDelivery.Web.Controllers
{
    public class PetsController : Controller
    {
        private readonly PawPrintDbcontext _context;
        private readonly IPawPrintService _pawPrintService;
        public PetsController(PawPrintDbcontext context, IPawPrintService pawPrintService)
        {
            _context = context;
            _pawPrintService = pawPrintService;
        }

        // GET: Pets
        public async Task<IActionResult> Index()
        {
            return View(_pawPrintService.GetAllPets());
        }

        // GET: Pets/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet = await _context.Pets
                .Include(p => p.AdoptionStatus)
                .Include(p => p.Gender)
                .Include(p => p.HealthStatus)
                .Include(p => p.Size)
                .Include(p => p.Type)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pet == null)
            {
                return NotFound();
            }

            return View(pet);
        }

        // GET: Pets/Create
        public IActionResult Create()
        {
            ViewData["AdoptionStatusId"] = new SelectList(_context.AdoptionStatuses, "Id", "Name");
            ViewData["GenderId"] = new SelectList(_context.PetGenders, "Id", "Name");
            ViewData["HealthStatusId"] = new SelectList(_context.HealthStatuses, "Id", "Name");
            ViewData["SizeId"] = new SelectList(_context.PetSizes, "Id", "Name");
            ViewData["TypeId"] = new SelectList(_context.PetTypes, "Id", "Name");
            return View();
        }

        // POST: Pets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Breed,AvatarImg,ImageShowcase,AgeYears,TypeId,GenderId,SizeId,AdoptionStatusId,HealthStatusId,GoodWithChildren,GoodWithDogs,GoodWithCats,EnergyLevel,Description,SpecialRequirements,BehavioralNotes,Id")] Pet pet)
        {
            if (ModelState.IsValid)
            {
                pet.Id = Guid.NewGuid();
                _context.Add(pet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdoptionStatusId"] = new SelectList(_context.AdoptionStatuses, "Id", "Name", pet.AdoptionStatusId);
            ViewData["GenderId"] = new SelectList(_context.PetGenders, "Id", "Name", pet.GenderId);
            ViewData["HealthStatusId"] = new SelectList(_context.HealthStatuses, "Id", "Name", pet.HealthStatusId);
            ViewData["SizeId"] = new SelectList(_context.PetSizes, "Id", "Name", pet.SizeId);
            ViewData["TypeId"] = new SelectList(_context.PetTypes, "Id", "Name", pet.TypeId);
            return View(pet);
        }

        // GET: Pets/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet = await _context.Pets.FindAsync(id);
            if (pet == null)
            {
                return NotFound();
            }
            ViewData["AdoptionStatusId"] = new SelectList(_context.AdoptionStatuses, "Id", "Name", pet.AdoptionStatusId);
            ViewData["GenderId"] = new SelectList(_context.PetGenders, "Id", "Name", pet.GenderId);
            ViewData["HealthStatusId"] = new SelectList(_context.HealthStatuses, "Id", "Name", pet.HealthStatusId);
            ViewData["SizeId"] = new SelectList(_context.PetSizes, "Id", "Name", pet.SizeId);
            ViewData["TypeId"] = new SelectList(_context.PetTypes, "Id", "Name", pet.TypeId);
            return View(pet);
        }

        // POST: Pets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Breed,AvatarImg,ImageShowcase,AgeYears,TypeId,GenderId,SizeId,AdoptionStatusId,HealthStatusId,GoodWithChildren,GoodWithDogs,GoodWithCats,EnergyLevel,Description,SpecialRequirements,BehavioralNotes,Id")] Pet pet)
        {
            if (id != pet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PetExists(pet.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdoptionStatusId"] = new SelectList(_context.AdoptionStatuses, "Id", "Name", pet.AdoptionStatusId);
            ViewData["GenderId"] = new SelectList(_context.PetGenders, "Id", "Name", pet.GenderId);
            ViewData["HealthStatusId"] = new SelectList(_context.HealthStatuses, "Id", "Name", pet.HealthStatusId);
            ViewData["SizeId"] = new SelectList(_context.PetSizes, "Id", "Name", pet.SizeId);
            ViewData["TypeId"] = new SelectList(_context.PetTypes, "Id", "Name", pet.TypeId);
            return View(pet);
        }

        // GET: Pets/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet = await _context.Pets
                .Include(p => p.AdoptionStatus)
                .Include(p => p.Gender)
                .Include(p => p.HealthStatus)
                .Include(p => p.Size)
                .Include(p => p.Type)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pet == null)
            {
                return NotFound();
            }

            return View(pet);
        }

        // POST: Pets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var pet = await _context.Pets.FindAsync(id);
            if (pet != null)
            {
                _context.Pets.Remove(pet);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PetExists(Guid id)
        {
            return _context.Pets.Any(e => e.Id == id);
        }
    }
}
