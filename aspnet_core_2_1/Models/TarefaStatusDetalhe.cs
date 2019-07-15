using System;
using System.Collections.Generic;

namespace ASPNET_Core_2_1.Models
{
    public partial class TarefaStatusDetalhe
    {
        public TarefaStatusDetalhe()
        {
            Metrica = new HashSet<Metrica>();
            PlanoAcao = new HashSet<PlanoAcao>();
            Tarefa = new HashSet<Tarefa>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; }

        public ICollection<Metrica> Metrica { get; set; }
        public ICollection<PlanoAcao> PlanoAcao { get; set; }
        public ICollection<Tarefa> Tarefa { get; set; }
    }
}
