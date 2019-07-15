using System;
using System.Collections.Generic;

namespace ASPNET_Core_2_1.Models
{
    public partial class CompromissoPessoa
    {
        public CompromissoPessoa()
        {
            Compromisso = new HashSet<Compromisso>();
        }

        public int Id { get; set; }
        public int? LkpCompromisso { get; set; }
        public int? LkpPessoa { get; set; }

        public Compromisso LkpCompromissoNavigation { get; set; }
        public Pessoas LkpPessoaNavigation { get; set; }
        public ICollection<Compromisso> Compromisso { get; set; }
    }
}
