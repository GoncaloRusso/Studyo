using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Studyo.Models;

namespace Studyo.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<AnkiCard> AnkiCards { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<QuizQuestion> QuizQuestions { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Workshop> Workshops { get; set; }
        public DbSet<WorkshopContent> WorkshopContents { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Subject>()
                .HasMany(s => s.Chapters)
                .WithOne(c => c.Subject)
                .HasForeignKey(c => c.SubjectId);

            // Lista de nomes das matérias
            var nomesDasMaterias = new List<string>
            {
                "Antropologia",
                "Aplicações Matemáticas B",
                "Biologia",
                "Ciência Política",
                "Clássicos da Literatura",
                "Desenho A",
                "Direito",
                "Economia A",
                "Economia C",
                "Filosofia A",
                "Filosofia B",
                "Física",
                "Geografia A",
                "Geografia C",
                "Geometria Descritiva A",
                "Grego",
                "História A",
                "História B",
                "História da Cultura e das Artes",
                "Língua Estrangeira I",
                "Língua Estrangeira II",
                "Língua Estrangeira III",
                "Latim A",
                "Latim B",
                "Literatura Portuguesa",
                "Literatura de Língua Portuguesa",
                "Materiais e Tecnologias",
                "Matemática A",
                "Matemática B",
                "História da Cultura e das Artes",
                "Oficina de Artes",
                "Oficina de Multimédia B",
                "Português",
                "Psicologia B",
                "Química",
                "Sociologia"
            };
            int chapterId = 1;  // Start the Chapter Ids from 1

            for (int i = 0; i < nomesDasMaterias.Count; i++)
            {
                var subject = new Subject
                {
                    Id = i + 1,
                    Name = nomesDasMaterias[i]
                };

                modelBuilder.Entity<Subject>().HasData(subject);

                // Add chapters specific to each subject
                if (subject.Name == "Matemática A")
                {
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Álgebra", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Geometria", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Cálculo", SubjectId = subject.Id });
                }
                else if (subject.Name == "Aplicações Matemáticas B")
                {
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Funções e Gráficos", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Sequências e Séries", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Probabilidades e Estatística", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Geometria no Plano e no Espaço", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Matemática Financeira", SubjectId = subject.Id });
                }
 


                else if (subject.Name == "Antropologia")
                {
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Antropologia Cultural", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Antropologia Social", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Antropologia Biológica", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Arqueologia", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Linguística Antropológica", SubjectId = subject.Id });
                }

                else if (subject.Name == "Literatura Portuguesa")
                {
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Literatura Medieval Portuguesa", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Renascimento e Classicismo", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Barroco e Neoclassicismo", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Romantismo", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Realismo e Naturalismo", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Modernismo e Contemporâneo", SubjectId = subject.Id });
                }

