using System;
using application.Exceptions;
using application.Models;
using application.Models.DTO;
using application.Repositories.IRepositories;
using application.Services.IService;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;

namespace application.Services
{
    public class BookingService : IBookingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookingService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Booking> CreateBookingAsync(BookingRequest req)
        {
            var availableWorkspace = await FindAvailableWorkspace(req);

            if (availableWorkspace == null)
            {
                throw new InvalidOperationException("No available workspace found.");
            }

            Booking booking = _mapper.Map<Booking>(req);
            booking.WorkspaceId = availableWorkspace.Id;
            _unitOfWork.Booking.Add(booking);
            await _unitOfWork.SaveAsync();
            return booking;
        }

        public async Task<Booking> UpdateBookingAsync(BookingRequest req)
        {
            Booking? booking = await _unitOfWork.Booking.GetAsync(b => b.Id == req.Id);
            if (booking == null)
            {
                throw new NotFoundException("Booking not found.");
            }
            var availableWorkspace = await FindAvailableWorkspace(req);

            if (availableWorkspace == null)
            {
                throw new InvalidOperationException("No available workspace found.");
            }

            _mapper.Map(req, booking);
            booking.WorkspaceId = availableWorkspace.Id;
            _unitOfWork.Booking.Update(booking);
            await _unitOfWork.SaveAsync();
            return booking;
        }

        public async Task<Workspace> FindAvailableWorkspace(BookingRequest req)
        {
            var workspaces = await _unitOfWork.Workspace.GetAllAsync(w => req.WorkspaceTypeId == w.WorkspaceTypeId && req.Capacity == w.Capacity);

            var workspaceIds = workspaces.Select(w => w.Id).ToList();

            var bookings = await _unitOfWork.Booking.GetAllAsync(b => workspaceIds.Contains(b.WorkspaceId));

            var overlappingBookings = bookings.Where(b => (req.Id == 0 || b.Id != req.Id) &&
                b.EndDate >= req.StartDate && b.StartDate <= req.EndDate &&
                b.EndTime >= req.StartTime && b.StartTime <= req.EndTime).Select(b => b.WorkspaceId).ToHashSet();

            return workspaces.Where(w => !overlappingBookings.Contains(w.Id)).FirstOrDefault()!;
        }

    
    }
}
