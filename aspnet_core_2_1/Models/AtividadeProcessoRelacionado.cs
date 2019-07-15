using System;
using System.Collections.Generic;

namespace ASPNET_Core_2_1.Models
{
    public partial class AtividadeProcessoRelacionado
    {
        public AtividadeProcessoRelacionado()
        {
            Atividade = new HashSet<Atividade>();
            Processo = new HashSet<Processo>();
        }

        public int Id { get; set; }
        public int? LkpAtividade { get; set; }
        public int? LkpProcesso { get; set; }

        public ICollection<Atividade> Atividade { get; set; }
        public ICollection<Processo> Processo { get; set; }
    }
}
