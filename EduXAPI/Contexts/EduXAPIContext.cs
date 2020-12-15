using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using EduXAPI.Domains;

namespace EduXAPI.Contexts
{
    public partial class EduXAPIContext : DbContext
    {
        public EduXAPIContext()
        {
        }

        public EduXAPIContext(DbContextOptions<EduXAPIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AlunoTurmas> AlunoTurmas { get; set; }
        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<Cursos> Cursos { get; set; }
        public virtual DbSet<Curtidas> Curtidas { get; set; }
        public virtual DbSet<Dicas> Dicas { get; set; }
        public virtual DbSet<Instituicoes> Instituicoes { get; set; }
        public virtual DbSet<ObjetivoAlunos> ObjetivoAlunos { get; set; }
        public virtual DbSet<Objetivos> Objetivos { get; set; }
        public virtual DbSet<Perfis> Perfis { get; set; }
        public virtual DbSet<ProfessorTurmas> ProfessorTurmas { get; set; }
        public virtual DbSet<Turmas> Turmas { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                  optionsBuilder.UseSqlServer("Data Source=LAPTOP-HJTFSJFK\\SQLEXPRESS;Initial Catalog=EduX;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlunoTurmas>(entity =>
            {
                entity.HasKey(e => e.IdAlunoTurma)
                    .HasName("PK__AlunoTur__8F3223BD2287EEB7");

                entity.Property(e => e.IdAlunoTurma).ValueGeneratedNever();

                entity.Property(e => e.Matricula)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTurmaNavigation)
                    .WithMany(p => p.AlunoTurmas)
                    .HasForeignKey(d => d.IdTurma)
                    .HasConstraintName("FK__AlunoTurm__IdTur__4F7CD00D");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.AlunoTurmas)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__AlunoTurm__IdUsu__4E88ABD4");
            });

            modelBuilder.Entity<Categorias>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__Categori__A3C02A10033D7C94");

                entity.Property(e => e.IdCategoria).ValueGeneratedNever();

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cursos>(entity =>
            {
                entity.HasKey(e => e.IdCurso)
                    .HasName("PK__Cursos__085F27D6BC24EBCE");

                entity.Property(e => e.IdCurso).ValueGeneratedNever();

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdInstituicaoNavigation)
                    .WithMany(p => p.Cursos)
                    .HasForeignKey(d => d.IdInstituicao)
                    .HasConstraintName("FK__Cursos__IdInstit__3C69FB99");
            });

            modelBuilder.Entity<Curtidas>(entity =>
            {
                entity.HasKey(e => e.IdCurtida)
                    .HasName("PK__Curtidas__2169583AE3F4B4E8");

                entity.Property(e => e.IdCurtida).ValueGeneratedNever();

                entity.HasOne(d => d.IdDicaNavigation)
                    .WithMany(p => p.Curtidas)
                    .HasForeignKey(d => d.IdDica)
                    .HasConstraintName("FK__Curtidas__IdDica__45F365D3");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Curtidas)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Curtidas__IdUsua__44FF419A");
            });

            modelBuilder.Entity<Dicas>(entity =>
            {
                entity.HasKey(e => e.IdDica)
                    .HasName("PK__Dicas__F168851608E1E657");

                entity.Property(e => e.IdDica).ValueGeneratedNever();

                entity.Property(e => e.Imagem)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Texto)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Dicas)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Dicas__IdUsuario__4222D4EF");
            });

            modelBuilder.Entity<Instituicoes>(entity =>
            {
                entity.HasKey(e => e.IdInstituicao)
                    .HasName("PK__Institui__B771C0D8555839C8");

                entity.Property(e => e.IdInstituicao).ValueGeneratedNever();

                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Cep)
                    .HasColumnName("CEP")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Complemento)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Logradouro)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Numero)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Uf)
                    .HasColumnName("UF")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<ObjetivoAlunos>(entity =>
            {
                entity.HasKey(e => e.IdObjetivoAluno)
                    .HasName("PK__Objetivo__81E21D7A39041DEE");

                entity.Property(e => e.IdObjetivoAluno).ValueGeneratedNever();

                entity.Property(e => e.DataEntrega).HasColumnType("datetime");

                entity.Property(e => e.Nota).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdAlunoTurmaNavigation)
                    .WithMany(p => p.ObjetivoAlunos)
                    .HasForeignKey(d => d.IdAlunoTurma)
                    .HasConstraintName("FK__ObjetivoA__IdAlu__5441852A");

                entity.HasOne(d => d.IdObjetivoNavigation)
                    .WithMany(p => p.ObjetivoAlunos)
                    .HasForeignKey(d => d.IdObjetivo)
                    .HasConstraintName("FK__ObjetivoA__IdObj__534D60F1");
            });

            modelBuilder.Entity<Objetivos>(entity =>
            {
                entity.HasKey(e => e.IdObjetivo)
                    .HasName("PK__Objetivo__E210F07169398584");

                entity.Property(e => e.IdObjetivo).ValueGeneratedNever();

                entity.Property(e => e.Descricao)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Objetivos)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK__Objetivos__IdCat__48CFD27E");
            });

            modelBuilder.Entity<Perfis>(entity =>
            {
                entity.HasKey(e => e.IdPerfil)
                    .HasName("PK__Perfis__C7BD5CC138A0226A");

                entity.Property(e => e.IdPerfil).ValueGeneratedNever();

                entity.Property(e => e.Permissao)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProfessorTurmas>(entity =>
            {
                entity.HasKey(e => e.IdProfessorTurma)
                    .HasName("PK__Professo__D4E74F9E6F84EB4B");

                entity.Property(e => e.IdProfessorTurma).ValueGeneratedNever();

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTurmaNavigation)
                    .WithMany(p => p.ProfessorTurmas)
                    .HasForeignKey(d => d.IdTurma)
                    .HasConstraintName("FK__Professor__IdTur__5812160E");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.ProfessorTurmas)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Professor__IdUsu__571DF1D5");
            });

            modelBuilder.Entity<Turmas>(entity =>
            {
                entity.HasKey(e => e.IdTurma)
                    .HasName("PK__Turmas__C1ECFFC93FFDA822");

                entity.Property(e => e.IdTurma).ValueGeneratedNever();

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Turmas)
                    .HasForeignKey(d => d.IdCurso)
                    .HasConstraintName("FK__Turmas__IdCurso__4BAC3F29");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuarios__5B65BF972D24C768");

                entity.Property(e => e.IdUsuario).ValueGeneratedNever();

                entity.Property(e => e.DataCadastro).HasColumnType("datetime");

                entity.Property(e => e.DataUltimoAcesso).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPerfilNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdPerfil)
                    .HasConstraintName("FK__Usuarios__IdPerf__3F466844");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
