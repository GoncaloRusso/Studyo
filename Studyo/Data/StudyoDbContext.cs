﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Studyo.Models;

namespace Studyo.Data
{
    public class StudyoDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<AnkiCard> AnkiCards { get; set; } = default!;
        public DbSet<Chapter> Chapters { get; set; } = default!;
        public DbSet<Quiz> Quizzes { get; set; } = default!;
        public DbSet<QuizQuestion> QuizQuestions { get; set; } = default!;
        public DbSet<QuizQuestionAnswer> QuizQuestionAnswers { get; set; } = default!;
        public DbSet<Subject> Subjects { get; set; } = default!;
        public DbSet<UserChapter> UserChapters { get; set; } = default!;
        public DbSet<UserSubject> UserSubjects { get; set; } = default!;
        public DbSet<Workshop> Workshops { get; set; } = default!;
        public DbSet<WorkshopContent> WorkshopContents { get; set; } = default!;

        public StudyoDbContext(DbContextOptions options) : base(options) { }
    }
}
