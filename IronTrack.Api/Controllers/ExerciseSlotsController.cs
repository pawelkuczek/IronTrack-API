using IronTrack.Api.Models;
using IronTrack.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace IronTrack.Api.Controllers
{
    [ApiController]
    [Route("exerciseslots")]
    public class ExerciseSlotsController : ControllerBase
    {
        private readonly IExerciseSlotsService _exerciseSlotsService;

        public ExerciseSlotsController(IExerciseSlotsService exerciseSlotsService)
        {
            _exerciseSlotsService = exerciseSlotsService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ExerciseSlot>> Get() => Ok(_exerciseSlotsService.GetAll());

        [HttpGet("{id:int}")]
        public ActionResult<ExerciseSlot> Get(int id)
        {
            var exerciseSlot = _exerciseSlotsService.Get(id);
            if (exerciseSlot is null)
            {

                return NotFound();
            }
            return exerciseSlot;
        }

        [HttpPost]
        public ActionResult Post([FromBody] ExerciseSlot exerciseSlot)
        {
            var id = _exerciseSlotsService.Create(exerciseSlot);
            if (id is null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Get), new {id}, null);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, ExerciseSlot exerciseSlot)
        {
            exerciseSlot.Id = id;
            if (!_exerciseSlotsService.Update(id, exerciseSlot))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
           if (!_exerciseSlotsService.Delete(id))
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
