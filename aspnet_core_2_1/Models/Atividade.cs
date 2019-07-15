using System;
using System.Collections.Generic;

namespace ASPNET_Core_2_1.Models
{
    public partial class Atividade
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int? LkpCargo { get; set; }
        public byte[] Imagem { get; set; }
        public int? LkpProcessosRelacionados { get; set; }
        public int? LkpProcesso { get; set; }
        public string Obs { get; set; }
        public int? LkpPessoa { get; set; }

        public Cargo LkpCargoNavigation { get; set; }
        public Pessoas LkpPessoaNavigation { get; set; }
        public Processo LkpProcessoNavigation { get; set; }
        public AtividadeProcessoRelacionado LkpProcessosRelacionadosNavigation { get; set; }
    }
}
