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
    public class QuestionController : ControllerBase
    {

        SurveyQuestionContext _context;

        public QuestionController(SurveyQuestionContext context)
        {
            _context = context;
        }

        /// <summary>
        ///  Get list of Questions by Survey ID
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetBySurvey/{id}")]
        public ActionResult GetBySurveyId(int id)
        {
            return Ok(_context.Surveys.Where(c => c.SurveyID == id)
                                .Include(c => c.Questions)
                                .FirstOrDefault().Questions);
        }

        // GET: api/<QuestionController>

        /// <summary>
        /// Get list of Questions
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Question> Get()
        {

            return _context.Questions.Include(c => c.Survey).ToList();
        }

        // GET api/<QuestionController>/5

        /// <summary>
        /// Get Single Question
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]

        public Question Get(int id)
        {
            // return _context.Questions.Find(id);
            return _context.Questions.Where(c => c.QuestionID.Equals(id)).Include(c => c.Survey).FirstOrDefault();
        }

        // POST api/<QuestionController>

        /// <summary>
        /// Post Question
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Question question)
        {
            if (question != null)
            {
                _context.Questions.Add(question);
                _context.SaveChanges();
                return Ok(question);
            }
            return BadRequest();
        }

        // PUT api/<QuestionController>/5

        /// <summary>
        /// Update an Existing Question [Authorized]
        /// </summary>
        /// <param name="id"></param>
        /// <param name="question"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut("{id}")]
        public ActionResult Put(int id, Question question)
        {
           // var existingQuestion = _context.Questions.Find(question.QuestionID);
            if (question != null)
            {
                _context.Questions.Update(question);
                _context.SaveChanges();
                return Ok(question);
            }
            return NotFound();
        }

        /// <summary>
        /// Delete an Existing Question
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var question = _context.Questions.Find(id);
            if (question != null)
            {
                _context.Remove(question);
                _context.SaveChanges();
                return Ok(question);
            }
            return BadRequest();
        }
    }
}
