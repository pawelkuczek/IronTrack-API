using System.Diagnostics;

namespace IronTrack.Api.Models
{
    [DebuggerDisplay("AthleteName: {AthleteName} | " +
        "ExerciseName : {ExerciseName} | " +
        "TargetRpe: {TargetRpe} |" +
        "Date: {Date} |")]
    public class ExerciseSlot
    {
        public int Id { get; set; }
        public string AthleteName { get; set; }
        public string ExerciseName { get; set; }
        public int TargetRpe { get; set; }
        public DateTime Date { get; set; }
    }
}
