using System;
using System.Collections.Generic;

namespace ASPNET_Core_2_1.Models
{
    public partial class Compromisso
    {
        public Compromisso()
        {
            CompromissoPessoa = new HashSet<CompromissoPessoa>();
            CompromissoPlanoAcao = new HashSet<CompromissoPlanoAcao>();
            InverseLkpCompromissoNavigation = new HashSet<Compromisso>();
            Pauta = new HashSet<Pauta>();
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public bool? Repetir { get; set; }
        public string Periodicidade { get; set; }
        public string OpcaoDataMensal { get; set; }
        public string ExpiraSelecao { get; set; }
        public DateTime? DataExpiracao { get; set; }
        public short? RepetirTarefa { get; set; }
        public short? NumeroOcorrencia { get; set; }
        public string DiasSemana { get; set; }
        public bool Anexar { get; set; }
        public int? LkpCompromisso { get; set; }
        public int? LkpResponsavel { get; set; }
        public int? LkpSolicitante { get; set; }
        public int? LkpPlanoAcao { get; set; }
        public int? LkpEnvolvidos { get; set; }
        public int? LkpSetor { get; set; }
        public int? LkpPauta { get; set; }
        public int? LkpAnexo { get; set; }
        public int? LkpPessoa { get; set; }

        public Anexo LkpAnexoNavigation { get; set; }
        public Compromisso LkpCompromissoNavigation { get; set; }
        public CompromissoPessoa LkpEnvolvidosNavigation { get; set; }
        public Pauta LkpPautaNavigation { get; set; }
        public Pessoas LkpPessoaNavigation { get; set; }
        public CompromissoPlanoAcao LkpPlanoAcaoNavigation { get; set; }
        public Pessoas LkpResponsavelNavigation { get; set; }
        public Setor LkpSetorNavigation { get; set; }
        public Pessoas LkpSolicitanteNavigation { get; set; }
        public ICollection<CompromissoPessoa> CompromissoPessoa { get; set; }
        public ICollection<CompromissoPlanoAcao> CompromissoPlanoAcao { get; set; }
        public ICollection<Compromisso> InverseLkpCompromissoNavigation { get; set; }
        public ICollection<Pauta> Pauta { get; set; }
    }
}
