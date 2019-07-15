using System;
using System.Collections.Generic;

namespace ASPNET_Core_2_1.Models
{
    public partial class Bsc
    {
        public Bsc()
        {
            Objetivo = new HashSet<Objetivo>();
            PlanoAcao = new HashSet<PlanoAcao>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public ICollection<Objetivo> Objetivo { get; set; }
        public ICollection<PlanoAcao> PlanoAcao { get; set; }
    }
}
