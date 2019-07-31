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

            /* Coleção de metricas template por camada */
            List<Metrica> colTemplateMetricaFinanceiro = new List<Metrica>();
            int? colFinanceiroMetricaPesoTotal = 0;
            foreach (var itemObj in colObjetivoFinanceiro)
            {
                foreach (var objMetrica in _context.Metrica.Where(m => m.LkpObjetivo == itemObj.Id && m.Nome != "DESEMPENHO" && m.Template == true).ToList<Metrica>())
                {
                    colFinanceiroMetricaPesoTotal = colFinanceiroMetricaPesoTotal + objMetrica.Peso;
                    colTemplateMetricaFinanceiro.Add(objMetrica);
                }
            }
            
            var colTemplateMetricaClientes = new List<Metrica>();
            int? colClienteMetricaPesoTotal = 0;
            foreach (var itemObj in colObjetivoClientes)
            {
                foreach (var objMetrica in _context.Metrica.Where(m => m.LkpObjetivo == itemObj.Id && m.Nome != "DESEMPENHO" && m.Template == true).ToList<Metrica>())
                {
                    colClienteMetricaPesoTotal = colClienteMetricaPesoTotal + objMetrica.Peso;
                    colTemplateMetricaClientes.Add(objMetrica);
                }
            }

            var colTemplateMetricaProcessoInterno = new List<Metrica>();
            int? colProcessoInternoMetricaPesoTotal = 0;
            foreach (var itemObj in colObjetivoProcessoInterno)
            {
                foreach (var objMetrica in _context.Metrica.Where(m => m.LkpObjetivo == itemObj.Id && m.Nome != "DESEMPENHO" && m.Template == true).ToList<Metrica>())
                {
                    colProcessoInternoMetricaPesoTotal = colProcessoInternoMetricaPesoTotal + objMetrica.Peso;
                    colTemplateMetricaProcessoInterno.Add(objMetrica);
                }
            }

            var colTemplateMetricaAprendizado = new List<Metrica>();
            int? colAprendizadoMetricaPesoTotal = 0;
            foreach (var itemObj in colObjetivoAprendizado)
            {
                foreach (var objMetrica in _context.Metrica.Where(m => m.LkpObjetivo == itemObj.Id && m.Nome != "DESEMPENHO" && m.Template == true).ToList<Metrica>())
                {
                    colAprendizadoMetricaPesoTotal = colAprendizadoMetricaPesoTotal + objMetrica.Peso;
                    colTemplateMetricaAprendizado.Add(objMetrica);
                }
            }

            /* Desempenho por camada */
            var colDesempenhoFinanceiro = new List<Metrica>();
            List<decimal> numeroDesempenhoFinanceiro = new List<decimal>();
            foreach (var itemObj in colObjetivoFinanceiro)
            {
                foreach (var objMetricaTemplate in _context.Metrica.Where(m => m.LkpObjetivo == itemObj.Id && m.Nome == "DESEMPENHO" && m.Template == true).ToList<Metrica>())
                {
                    colDesempenhoFinanceiro.Add(objMetricaTemplate);
                    var objMetrica = _context.Metrica.Where(m => m.LkpMetrica == objMetricaTemplate.Id).First();
                    numeroDesempenhoFinanceiro.Add(objMetrica.Executado);
                }
            }

            var colDesempenhoCliente = new List<Metrica>();
            List<decimal> numeroDesempenhoCliente = new List<decimal>();
            foreach (var itemObj in colObjetivoClientes)
            {
                foreach (var objMetricaTemplate in _context.Metrica.Where(m => m.LkpObjetivo == itemObj.Id && m.Nome == "DESEMPENHO" && m.Template == true).ToList<Metrica>())
                {
                    colDesempenhoCliente.Add(objMetricaTemplate);
                    var objMetrica = _context.Metrica.Where(m => m.LkpMetrica == objMetricaTemplate.Id).First();
                    numeroDesempenhoCliente.Add(objMetrica.Executado);
                }   
            }

            var colDesempenhoProcessoInterno = new List<Metrica>();
            List<decimal> numeroDesempenhoProcessoInterno = new List<decimal>();
            foreach (var itemObj in colObjetivoProcessoInterno)
            {
                foreach (var objMetricaTemplate in _context.Metrica.Where(m => m.LkpObjetivo == itemObj.Id && m.Nome == "DESEMPENHO" && m.Template == true).ToList<Metrica>())
                {
                    colDesempenhoProcessoInterno.Add(objMetricaTemplate);
                    var objMetrica = _context.Metrica.Where(m => m.LkpMetrica == objMetricaTemplate.Id).First();
                    numeroDesempenhoProcessoInterno.Add(objMetrica.Executado);
                }
            }

            var colDesempenhoAprendizado = new List<Metrica>();
            List<decimal> numeroDesempenhoAprendizado = new List<decimal>();
            foreach (var itemObj in colObjetivoAprendizado)
            {
                foreach (var objMetricaTemplate in _context.Metrica.Where(m => m.LkpObjetivo == itemObj.Id && m.Nome == "DESEMPENHO" && m.Template == true).ToList<Metrica>())
                {
                    colDesempenhoAprendizado.Add(objMetricaTemplate);
                    var objMetrica = _context.Metrica.Where(m => m.LkpMetrica == objMetricaTemplate.Id).First();
                    numeroDesempenhoAprendizado.Add(objMetrica.Executado);
                }
            }

            /* Cálculo da média ponderada do desempenho financeiro */
            
            /* Cálculo da média ponderada do desempenho cliente */
            /* Cálculo da média ponderada do desempenho processo interno */
            /* Cálculo da média ponderada do desempenho aprendizado */
            /* Miscelania */

            /* Definição das ViewBags Financeiro*/
            ViewBag.colPlanosFinanceiro = colPlanosFinanceiro;  
            ViewBag.colObjetivoFinanceiro = colObjetivoFinanceiro;
            ViewBag.colDesempenhoFinanceiro = colDesempenhoFinanceiro;
            ViewBag.numeroDesempenhoFinanceiro = numeroDesempenhoFinanceiro;
            ViewBag.colMediaDesempenhoFinanceiro = numeroDesempenhoFinanceiro.Count > 0 ? Math.Round(numeroDesempenhoFinanceiro.Average()) : 0;
            ViewBag.colTemplateMetricaFinanceiro = colTemplateMetricaFinanceiro;

            /* Definição das ViewBags Cliente */
            ViewBag.colPlanosCliente = colPlanosClientes;
            ViewBag.ObjetivoCliente = colObjetivoClientes;
            ViewBag.colDesempenhoCliente = colDesempenhoCliente;
            ViewBag.numeroDesempenhoCliente = numeroDesempenhoCliente;
            ViewBag.colMediaDesempenhoCliente = numeroDesempenhoCliente.Count > 0 ? Math.Round(numeroDesempenhoCliente.Average()) : 0;
            ViewBag.colTemplateMetricaCliente = colTemplateMetricaClientes;

            /* Definição das ViewBags Processo Interno */
            ViewBag.colPlanosProcessoInterno = colPlanosProcessoInterno;
            ViewBag.ObjetivoProcessoInterno = colObjetivoProcessoInterno;
            ViewBag.numeroDesempenhoProcessoInterno = numeroDesempenhoProcessoInterno;
            ViewBag.colMediaDesempenhoProcessoInterno = numeroDesempenhoProcessoInterno.Count > 0 ? Math.Round(numeroDesempenhoProcessoInterno.Average()) : 0;
            ViewBag.colTemplateMetricaProcessoInterno = colTemplateMetricaProcessoInterno;

            /* Definição das ViewBags Aprendizado */
            ViewBag.colPlanosAprendizado = colPlanosAprendizado;
            ViewBag.ObjetivoAprendizado = colObjetivoAprendizado;
            ViewBag.numeroDesempenhoAprendizado = numeroDesempenhoAprendizado;
            ViewBag.colMediaDesempenhoAprendizado = numeroDesempenhoAprendizado.Count > 0 ? Math.Round(numeroDesempenhoAprendizado.Average()) : 0;
            ViewBag.colTemplateMetricaAprendizado = colTemplateMetricaAprendizado;

            /* Model View */
            ViewBag.colMetrica = _context.Metrica.Where(m => m.LkpMetrica != null).ToList<Metrica>();
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
