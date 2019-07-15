using System;
using System.Collections.Generic;

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
        public decimal? Executado { get; set; }
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
    }
}
