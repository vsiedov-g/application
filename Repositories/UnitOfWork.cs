using System;
using application.Data;
using application.Models;
using application.Repositories.IRepositories;
using static application.Repositories.IRepositories.IRepository;

namespace application.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;

        public IRepository<Coworking> Coworking { get; private set; }
        public IRepository<Booking> Booking { get; private set; }
        public IRepository<Workspace> Workspace { get; private set; }
        public IRepository<WorkspaceType> WorkspaceType { get; private set; }
        public IRepository<Amenity> Amenity { get; private set; }

        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            Coworking = new Repository<Coworking>(_db);
            Booking = new Repository<Booking>(_db);
            Workspace = new Repository<Workspace>(_db);
            WorkspaceType = new Repository<WorkspaceType>(_db);
            Amenity = new Repository<Amenity>(_db);
        }
        
        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
