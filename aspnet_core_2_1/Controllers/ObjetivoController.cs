using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPNET_Core_2_1.Models;

namespace MEUNEGOCIO.Controllers
{
    public class ObjetivoController : Controller
    {
        private readonly meunegocioContext _context;

        public ObjetivoController(meunegocioContext context)
        {
            _context = context;
        }

        // GET: Objetivoes
        public async Task<IActionResult> Index()
        {
            var meunegocioContext = _context.Objetivo.Include(o => o.LkpMetricaNavigation).Include(o => o.LkpPerspectivaNavigation).Include(o => o.LkpPessoaNavigation).Include(o => o.LkpResponsavelNavigation);
            return View(await meunegocioContext.ToListAsync());
        }
        public async Task<IActionResult> v5()
        {
            return View();
        }
        public async Task<IActionResult> teste()
        {
            return View();
        }
        // GET: Objetivoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objetivo = await _context.Objetivo
                .Include(o => o.LkpMetricaNavigation)
                .Include(o => o.LkpPerspectivaNavigation)
                .Include(o => o.LkpPessoaNavigation)
                .Include(o => o.LkpResponsavelNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (objetivo == null)
            {
                return NotFound();
            }

            return View(objetivo);
        }

        // GET: Objetivoes/Create
        public IActionResult Create()
        {
            ViewData["LkpMetrica"] = new SelectList(_context.Metrica, "Id", "Id");
            ViewData["LkpPerspectiva"] = new SelectList(_context.Bsc, "Id", "Id");
            ViewData["LkpPessoa"] = new SelectList(_context.Pessoas, "Id", "Id");
            ViewData["LkpResponsavel"] = new SelectList(_context.ObjetivoPessoa, "Id", "Id");
            return View();
        }

        // POST: Objetivoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao,Nivel,DataInicio,DataTermino,Imagem,LkpPessoa,LkpResponsavel,LkpMetrica,LkpPerspectiva")] Objetivo objetivo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(objetivo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LkpMetrica"] = new SelectList(_context.Metrica, "Id", "Id", objetivo.LkpMetrica);
            ViewData["LkpPerspectiva"] = new SelectList(_context.Bsc, "Id", "Id", objetivo.LkpPerspectiva);
            ViewData["LkpPessoa"] = new SelectList(_context.Pessoas, "Id", "Id", objetivo.LkpPessoa);
            ViewData["LkpResponsavel"] = new SelectList(_context.ObjetivoPessoa, "Id", "Id", objetivo.LkpResponsavel);
            return View(objetivo);
        }

        // GET: Objetivoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objetivo = await _context.Objetivo.FindAsync(id);
            if (objetivo == null)
            {
                return NotFound();
            }
            ViewData["LkpMetrica"] = new SelectList(_context.Metrica, "Id", "Id", objetivo.LkpMetrica);
            ViewData["LkpPerspectiva"] = new SelectList(_context.Bsc, "Id", "Id", objetivo.LkpPerspectiva);
            ViewData["LkpPessoa"] = new SelectList(_context.Pessoas, "Id", "Id", objetivo.LkpPessoa);
            ViewData["LkpResponsavel"] = new SelectList(_context.ObjetivoPessoa, "Id", "Id", objetivo.LkpResponsavel);
            return View(objetivo);
        }

        // POST: Objetivoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao,Nivel,DataInicio,DataTermino,Imagem,LkpPessoa,LkpResponsavel,LkpMetrica,LkpPerspectiva")] Objetivo objetivo)
        {
            if (id != objetivo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(objetivo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObjetivoExists(objetivo.Id))
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
            ViewData["LkpMetrica"] = new SelectList(_context.Metrica, "Id", "Id", objetivo.LkpMetrica);
            ViewData["LkpPerspectiva"] = new SelectList(_context.Bsc, "Id", "Id", objetivo.LkpPerspectiva);
            ViewData["LkpPessoa"] = new SelectList(_context.Pessoas, "Id", "Id", objetivo.LkpPessoa);
            ViewData["LkpResponsavel"] = new SelectList(_context.ObjetivoPessoa, "Id", "Id", objetivo.LkpResponsavel);
            return View(objetivo);
        }

        // GET: Objetivoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objetivo = await _context.Objetivo
                .Include(o => o.LkpMetricaNavigation)
                .Include(o => o.LkpPerspectivaNavigation)
                .Include(o => o.LkpPessoaNavigation)
                .Include(o => o.LkpResponsavelNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (objetivo == null)
            {
                return NotFound();
            }

            return View(objetivo);
        }

        // POST: Objetivoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var objetivo = await _context.Objetivo.FindAsync(id);
            _context.Objetivo.Remove(objetivo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObjetivoExists(int id)
        {
            return _context.Objetivo.Any(e => e.Id == id);
        }
    }
}
