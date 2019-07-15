using System;
using System.Collections.Generic;

namespace ASPNET_Core_2_1.Models
{
    public partial class Anexo
    {
        public Anexo()
        {
            Compromisso = new HashSet<Compromisso>();
            Feed = new HashSet<Feed>();
            Tarefa = new HashSet<Tarefa>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int? LkpTarefa { get; set; }
        public int? LkpFeed { get; set; }
        public string Link { get; set; }
        public byte[] Arquivo { get; set; }

        public Feed LkpFeedNavigation { get; set; }
        public Tarefa LkpTarefaNavigation { get; set; }
        public ICollection<Compromisso> Compromisso { get; set; }
        public ICollection<Feed> Feed { get; set; }
        public ICollection<Tarefa> Tarefa { get; set; }
    }
}
