using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using fitnessMVCmockup01.Data;
using fitnessMVCmockup01.Models;

namespace fitnessMVCmockup01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoalController : ControllerBase
    {
        private readonly FitnessContext _context;

        public GoalController(FitnessContext context)
        {
            _context = context;
        }

        // GET: api/Goal
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Goal>>> GetGoals()
        {
          if (_context.Goals == null)
          {
              return NotFound();
          }
            return await _context.Goals.ToListAsync();
        }

        // GET: api/Goal/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Goal>> GetGoal(int id)
        {
          if (_context.Goals == null)
          {
              return NotFound();
          }
            var goal = await _context.Goals.FindAsync(id);

            if (goal == null)
            {
                return NotFound();
            }

            return goal;
        }

        // PUT: api/Goal/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGoal(int id, Goal goal)
        {
            if (id != goal.GoalId)
            {
                return BadRequest();
            }

            _context.Entry(goal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GoalExists(id))
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

        // POST: api/Goal
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Goal>> PostGoal(Goal goal)
        {
          if (_context.Goals == null)
          {
              return Problem("Entity set 'FitnessContext.Goals'  is null.");
          }
            _context.Goals.Add(goal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGoal", new { id = goal.GoalId }, goal);
        }

        // DELETE: api/Goal/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGoal(int id)
        {
            if (_context.Goals == null)
            {
                return NotFound();
            }
            var goal = await _context.Goals.FindAsync(id);
            if (goal == null)
            {
                return NotFound();
            }

            _context.Goals.Remove(goal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // : api/Goal/5
        //


        private bool GoalExists(int id)
        {
            return (_context.Goals?.Any(e => e.GoalId == id)).GetValueOrDefault();
        }
    }
}
