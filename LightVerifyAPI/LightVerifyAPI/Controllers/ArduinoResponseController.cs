using LightVerifyAPI.Models;
using LightVerifyAPI.Other;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LightVerifyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArduinoResponseController : ControllerBase
    {
        private readonly LightVerifyAPIContext _context;

        public ArduinoResponseController(LightVerifyAPIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArduinoResponse>>> GetArduinoResponse()
        {
            return await _context.ArduinoResponses.ToListAsync();
;       }

        [HttpGet("{id}")]
        public async Task<ActionResult<ArduinoResponse>> GetArduinoResponseById(int id)
        {
            var course = await _context.ArduinoResponses.Where(c => c.Id.Equals(id)).FirstOrDefaultAsync();      
            if(course == null)
            {
                return NotFound();
            }
            return course;
        }

        [HttpPost]
        public async Task<ActionResult<ArduinoResponse>> SetResponse(string arduinoResponse_s) //s == status
        {
            ArduinoResponse arduinoResponse = new ArduinoResponse { Date = GetDate(), Time = GetTime(), Status = arduinoResponse_s };
            _context.ArduinoResponses.Add(arduinoResponse);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetArduinoResponseById), new { id = arduinoResponse.Id }, arduinoResponse);
        }


        /*[HttpPost]
        public async Task<ActionResult<ArduinoResponse>> SetArduinoResponse(string date_s, string time_s, string arduinoResponse_s) //s == status
        {
            ArduinoResponse arduinoResponse = new ArduinoResponse { Date = date_s, Time = time_s, Status = arduinoResponse_s };
            _context.ArduinoResponses.Add(arduinoResponse);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetArduinoResponseById), new { id = arduinoResponse.Id }, arduinoResponse);
        }*/
        
        
        private string GetDate()
        {
            string day = "";

            string fullDate = DateTime.Today.ToString();
            if (fullDate.Length > 10)
                fullDate = fullDate.Substring(0, 10);

            switch (DateTime.Now.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    day = "Mon";
                    break;

                case DayOfWeek.Tuesday:
                    day = "Tue";
                    break;

                case DayOfWeek.Wednesday:
                    day = "Wed";
                    break;

                case DayOfWeek.Thursday:
                    day = "Thu";
                    break;

                case DayOfWeek.Friday:
                    day = "Fri";
                    break;

                case DayOfWeek.Saturday:
                    day = "Sat";
                    break;

                case DayOfWeek.Sunday:
                    day = "Sun";
                    break;
            }

            return day + ". " + fullDate;
        }

        private string GetTime()
        {
            string hour = DateTime.Now.TimeOfDay.ToString();
            if (hour.Length > 8)
                hour = hour.Substring(0, 8);

            return hour;
        }
    }
}
