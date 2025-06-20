using System;
using application.Models.DTO;
using application.Repositories.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace application.Controllers
{
    [Route("api/coworkings")]
    [ApiController]
    public class CoworkingController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CoworkingController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var coworkings = await _unitOfWork.Coworking.GetAllAsync(includeProperties: "WorkspaceTypes.Workspaces");
            return Ok(_mapper.Map<IEnumerable<CoworkingDto>>(coworkings));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var coworking = await _unitOfWork.Coworking.GetAsync(c => c.Id == id, includeProperties: "WorkspaceTypes.Workspaces");
            if (coworking == null)
            {
                return NotFound("Coworking space not found");
            }
            return Ok(_mapper.Map<CoworkingDto>(coworking));
        }

        [HttpGet("{id}/workspaceTypes")]
        public async Task<IActionResult> GetAllCoworkingWorkspaceTypes(int id)
        {
            var coworking = await _unitOfWork.Coworking.GetAsync(c => c.Id == id, includeProperties: "WorkspaceTypes.Workspaces,WorkspaceTypes.Amenities");
            return Ok(_mapper.Map<IEnumerable<WorkspaceTypeDto>>(coworking.WorkspaceTypes));
        }

    }
}
