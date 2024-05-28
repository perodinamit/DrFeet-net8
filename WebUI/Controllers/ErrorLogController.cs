using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;
using System.Text.RegularExpressions;

namespace WebUI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ErrorLogController : Controller
    {
        private readonly string _logFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Logs", "logs.json");
        [HttpGet]
        public ActionResult<IEnumerable<LogEntry>> GetLogs()
        {
            if (!System.IO.File.Exists(_logFilePath))
            {
                return NotFound("Log file not found.");
            }

            var logLines = System.IO.File.ReadAllLines(_logFilePath);
            var logEntries = new ConcurrentBag<LogEntry>();

            Parallel.ForEach(logLines, line =>
            {
                var logEntry = ParseLogEntry(line);
                if (logEntry != null)
                {
                    logEntries.Add(logEntry);
                }
            });


            return Ok(logEntries);
        }



        private LogEntry ParseLogEntry(string logLine)
        {
            // Regex to match the log entry format
            var regex = new Regex(@"^(?<timestamp>\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2}\.\d{3} \+\d{2}:\d{2}) \[(?<level>\w+)\] (?<message>.+)$");
            var match = regex.Match(logLine);

            if (match.Success)
            {
                return new LogEntry
                {
                    Timestamp = DateTime.Parse(match.Groups["timestamp"].Value),
                    Level = match.Groups["level"].Value,
                    Message = match.Groups["message"].Value
                };
            }

            return null;
        }



        public class LogEntry
        {
            public DateTime Timestamp { get; set; }
            public string Level { get; set; }
            public string Message { get; set; }
        }
    }
}
