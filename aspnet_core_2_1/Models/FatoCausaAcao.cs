using System;
using System.Collections.Generic;

namespace ASPNET_Core_2_1.Models
{
    public partial class FatoCausaAcao
    {
        public FatoCausaAcao()
        {
            PlanoAcao = new HashSet<PlanoAcao>();
        }

        public int Id { get; set; }
        public string Fato { get; set; }
        public string Causa { get; set; }
        public string Acao { get; set; }
        public int? LkpPessoa { get; set; }
        public int? LkpPlanoAcao { get; set; }

        public Pessoas LkpPessoaNavigation { get; set; }
        public PlanoAcao LkpPlanoAcaoNavigation { get; set; }
        public ICollection<PlanoAcao> PlanoAcao { get; set; }
    }
}
