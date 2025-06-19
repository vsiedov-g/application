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

    }
}
