using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Studyo.Data;
using Studyo.Models;

namespace Studyo.Controllers
{
    /// <summary>
    /// Class responsable for managing the requests towards a single subject and providing all the needed information to the Views so all the functions regarding a
    /// subject work
    /// </summary>
    [Authorize]
    public class DisciplinaController : Controller
    {
        private readonly StudyoDbContext _context;
        private readonly UserManager<IdentityUser> _userManger;
        
        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="context"> Model for saving data for the data base</param>
        /// <param name="userManager"> Managing the logged in user </param>
        public DisciplinaController(StudyoDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManger = userManager;
        }

        /// <summary>
        /// Calls the View responsible for loading the page of a Subject, providing it with a UserSubject class as a model, which keeps the interaction of the User with the Subject
        /// and the information of said Subject
        ///
        /// </summary>
        /// <param name="id">Subject Id</param>
        /// <param name="searchString">Search bar text</param>
        /// <returns>View with UserSubject</returns>
        public async Task<IActionResult> Index(int id, string searchString)
        {
            IdentityUser? user = await _userManger.GetUserAsync(User);

            if (user == null) { return NotFound(); }

            var subject = _context.Subjects.Where((subject) => subject.Id == id).FirstOrDefault();

            if (subject == null) { return NotFound(); }

            if (!string.IsNullOrEmpty(searchString))
            {
                subject.Chapters = [.. _context.Chapters.Where((chapter) => chapter.SubjectId == id &&
                    chapter.Name.Contains(searchString))];
            }
            else
            {
                subject.Chapters = [.. _context.Chapters.Where((chapter) => chapter.SubjectId == id)];
            }

            var userSubject = _context.UserSubjects.Where((userSubject) => userSubject.SubjectId == id && userSubject.UserId == user.Id).FirstOrDefault();

            userSubject ??= EnrollUserToSubject(user.Id, id);

            userSubject.UserChapters =
            [
                .. _context.UserChapters.Where((userChapter) => userChapter.UserId == user.Id && subject.Chapters.Contains(userChapter.Chapter)),
            ];

            ViewBag.CurrentFilter = searchString;

            return View(userSubject);
        }


        /// <summary>
        /// Calls the View responsible for loading the page of a Quiz, providing it with a Quiz class as a model, making sure to prepair all of its data before sending it
        /// </summary>
        /// <param name="id"> Chapter Id</param>
        /// <returns> View with Quiz</returns>
        public IActionResult Quiz(int id)
        {
            var quiz = _context.Quizzes.Where(q => q.ChapterId == id).FirstOrDefault();
            if (quiz == null) { return NotFound(); }

            quiz.Chapter = _context.Chapters.Where(c => c.Id == quiz.ChapterId).First();

            quiz.QuizQuestions = _context.QuizQuestions.Where(qq => qq.QuizId == quiz.Id).ToList();
            if (quiz.QuizQuestions.IsNullOrEmpty()) { return NotFound(); }

            foreach (QuizQuestion qq in quiz.QuizQuestions)
            {
                qq.Answers = _context.QuizQuestionAnswers.Where(qqa => qqa.QuizQuestionId == qq.Id).ToList();
                Shuffle(qq.Answers);
            }

            return View(quiz);
        }


        /// <summary>
        /// Calls the View responsible for loading the page of a Chapter, providing it with said Chapter class as a model, which contains its information
        /// </summary>
        /// <param name="id"> Chapter Id</param>
        /// <returns> View with chapter</returns>
        public IActionResult Content(int id)
        {
            var chapter = _context.Chapters.Where(c => c.Id == id).FirstOrDefault();

            if (chapter == null)
            {
                return NotFound();
            }

            return View(chapter);
        }

        /// <summary>
        /// Work in Progress!
        /// Calls the View to load Anki Card
        /// </summary>
        /// <returns></returns>
        public IActionResult AnkiCards() { return View(); }


        /// <summary>
        /// Calls the View responsible for loading the page showing the result obtained by the user on quiz submition.
        /// Function makes sure to take the necessary steps creating or editing the UserChapter class, which keeps the information of the interactions of the User with the Chapter,
        /// and saving or discarding the result as a BestGrade or not.
        /// 
        /// </summary>
        /// <param name="chapterId"> Chapter Id</param>
        /// <param name="score"> Score obtained</param>
        /// <returns>View with UserChapter</returns>
        public async Task<IActionResult> QuizResult(int chapterId, int score)
        {
            IdentityUser? user = await _userManger.GetUserAsync(User);

            if (user == null) { return NotFound(); }

            var userChapter = _context.UserChapters.Where((userChapter) => userChapter.ChapterId == chapterId && userChapter.UserId == user.Id).FirstOrDefault();

            if (userChapter == null)
            {
                userChapter = new UserChapter
                {
                    UserId = user.Id,
                    ChapterId = chapterId,
                    CurrentScore = score,
                    BestGrade = score
                };

                _context.UserChapters.Add(userChapter);
            }

            else
            {
                userChapter.CurrentScore = score;
                userChapter.BestGrade = (score > userChapter.BestGrade) ? score : userChapter.BestGrade;
            }

            userChapter.Chapter = _context.Chapters.Where((chapter) => chapter.Id == chapterId).FirstOrDefault();
            if (userChapter.Chapter == null) { return NotFound(); }

            _context.SaveChanges();

            return View(userChapter);
        }

        /// <summary>
        /// In case it is the First time a User opens a Subject, this function is called, which is responsible for creating a UserSubject class and saving it to the context.
        /// </summary>
        /// <param name="userId"> User Id</param>
        /// <param name="subjectId"> Subject Id</param>
        /// <returns>UserSubject</returns>
        private UserSubject EnrollUserToSubject(string userId, int subjectId)
        {
            UserSubject userSubject = new UserSubject
            {
                UserId = userId,
                SubjectId = subjectId
            };

            _context.UserSubjects.Add(userSubject);
            _context.SaveChanges();

            return userSubject;
        }


        /// <summary>
        /// Function called when loading the page of a Quiz, responsible for shuffling the answers of each question so they don't always show in the same order.
        /// </summary>
        /// <typeparam name="T"> Default type loaded with Answers</typeparam>
        /// <param name="list"> List of Answers</param>
        private static void Shuffle<T>(List<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
