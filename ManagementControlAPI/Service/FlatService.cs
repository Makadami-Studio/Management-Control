using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManagementControlAPI.Controllers;
using ManagementControlAPI.Data;
using ManagementControlAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagementControlAPI.Service
{
    public class FlatService : IFlatService
    {
        private readonly DatabaseContext _context;

        public FlatService(DatabaseContext context)
        {
            _context = context;
        }

        public void CreateFlat(Flat flat)
        {
            flat.CreatedAt = DateTime.Now;
            flat.UpdatedAt = DateTime.Now;
            _context.Flats.Add(flat);
            _context.SaveChanges();
        }

        public List<Flat> GetAllFlats()
        {
            return _context.Flats
                .Include(f => f.Users)
                .Include(f => f.Owner)
                .Include(f => f.Tasks)
                .ToList();
        }

        public Flat? GetFlatById(int id)
        {
            return _context.Flats
                .Include(f => f.Users)
                .Include(f => f.Owner)
                .Include(f => f.Tasks)
                .FirstOrDefault(f => f.Id == id);
        }

        public void DeleteFlat(int id)
        {
            var flat = _context.Flats.Find(id);
            if (flat != null)
            {
                _context.Flats.Remove(flat);
                _context.SaveChanges();
            }
        }

        public void UpdateFlat(Flat flat)
        {
            flat.UpdatedAt = DateTime.Now;
            _context.Flats.Update(flat);
            _context.SaveChanges();
        }

        public void AddUserToFlat(int flatId, User user)
        {
            var flat = _context.Flats.Include(f => f.Users).FirstOrDefault(f => f.Id == flatId);
            var userFromDb = _context.Users.Find(user.Id);

            if (flat != null && userFromDb != null && !flat.Users.Any(u => u.Id == user.Id))
            {
                flat.Users.Add(userFromDb);
                _context.SaveChanges();
            }
        }

        public void RemoveUserFromFlat(int flatId, int userId)
        {
            var flat = _context.Flats.Include(f => f.Users).FirstOrDefault(f => f.Id == flatId);
            var user = _context.Users.Find(userId);

            if (flat != null && user != null && flat.Users.Contains(user))
            {
                flat.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public List<User> GetUsersInFlat(int flatId)
        {
            return _context.Flats
                .Include(f => f.Users)
                .FirstOrDefault(f => f.Id == flatId)?
                .Users ?? new List<User>();
        }

        public List<Tasks> GetTasksInFlat(int flatId)
        {
            return _context.Tasks
                .Include(t => t.AssignedTo)
                .Include(t => t.CreatedBy)
                .Include(t => t.UpdatedBy)
                .Where(t => t.AssignedFlatId == flatId)
                .ToList();
        }

        object IFlatService.GetFlatById(int id)
        {
            return GetFlatById(id) ?? throw new InvalidOperationException("Flat not found.");
        }

        object IFlatService.GetTasksInFlat(int flatId)
        {
            return GetTasksInFlat(flatId);
        }

        object IFlatService.GetUsersInFlat(int flatId)
        {
            return GetUsersInFlat(flatId);
        }
    }
}