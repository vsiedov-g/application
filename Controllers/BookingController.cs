using System;
using System.ComponentModel;
using application.Exceptions;
using application.Models;
using application.Models.DTO;
using application.Repositories.IRepositories;
using application.Services.IService;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;


namespace application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : Controller
    {
         private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IBookingService _bookingService;

        public BookingController(IUnitOfWork unitOfWork, IMapper mapper, IBookingService bookingService) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _bookingService = bookingService;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var bookings = await _unitOfWork.Booking.GetAllAsync(includeProperties: "Workspace.WorkspaceType");
            if(bookings == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<BookingResponce>>(bookings));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var booking = await _unitOfWork.Booking.GetAsync(u => id == u.Id, includeProperties: "Workspace.WorkspaceType");
            if(booking == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<BookingResponce>(booking));
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateBooking([FromBody] BookingRequest req)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            try
            {
                Booking booking = await _bookingService.CreateBookingAsync(req);
                return Ok(booking.Id);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateBooking([FromBody] BookingRequest req)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                Booking booking = await _bookingService.UpdateBookingAsync(req);
                return Ok(booking.Id);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var booking = await _unitOfWork.Booking.GetAsync(u => id == u.Id);
            if(booking == null)
            {
                return NotFound();
            }
            _unitOfWork.Booking.Remove(booking);
            await _unitOfWork.SaveAsync();
            return Ok(booking.Id);
        }

    }
    
}
