using System;
using System.Collections.Generic;

namespace ASPNET_Core_2_1.Models
{
    public partial class Modelo
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int? LkpPessoa { get; set; }

        public Pessoas LkpPessoaNavigation { get; set; }
    }
}
