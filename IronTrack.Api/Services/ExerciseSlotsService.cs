using IronTrack.Api.Models;

namespace IronTrack.Api.Services
{
    public class ExerciseSlotsService : IExerciseSlotsService
    {
        private static readonly List<ExerciseSlot> _exerciseSlots = new();
        private static readonly List<string> _allowedExercises = new()
        {
            "Squat", "Bench Press", "Deadlift"
        };

        private static int _id = 1;

        public ExerciseSlot Get(int id)
        {
            var exerciseSlot = _exerciseSlots.SingleOrDefault(x => x.Id == id);
            return exerciseSlot;
        }

        public IEnumerable<ExerciseSlot> GetAll()
        {
            return _exerciseSlots;

        }
        public int? Create(ExerciseSlot exerciseSlot)
        {
            if (!_allowedExercises.Contains(exerciseSlot.ExerciseName))
            {
                return default;
            }

            if (exerciseSlot.Date < DateTime.UtcNow.AddDays(1).Date || exerciseSlot.Date > DateTime.UtcNow.AddDays(14).Date)
            {
                return default;
            }

            var exerciseAlreadyAssigned = _exerciseSlots.Any(x =>
            x.AthleteName == exerciseSlot.AthleteName &&
            x.ExerciseName == exerciseSlot.ExerciseName &&
            x.Date.Date == exerciseSlot.Date.Date);

            if (exerciseAlreadyAssigned)
            {
                return default;
            }
            exerciseSlot.Id = _id;

            _id++;
            _exerciseSlots.Add(exerciseSlot);
            return exerciseSlot.Id;
        }

        public bool Update(int id, ExerciseSlot exerciseSlot)
        {
            var existingExerciseSlot = _exerciseSlots.SingleOrDefault(x => x.Id == id);
            if (existingExerciseSlot is null)
            {

                return false;
            }
            existingExerciseSlot.TargetRpe = exerciseSlot.TargetRpe;

            return true;
        }

        public bool Delete(int id)
        {
            var existingExerciseSlot = _exerciseSlots.SingleOrDefault(x => x.Id == id);
            if (existingExerciseSlot is null)
            {

                return false;
            }

            _exerciseSlots.Remove(existingExerciseSlot);

            return true;
        }
    }
}
