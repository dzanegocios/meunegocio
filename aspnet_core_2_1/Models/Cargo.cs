using System;
using System.Collections.Generic;

namespace ASPNET_Core_2_1.Models
{
    public partial class Cargo
    {
        public Cargo()
        {
            Atividade = new HashSet<Atividade>();
            Pessoas = new HashSet<Pessoas>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int? LkpPerfil { get; set; }
        public int? LkpSetor { get; set; }

        public Perfil LkpPerfilNavigation { get; set; }
        public Setor LkpSetorNavigation { get; set; }
        public ICollection<Atividade> Atividade { get; set; }
        public ICollection<Pessoas> Pessoas { get; set; }
    }
}
