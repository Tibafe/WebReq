using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebReq_V1.Context;
using WebReq_V1.Models;

namespace WebReq_V1.Controllers
{
    public class SolicitanteController : Controller
    {
        private readonly Contexto _context;

        public SolicitanteController(Contexto context)
        {
            _context = context;
        }

        // GET: Solicitante
        public async Task<IActionResult> Index()
        {
              return View(await _context.Solicitante.ToListAsync());
        }

        // GET: Solicitante/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Solicitante == null)
            {
                return NotFound();
            }

            var solicitante = await _context.Solicitante
                .FirstOrDefaultAsync(m => m.Id == id);
            if (solicitante == null)
            {
                return NotFound();
            }

            return View(solicitante);
        }

        // GET: Solicitante/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Solicitante/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Ddd,Telefone")] Solicitante solicitante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(solicitante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(solicitante);
        }

        // GET: Solicitante/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Solicitante == null)
            {
                return NotFound();
            }

            var solicitante = await _context.Solicitante.FindAsync(id);
            if (solicitante == null)
            {
                return NotFound();
            }
            return View(solicitante);
        }

        // POST: Solicitante/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Ddd,Telefone")] Solicitante solicitante)
        {
            if (id != solicitante.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(solicitante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SolicitanteExists(solicitante.Id))
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
            return View(solicitante);
        }

        // GET: Solicitante/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Solicitante == null)
            {
                return NotFound();
            }

            var solicitante = await _context.Solicitante
                .FirstOrDefaultAsync(m => m.Id == id);
            if (solicitante == null)
            {
                return NotFound();
            }

            return View(solicitante);
        }

        // POST: Solicitante/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Solicitante == null)
            {
                return Problem("Entity set 'Contexto.Solicitante'  is null.");
            }
            var solicitante = await _context.Solicitante.FindAsync(id);
            if (solicitante != null)
            {
                _context.Solicitante.Remove(solicitante);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SolicitanteExists(int id)
        {
          return _context.Solicitante.Any(e => e.Id == id);
        }
    }
}
