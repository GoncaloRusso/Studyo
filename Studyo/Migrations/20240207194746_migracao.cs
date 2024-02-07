using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Studyo.Migrations
{
    /// <inheritdoc />
    public partial class migracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "File",
                table: "Materials",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "QuizId",
                table: "Materials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "Chapters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Antropologia" },
                    { 2, "Aplicações Matemáticas B" },
                    { 3, "Biologia" },
                    { 4, "Ciência Política" },
                    { 5, "Clássicos da Literatura" },
                    { 6, "Desenho A" },
                    { 7, "Direito" },
                    { 8, "Economia A" },
                    { 9, "Economia C" },
                    { 10, "Filosofia A" },
                    { 11, "Filosofia B" },
                    { 12, "Física" },
                    { 13, "Geografia A" },
                    { 14, "Geografia C" },
                    { 15, "Geometria Descritiva A" },
                    { 16, "Grego" },
                    { 17, "História A" },
                    { 18, "História B" },
                    { 19, "História da Cultura e das Artes" },
                    { 20, "Língua Estrangeira I" },
                    { 21, "Língua Estrangeira II" },
                    { 22, "Língua Estrangeira III" },
                    { 23, "Latim A" },
                    { 24, "Latim B" },
                    { 25, "Literatura Portuguesa" },
                    { 26, "Literatura de Língua Portuguesa" },
                    { 27, "Materiais e Tecnologias" },
                    { 28, "Matemática A" },
                    { 29, "Matemática B" },
                    { 30, "História da Cultura e das Artes" },
                    { 31, "Oficina de Artes" },
                    { 32, "Oficina de Multimédia B" },
                    { 33, "Português" },
                    { 34, "Psicologia B" },
                    { 35, "Química" },
                    { 36, "Sociologia" }
                });

            migrationBuilder.InsertData(
                table: "Chapters",
                columns: new[] { "Id", "Name", "SubjectId" },
                values: new object[,]
                {
                    { 1, "Antropologia Cultural", 1 },
                    { 2, "Antropologia Social", 1 },
                    { 3, "Antropologia Biológica", 1 },
                    { 4, "Arqueologia", 1 },
                    { 5, "Linguística Antropológica", 1 },
                    { 6, "Funções e Gráficos", 2 },
                    { 7, "Sequências e Séries", 2 },
                    { 8, "Probabilidades e Estatística", 2 },
                    { 9, "Geometria no Plano e no Espaço", 2 },
                    { 10, "Matemática Financeira", 2 },
                    { 11, "Citologia", 3 },
                    { 12, "Genética", 3 },
                    { 13, "Ecologia", 3 },
                    { 14, "Evolução", 3 },
                    { 15, "Anatomia Humana", 3 },
                    { 16, "Teoria Política", 4 },
                    { 17, "Sistemas Políticos", 4 },
                    { 18, "Política Comparada", 4 },
                    { 19, "Relações Internacionais", 4 },
                    { 20, "Literatura Grega", 5 },
                    { 21, "Literatura Latina", 5 },
                    { 22, "Literatura Renascentista", 5 },
                    { 23, "Literatura Moderna", 5 },
                    { 24, "Fundamentos do Desenho", 6 },
                    { 25, "Perspectiva e Sombreamento", 6 },
                    { 26, "Desenho de Figura Humana", 6 },
                    { 27, "Desenho de Paisagem", 6 },
                    { 28, "Direito Constitucional", 7 },
                    { 29, "Direito Civil", 7 },
                    { 30, "Direito Penal", 7 },
                    { 31, "Direito Administrativo", 7 },
                    { 32, "Direito Tributário", 7 },
                    { 33, "Microeconomia", 8 },
                    { 34, "Macroeconomia", 8 },
                    { 35, "Economia Internacional", 8 },
                    { 36, "Economia do Setor Público", 8 },
                    { 37, "Economia do Trabalho", 8 },
                    { 38, "Economia Monetária", 9 },
                    { 39, "Economia Industrial", 9 },
                    { 40, "Economia Ambiental", 9 },
                    { 41, "Economia do Desenvolvimento", 9 },
                    { 42, "Metafísica", 10 },
                    { 43, "Epistemologia", 10 },
                    { 44, "Ética", 10 },
                    { 45, "Estética", 10 },
                    { 46, "Filosofia da Mente", 11 },
                    { 47, "Filosofia da Ciência", 11 },
                    { 48, "Filosofia da Linguagem", 11 },
                    { 49, "Filosofia da Religião", 11 },
                    { 50, "Mecânica Clássica", 12 },
                    { 51, "Eletromagnetismo", 12 },
                    { 52, "Termodinâmica", 12 },
                    { 53, "Óptica", 12 },
                    { 54, "Física Quântica", 12 },
                    { 55, "Relatividade", 12 },
                    { 56, "Física Nuclear", 12 },
                    { 57, "Geografia Física", 13 },
                    { 58, "Geografia Humana", 13 },
                    { 59, "Geografia Econômica", 13 },
                    { 60, "Geografia Política", 13 },
                    { 61, "Geografia Urbana", 14 },
                    { 62, "Geografia Rural", 14 },
                    { 63, "Geografia do Brasil", 14 },
                    { 64, "Geografia da Europa", 14 },
                    { 65, "Fundamentos da Geometria Descritiva", 15 },
                    { 66, "Projeções Ortogonais", 15 },
                    { 67, "Projeções Oblíquas", 15 },
                    { 68, "Interseções e Desenvolvimentos", 15 },
                    { 69, "Gramática Grega", 16 },
                    { 70, "Literatura Grega Clássica", 16 },
                    { 71, "Mitologia Grega", 16 },
                    { 72, "História da Grécia Antiga", 16 },
                    { 73, "Pré-História", 17 },
                    { 74, "Antiguidade", 17 },
                    { 75, "Idade Média", 17 },
                    { 76, "Idade Moderna", 17 },
                    { 77, "Idade Contemporânea", 17 },
                    { 78, "História do Brasil", 18 },
                    { 79, "História de Portugal", 18 },
                    { 80, "História da América", 18 },
                    { 81, "História da África", 18 },
                    { 82, "História da Ásia", 18 },
                    { 83, "Arte na Pré-História", 19 },
                    { 84, "Arte na Antiguidade", 19 },
                    { 85, "Arte na Idade Média", 19 },
                    { 86, "Arte no Renascimento", 19 },
                    { 87, "Arte Contemporânea", 19 },
                    { 88, "Gramática Básica", 20 },
                    { 89, "Vocabulário Básico", 20 },
                    { 90, "Conversação Básica", 20 },
                    { 91, "Leitura e Compreensão de Textos", 20 },
                    { 92, "Gramática Avançada", 21 },
                    { 93, "Vocabulário Avançado", 21 },
                    { 94, "Conversação Avançada", 21 },
                    { 95, "Leitura e Compreensão de Textos Avançados", 21 },
                    { 96, "Gramática Proficiente", 22 },
                    { 97, "Vocabulário Proficiente", 22 },
                    { 98, "Conversação Proficiente", 22 },
                    { 99, "Leitura e Compreensão de Textos Proficientes", 22 },
                    { 100, "Gramática Latina Básica", 23 },
                    { 101, "Vocabulário Latino Básico", 23 },
                    { 102, "Leitura e Compreensão de Textos Latinos Básicos", 23 },
                    { 103, "Gramática Latina Avançada", 24 },
                    { 104, "Vocabulário Latino Avançado", 24 },
                    { 105, "Leitura e Compreensão de Textos Latinos Avançados", 24 },
                    { 106, "Literatura Medieval Portuguesa", 25 },
                    { 107, "Renascimento e Classicismo", 25 },
                    { 108, "Barroco e Neoclassicismo", 25 },
                    { 109, "Romantismo", 25 },
                    { 110, "Realismo e Naturalismo", 25 },
                    { 111, "Modernismo e Contemporâneo", 25 },
                    { 112, "Literatura Angolana", 26 },
                    { 113, "Literatura Brasileira", 26 },
                    { 114, "Literatura Moçambicana", 26 },
                    { 115, "Literatura Cabo-Verdiana", 26 },
                    { 116, "Materiais Metálicos", 27 },
                    { 117, "Materiais Cerâmicos", 27 },
                    { 118, "Materiais Poliméricos", 27 },
                    { 119, "Materiais Compósitos", 27 },
                    { 120, "Álgebra", 28 },
                    { 121, "Geometria", 28 },
                    { 122, "Cálculo", 28 },
                    { 123, "Funções Reais de Variável Real", 29 },
                    { 124, "Sequências e Sucessões", 29 },
                    { 125, "Limites e Continuidade", 29 },
                    { 126, "Diferenciação", 29 },
                    { 127, "Arte na Pré-História", 30 },
                    { 128, "Arte na Antiguidade", 30 },
                    { 129, "Arte na Idade Média", 30 },
                    { 130, "Arte no Renascimento", 30 },
                    { 131, "Arte Contemporânea", 30 },
                    { 132, "Pintura", 31 },
                    { 133, "Escultura", 31 },
                    { 134, "Cerâmica", 31 },
                    { 135, "Fotografia", 31 },
                    { 136, "Design Gráfico", 32 },
                    { 137, "Animação Digital", 32 },
                    { 138, "Produção de Vídeo", 32 },
                    { 139, "Programação Web", 32 },
                    { 140, "Gramática", 33 },
                    { 141, "Literatura Portuguesa", 33 },
                    { 142, "Oratória", 33 },
                    { 143, "Escrita Criativa", 33 },
                    { 144, "Psicologia Cognitiva", 34 },
                    { 145, "Psicologia Social", 34 },
                    { 146, "Psicologia do Desenvolvimento", 34 },
                    { 147, "Psicologia Clínica", 34 },
                    { 148, "Química Geral", 35 },
                    { 149, "Química Orgânica", 35 },
                    { 150, "Química Inorgânica", 35 },
                    { 151, "Química Analítica", 35 },
                    { 152, "Sociologia Geral", 36 },
                    { 153, "Sociologia da Educação", 36 },
                    { 154, "Sociologia do Trabalho", 36 },
                    { 155, "Sociologia Urbana", 36 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Materials_QuizId",
                table: "Materials",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_Chapters_SubjectId",
                table: "Chapters",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chapters_Subjects_SubjectId",
                table: "Chapters",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Quizzes_QuizId",
                table: "Materials",
                column: "QuizId",
                principalTable: "Quizzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chapters_Subjects_SubjectId",
                table: "Chapters");

            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Quizzes_QuizId",
                table: "Materials");

            migrationBuilder.DropIndex(
                name: "IX_Materials_QuizId",
                table: "Materials");

            migrationBuilder.DropIndex(
                name: "IX_Chapters_SubjectId",
                table: "Chapters");

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DropColumn(
                name: "File",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "QuizId",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Chapters");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
