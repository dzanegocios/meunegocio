using System;
using System.Collections.Generic;

namespace ASPNET_Core_2_1.Models
{
    public partial class Feed
    {
        public Feed()
        {
            Anexo = new HashSet<Anexo>();
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int? LkpPessoa { get; set; }
        public int? LkpAnexo { get; set; }

        public Anexo LkpAnexoNavigation { get; set; }
        public Pessoas LkpPessoaNavigation { get; set; }
        public ICollection<Anexo> Anexo { get; set; }
    }
}
