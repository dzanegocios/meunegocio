using System;
using System.Collections.Generic;

namespace ASPNET_Core_2_1.Models
{
    public partial class Setor
    {
        public Setor()
        {
            Cargo = new HashSet<Cargo>();
            Compromisso = new HashSet<Compromisso>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int? LkpPessoa { get; set; }
        public int? LkpArea { get; set; }

        public Area LkpAreaNavigation { get; set; }
        public ICollection<Cargo> Cargo { get; set; }
        public ICollection<Compromisso> Compromisso { get; set; }
    }
}
