using System;
using System.Collections.Generic;

namespace ASPNET_Core_2_1.Models
{
    public partial class Pessoas
    {
        public Pessoas()
        {
            Area = new HashSet<Area>();
            Atividade = new HashSet<Atividade>();
            CompromissoLkpPessoaNavigation = new HashSet<Compromisso>();
            CompromissoLkpResponsavelNavigation = new HashSet<Compromisso>();
            CompromissoLkpSolicitanteNavigation = new HashSet<Compromisso>();
            CompromissoPessoa = new HashSet<CompromissoPessoa>();
            Diagnostico = new HashSet<Diagnostico>();
            FatoCausaAcao = new HashSet<FatoCausaAcao>();
            Feed = new HashSet<Feed>();
            Filosofia = new HashSet<Filosofia>();
            Metrica = new HashSet<Metrica>();
            Modelo = new HashSet<Modelo>();
            Objetivo = new HashSet<Objetivo>();
            ObjetivoPessoa = new HashSet<ObjetivoPessoa>();
            PautaLkpPessoaNavigation = new HashSet<Pauta>();
            PautaLkpResponsavelNavigation = new HashSet<Pauta>();
            Perfil = new HashSet<Perfil>();
            PerfilPessoa = new HashSet<PerfilPessoa>();
            PlanoAcaoLkpPessoaNavigation = new HashSet<PlanoAcao>();
            PlanoAcaoLkpResponsavelNavigation = new HashSet<PlanoAcao>();
            Preferencia = new HashSet<Preferencia>();
            Processo = new HashSet<Processo>();
            TarefaLkpPessoaNavigation = new HashSet<Tarefa>();
            TarefaLkpResponsavelNavigation = new HashSet<Tarefa>();
            TarefaLkpSolicitanteNavigation = new HashSet<Tarefa>();
        }

        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public bool? Administrador { get; set; }
        public bool? Convidado { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public int? LkpPerfil { get; set; }
        public int? LkpCargo { get; set; }

        public Cargo LkpCargoNavigation { get; set; }
        public Perfil LkpPerfilNavigation { get; set; }
        public ICollection<Area> Area { get; set; }
        public ICollection<Atividade> Atividade { get; set; }
        public ICollection<Compromisso> CompromissoLkpPessoaNavigation { get; set; }
        public ICollection<Compromisso> CompromissoLkpResponsavelNavigation { get; set; }
        public ICollection<Compromisso> CompromissoLkpSolicitanteNavigation { get; set; }
        public ICollection<CompromissoPessoa> CompromissoPessoa { get; set; }
        public ICollection<Diagnostico> Diagnostico { get; set; }
        public ICollection<FatoCausaAcao> FatoCausaAcao { get; set; }
        public ICollection<Feed> Feed { get; set; }
        public ICollection<Filosofia> Filosofia { get; set; }
        public ICollection<Metrica> Metrica { get; set; }
        public ICollection<Modelo> Modelo { get; set; }
        public ICollection<Objetivo> Objetivo { get; set; }
        public ICollection<ObjetivoPessoa> ObjetivoPessoa { get; set; }
        public ICollection<Pauta> PautaLkpPessoaNavigation { get; set; }
        public ICollection<Pauta> PautaLkpResponsavelNavigation { get; set; }
        public ICollection<Perfil> Perfil { get; set; }
        public ICollection<PerfilPessoa> PerfilPessoa { get; set; }
        public ICollection<PlanoAcao> PlanoAcaoLkpPessoaNavigation { get; set; }
        public ICollection<PlanoAcao> PlanoAcaoLkpResponsavelNavigation { get; set; }
        public ICollection<Preferencia> Preferencia { get; set; }
        public ICollection<Processo> Processo { get; set; }
        public ICollection<Tarefa> TarefaLkpPessoaNavigation { get; set; }
        public ICollection<Tarefa> TarefaLkpResponsavelNavigation { get; set; }
        public ICollection<Tarefa> TarefaLkpSolicitanteNavigation { get; set; }
    }
}
