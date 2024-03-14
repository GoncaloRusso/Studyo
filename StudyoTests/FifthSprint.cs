using System;
using System.Reflection.Metadata;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Studyo.Controllers;
using Studyo.Data;
using Studyo.Models;

namespace StudyoTests
{
    public class FifthSprint
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

    }
}