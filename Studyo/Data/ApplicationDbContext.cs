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
    }
}
