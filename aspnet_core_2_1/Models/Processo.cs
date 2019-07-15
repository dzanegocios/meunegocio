using System;
using System.Collections.Generic;

namespace ASPNET_Core_2_1.Models
{
    public partial class Processo
    {
        public Processo()
        {
            Atividade = new HashSet<Atividade>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Url { get; set; }
        public byte[] Fluxograma { get; set; }
        public int? LkpAtividade { get; set; }
        public int? LkpPessoa { get; set; }

        public AtividadeProcessoRelacionado LkpAtividadeNavigation { get; set; }
        public Pessoas LkpPessoaNavigation { get; set; }
        public ICollection<Atividade> Atividade { get; set; }
    }
}
