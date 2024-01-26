using Aidn.NewsScore.Communication;
using Aidn.NewsScore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aidn.NewsScore.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class NewsScoreController : ControllerBase
    {
        private readonly ILogger<NewsScoreController> _logger;

        IScoreRequestValidator _scoreValidator;
        IScoreResponseEvaluator _scoreEvaluator;

        public NewsScoreController(ILogger<NewsScoreController> logger, IScoreRequestValidator scoreValidator, IScoreResponseEvaluator scoreEvaluator)
        {
            _logger = logger;

            _scoreValidator = scoreValidator;
            _scoreEvaluator = scoreEvaluator;
        }

        [HttpPost(Name = "PostNewsScore")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Post(RequestMeasurements request)
        {
            if (!_scoreValidator.IsValid(request))
            {
                _logger.LogWarning("Values out of scope");
                return BadRequest("Values out of scope.");
            }

            int score = _scoreEvaluator.Evaluate(request);

            return Ok(new ResponseScore() { 
                Score = score 
            });
        }
    }
}
