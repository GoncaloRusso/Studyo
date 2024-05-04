namespace Studyo.Models
{
    /// <summary>
    /// Model for Pomodoro. Detailing its parameters
    /// </summary>
    public class Pomodoro
    {
        /// <summary>
        /// Time the user will be studying for
        /// </summary>
        public int StudyTime { get; set; }

        /// <summary>
        /// Time the user will be resting for
        /// </summary>
        public int RestTime { get; set; }

        /// <summary>
        /// Number of Cycles the user will repeat
        /// </summary>
        public byte Cycles { get; set; }

        /// <summary>
        /// Current date of Usage
        /// </summary>
        public DateTime DateTime { get; set; }
    }
}
