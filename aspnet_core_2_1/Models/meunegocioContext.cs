using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ASPNET_Core_2_1.Models
{
    public partial class meunegocioContext : DbContext
    {
        public meunegocioContext()
        {
        }

        public meunegocioContext(DbContextOptions<meunegocioContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Anexo> Anexo { get; set; }
        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<Atividade> Atividade { get; set; }
        public virtual DbSet<AtividadeProcessoRelacionado> AtividadeProcessoRelacionado { get; set; }
        public virtual DbSet<Bsc> Bsc { get; set; }
        public virtual DbSet<Cargo> Cargo { get; set; }
        public virtual DbSet<Compromisso> Compromisso { get; set; }
        public virtual DbSet<CompromissoPessoa> CompromissoPessoa { get; set; }
        public virtual DbSet<CompromissoPlanoAcao> CompromissoPlanoAcao { get; set; }
        public virtual DbSet<Diagnostico> Diagnostico { get; set; }
        public virtual DbSet<FatoCausaAcao> FatoCausaAcao { get; set; }
        public virtual DbSet<Feed> Feed { get; set; }
        public virtual DbSet<Filosofia> Filosofia { get; set; }
        public virtual DbSet<Metrica> Metrica { get; set; }
        public virtual DbSet<Modelo> Modelo { get; set; }
        public virtual DbSet<Objetivo> Objetivo { get; set; }
        public virtual DbSet<ObjetivoPessoa> ObjetivoPessoa { get; set; }
        public virtual DbSet<Pauta> Pauta { get; set; }
        public virtual DbSet<Perfil> Perfil { get; set; }
        public virtual DbSet<PerfilPessoa> PerfilPessoa { get; set; }
        public virtual DbSet<Pessoas> Pessoas { get; set; }
        public virtual DbSet<PlanoAcao> PlanoAcao { get; set; }
        public virtual DbSet<Preferencia> Preferencia { get; set; }
        public virtual DbSet<Processo> Processo { get; set; }
        public virtual DbSet<RelacaoObjetivo> RelacaoObjetivo { get; set; }
        public virtual DbSet<Setor> Setor { get; set; }
        public virtual DbSet<Tarefa> Tarefa { get; set; }
        public virtual DbSet<TarefaStatus> TarefaStatus { get; set; }
        public virtual DbSet<TarefaStatusDetalhe> TarefaStatusDetalhe { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=LAPTOP-CUMLKL08\\SQLEXPRESS;Database=meu-negocio;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anexo>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Arquivo).HasColumnName("arquivo");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Link)
                    .HasColumnName("link")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LkpFeed).HasColumnName("lkpFeed");

                entity.Property(e => e.LkpTarefa).HasColumnName("lkpTarefa");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.LkpFeedNavigation)
                    .WithMany(p => p.Anexo)
                    .HasForeignKey(d => d.LkpFeed)
                    .HasConstraintName("FK_Anexo_Feed");

                entity.HasOne(d => d.LkpTarefaNavigation)
                    .WithMany(p => p.Anexo)
                    .HasForeignKey(d => d.LkpTarefa)
                    .HasConstraintName("lkpTarefa");
            });

            modelBuilder.Entity<Area>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LkpPerfil).HasColumnName("lkpPerfil");

                entity.Property(e => e.Titulo)
                    .HasColumnName("titulo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.LkpPerfilNavigation)
                    .WithMany(p => p.Area)
                    .HasForeignKey(d => d.LkpPerfil)
                    .HasConstraintName("lkpPerfil");
            });

            modelBuilder.Entity<Atividade>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Imagem).HasColumnName("imagem");

                entity.Property(e => e.LkpCargo).HasColumnName("lkpCargo");

                entity.Property(e => e.LkpPessoa).HasColumnName("lkpPessoa");

                entity.Property(e => e.LkpProcesso).HasColumnName("lkpProcesso");

                entity.Property(e => e.LkpProcessosRelacionados).HasColumnName("lkpProcessosRelacionados");

                entity.Property(e => e.Obs)
                    .HasColumnName("OBS")
                    .HasColumnType("text");

                entity.HasOne(d => d.LkpCargoNavigation)
                    .WithMany(p => p.Atividade)
                    .HasForeignKey(d => d.LkpCargo)
                    .HasConstraintName("FK_Atividade_Cargo");

                entity.HasOne(d => d.LkpPessoaNavigation)
                    .WithMany(p => p.Atividade)
                    .HasForeignKey(d => d.LkpPessoa)
                    .HasConstraintName("FK_Atividade_Pessoa");

                entity.HasOne(d => d.LkpProcessoNavigation)
                    .WithMany(p => p.Atividade)
                    .HasForeignKey(d => d.LkpProcesso)
                    .HasConstraintName("FK_Atividade_Processo");

                entity.HasOne(d => d.LkpProcessosRelacionadosNavigation)
                    .WithMany(p => p.Atividade)
                    .HasForeignKey(d => d.LkpProcessosRelacionados)
                    .HasConstraintName("FK_Atividade_AtividadeProcessoRelacionado");
            });

            modelBuilder.Entity<AtividadeProcessoRelacionado>(entity =>
            {
                entity.ToTable("Atividade_ProcessoRelacionado");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.LkpAtividade).HasColumnName("lkpAtividade");

                entity.Property(e => e.LkpProcesso).HasColumnName("lkpProcesso");
            });

            modelBuilder.Entity<Bsc>(entity =>
            {
                entity.ToTable("BSC");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cargo>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LkpPerfil).HasColumnName("lkpPerfil");

                entity.Property(e => e.LkpSetor).HasColumnName("lkpSetor");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.LkpPerfilNavigation)
                    .WithMany(p => p.Cargo)
                    .HasForeignKey(d => d.LkpPerfil)
                    .HasConstraintName("FK_Cargo_Perfil");

                entity.HasOne(d => d.LkpSetorNavigation)
                    .WithMany(p => p.Cargo)
                    .HasForeignKey(d => d.LkpSetor)
                    .HasConstraintName("FK_Cargo_Setor");
            });

            modelBuilder.Entity<Compromisso>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Anexar).HasColumnName("anexar");

                entity.Property(e => e.DataExpiracao)
                    .HasColumnName("dataExpiracao")
                    .HasColumnType("date");

                entity.Property(e => e.DataFim)
                    .HasColumnName("dataFim")
                    .HasColumnType("datetime");

                entity.Property(e => e.DataInicio)
                    .HasColumnName("dataInicio")
                    .HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasColumnType("text");

                entity.Property(e => e.DiasSemana)
                    .HasColumnName("diasSemana")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.ExpiraSelecao)
                    .HasColumnName("expiraSelecao")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LkpAnexo).HasColumnName("lkpAnexo");

                entity.Property(e => e.LkpCompromisso).HasColumnName("lkpCompromisso");

                entity.Property(e => e.LkpEnvolvidos).HasColumnName("lkpEnvolvidos");

                entity.Property(e => e.LkpPauta).HasColumnName("lkpPauta");

                entity.Property(e => e.LkpPessoa).HasColumnName("lkpPessoa");

                entity.Property(e => e.LkpPlanoAcao).HasColumnName("lkpPlanoAcao");

                entity.Property(e => e.LkpResponsavel).HasColumnName("lkpResponsavel");

                entity.Property(e => e.LkpSetor).HasColumnName("lkpSetor");

                entity.Property(e => e.LkpSolicitante).HasColumnName("lkpSolicitante");

                entity.Property(e => e.NumeroOcorrencia).HasColumnName("numeroOcorrencia");

                entity.Property(e => e.OpcaoDataMensal)
                    .HasColumnName("opcaoDataMensal")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Periodicidade)
                    .HasColumnName("periodicidade")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Repetir).HasColumnName("repetir");

                entity.Property(e => e.RepetirTarefa).HasColumnName("repetirTarefa");

                entity.Property(e => e.Titulo)
                    .HasColumnName("titulo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.LkpAnexoNavigation)
                    .WithMany(p => p.Compromisso)
                    .HasForeignKey(d => d.LkpAnexo)
                    .HasConstraintName("FK_Compromisso_Anexo");

                entity.HasOne(d => d.LkpCompromissoNavigation)
                    .WithMany(p => p.InverseLkpCompromissoNavigation)
                    .HasForeignKey(d => d.LkpCompromisso)
                    .HasConstraintName("FK_Compromisso_Compromisso");

                entity.HasOne(d => d.LkpEnvolvidosNavigation)
                    .WithMany(p => p.Compromisso)
                    .HasForeignKey(d => d.LkpEnvolvidos)
                    .HasConstraintName("FK_CompromissoPessoa_Envolvidos");

                entity.HasOne(d => d.LkpPautaNavigation)
                    .WithMany(p => p.Compromisso)
                    .HasForeignKey(d => d.LkpPauta)
                    .HasConstraintName("FK_Compromisso_Pauta");

                entity.HasOne(d => d.LkpPessoaNavigation)
                    .WithMany(p => p.CompromissoLkpPessoaNavigation)
                    .HasForeignKey(d => d.LkpPessoa)
                    .HasConstraintName("FK_Compromisso_Pessoa");

                entity.HasOne(d => d.LkpPlanoAcaoNavigation)
                    .WithMany(p => p.Compromisso)
                    .HasForeignKey(d => d.LkpPlanoAcao)
                    .HasConstraintName("FK_Compromisso_CompromissoPlanoAcao");

                entity.HasOne(d => d.LkpResponsavelNavigation)
                    .WithMany(p => p.CompromissoLkpResponsavelNavigation)
                    .HasForeignKey(d => d.LkpResponsavel)
                    .HasConstraintName("FK_Compromisso_Responsavel");

                entity.HasOne(d => d.LkpSetorNavigation)
                    .WithMany(p => p.Compromisso)
                    .HasForeignKey(d => d.LkpSetor)
                    .HasConstraintName("FK_Compromisso_Setor");

                entity.HasOne(d => d.LkpSolicitanteNavigation)
                    .WithMany(p => p.CompromissoLkpSolicitanteNavigation)
                    .HasForeignKey(d => d.LkpSolicitante)
                    .HasConstraintName("FK_Compromisso_Solicitante");
            });

            modelBuilder.Entity<CompromissoPessoa>(entity =>
            {
                entity.ToTable("Compromisso_Pessoa");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LkpCompromisso).HasColumnName("lkpCompromisso");

                entity.Property(e => e.LkpPessoa).HasColumnName("lkpPessoa");

                entity.HasOne(d => d.LkpCompromissoNavigation)
                    .WithMany(p => p.CompromissoPessoa)
                    .HasForeignKey(d => d.LkpCompromisso)
                    .HasConstraintName("FK_CompromissoPessoa_Compromisso");

                entity.HasOne(d => d.LkpPessoaNavigation)
                    .WithMany(p => p.CompromissoPessoa)
                    .HasForeignKey(d => d.LkpPessoa)
                    .HasConstraintName("FK_CompromissoPessoa_Pessoa");
            });

            modelBuilder.Entity<CompromissoPlanoAcao>(entity =>
            {
                entity.ToTable("Compromisso_PlanoAcao");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LkpCompromisso).HasColumnName("lkpCompromisso");

                entity.Property(e => e.LkpPlanoAcao).HasColumnName("lkpPlanoAcao");

                entity.HasOne(d => d.LkpCompromissoNavigation)
                    .WithMany(p => p.CompromissoPlanoAcao)
                    .HasForeignKey(d => d.LkpCompromisso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Compromisso_Compromisso_PlanoAcao");

                entity.HasOne(d => d.LkpPlanoAcaoNavigation)
                    .WithMany(p => p.CompromissoPlanoAcao)
                    .HasForeignKey(d => d.LkpPlanoAcao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Compromisso_PlanoAcao_PlanoAcao");
            });

            modelBuilder.Entity<Diagnostico>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Categoria)
                    .HasColumnName("categoria")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasColumnType("text");

                entity.Property(e => e.LkpPessoa).HasColumnName("lkpPessoa");

                entity.HasOne(d => d.LkpPessoaNavigation)
                    .WithMany(p => p.Diagnostico)
                    .HasForeignKey(d => d.LkpPessoa)
                    .HasConstraintName("FK_Diagnostico_Pessoa");
            });

            modelBuilder.Entity<FatoCausaAcao>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Acao)
                    .HasColumnName("acao")
                    .HasColumnType("text");

                entity.Property(e => e.Causa)
                    .HasColumnName("causa")
                    .HasColumnType("text");

                entity.Property(e => e.Fato)
                    .HasColumnName("fato")
                    .HasColumnType("text");

                entity.Property(e => e.LkpPessoa).HasColumnName("lkpPessoa");

                entity.Property(e => e.LkpPlanoAcao).HasColumnName("lkpPlanoAcao");

                entity.HasOne(d => d.LkpPessoaNavigation)
                    .WithMany(p => p.FatoCausaAcao)
                    .HasForeignKey(d => d.LkpPessoa)
                    .HasConstraintName("FK_FatoCausaAcao_Pessoa");

                entity.HasOne(d => d.LkpPlanoAcaoNavigation)
                    .WithMany(p => p.FatoCausaAcao)
                    .HasForeignKey(d => d.LkpPlanoAcao)
                    .HasConstraintName("FK_FatoCausaAcao_PlanoAcao");
            });

            modelBuilder.Entity<Feed>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasColumnType("text");

                entity.Property(e => e.LkpAnexo).HasColumnName("lkpAnexo");

                entity.Property(e => e.LkpPessoa).HasColumnName("lkpPessoa");

                entity.Property(e => e.Titulo)
                    .HasColumnName("titulo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.LkpAnexoNavigation)
                    .WithMany(p => p.Feed)
                    .HasForeignKey(d => d.LkpAnexo)
                    .HasConstraintName("FK_Feed_Anexo");

                entity.HasOne(d => d.LkpPessoaNavigation)
                    .WithMany(p => p.Feed)
                    .HasForeignKey(d => d.LkpPessoa)
                    .HasConstraintName("FK_Feed_Pessoa");
            });

            modelBuilder.Entity<Filosofia>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Categoria)
                    .HasColumnName("categoria")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasColumnType("text");

                entity.Property(e => e.LkpPessoa).HasColumnName("lkpPessoa");

                entity.Property(e => e.Sequencia).HasColumnName("sequencia");

                entity.Property(e => e.Titulo)
                    .HasColumnName("titulo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.LkpPessoaNavigation)
                    .WithMany(p => p.Filosofia)
                    .HasForeignKey(d => d.LkpPessoa)
                    .HasConstraintName("FK_Filosofia_Pessoa");
            });

            modelBuilder.Entity<Metrica>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("date");

                entity.Property(e => e.Executado)
                    .HasColumnName("executado")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Indice)
                    .HasColumnName("indice")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LkpMetrica).HasColumnName("lkpMetrica");

                entity.Property(e => e.LkpObjetivo).HasColumnName("lkpObjetivo");

                entity.Property(e => e.LkpPessoa).HasColumnName("lkpPessoa");

                entity.Property(e => e.LkpPlanoAcao).HasColumnName("lkpPlanoAcao");

                entity.Property(e => e.LkpStatusDetalheTarefa).HasColumnName("lkpStatusDetalheTarefa");

                entity.Property(e => e.LkpTarefaStatus).HasColumnName("lkpTarefaStatus");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ParecerDescritivo)
                    .HasColumnName("parecerDescritivo")
                    .HasColumnType("text");

                entity.Property(e => e.Peso).HasColumnName("peso");

                entity.Property(e => e.Planejado)
                    .HasColumnName("planejado")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Razao)
                    .HasColumnName("razao")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Template).HasColumnName("template");

                entity.Property(e => e.Unidade)
                    .HasColumnName("unidade")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.LkpMetricaNavigation)
                    .WithMany(p => p.InverseLkpMetricaNavigation)
                    .HasForeignKey(d => d.LkpMetrica)
                    .HasConstraintName("FK_Metrica_Metrica");

                entity.HasOne(d => d.LkpObjetivoNavigation)
                    .WithMany(p => p.Metrica)
                    .HasForeignKey(d => d.LkpObjetivo)
                    .HasConstraintName("FK_Metrica_Objetivo");

                entity.HasOne(d => d.LkpPessoaNavigation)
                    .WithMany(p => p.Metrica)
                    .HasForeignKey(d => d.LkpPessoa)
                    .HasConstraintName("FK_Metrica_Pessoa");

                entity.HasOne(d => d.LkpPlanoAcaoNavigation)
                    .WithMany(p => p.Metrica)
                    .HasForeignKey(d => d.LkpPlanoAcao)
                    .HasConstraintName("FK_Metrica_PlanoAcao");

                entity.HasOne(d => d.LkpStatusDetalheTarefaNavigation)
                    .WithMany(p => p.Metrica)
                    .HasForeignKey(d => d.LkpStatusDetalheTarefa)
                    .HasConstraintName("FK_Metrica_TarefaStatusDetalhe");

                entity.HasOne(d => d.LkpTarefaStatusNavigation)
                    .WithMany(p => p.Metrica)
                    .HasForeignKey(d => d.LkpTarefaStatus)
                    .HasConstraintName("FK_Metrica_TarefaStatus");
            });

            modelBuilder.Entity<Modelo>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasColumnType("text");

                entity.Property(e => e.LkpPessoa).HasColumnName("lkpPessoa");

                entity.Property(e => e.Titulo)
                    .HasColumnName("titulo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.LkpPessoaNavigation)
                    .WithMany(p => p.Modelo)
                    .HasForeignKey(d => d.LkpPessoa)
                    .HasConstraintName("FK_Modelo_Pessoa");
            });

            modelBuilder.Entity<Objetivo>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DataInicio)
                    .HasColumnName("dataInicio")
                    .HasColumnType("date");

                entity.Property(e => e.DataTermino)
                    .HasColumnName("dataTermino")
                    .HasColumnType("date");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Imagem).HasColumnName("imagem");

                entity.Property(e => e.LkpMetrica).HasColumnName("lkpMetrica");

                entity.Property(e => e.LkpPerspectiva).HasColumnName("lkpPerspectiva");

                entity.Property(e => e.LkpPessoa).HasColumnName("lkpPessoa");

                entity.Property(e => e.LkpResponsavel).HasColumnName("lkpResponsavel");

                entity.Property(e => e.Nivel)
                    .HasColumnName("nivel")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.LkpMetricaNavigation)
                    .WithMany(p => p.Objetivo)
                    .HasForeignKey(d => d.LkpMetrica)
                    .HasConstraintName("FK_Objetivo_Metrica");

                entity.HasOne(d => d.LkpPerspectivaNavigation)
                    .WithMany(p => p.Objetivo)
                    .HasForeignKey(d => d.LkpPerspectiva)
                    .HasConstraintName("FK_Objetivo_BSC");

                entity.HasOne(d => d.LkpPessoaNavigation)
                    .WithMany(p => p.Objetivo)
                    .HasForeignKey(d => d.LkpPessoa)
                    .HasConstraintName("FK_Objetivo_Pessoa");

                entity.HasOne(d => d.LkpResponsavelNavigation)
                    .WithMany(p => p.Objetivo)
                    .HasForeignKey(d => d.LkpResponsavel)
                    .HasConstraintName("FK_Objetivo_ObjetivoPessoa");
            });

            modelBuilder.Entity<ObjetivoPessoa>(entity =>
            {
                entity.ToTable("Objetivo_Pessoa");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LkpObjetivo).HasColumnName("lkpObjetivo");

                entity.Property(e => e.LkpPessoa).HasColumnName("lkpPessoa");

                entity.HasOne(d => d.LkpObjetivoNavigation)
                    .WithMany(p => p.ObjetivoPessoa)
                    .HasForeignKey(d => d.LkpObjetivo)
                    .HasConstraintName("FK_ObjetivoPessoa_Objetivo");

                entity.HasOne(d => d.LkpPessoaNavigation)
                    .WithMany(p => p.ObjetivoPessoa)
                    .HasForeignKey(d => d.LkpPessoa)
                    .HasConstraintName("FK_ObjetivoPessoa_Pessoa");
            });

            modelBuilder.Entity<Pauta>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Assunto)
                    .HasColumnName("assunto")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasColumnType("text");

                entity.Property(e => e.LkpCompromisso).HasColumnName("lkpCompromisso");

                entity.Property(e => e.LkpPessoa).HasColumnName("lkpPessoa");

                entity.Property(e => e.LkpPlanoAcao).HasColumnName("lkpPlanoAcao");

                entity.Property(e => e.LkpResponsavel).HasColumnName("lkpResponsavel");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.TempoDuracao).HasColumnName("tempoDuracao");

                entity.HasOne(d => d.LkpCompromissoNavigation)
                    .WithMany(p => p.Pauta)
                    .HasForeignKey(d => d.LkpCompromisso)
                    .HasConstraintName("FK_Pauta_Compromisso");

                entity.HasOne(d => d.LkpPessoaNavigation)
                    .WithMany(p => p.PautaLkpPessoaNavigation)
                    .HasForeignKey(d => d.LkpPessoa)
                    .HasConstraintName("FK_Pauta_Pessoa");

                entity.HasOne(d => d.LkpPlanoAcaoNavigation)
                    .WithMany(p => p.Pauta)
                    .HasForeignKey(d => d.LkpPlanoAcao)
                    .HasConstraintName("FK_Pauta_PlanoAcao");

                entity.HasOne(d => d.LkpResponsavelNavigation)
                    .WithMany(p => p.PautaLkpResponsavelNavigation)
                    .HasForeignKey(d => d.LkpResponsavel)
                    .HasConstraintName("FK_Pauta_Responsavel");
            });

            modelBuilder.Entity<Perfil>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Amarelo).HasColumnName("amarelo");

                entity.Property(e => e.Azul).HasColumnName("azul");

                entity.Property(e => e.DiasPlano).HasColumnName("diasPlano");

                entity.Property(e => e.DiasTarefa).HasColumnName("diasTarefa");

                entity.Property(e => e.LkpPessoa).HasColumnName("lkpPessoa");

                entity.Property(e => e.LkpPessoas).HasColumnName("lkpPessoas");

                entity.Property(e => e.Verde).HasColumnName("verde");

                entity.Property(e => e.Vermelho).HasColumnName("vermelho");

                entity.HasOne(d => d.LkpPessoaNavigation)
                    .WithMany(p => p.Perfil)
                    .HasForeignKey(d => d.LkpPessoa)
                    .HasConstraintName("FK_Perfil_Pessoa");

                entity.HasOne(d => d.LkpPessoasNavigation)
                    .WithMany(p => p.Perfil)
                    .HasForeignKey(d => d.LkpPessoas)
                    .HasConstraintName("FK_Perfil_PerfilPessoa");
            });

            modelBuilder.Entity<PerfilPessoa>(entity =>
            {
                entity.ToTable("Perfil_Pessoa");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LkpPerfil).HasColumnName("lkpPerfil");

                entity.Property(e => e.LkpPessoa).HasColumnName("lkpPessoa");

                entity.HasOne(d => d.LkpPerfilNavigation)
                    .WithMany(p => p.PerfilPessoa)
                    .HasForeignKey(d => d.LkpPerfil)
                    .HasConstraintName("FK_PerfilPessoa_Perfil");

                entity.HasOne(d => d.LkpPessoaNavigation)
                    .WithMany(p => p.PerfilPessoa)
                    .HasForeignKey(d => d.LkpPessoa)
                    .HasConstraintName("FK_PerfilPessoa_Pessoa");
            });

            modelBuilder.Entity<Pessoas>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Administrador).HasColumnName("administrador");

                entity.Property(e => e.Convidado).HasColumnName("convidado");

                entity.Property(e => e.Cpf)
                    .HasColumnName("cpf")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.LkpCargo).HasColumnName("lkpCargo");

                entity.Property(e => e.LkpPerfil).HasColumnName("lkpPerfil");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sobrenome)
                    .HasColumnName("sobrenome")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .HasColumnName("telefone")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .HasColumnName("tipo")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.LkpCargoNavigation)
                    .WithMany(p => p.Pessoas)
                    .HasForeignKey(d => d.LkpCargo)
                    .HasConstraintName("FK_Pessoas_Cargo");

                entity.HasOne(d => d.LkpPerfilNavigation)
                    .WithMany(p => p.Pessoas)
                    .HasForeignKey(d => d.LkpPerfil)
                    .HasConstraintName("FK_Pessoas_Perfil");
            });

            modelBuilder.Entity<PlanoAcao>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DataFinal)
                    .HasColumnName("dataFinal")
                    .HasColumnType("date");

                entity.Property(e => e.DataInicial)
                    .HasColumnName("dataInicial")
                    .HasColumnType("date");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasColumnType("text");

                entity.Property(e => e.EmAtraso)
                    .HasColumnName("emAtraso")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmDia)
                    .HasColumnName("emDia")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LkpFatoCausaAcao).HasColumnName("lkpFatoCausaAcao");

                entity.Property(e => e.LkpMetrica).HasColumnName("lkpMetrica");

                entity.Property(e => e.LkpObjetivo).HasColumnName("lkpObjetivo");

                entity.Property(e => e.LkpPerspectiva).HasColumnName("lkpPerspectiva");

                entity.Property(e => e.LkpPessoa).HasColumnName("lkpPessoa");

                entity.Property(e => e.LkpResponsavel).HasColumnName("lkpResponsavel");

                entity.Property(e => e.LkpStatusDetalheTarefa).HasColumnName("lkpStatusDetalheTarefa");

                entity.Property(e => e.LkpTarefa).HasColumnName("lkpTarefa");

                entity.Property(e => e.LkpTarefaStatus).HasColumnName("lkpTarefaStatus");

                entity.Property(e => e.Titulo)
                    .HasColumnName("titulo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.LkpFatoCausaAcaoNavigation)
                    .WithMany(p => p.PlanoAcao)
                    .HasForeignKey(d => d.LkpFatoCausaAcao)
                    .HasConstraintName("FK_PlanoAcao_FatoCausaAcao");

                entity.HasOne(d => d.LkpMetricaNavigation)
                    .WithMany(p => p.PlanoAcao)
                    .HasForeignKey(d => d.LkpMetrica)
                    .HasConstraintName("FK_PlanoAcao_Metrica");

                entity.HasOne(d => d.LkpObjetivoNavigation)
                    .WithMany(p => p.PlanoAcao)
                    .HasForeignKey(d => d.LkpObjetivo)
                    .HasConstraintName("FK_PlanoAcao_Objetivo");

                entity.HasOne(d => d.LkpPerspectivaNavigation)
                    .WithMany(p => p.PlanoAcao)
                    .HasForeignKey(d => d.LkpPerspectiva)
                    .HasConstraintName("FK_PlanoAcao_BSC");

                entity.HasOne(d => d.LkpPessoaNavigation)
                    .WithMany(p => p.PlanoAcaoLkpPessoaNavigation)
                    .HasForeignKey(d => d.LkpPessoa)
                    .HasConstraintName("FK_PlanoAcao_Pessoa");

                entity.HasOne(d => d.LkpResponsavelNavigation)
                    .WithMany(p => p.PlanoAcaoLkpResponsavelNavigation)
                    .HasForeignKey(d => d.LkpResponsavel)
                    .HasConstraintName("FK_PlanoAcao_Responsavel");

                entity.HasOne(d => d.LkpStatusDetalheTarefaNavigation)
                    .WithMany(p => p.PlanoAcao)
                    .HasForeignKey(d => d.LkpStatusDetalheTarefa)
                    .HasConstraintName("FK_PlanoAcao_TarefaStatusDetalhe");

                entity.HasOne(d => d.LkpTarefaNavigation)
                    .WithMany(p => p.PlanoAcao)
                    .HasForeignKey(d => d.LkpTarefa)
                    .HasConstraintName("FK_PlanoAcao_Tarefa");

                entity.HasOne(d => d.LkpTarefaStatusNavigation)
                    .WithMany(p => p.PlanoAcao)
                    .HasForeignKey(d => d.LkpTarefaStatus)
                    .HasConstraintName("FK_PlanoAcao_TarefaStatus");
            });

            modelBuilder.Entity<Preferencia>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LkpPessoa).HasColumnName("lkpPessoa");

                entity.HasOne(d => d.LkpPessoaNavigation)
                    .WithMany(p => p.Preferencia)
                    .HasForeignKey(d => d.LkpPessoa)
                    .HasConstraintName("FK_Preferencia_Pessoa");
            });

            modelBuilder.Entity<Processo>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasColumnType("text");

                entity.Property(e => e.Fluxograma).HasColumnName("fluxograma");

                entity.Property(e => e.LkpAtividade).HasColumnName("lkpAtividade");

                entity.Property(e => e.LkpPessoa).HasColumnName("lkpPessoa");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.HasOne(d => d.LkpAtividadeNavigation)
                    .WithMany(p => p.Processo)
                    .HasForeignKey(d => d.LkpAtividade)
                    .HasConstraintName("FK_Processo_AtividadeProcessoRelacionado");

                entity.HasOne(d => d.LkpPessoaNavigation)
                    .WithMany(p => p.Processo)
                    .HasForeignKey(d => d.LkpPessoa)
                    .HasConstraintName("FK_Processo_Pessoa");
            });

            modelBuilder.Entity<RelacaoObjetivo>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.LkpObjetivo).HasColumnName("lkpObjetivo");

                entity.Property(e => e.LkpObjetivosRelacionados).HasColumnName("lkpObjetivosRelacionados");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.InverseIdNavigation)
                    .HasForeignKey<RelacaoObjetivo>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RelacaoObjetivo_RelacaoObjetivo");

                entity.HasOne(d => d.LkpObjetivoNavigation)
                    .WithMany(p => p.RelacaoObjetivo)
                    .HasForeignKey(d => d.LkpObjetivo)
                    .HasConstraintName("FK_RelacaoObjetivo_ObjetivoPrincipal");
            });

            modelBuilder.Entity<Setor>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LkpArea).HasColumnName("lkpArea");

                entity.Property(e => e.LkpPessoa).HasColumnName("lkpPessoa");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.LkpAreaNavigation)
                    .WithMany(p => p.Setor)
                    .HasForeignKey(d => d.LkpArea)
                    .HasConstraintName("FK_Setor_Area");
            });

            modelBuilder.Entity<Tarefa>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DataConclusao)
                    .HasColumnName("dataConclusao")
                    .HasColumnType("datetime");

                entity.Property(e => e.DataVencimento)
                    .HasColumnName("dataVencimento")
                    .HasColumnType("date");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasColumnType("text");

                entity.Property(e => e.Gravidade).HasColumnName("gravidade");

                entity.Property(e => e.LkpAnexo).HasColumnName("lkpAnexo");

                entity.Property(e => e.LkpPessoa).HasColumnName("lkpPessoa");

                entity.Property(e => e.LkpPlanoAcao).HasColumnName("lkpPlanoAcao");

                entity.Property(e => e.LkpResponsavel).HasColumnName("lkpResponsavel");

                entity.Property(e => e.LkpSolicitante).HasColumnName("lkpSolicitante");

                entity.Property(e => e.LkpTarefaStatus).HasColumnName("lkpTarefaStatus");

                entity.Property(e => e.LkpTarefaStatusDetalhe).HasColumnName("lkpTarefaStatusDetalhe");

                entity.Property(e => e.ParecerDescritivo)
                    .HasColumnName("parecerDescritivo")
                    .HasColumnType("text");

                entity.Property(e => e.TempoDuracao).HasColumnName("tempoDuracao");

                entity.Property(e => e.Tendencia).HasColumnName("tendencia");

                entity.Property(e => e.Titulo)
                    .HasColumnName("titulo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Total).HasColumnName("total");

                entity.Property(e => e.Urgencia).HasColumnName("urgencia");

                entity.HasOne(d => d.LkpAnexoNavigation)
                    .WithMany(p => p.Tarefa)
                    .HasForeignKey(d => d.LkpAnexo)
                    .HasConstraintName("FK_Tarefa_Anexo");

                entity.HasOne(d => d.LkpPessoaNavigation)
                    .WithMany(p => p.TarefaLkpPessoaNavigation)
                    .HasForeignKey(d => d.LkpPessoa)
                    .HasConstraintName("FK_Tarefa_Pessoa");

                entity.HasOne(d => d.LkpPlanoAcaoNavigation)
                    .WithMany(p => p.Tarefa)
                    .HasForeignKey(d => d.LkpPlanoAcao)
                    .HasConstraintName("FK_Tarefa_PlanoAcao");

                entity.HasOne(d => d.LkpResponsavelNavigation)
                    .WithMany(p => p.TarefaLkpResponsavelNavigation)
                    .HasForeignKey(d => d.LkpResponsavel)
                    .HasConstraintName("FK_Tarefa_Responsavel");

                entity.HasOne(d => d.LkpSolicitanteNavigation)
                    .WithMany(p => p.TarefaLkpSolicitanteNavigation)
                    .HasForeignKey(d => d.LkpSolicitante)
                    .HasConstraintName("FK_Tarefa_Solicitante");

                entity.HasOne(d => d.LkpTarefaStatusNavigation)
                    .WithMany(p => p.Tarefa)
                    .HasForeignKey(d => d.LkpTarefaStatus)
                    .HasConstraintName("FK_Tarefa_TarefaStatus");

                entity.HasOne(d => d.LkpTarefaStatusDetalheNavigation)
                    .WithMany(p => p.Tarefa)
                    .HasForeignKey(d => d.LkpTarefaStatusDetalhe)
                    .HasConstraintName("FK_Tarefa_TarefaStatusDetalhe");
            });

            modelBuilder.Entity<TarefaStatus>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TarefaStatusDetalhe>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .HasColumnName("senha")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
        }
    }
}
