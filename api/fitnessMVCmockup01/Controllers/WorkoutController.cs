using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using fitnessMVCmockup01.Data;
using fitnessMVCmockup01.Models;
using fitnessMVCmockup01.Dto;

namespace fitnessMVCmockup01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutController : ControllerBase
    {
        private readonly FitnessContext _context;

        public WorkoutController(FitnessContext context)
        {
            _context = context;
        }

        // GET: api/Workout
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Workout>>> GetWorkouts()
        {
          if (_context.Workouts == null)
          {
              return NotFound();
          }
            return await _context.Workouts.ToListAsync();
        }

        // GET: api/Workout/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Workout>> GetWorkout(int id)
        {
          if (_context.Workouts == null)
          {
              return NotFound();
          }
            var workout = await _context.Workouts.FindAsync(id);

            if (workout == null)
            {
                return NotFound();
            }

            return workout;
        }

        // PUT: api/Workout/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkout(int id, Workout workout)
        {
            if (id != workout.WorkoutId)
            {
                return BadRequest();
            }

            _context.Entry(workout).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkoutExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Workout
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Workout>> PostWorkout(Workout workout)
        {
          if (_context.Workouts == null)
          {
              return Problem("Entity set 'FitnessContext.Workouts'  is null.");
          }
            _context.Workouts.Add(workout);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWorkout", new { id = workout.WorkoutId }, workout);
        }

        // DELETE: api/Workout/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkout(int id)
        {
            if (_context.Workouts == null)
            {
                return NotFound();
            }
            var workout = await _context.Workouts.FindAsync(id);
            if (workout == null)
            {
                return NotFound();
            }

            _context.Workouts.Remove(workout);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //Get Workouts By User
        //[Route("/api/user/<id>/workout")]
        [Route("/api/user/{id}/workout")]
        [HttpPost]
        public async Task<IActionResult> GetWorkoutsByUser([FromBody] UserWorkoutsRequestDto userWorkoutsRequestDto)
        {
            User user;
            user = _context.Users.Where(user => user.UserEmail == userLoginRequestDto.EmailAddress).FirstOrDefault();


            return NoContent();
        }

        private bool WorkoutExists(int id)
        {
            return (_context.Workouts?.Any(e => e.WorkoutId == id)).GetValueOrDefault();
        }
    }
}
