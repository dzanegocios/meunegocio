using System;
using System.Collections.Generic;

namespace ASPNET_Core_2_1.Models
{
    public partial class PlanoAcao
    {
        public PlanoAcao()
        {
            CompromissoPlanoAcao = new HashSet<CompromissoPlanoAcao>();
            FatoCausaAcao = new HashSet<FatoCausaAcao>();
            Metrica = new HashSet<Metrica>();
            Pauta = new HashSet<Pauta>();
            Tarefa = new HashSet<Tarefa>();
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataInicial { get; set; }
        public DateTime? DataFinal { get; set; }
        public string EmDia { get; set; }
        public string EmAtraso { get; set; }
        public int? LkpPessoa { get; set; }
        public int? LkpPerspectiva { get; set; }
        public int? LkpResponsavel { get; set; }
        public int? LkpObjetivo { get; set; }
        public int? LkpTarefaStatus { get; set; }
        public int? LkpStatusDetalheTarefa { get; set; }
        public int? LkpTarefa { get; set; }
        public int? LkpMetrica { get; set; }
        public int? LkpFatoCausaAcao { get; set; }

        public FatoCausaAcao LkpFatoCausaAcaoNavigation { get; set; }
        public Metrica LkpMetricaNavigation { get; set; }
        public Objetivo LkpObjetivoNavigation { get; set; }
        public Bsc LkpPerspectivaNavigation { get; set; }
        public Pessoas LkpPessoaNavigation { get; set; }
        public Pessoas LkpResponsavelNavigation { get; set; }
        public TarefaStatusDetalhe LkpStatusDetalheTarefaNavigation { get; set; }
        public Tarefa LkpTarefaNavigation { get; set; }
        public TarefaStatus LkpTarefaStatusNavigation { get; set; }
        public ICollection<CompromissoPlanoAcao> CompromissoPlanoAcao { get; set; }
        public ICollection<FatoCausaAcao> FatoCausaAcao { get; set; }
        public ICollection<Metrica> Metrica { get; set; }
        public ICollection<Pauta> Pauta { get; set; }
        public ICollection<Tarefa> Tarefa { get; set; }
    }
}
