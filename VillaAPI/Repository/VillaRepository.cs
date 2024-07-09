using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using VillaAPI.Data;
using VillaAPI.Models;
using VillaAPI.Repository.IRepository;

namespace VillaAPI.Repository;

public class VillaRepository : Repository<Villa>, IVillaRepository
{
    private readonly ApplicationDbContext _db;

    public VillaRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }

    // public async Task<Villa> UpdateAsync(Villa entity)
    // {
    //     entity.Updated = DateTime.Now; // Update the Updated date
    //     _db.Villas.Update(entity);
    //     await _db.SaveChangesAsync();
    //     return entity;
    // }

    public new async Task CreateAsync(Villa entity)
    {
        entity.Created = DateTime.Now; // Set the Created date
        await _dbSet.AddAsync(entity);
        await SaveAsync();
    }

    public new async Task UpdateAsync(Villa entity)
    {
        entity.Updated = DateTime.Now; // Update the Updated date
        _dbSet.Update(entity);
        await SaveAsync();
    }
}