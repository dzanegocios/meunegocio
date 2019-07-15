using System;
using System.Collections.Generic;

namespace ASPNET_Core_2_1.Models
{
    public partial class Area
    {
        public Area()
        {
            Setor = new HashSet<Setor>();
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int? LkpPerfil { get; set; }

        public Pessoas LkpPerfilNavigation { get; set; }
        public ICollection<Setor> Setor { get; set; }
    }
}
