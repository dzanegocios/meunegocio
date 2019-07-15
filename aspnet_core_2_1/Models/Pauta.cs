using System;
using System.Collections.Generic;

namespace ASPNET_Core_2_1.Models
{
    public partial class Pauta
    {
        public Pauta()
        {
            Compromisso = new HashSet<Compromisso>();
        }

        public int Id { get; set; }
        public string Assunto { get; set; }
        public string Descricao { get; set; }
        public short? TempoDuracao { get; set; }
        public string Status { get; set; }
        public int? LkpPessoa { get; set; }
        public int? LkpCompromisso { get; set; }
        public int? LkpPlanoAcao { get; set; }
        public int? LkpResponsavel { get; set; }

        public Compromisso LkpCompromissoNavigation { get; set; }
        public Pessoas LkpPessoaNavigation { get; set; }
        public PlanoAcao LkpPlanoAcaoNavigation { get; set; }
        public Pessoas LkpResponsavelNavigation { get; set; }
        public ICollection<Compromisso> Compromisso { get; set; }
    }
}
