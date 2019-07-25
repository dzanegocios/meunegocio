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
            /* Camadas BSC */
            var bscFinanceiro = _context.Bsc.Where(b => b.Nome == "Financeiro").ToList<Bsc>().First();
            var bscClientes = _context.Bsc.Where(b => b.Nome == "Clientes").ToList<Bsc>().First();
            var bscProcessoInterno = _context.Bsc.Where(b => b.Nome == "Processos Internos").ToList<Bsc>().First();
            var bscAprendizado = _context.Bsc.Where(b => b.Nome == "Aprendizado e Crescimento").ToList<Bsc>().First();

            /* Coleção de planos por camada */
            var colPlanosFinanceiro = _context.PlanoAcao.Where(p => p.LkpPerspectiva == bscFinanceiro.Id).ToList<PlanoAcao>();
            var colPlanosClientes = _context.PlanoAcao.Where(p => p.LkpPerspectiva == bscClientes.Id).ToList<PlanoAcao>();
            var colPlanosProcessoInterno = _context.PlanoAcao.Where(p => p.LkpPerspectiva == bscProcessoInterno.Id).ToList<PlanoAcao>();
            var colPlanosAprendizado = _context.PlanoAcao.Where(p => p.LkpPerspectiva == bscAprendizado.Id).ToList<PlanoAcao>();

            /* Coleção de objetivos por camada */
            var colObjetivoFinanceiro = _context.Objetivo.Where(o => o.LkpPerspectiva == bscFinanceiro.Id).ToList<Objetivo>();
            var colObjetivoClientes = _context.Objetivo.Where(o => o.LkpPerspectiva == bscClientes.Id).ToList<Objetivo>();
            var colObjetivoProcessoInterno = _context.Objetivo.Where(o => o.LkpPerspectiva == bscProcessoInterno.Id).ToList<Objetivo>();
            var colObjetivoAprendizado = _context.Objetivo.Where(o => o.LkpPerspectiva == bscAprendizado.Id).ToList<Objetivo>();

            /* Coleção de metricas por camada */
            var colMetricaFinanceiro = new List<Metrica>();
            foreach (var itemObj in colObjetivoFinanceiro)
            {
                foreach (var objMetrica in _context.Metrica.Where(m => m.LkpObjetivo == itemObj.Id).ToList<Metrica>())
                {
                    colMetricaFinanceiro.Add(objMetrica);
                }
            }
            
            var colMetricaClientes = new List<Metrica>();
            foreach (var itemObj in colObjetivoClientes)
            {
                foreach (var objMetrica in _context.Metrica.Where(m => m.LkpObjetivo == itemObj.Id).ToList<Metrica>())
                {
                    colMetricaClientes.Add(objMetrica);
                }
            }

            var colMetricaProcessoInterno = new List<Metrica>();
            foreach (var itemObj in colObjetivoProcessoInterno)
            {
                foreach (var objMetrica in _context.Metrica.Where(m => m.LkpObjetivo == itemObj.Id).ToList<Metrica>())
                {
                    colMetricaProcessoInterno.Add(objMetrica);
                }
            }

            var colMetricaAprendizado = new List<Metrica>();
            foreach (var itemObj in colObjetivoAprendizado)
            {
                foreach (var objMetrica in _context.Metrica.Where(m => m.LkpObjetivo == itemObj.Id).ToList<Metrica>())
                {
                    colMetricaAprendizado.Add(objMetrica);
                }
            }

            /* Desempenho por camada */
            var colDesempenhoFinanceiro = new List<Metrica>();
            List<decimal> numeroDesempenhoFinanceiro = new List<decimal>();
            foreach (var itemObj in colObjetivoFinanceiro)
            {
                foreach (var objMetrica in _context.Metrica.Where(m => m.LkpObjetivo == itemObj.Id && m.Nome == "DESEMPENHO").ToList<Metrica>())
                {
                    colDesempenhoFinanceiro.Add(objMetrica);
                    numeroDesempenhoFinanceiro.Add(objMetrica.Executado);
                }
            }
            /* Definição das ViewBags */
            ViewBag.colPlanosFinanceiro = colPlanosFinanceiro;  
            ViewBag.colObjetivoFinanceiro = colObjetivoFinanceiro;
            ViewBag.colDesempenhoFinanceiro = colDesempenhoFinanceiro;
            ViewBag.numeroDesempenhoFinanceiro = numeroDesempenhoFinanceiro;
            ViewBag.colMediaDesempenhoFinanceiro = Math.Round(numeroDesempenhoFinanceiro.Average());
            ViewBag.colMetricaFinanceiro = _context.Metrica.Where(m => m.Nome != "DESEMPENHO").Include(m => m.LkpMetricaNavigation).Include(m => m.LkpObjetivoNavigation).Include(m => m.LkpPessoaNavigation).Include(m => m.LkpPlanoAcaoNavigation).Include(m => m.LkpStatusDetalheTarefaNavigation).Include(m => m.LkpTarefaStatusNavigation).ToList<Metrica>();
            return View(await meunegocioContext.ToListAsync());
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
