using IronTrack.Api.Models;

namespace IronTrack.Api.Services
{
    public interface IExerciseSlotsService
    {
        IEnumerable<ExerciseSlot> GetAll();
        ExerciseSlot Get(int id);
        int? Create(ExerciseSlot exerciseSlot);
        bool Update(int id, ExerciseSlot exerciseSlot);
        bool Delete(int id);

    }
}
