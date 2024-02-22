using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Studyo.Models;

namespace Studyo.Data
{
    public class StudyoDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<AnkiCard> AnkiCards { get; set; } = default!;
        public DbSet<Chapter> Chapters { get; set; } = default!;
        public DbSet<DisciplinaUser> DisciplinaUsers { get; set; } = default!;
        public DbSet<Quiz> Quizzes { get; set; } = default!;
        public DbSet<QuizQuestion> QuizQuestions { get; set; } = default!;
        public DbSet<Material> Materials { get; set; } = default!;
        public DbSet<Subject> Subjects { get; set; } = default!;
        public DbSet<Workshop> Workshops { get; set; } = default!;
        public DbSet<WorkshopContent> WorkshopContents { get; set; } = default!;

        public StudyoDbContext(DbContextOptions options) : base(options) { }
    }
}
