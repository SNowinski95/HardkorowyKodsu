using DbAPI.DB.Models;
using DbAPI.DB.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DbAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TableController : ControllerBase
    {
        private readonly ITableRepository _tableRepository;

        public TableController(ITableRepository tableRepository)
        {
            ArgumentNullException.ThrowIfNull(tableRepository);
            _tableRepository = tableRepository;
        }

        [HttpGet("GetTables")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<string>>> GetTables()
        {
            return Ok(await _tableRepository.GetAllTablesAsync());
        }
        [HttpGet("GetViews")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<string>>> GetViews()
        {
            return Ok(await _tableRepository.GetAllViewsAsync());
        }
        [HttpGet("GetColumns/{tableName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Column>>> GetColumns(string tableName)
        {
            if (string.IsNullOrWhiteSpace(tableName))
            {
                return BadRequest("table name can not be epmty");
            }
            return Ok(await _tableRepository.GetColumnsAsync(tableName));
        }
    }
}
