﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using quested_backend.Domain.Requests.School;
using quested_backend.Domain.Services;

namespace quested_backend.Controllers
{
    public class SchoolController : ControllerBase
    {
        private readonly ISchoolService _schoolService;

        public SchoolController(ISchoolService schoolService)
        {
            _schoolService = schoolService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _schoolService.GetSchoolsAsync();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _schoolService.GetSchoolAsync(
                new GetSchoolRequest{ Id = id });
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddSchoolRequest schoolRequest)
        {
            var result = await _schoolService.AddSchoolAsync(schoolRequest);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, null );
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, EditSchoolRequest schoolRequest)
        {
            schoolRequest.Id = id;
            var result = await _schoolService.EditSchoolAsync(schoolRequest);
            return Ok(result);
        }
    }
}