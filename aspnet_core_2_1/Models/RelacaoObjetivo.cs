using System;
using System.Collections.Generic;

namespace ASPNET_Core_2_1.Models
{
    public partial class RelacaoObjetivo
    {
        public int Id { get; set; }
        public int? LkpObjetivo { get; set; }
        public int? LkpObjetivosRelacionados { get; set; }

        public RelacaoObjetivo IdNavigation { get; set; }
        public Objetivo LkpObjetivoNavigation { get; set; }
        public RelacaoObjetivo InverseIdNavigation { get; set; }
    }
}
