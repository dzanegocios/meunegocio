using System;
using System.Collections.Generic;

namespace ASPNET_Core_2_1.Models
{
    public partial class PerfilPessoa
    {
        public PerfilPessoa()
        {
            Perfil = new HashSet<Perfil>();
        }

        public int Id { get; set; }
        public int? LkpPerfil { get; set; }
        public int? LkpPessoa { get; set; }

        public Perfil LkpPerfilNavigation { get; set; }
        public Pessoas LkpPessoaNavigation { get; set; }
        public ICollection<Perfil> Perfil { get; set; }
    }
}
