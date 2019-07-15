using System;
using System.Collections.Generic;

namespace ASPNET_Core_2_1.Models
{
    public partial class Objetivo
    {
        public Objetivo()
        {
            Metrica = new HashSet<Metrica>();
            ObjetivoPessoa = new HashSet<ObjetivoPessoa>();
            PlanoAcao = new HashSet<PlanoAcao>();
            RelacaoObjetivo = new HashSet<RelacaoObjetivo>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Nivel { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataTermino { get; set; }
        public byte[] Imagem { get; set; }
        public int? LkpPessoa { get; set; }
        public int? LkpResponsavel { get; set; }
        public int? LkpMetrica { get; set; }
        public int? LkpPerspectiva { get; set; }

        public Metrica LkpMetricaNavigation { get; set; }
        public Bsc LkpPerspectivaNavigation { get; set; }
        public Pessoas LkpPessoaNavigation { get; set; }
        public ObjetivoPessoa LkpResponsavelNavigation { get; set; }
        public ICollection<Metrica> Metrica { get; set; }
        public ICollection<ObjetivoPessoa> ObjetivoPessoa { get; set; }
        public ICollection<PlanoAcao> PlanoAcao { get; set; }
        public ICollection<RelacaoObjetivo> RelacaoObjetivo { get; set; }
    }
}
