using System;
using application.Models;
using application.Models.DTO;
using application.Repositories.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace application.Controllers
{
    [Route("api/workspaces")]
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

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int? workspaceTypeId)
        {
            if (workspaceTypeId != null)
            {
                var workspaceType = await _unitOfWork.WorkspaceType.GetAsync(w => w.Id == workspaceTypeId, includeProperties: "Workspaces");
                if (workspaceType == null)
                {
                    return NotFound("Workspace type not found");
                }
                return Ok(_mapper.Map<IEnumerable<WorkspaceDto>>(workspaceType.Workspaces));
            }
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
