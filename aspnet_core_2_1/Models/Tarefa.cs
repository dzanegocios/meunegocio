using System;
using System.Collections.Generic;

namespace ASPNET_Core_2_1.Models
{
    public partial class Tarefa
    {
        public Tarefa()
        {
            Anexo = new HashSet<Anexo>();
            PlanoAcao = new HashSet<PlanoAcao>();
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataVencimento { get; set; }
        public DateTime? DataConclusao { get; set; }
        public short? TempoDuracao { get; set; }
        public int? LkpPessoa { get; set; }
        public int? LkpResponsavel { get; set; }
        public int? LkpSolicitante { get; set; }
        public int? LkpPlanoAcao { get; set; }
        public int? LkpTarefaStatus { get; set; }
        public int? LkpTarefaStatusDetalhe { get; set; }
        public short? Gravidade { get; set; }
        public short? Urgencia { get; set; }
        public short? Tendencia { get; set; }
        public short? Total { get; set; }
        public string ParecerDescritivo { get; set; }
        public int? LkpAnexo { get; set; }

        public Anexo LkpAnexoNavigation { get; set; }
        public Pessoas LkpPessoaNavigation { get; set; }
        public PlanoAcao LkpPlanoAcaoNavigation { get; set; }
        public Pessoas LkpResponsavelNavigation { get; set; }
        public Pessoas LkpSolicitanteNavigation { get; set; }
        public TarefaStatusDetalhe LkpTarefaStatusDetalheNavigation { get; set; }
        public TarefaStatus LkpTarefaStatusNavigation { get; set; }
        public ICollection<Anexo> Anexo { get; set; }
        public ICollection<PlanoAcao> PlanoAcao { get; set; }
    }
}
