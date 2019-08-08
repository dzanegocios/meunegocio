using System;
using System.Collections.Generic;
using System.Linq;

namespace ASPNET_Core_2_1.Models
{
    public partial class Metrica
    {
        public Metrica()
        {
            InverseLkpMetricaNavigation = new HashSet<Metrica>();
            Objetivo = new HashSet<Objetivo>();
            PlanoAcao = new HashSet<PlanoAcao>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Indice { get; set; }
        public DateTime? Data { get; set; }
        public string Unidade { get; set; }
        public short? Peso { get; set; }
        public bool? Template { get; set; }
        public decimal? Planejado { get; set; }
        public decimal Executado { get; set; }
        public decimal? Razao { get; set; }
        public string ParecerDescritivo { get; set; }
        public int? LkpObjetivo { get; set; }
        public int? LkpPessoa { get; set; }
        public int? LkpPlanoAcao { get; set; }
        public int? LkpTarefaStatus { get; set; }
        public int? LkpStatusDetalheTarefa { get; set; }
        public int? LkpMetrica { get; set; }

        public Metrica LkpMetricaNavigation { get; set; }
        public Objetivo LkpObjetivoNavigation { get; set; }
        public Pessoas LkpPessoaNavigation { get; set; }
        public PlanoAcao LkpPlanoAcaoNavigation { get; set; }
        public TarefaStatusDetalhe LkpStatusDetalheTarefaNavigation { get; set; }
        public TarefaStatus LkpTarefaStatusNavigation { get; set; }
        public ICollection<Metrica> InverseLkpMetricaNavigation { get; set; }
        public ICollection<Objetivo> Objetivo { get; set; }
        public ICollection<PlanoAcao> PlanoAcao { get; set; }

        private readonly meunegocioContext _context;

        public void desempenhoMetricaMetometro(int IDMetrica, DateTime dataMetrica)
        {
            var objMetricaTemplate = _context.Metrica.Where(m => m.Id == IDMetrica).First();
            var objObjetivo = _context.Objetivo.Where(o => o.Id == objMetricaTemplate.LkpObjetivo).First();
            var objMetricaDesempenhoTemplate = _context.Metrica.Where(m => m.LkpObjetivo == objObjetivo.Id && m.Nome == "DESEMPENHO").First();
            var objMetricaDesempenho = _context.Metrica.Where(m => m.LkpMetrica == objMetricaDesempenhoTemplate.Id && m.Data == dataMetrica).First();
            decimal? executado = 0, peso = 0;
            var colTemplates = _context.Metrica.Where(m => m.LkpObjetivo == objObjetivo.Id && m.Nome != "DESEMPENHO");
            var colMetricaPesoTotal = _context.Metrica.Where(m => m.LkpObjetivo == objObjetivo.Id && m.Nome != "DESEMPENHO");

            foreach (var metricaTemplate in colTemplates)
            {
                foreach (var itemMetrica in _context.Metrica.Where(m => m.LkpMetrica == metricaTemplate.Id && m.Data == dataMetrica && m.Nome != "DESEMPENHO"))
                {
                    var objPesoTemplate = _context.Metrica.Where(m => m.Id == itemMetrica.LkpMetrica).First();
                    if (itemMetrica.Razao > 0)
                    {
                        executado = executado + itemMetrica.Razao * objPesoTemplate.Peso / colMetricaPesoTotal.Sum(m => m.Peso) * 100;
                    }
                    peso = peso + objPesoTemplate.Peso / colMetricaPesoTotal.Sum(m => m.Peso) * 100;
                }
            }
            if (executado > 0 && peso > 0)
            {
                var mediaPonderadaExecutada = executado / peso;
                objMetricaDesempenho.Executado = (decimal)mediaPonderadaExecutada;
                objMetricaDesempenho.Planejado = 100;
            }
            else
            {
                objMetricaDesempenho.Executado = 0;
                objMetricaDesempenho.Planejado = 0;
            }
            // Salvar alterações no banco
            _context.SaveChanges();
        }
        public String corFundo(decimal razao, string indice, List<int> valores)
        {
            string corFundo = null;
            string vermelho = "#ff7675", amarelo = "#ffeaa7", verde = "#99e3d4", azul = "#74b9ff", cinza = "#c2c2a3";
            if (indice == "Quanto maior melhor")
            {
                if (razao >= valores[0] + valores[1] + valores[2])
                {
                    corFundo = azul;
                }
                if (razao <= valores[0] + valores[1] + valores[2])
                {
                    corFundo = verde;
                }
                if (razao <= valores[1] + valores[2])
                {
                    corFundo = amarelo;
                }
                if (razao <= valores[2])
                {
                    corFundo = vermelho;
                }
            }
            // Indice 'quanto menor melhor'
            else
            {
                if (razao >= valores[2])
                {
                    corFundo = vermelho;
                }
                if (razao <= valores[1] + valores[2])
                {
                    corFundo = amarelo;
                }
                if (razao <= valores[0] + valores[1] + valores[2])
                {
                    corFundo = verde;
                }
                if (razao <= valores[0] + valores[1] + valores[2])
                {
                    corFundo = azul;
                }
            }
            if (razao == -1)
            {
                corFundo = "#b2bec3";
            }
            return corFundo;
        }
        public String corBorda(decimal razao, string indice, List<int> valores)
        {
            string corFundo = null;
            string vermelho = "#d63031", amarelo = "#fdcb6e", verde = "#00b894", azul = "#0984e3", cinza = "#c2c2a3";
            if (indice == "Quanto maior melhor")
            {
                if (razao >= valores[0] + valores[1] + valores[2])
                {
                    corFundo = azul;
                }
                if (razao <= valores[0] + valores[1] + valores[2])
                {
                    corFundo = verde;
                }
                if (razao <= valores[1] + valores[2])
                {
                    corFundo = amarelo;
                }
                if (razao <= valores[2])
                {
                    corFundo = vermelho;
                }
            }
            // Indice 'quanto menor melhor'
            else
            {
                if (razao >= valores[2])
                {
                    corFundo = vermelho;
                }
                if (razao <= valores[1] + valores[2])
                {
                    corFundo = amarelo;
                }
                if (razao <= valores[0] + valores[1] + valores[2])
                {
                    corFundo = verde;
                }
                if (razao <= valores[0] + valores[1] + valores[2])
                {
                    corFundo = azul;
                }
            }
            if (razao == -1)
            {
                corFundo = "#636e72";
            }
            return corFundo;
        }
       
    }
}
