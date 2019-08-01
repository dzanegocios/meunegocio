using System;
using System.Collections.Generic;

namespace ASPNET_Core_2_1.Models
{
    public partial class Perfil
    {
        public Perfil()
        {
            Cargo = new HashSet<Cargo>();
            PerfilPessoa = new HashSet<PerfilPessoa>();
            Pessoas = new HashSet<Pessoas>();
        }

        public int Id { get; set; }
        public short? Vermelho { get; set; }
        public short? Amarelo { get; set; }
        public short? Verde { get; set; }
        public short? Azul { get; set; }
        public short? DiasPlano { get; set; }
        public short? DiasTarefa { get; set; }
        public int? LkpPessoa { get; set; }
        public int? LkpPessoas { get; set; }

        public Pessoas LkpPessoaNavigation { get; set; }
        public PerfilPessoa LkpPessoasNavigation { get; set; }
        public ICollection<Cargo> Cargo { get; set; }
        public ICollection<PerfilPessoa> PerfilPessoa { get; set; }
        public ICollection<Pessoas> Pessoas { get; set; }

        public List<int> getValoresCor()
        {
            List<int> valores = new List<int>();
            valores.Add((int)Vermelho);
            valores.Add((int)Amarelo);
            valores.Add((int)Verde);
            valores.Add((int)Azul);
            return valores;
        }
    }
}
