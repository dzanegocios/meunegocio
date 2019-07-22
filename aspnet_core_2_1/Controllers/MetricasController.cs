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
    public class MetricasController : Controller
    {
        private readonly meunegocioContext _context;

        public MetricasController(meunegocioContext context)
        {
            _context = context;
        }

        // GET: Metricas
        public async Task<IActionResult> Index()
        {
            var meunegocioContext = _context.Metrica.Include(m => m.LkpMetricaNavigation).Include(m => m.LkpObjetivoNavigation).Include(m => m.LkpPessoaNavigation).Include(m => m.LkpPlanoAcaoNavigation).Include(m => m.LkpStatusDetalheTarefaNavigation).Include(m => m.LkpTarefaStatusNavigation);
            return View(await meunegocioContext.ToListAsync());
        }

        // GET: Metricas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metrica = await _context.Metrica
                .Include(m => m.LkpMetricaNavigation)
                .Include(m => m.LkpObjetivoNavigation)
                .Include(m => m.LkpPessoaNavigation)
                .Include(m => m.LkpPlanoAcaoNavigation)
                .Include(m => m.LkpStatusDetalheTarefaNavigation)
                .Include(m => m.LkpTarefaStatusNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (metrica == null)
            {
                return NotFound();
            }

            return View(metrica);
        }

        // GET: Metricas/Create
        public IActionResult Create()
        {
            ViewData["LkpMetrica"] = new SelectList(_context.Metrica, "Id", "Id");
            ViewData["LkpObjetivo"] = new SelectList(_context.Objetivo, "Id", "Id");
            ViewData["LkpPessoa"] = new SelectList(_context.Pessoas, "Id", "Id");
            ViewData["LkpPlanoAcao"] = new SelectList(_context.PlanoAcao, "Id", "Id");
            ViewData["LkpStatusDetalheTarefa"] = new SelectList(_context.TarefaStatusDetalhe, "Id", "Id");
            ViewData["LkpTarefaStatus"] = new SelectList(_context.TarefaStatus, "Id", "Id");
            return View();
        }

        // POST: Metricas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Indice,Data,Unidade,Peso,Template,Planejado,Executado,Razao,ParecerDescritivo,LkpObjetivo,LkpPessoa,LkpPlanoAcao,LkpTarefaStatus,LkpStatusDetalheTarefa,LkpMetrica")] Metrica metrica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(metrica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LkpMetrica"] = new SelectList(_context.Metrica, "Id", "Nome", metrica.LkpMetrica);
            ViewData["LkpObjetivo"] = new SelectList(_context.Objetivo, "Id", "Id", metrica.LkpObjetivo);
            ViewData["LkpPessoa"] = new SelectList(_context.Pessoas, "Id", "Id", metrica.LkpPessoa);
            ViewData["LkpPlanoAcao"] = new SelectList(_context.PlanoAcao, "Id", "Id", metrica.LkpPlanoAcao);
            ViewData["LkpStatusDetalheTarefa"] = new SelectList(_context.TarefaStatusDetalhe, "Id", "Id", metrica.LkpStatusDetalheTarefa);
            ViewData["LkpTarefaStatus"] = new SelectList(_context.TarefaStatus, "Id", "Id", metrica.LkpTarefaStatus);
            return View(metrica);
        }

        // GET: Metricas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metrica = await _context.Metrica.FindAsync(id);
            if (metrica == null)
            {
                return NotFound();
            }
            ViewData["LkpMetrica"] = new SelectList(_context.Metrica, "Id", "Nome", metrica.LkpMetrica);
            ViewData["LkpObjetivo"] = new SelectList(_context.Objetivo, "Id", "Id", metrica.LkpObjetivo);
            ViewData["LkpPessoa"] = new SelectList(_context.Pessoas, "Id", "Nome", metrica.LkpPessoa);
            ViewData["LkpPlanoAcao"] = new SelectList(_context.PlanoAcao, "Id", "Titulo", metrica.LkpPlanoAcao);
            ViewData["LkpStatusDetalheTarefa"] = new SelectList(_context.TarefaStatusDetalhe, "Id", "Descricao", metrica.LkpStatusDetalheTarefa);
            ViewData["LkpTarefaStatus"] = new SelectList(_context.TarefaStatus, "Id", "Descricao", metrica.LkpTarefaStatus);
            return View(metrica);
        }

        // POST: Metricas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Indice,Data,Unidade,Peso,Template,Planejado,Executado,Razao,ParecerDescritivo,LkpObjetivo,LkpPessoa,LkpPlanoAcao,LkpTarefaStatus,LkpStatusDetalheTarefa,LkpMetrica")] Metrica metrica)
        {
            if (id != metrica.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(metrica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MetricaExists(metrica.Id))
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
            ViewData["LkpMetrica"] = new SelectList(_context.Metrica, "Id", "Id", metrica.LkpMetrica);
            ViewData["LkpObjetivo"] = new SelectList(_context.Objetivo, "Id", "Titulo", metrica.LkpObjetivo);
            ViewData["LkpPessoa"] = new SelectList(_context.Pessoas, "Id", "Id", metrica.LkpPessoa);
            ViewData["LkpPlanoAcao"] = new SelectList(_context.PlanoAcao, "Id", "Id", metrica.LkpPlanoAcao);
            ViewData["LkpStatusDetalheTarefa"] = new SelectList(_context.TarefaStatusDetalhe, "Id", "Id", metrica.LkpStatusDetalheTarefa);
            ViewData["LkpTarefaStatus"] = new SelectList(_context.TarefaStatus, "Id", "Id", metrica.LkpTarefaStatus);
            return View(metrica);
        }

        // GET: Metricas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metrica = await _context.Metrica
                .Include(m => m.LkpMetricaNavigation)
                .Include(m => m.LkpObjetivoNavigation)
                .Include(m => m.LkpPessoaNavigation)
                .Include(m => m.LkpPlanoAcaoNavigation)
                .Include(m => m.LkpStatusDetalheTarefaNavigation)
                .Include(m => m.LkpTarefaStatusNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (metrica == null)
            {
                return NotFound();
            }

            return View(metrica);
        }

        // POST: Metricas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var metrica = await _context.Metrica.FindAsync(id);
            _context.Metrica.Remove(metrica);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MetricaExists(int id)
        {
            return _context.Metrica.Any(e => e.Id == id);
        }
    }
}
