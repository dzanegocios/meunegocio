using System;
using System.Collections.Generic;

namespace ASPNET_Core_2_1.Models
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
