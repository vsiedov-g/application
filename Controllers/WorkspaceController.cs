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
    public class WorkspaceController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WorkspaceController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var workspaces = await _unitOfWork.Workspace.GetAllAsync(includeProperties: "WorkspaceType");
            return Ok(_mapper.Map<IEnumerable<WorkspaceDto>>(workspaces));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Workspace workspace = await _unitOfWork.Workspace.GetAsync(u => id == u.Id, includeProperties: "WorkspaceType");
            if (workspace == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<WorkspaceDto>(workspace));
        }
    }
}
