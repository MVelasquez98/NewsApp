using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsApp.Core.Services.Contracts;
using NewsApp.Model;

namespace NewsApp.Api.Controllers
{
    [ApiController]
    [Route("api/news")]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        [HttpGet("search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<Article>>> GetNewsAsync([FromQuery] string dateFrom, [FromQuery] string dateTo, [FromQuery] string keywords, [FromQuery] int page, [FromQuery] int pageSize)
        {
            try
            {
                var news = await _newsService.GetNewsAsync(dateFrom, dateTo, keywords, page, pageSize);
                if (news != null && news.Count == 0)
                {
                    return NoContent();
                }
                return Ok(news);
            }
            catch (Exception ex)
            {
                // log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("top-headlines")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<Article>>> GetTopHeadlinesAsync([FromQuery] string country, [FromQuery] int page, [FromQuery] int pageSize)
        {
            try
            {
                var news = await _newsService.GetTopHeadlinesAsync(country, page, pageSize);
                if (news != null && news.Count == 0)
                {
                    return NoContent();
                }
                return Ok(news);
            }
            catch (Exception ex)
            {
                // log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
