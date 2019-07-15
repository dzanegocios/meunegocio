using System;
using System.Collections.Generic;

namespace ASPNET_Core_2_1.Models
{
    public partial class Preferencia
    {
        public int Id { get; set; }
        public int? LkpPessoa { get; set; }

        public Pessoas LkpPessoaNavigation { get; set; }
    }
}
