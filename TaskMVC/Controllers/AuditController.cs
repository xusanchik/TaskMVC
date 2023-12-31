﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskMVC.Entity;
using TaskMVC.Interface;

namespace TaskMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditController : ControllerBase
    {
        private readonly IAuditRepository _context;
        public AuditController(IAuditRepository auditRepository) => _context = auditRepository;
        [HttpGet("List")]
        [ProducesResponseType(typeof(List<AuditLogViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAudits() => Ok(await _context.GetAllAudits());

        [HttpGet("Date")]
        [ProducesResponseType(typeof(List<AuditLogViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetFiltered(string? fromDate, string? toDate)
        {
            try
            {
                return Ok(await _context.GetFiltered(fromDate, toDate));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Name")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SortByUserName(string name)
        {
            try
            {
                return Ok(await _context.SortByUserName(name));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}

