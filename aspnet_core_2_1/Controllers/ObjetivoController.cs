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

            /* INICIO */
            Perfil objPerfil = _context.Perfil.Where(pr => pr.LkpPessoa == _context.Pessoas.Where(ps => ps.Email == "dsilvanicolas@gmail.com").First().Id).First();
            Metrica objMetricaPadrao = new Metrica();
            var colCamadas = _context.Bsc.Where(b => b.Id != null);
            int contadorCamada = 0, contadorObjetivo = 0;
            var colObjetivo = _context.Objetivo.Where(o => o.Id != null);
            List<decimal> listaDesempenhoCamada = new List<decimal>();
            List<decimal> listaDesempenhoObjetivo = new List<decimal>();
            List<decimal> listaAuxiliarDesempenhoObjetivo = new List<decimal>();
            List<String> corFundoCamada = new List<string>();
            List<String> corBordaCamada = new List<string>();
            List<String> corFundoObjetivo = new List<string>();
            List<String> corBordaObjetivo = new List<string>();
            List<PlanoAcao> colPlanoAcaoCamada = new List<PlanoAcao>();
            foreach (var camada in _context.Bsc.Where(b => b.Id != null))
            {
                listaAuxiliarDesempenhoObjetivo = new List<decimal>();

                foreach (var objetivo in colObjetivo.Where(o => o.LkpPerspectiva == camada.Id && o.LkpPessoa == objPerfil.LkpPessoa))
                {
                    try
                    {
                        var objMetricaTemplate = _context.Metrica.Where(m => m.LkpObjetivo == objetivo.Id && m.Nome == "DESEMPENHO").First();
                        var objMetricaDesempenho = _context.Metrica.Where(m => m.LkpMetrica == objMetricaTemplate.Id).First();

                        /* Inserindo desempenho de cada objetivo em uma lista */
                        listaDesempenhoObjetivo.Add(objMetricaDesempenho.Executado);
                        listaAuxiliarDesempenhoObjetivo.Add(objMetricaDesempenho.Executado);

                        /* Definição de cores de fundo e borda dos objetivos */
                        corFundoObjetivo.Add(objMetricaPadrao.corFundo(listaDesempenhoObjetivo.Count > 0 ? listaDesempenhoObjetivo[contadorObjetivo] : -1, "Quanto maior melhor", objPerfil.getValoresCor()));
                        corBordaObjetivo.Add(objMetricaPadrao.corBorda(listaDesempenhoObjetivo.Count > 0 ? listaDesempenhoObjetivo[contadorObjetivo] : -1, "Quanto maior melhor", objPerfil.getValoresCor()));

                    }
                    catch
                    {
                        listaDesempenhoObjetivo.Add(-1);
                        listaAuxiliarDesempenhoObjetivo.Add(-1);

                        /* Definição de cores de fundo e borda dos objetivos */
                        corFundoObjetivo.Add(objMetricaPadrao.corFundo(-1, "Quanto maior melhor", objPerfil.getValoresCor()));
                        corBordaObjetivo.Add(objMetricaPadrao.corBorda(-1, "Quanto maior melhor", objPerfil.getValoresCor()));

                    }

                    contadorObjetivo += 1;
                }
                /* Inserindo desempenho de cada camada em uma lista */
                if (listaAuxiliarDesempenhoObjetivo.Count() > 0)
                {
                    listaDesempenhoCamada.Add(listaAuxiliarDesempenhoObjetivo.Average());
                }
                else
                {
                    listaDesempenhoCamada.Add(-1);
                }
                /* Definição de cores de fundo e borda das camadas */
                corFundoCamada.Add(objMetricaPadrao.corFundo(listaDesempenhoCamada.Count > 0 ? listaDesempenhoCamada[contadorCamada] : -1, "Quanto maior melhor", objPerfil.getValoresCor()));
                corBordaCamada.Add(objMetricaPadrao.corBorda(listaDesempenhoCamada.Count > 0 ? listaDesempenhoCamada[contadorCamada] : -1, "Quanto maior melhor", objPerfil.getValoresCor()));

                /* Coleção de planos por camada */
                foreach (var plano in _context.PlanoAcao.Where(p => p.LkpPerspectiva == camada.Id))
                {
                    colPlanoAcaoCamada.Add(plano);

                }
                
                contadorCamada += 1;
            }
            /* View Bags */
            ViewBag.colMetrica = _context.Metrica.Where(m => m.LkpMetrica != null).ToList<Metrica>();
            ViewBag.listaDesempenhoCamada = listaDesempenhoCamada;
            ViewBag.listaDesempenhoObjetivo = listaDesempenhoObjetivo;
            ViewBag.colTemplateMetrica = _context.Metrica.Where(m => m.Template == true && m.LkpPessoa == objPerfil.LkpPessoa && m.Nome != "DESEMPENHO");
            ViewBag.colObjetivo = colObjetivo;
            ViewBag.colCamadas = colCamadas;
            ViewBag.corBordaCamada = corBordaCamada;
            ViewBag.corFundoCamada = corFundoCamada;
            ViewBag.corBordaObjetivo = corBordaObjetivo;
            ViewBag.corFundoObjetivo = corFundoObjetivo;
            ViewBag.colPlanoAcaoCamada = colPlanoAcaoCamada;
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
