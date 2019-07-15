using System;
using System.Collections.Generic;

namespace ASPNET_Core_2_1.Models
{
    public partial class Diagnostico
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public int? LkpPessoa { get; set; }

        public Pessoas LkpPessoaNavigation { get; set; }
    }
}
