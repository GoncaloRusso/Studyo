using System;
using System.Reflection.Metadata;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Studyo.Models;

namespace StudyoTests
{
    public class StudyoTester
    {
        [Fact]
        public void AccessChapterQuiz()
        {
            
        }

        [Fact]
        public void CreatePomodoroTest()
        {
            Pomodoro pomodoro = new Pomodoro();

            pomodoro.StudyTime = 1;
            pomodoro.RestTime = 1;
            pomodoro.Cycles = 1;
            pomodoro.DateTime = DateTime.Now;

            pomodoro.Should().NotBeNull();
        }

        [Fact]
        public void ShuffleTest()
        {
            DisciplinaController disciplinaController = new DisciplinaController(null, null);

            
        }

    }
}