                else if (subject.Name == "Física")
                {
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Mecânica Clássica", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Eletromagnetismo", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Termodinâmica", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Óptica", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Física Quântica", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Relatividade", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Física Nuclear", SubjectId = subject.Id });
                }
                else if (subject.Name == "Biologia")
                {
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Citologia", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Genética", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Ecologia", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Evolução", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Anatomia Humana", SubjectId = subject.Id });
                }
                else if (subject.Name == "Ciência Política")
                {
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Teoria Política", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Sistemas Políticos", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Política Comparada", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Relações Internacionais", SubjectId = subject.Id });
                }
                else if (subject.Name == "Clássicos da Literatura")
                {
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Literatura Grega", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Literatura Latina", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Literatura Renascentista", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Literatura Moderna", SubjectId = subject.Id });
                }
                else if (subject.Name == "Desenho A")
                {
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Fundamentos do Desenho", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Perspectiva e Sombreamento", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Desenho de Figura Humana", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Desenho de Paisagem", SubjectId = subject.Id });
                }
                else if (subject.Name == "Direito")
                {
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Direito Constitucional", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Direito Civil", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Direito Penal", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Direito Administrativo", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Direito Tributário", SubjectId = subject.Id });
                }
                else if (subject.Name == "Economia A")
                {
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Microeconomia", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Macroeconomia", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Economia Internacional", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Economia do Setor Público", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Economia do Trabalho", SubjectId = subject.Id });
                }
                else if (subject.Name == "Economia C")
                {
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Economia Monetária", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Economia Industrial", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Economia Ambiental", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Economia do Desenvolvimento", SubjectId = subject.Id });
                }
                else if (subject.Name == "Filosofia A")
                {
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Metafísica", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Epistemologia", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Ética", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Estética", SubjectId = subject.Id });
                }
                else if (subject.Name == "Filosofia B")
                {
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Filosofia da Mente", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Filosofia da Ciência", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Filosofia da Linguagem", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Filosofia da Religião", SubjectId = subject.Id });
                }
                else if (subject.Name == "Física")
                {
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Mecânica Clássica", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Eletromagnetismo", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Termodinâmica", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Óptica", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Física Quântica", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Relatividade", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Física Nuclear", SubjectId = subject.Id });
                }
                else if (subject.Name == "Geografia A")
                {
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Geografia Física", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Geografia Humana", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Geografia Econômica", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Geografia Política", SubjectId = subject.Id });
                }
                else if (subject.Name == "Geografia C")
                {
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Geografia Urbana", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Geografia Rural", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Geografia do Brasil", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Geografia da Europa", SubjectId = subject.Id });
                }
                else if (subject.Name == "Geometria Descritiva A")
                {
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Fundamentos da Geometria Descritiva", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Projeções Ortogonais", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Projeções Oblíquas", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Interseções e Desenvolvimentos", SubjectId = subject.Id });
                }
                else if (subject.Name == "Grego")
                {
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Gramática Grega", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Literatura Grega Clássica", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Mitologia Grega", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "História da Grécia Antiga", SubjectId = subject.Id });
                }
                else if (subject.Name == "História A")
                {
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Pré-História", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Antiguidade", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Idade Média", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Idade Moderna", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Idade Contemporânea", SubjectId = subject.Id });
                }
                else if (subject.Name == "História B")
                {
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "História do Brasil", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "História de Portugal", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "História da América", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "História da África", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "História da Ásia", SubjectId = subject.Id });
                }
                else if (subject.Name == "História da Cultura e das Artes")
                {
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Arte na Pré-História", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Arte na Antiguidade", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Arte na Idade Média", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Arte no Renascimento", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Arte Contemporânea", SubjectId = subject.Id });
                }
                else if (subject.Name == "Língua Estrangeira I")
                {
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Gramática Básica", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Vocabulário Básico", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Conversação Básica", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Leitura e Compreensão de Textos", SubjectId = subject.Id });
                }
                else if (subject.Name == "Língua Estrangeira II")
                {
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Gramática Avançada", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Vocabulário Avançado", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Conversação Avançada", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Leitura e Compreensão de Textos Avançados", SubjectId = subject.Id });
                }
                else if (subject.Name == "Língua Estrangeira III")
                {
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Gramática Proficiente", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Vocabulário Proficiente", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Conversação Proficiente", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Leitura e Compreensão de Textos Proficientes", SubjectId = subject.Id });
                }
                else if (subject.Name == "Latim A")
                {
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Gramática Latina Básica", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Vocabulário Latino Básico", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Leitura e Compreensão de Textos Latinos Básicos", SubjectId = subject.Id });
                }
                else if (subject.Name == "Latim B")
                {
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Gramática Latina Avançada", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Vocabulário Latino Avançado", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Leitura e Compreensão de Textos Latinos Avançados", SubjectId = subject.Id });
                }
                else if (subject.Name == "Literatura de Língua Portuguesa")
                {
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Literatura Angolana", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Literatura Brasileira", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Literatura Moçambicana", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Literatura Cabo-Verdiana", SubjectId = subject.Id });
                }
                else if (subject.Name == "Materiais e Tecnologias")
                {
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Materiais Metálicos", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Materiais Cerâmicos", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Materiais Poliméricos", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Materiais Compósitos", SubjectId = subject.Id });
                }
                else if (subject.Name == "Matemática A")
                {
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Números e Operações", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Álgebra", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Geometria", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Funções", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Probabilidades e Estatística", SubjectId = subject.Id });
                }
                else if (subject.Name == "Matemática B")
                {
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Funções Reais de Variável Real", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Sequências e Sucessões", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Limites e Continuidade", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Diferenciação", SubjectId = subject.Id });
                }
                else if (subject.Name == "Matemática Aplicada Às Ciências Sociais")
                {
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Análise Combinatória", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Probabilidades", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Estatística Descritiva", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Estatística Inferencial", SubjectId = subject.Id });
                }
                else if (subject.Name == "Oficina de Artes")
                {
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Pintura", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Escultura", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Cerâmica", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Fotografia", SubjectId = subject.Id });
                }
                else if (subject.Name == "Oficina de Multimédia B")
                {
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Design Gráfico", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Animação Digital", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Produção de Vídeo", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Programação Web", SubjectId = subject.Id });
                }
                else if (subject.Name == "Português")
                {
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Gramática", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Literatura Portuguesa", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Oratória", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Escrita Criativa", SubjectId = subject.Id });
                }
                else if (subject.Name == "Psicologia B")
                {
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Psicologia Cognitiva", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Psicologia Social", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Psicologia do Desenvolvimento", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Psicologia Clínica", SubjectId = subject.Id });
                }
                else if (subject.Name == "Química")
                {
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Química Geral", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Química Orgânica", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Química Inorgânica", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Química Analítica", SubjectId = subject.Id });
                }
                else if (subject.Name == "Sociologia")
                {
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Sociologia Geral", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Sociologia da Educação", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Sociologia do Trabalho", SubjectId = subject.Id });
                    modelBuilder.Entity<Chapter>().HasData(new Chapter { Id = chapterId++, Name = "Sociologia Urbana", SubjectId = subject.Id });
                }

            }
        }
    }
}
