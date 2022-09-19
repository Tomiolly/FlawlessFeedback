using FlawlessFeedbackAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlawlessFeedbackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionController : ControllerBase
    {
        SurveyQuestionContext _context;
        public OptionController(SurveyQuestionContext context)
        {
            _context = context;
        }

        // GET: api/<OptionController>

        /// <summary>
        /// Get List of Options
        /// </summary>
        /// <returns></returns>   
        [HttpGet]
        public IEnumerable<Option> Get()
        {
            return _context.Options.ToList();
        }

        // GET api/<OptionController>/5

        /// <summary>
        /// Get Option by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Option Get(int id)
        {
           // return _context.Options.Find(id);
            return _context.Options.Where(c => c.OptionID.Equals(id)).Include(c => c.Question).ThenInclude(c => c.Survey).FirstOrDefault();
        }

        // POST api/<OptionController>

        /// <summary>
        /// Post Option
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Option option)
        {
            if (option != null)
            {
                _context.Options.Add(option);
                _context.SaveChanges();
                return Ok(option);
            }
            return BadRequest();
        }

        // PUT api/<OptionController>/5

        /// <summary>
        /// Update an Existing Option [Authorized]
        /// </summary>
        /// <param name="id"></param>
        /// <param name="option"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Authorize]
        public ActionResult Put(int id, Option option)
        {
            //var existingOption = _context.Options.Find(option.OptionID);
            if (option != null)
            {
                _context.Options.Update(option);
                _context.SaveChanges();
                return Ok(option);
            }
            return NotFound();
        }

        /// <summary>
        /// Delete an Option [Authorized]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var option = _context.Options.Find(id);
            if (option != null)
            {
                _context.Remove(option);
                _context.SaveChanges();
                return Ok(option);
            }
            return BadRequest();
        }
    }
}
