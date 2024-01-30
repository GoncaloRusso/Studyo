namespace Studyo.Models
{
    public class Pomodoro
    {
        public int StudyTime { get; set; }
        public int RestTime { get; set; }
        public byte Cycles { get; set; }

        public void SetStudyTime(int studyTime)
        {
            StudyTime = studyTime;
        }

        public void SetRestTime(int restTime)
        {
            RestTime = restTime;
        }

        public void SetCycles(byte cycles)
        {
            Cycles = cycles;
        }

        public void Start()
        {
            // Implementação do método Start
        }
    }
}
