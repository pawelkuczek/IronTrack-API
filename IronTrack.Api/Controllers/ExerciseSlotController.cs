using IronTrack.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace IronTrack.Api.Controllers
{
    [ApiController]
    [Route("exerciseslots")]
    public class ExerciseSlotsController : ControllerBase
    {
        private static readonly List<ExerciseSlot> _exerciseSlots = new();
        private static readonly List<string> _allowedExercises = new()
        {
            "Squat", "Bench Press", "Deadlift"
        };

        private static int _id = 1;

        [HttpGet]
        public ActionResult<IEnumerable<ExerciseSlot>> Get() => Ok(_exerciseSlots);

        [HttpGet("{id:int}")]
        public ActionResult<ExerciseSlot> Get(int id)
        {
            var exerciseSlot = _exerciseSlots.SingleOrDefault(x => x.Id == id);
            if (exerciseSlot is null)
            {

                return NotFound();
            }
            return exerciseSlot;
        }

        [HttpPost]
        public ActionResult Post([FromBody] ExerciseSlot exerciseSlot)
        {
            if (!_allowedExercises.Contains(exerciseSlot.ExerciseName))
            {

                return BadRequest();
            }

            exerciseSlot.Date = DateTime.UtcNow.AddDays(1);
            var exerciseAlreadyAssigned = _exerciseSlots.Any(x =>
            x.AthleteName == exerciseSlot.AthleteName &&
            x.ExerciseName == exerciseSlot.ExerciseName &&
            x.Date.Date == exerciseSlot.Date.Date);

            if (exerciseAlreadyAssigned)
            {
                return BadRequest();
            }
            exerciseSlot.Id = _id;

            _id++;
            _exerciseSlots.Add(exerciseSlot);
            return CreatedAtAction(nameof(Get), new { id = exerciseSlot.Id }, null);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, ExerciseSlot exerciseSlot)
        {
            var existingExerciseSlot = _exerciseSlots.SingleOrDefault(x => x.Id == id);
            if (existingExerciseSlot is null)
            {

                return NotFound();
            }
            existingExerciseSlot.TargetRpe = exerciseSlot.TargetRpe;

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var existingExerciseSlot = _exerciseSlots.SingleOrDefault(x => x.Id == id);
            if (existingExerciseSlot is null)
            {

                return NotFound();
            }

            _exerciseSlots.Remove(existingExerciseSlot);

            return NoContent();
        }
    }
}
