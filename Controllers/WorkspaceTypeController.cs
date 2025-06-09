using System;
using application.Models;
using application.Models.DTO;
using application.Repositories.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkspaceTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WorkspaceTypeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var workspaceTypes = await _unitOfWork.WorkspaceType.GetAllAsync(includeProperties: "Workspaces,Amenities");
            return Ok(_mapper.Map<IEnumerable<WorkspaceTypeDto>>(workspaceTypes));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            WorkspaceType workspaceType = await _unitOfWork.WorkspaceType.GetAsync(u => id == u.Id, includeProperties: "Workspaces,Amenities");
            if (workspaceType == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<WorkspaceTypeDto>(workspaceType));
        }

    }
}
