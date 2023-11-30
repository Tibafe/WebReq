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
    public class RequisicaoController : Controller
    {
        private readonly Contexto _context;

        public RequisicaoController(Contexto context)
        {
            _context = context;
        }

        // GET: Requisicao
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Requisicao.Include(r => r.Clientes).Include(r => r.Produtos).Include(r => r.Solicitantes);
            return View(await contexto.ToListAsync());
        }

        // GET: Requisicao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Requisicao == null)
            {
                return NotFound();
            }

            var requisicao = await _context.Requisicao
                .Include(r => r.Clientes)
                .Include(r => r.Produtos)
                .Include(r => r.Solicitantes)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (requisicao == null)
            {
                return NotFound();
            }

            return View(requisicao);
        }

        // GET: Requisicao/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Nome");
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "Id", "Nome");
            ViewData["SolicitanteId"] = new SelectList(_context.Solicitante, "Id", "Nome");
            return View();
        }

        // POST: Requisicao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Data,Quantidade,ClienteId,SolicitanteId,ProdutoId")] Requisicao requisicao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(requisicao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Nome", requisicao.ClienteId);
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "Id", "Nome", requisicao.ProdutoId);
            ViewData["SolicitanteId"] = new SelectList(_context.Solicitante, "Id", "Nome", requisicao.SolicitanteId);
            return View(requisicao);
        }

        // GET: Requisicao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Requisicao == null)
            {
                return NotFound();
            }

            var requisicao = await _context.Requisicao.FindAsync(id);
            if (requisicao == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Nome", requisicao.ClienteId);
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "Id", "Nome", requisicao.ProdutoId);
            ViewData["SolicitanteId"] = new SelectList(_context.Solicitante, "Id", "Nome", requisicao.SolicitanteId);
            return View(requisicao);
        }

        // POST: Requisicao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Data,Quantidade,ClienteId,SolicitanteId,ProdutoId")] Requisicao requisicao)
        {
            if (id != requisicao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(requisicao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequisicaoExists(requisicao.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Nome", requisicao.ClienteId);
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "Id", "Nome", requisicao.ProdutoId);
            ViewData["SolicitanteId"] = new SelectList(_context.Solicitante, "Id", "Nome", requisicao.SolicitanteId);
            return View(requisicao);
        }

        // GET: Requisicao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Requisicao == null)
            {
                return NotFound();
            }

            var requisicao = await _context.Requisicao
                .Include(r => r.Clientes)
                .Include(r => r.Produtos)
                .Include(r => r.Solicitantes)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (requisicao == null)
            {
                return NotFound();
            }

            return View(requisicao);
        }

        // POST: Requisicao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Requisicao == null)
            {
                return Problem("Entity set 'Contexto.Requisicao'  is null.");
            }
            var requisicao = await _context.Requisicao.FindAsync(id);
            if (requisicao != null)
            {
                _context.Requisicao.Remove(requisicao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequisicaoExists(int id)
        {
          return _context.Requisicao.Any(e => e.Id == id);
        }
    }
}
