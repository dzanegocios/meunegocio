using System;
using System.Collections.Generic;

namespace ASPNET_Core_2_1.Models
{
    public partial class CompromissoPlanoAcao
    {
        public CompromissoPlanoAcao()
        {
            Compromisso = new HashSet<Compromisso>();
        }

        public int Id { get; set; }
        public int LkpCompromisso { get; set; }
        public int LkpPlanoAcao { get; set; }

        public Compromisso LkpCompromissoNavigation { get; set; }
        public PlanoAcao LkpPlanoAcaoNavigation { get; set; }
        public ICollection<Compromisso> Compromisso { get; set; }
    }
}
