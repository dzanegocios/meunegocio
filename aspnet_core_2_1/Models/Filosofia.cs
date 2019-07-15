using System;
using System.Collections.Generic;

namespace ASPNET_Core_2_1.Models
{
    public partial class Filosofia
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public short? Sequencia { get; set; }
        public int? LkpPessoa { get; set; }

        public Pessoas LkpPessoaNavigation { get; set; }
    }
}
