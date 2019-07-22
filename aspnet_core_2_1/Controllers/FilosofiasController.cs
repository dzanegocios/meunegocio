using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPNET_Core_2_1.Models;

namespace MEUNEGOCIO.views
{
    public class FilosofiasController : Controller
    {
        private readonly meunegocioContext _context;

        public FilosofiasController(meunegocioContext context)
        {
            _context = context;
        }

        // GET: Filosofias
        public async Task<IActionResult> Index()
        {
            var meunegocioContext = _context.Filosofia.Include(f => f.LkpPessoaNavigation);
            return View(await meunegocioContext.ToListAsync());
        }

        // GET: Filosofias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filosofia = await _context.Filosofia
                .Include(f => f.LkpPessoaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filosofia == null)
            {
                return NotFound();
            }

            return View(filosofia);
        }

        // GET: Filosofias/Create
        public IActionResult Create()
        {
            ViewData["LkpPessoa"] = new SelectList(_context.Pessoas, "Id", "Id");
            return View();
        }

        // POST: Filosofias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Descricao,Categoria,Sequencia,LkpPessoa")] Filosofia filosofia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filosofia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LkpPessoa"] = new SelectList(_context.Pessoas, "Id", "Id", filosofia.LkpPessoa);
            return View(filosofia);
        }

        // GET: Filosofias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filosofia = await _context.Filosofia.FindAsync(id);
            if (filosofia == null)
            {
                return NotFound();
            }
            ViewData["LkpPessoa"] = new SelectList(_context.Pessoas, "Id", "Id", filosofia.LkpPessoa);
            return View(filosofia);
        }

        // POST: Filosofias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Descricao,Categoria,Sequencia,LkpPessoa")] Filosofia filosofia)
        {
            if (id != filosofia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filosofia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilosofiaExists(filosofia.Id))
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
            ViewData["LkpPessoa"] = new SelectList(_context.Pessoas, "Id", "Id", filosofia.LkpPessoa);
            return View(filosofia);
        }

        // GET: Filosofias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filosofia = await _context.Filosofia
                .Include(f => f.LkpPessoaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filosofia == null)
            {
                return NotFound();
            }

            return View(filosofia);
        }

        // POST: Filosofias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var filosofia = await _context.Filosofia.FindAsync(id);
            _context.Filosofia.Remove(filosofia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilosofiaExists(int id)
        {
            return _context.Filosofia.Any(e => e.Id == id);
        }
    }
}
