using System;
using System.Collections.Generic;

namespace ASPNET_Core_2_1.Models
{
    public partial class ObjetivoPessoa
    {
        public ObjetivoPessoa()
        {
            Objetivo = new HashSet<Objetivo>();
        }

        public int Id { get; set; }
        public int? LkpObjetivo { get; set; }
        public int? LkpPessoa { get; set; }

        public Objetivo LkpObjetivoNavigation { get; set; }
        public Pessoas LkpPessoaNavigation { get; set; }
        public ICollection<Objetivo> Objetivo { get; set; }
    }
}
