using FlawlessFeedbackAPI.Models;
using FlawlessFeedbackAPI.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlawlessFeedbackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        SurveyQuestionContext _context;

        public SurveyController(SurveyQuestionContext context)
        {
            _context = context;
        }


        // GET: api/<SurveyController>
        /// <summary>
        ///  Get list of Surveys
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Survey> Get()
        {
            return _context.Surveys.ToList();
        }

        /// <summary>
        /// Get Single Survey
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Survey Get(int id)
        {
            return _context.Surveys.Find(id);
        }

        /// <summary>
        /// Post Survey
        /// </summary>
        /// <param name="survey"></param>
        /// <returns></returns>
        // POST api/<SurveyController>
        [HttpPost]
        public IActionResult Post(Survey survey)
        {
            if (survey != null)
            {
                _context.Surveys.Add(survey);
                _context.SaveChanges();
                return Ok(survey);
            }
            return BadRequest();
        }

        /// <summary>
        /// Put Survey [Authorized only]
        /// </summary>
        /// <param name="survey"></param>
        /// <returns></returns>
        // PUT api/<SurveyController>/5
        [Authorize]
        [HttpPut("{id}")]
        public ActionResult Put(Survey survey)
        {
            //var existingSurvey = _context.Surveys.Find(survey.SurveyID);
            if (survey != null)
            {
                _context.Surveys.Update(survey).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return Ok(survey);
            }
            return NotFound();
        }

        /// <summary>
        /// Delete Survey [Authorized only]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var survey = _context.Surveys.Find(id);
            if (survey != null)
            {
                _context.Remove(survey);
                _context.SaveChanges();
                return Ok(survey);
            }
            return BadRequest();
        }
        /// <summary>
        /// Generates the Survey Report for Bar Chart
        /// </summary>
        /// <returns></returns>
        [HttpGet("NumberOfQuestions")]
        public ActionResult GenerateSurveyReport()
        {
            List<SurveyQuestionReportViewModel> svyViewModelList = new List<SurveyQuestionReportViewModel>();

            foreach (var survey in _context.Surveys.ToList())
            {
                int questionCount = 0;

                foreach(var question in _context.Questions.ToList().Where(c => c.SurveyID == survey.SurveyID))
                {
                    questionCount++;
                }

                var svyViewModel = new SurveyQuestionReportViewModel
                {
                    SurveyTopic = survey.SurveyTopic,
                    NumberOfQuestions = questionCount
                };

                svyViewModelList.Add(svyViewModel);
            }
            return Ok(svyViewModelList);
        }
    }
}
