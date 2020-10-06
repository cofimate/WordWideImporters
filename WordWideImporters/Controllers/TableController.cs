using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WordWideImporters.Services;


namespace WordWideImporters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : Controller
    {
        private IWorldWideImporterTables _tableRepository { get; set; } 
        public TableController(IWorldWideImporterTables tableRepository) {
            _tableRepository = tableRepository;
        }

        //api/Table/tableName
        [HttpGet("{tableName}", Name = "GetTable")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public IActionResult GetTable(string tableName)
        {
            if (!_tableRepository.TableExists(tableName))
            {
                return NotFound();
            }

            var tableData = _tableRepository.GetTableData(tableName);

            if (!tableData.ContainsListCollection)
            {
                return BadRequest("Something bad");
            } else
            {
                return Ok(tableData);
            }
        }

        [HttpGet("table/paginated/{tableName}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public IActionResult GetTablePaginated(string tableName,int limit=10,int offset=0)
        {
            if (!_tableRepository.TableExists(tableName))
            {
                return NotFound();
            }

            var tableData = _tableRepository.GetTableData(tableName);

            if (!tableData.ContainsListCollection)
            {
                return BadRequest("Something bad");
            }
            else
            {
                return Ok(tableData);
            }
        }
    }
}
