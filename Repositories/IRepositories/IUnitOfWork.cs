using System;
using application.Models;
using static application.Repositories.IRepositories.IRepository;

namespace application.Repositories.IRepositories
{
    public interface IUnitOfWork
    {
        IRepository<Booking> Booking { get; }
        IRepository<Workspace> Workspace { get; }
        IRepository<WorkspaceType> WorkspaceType { get; }
        IRepository<Amenity> Amenity { get; }
        Task SaveAsync();
    }
}
