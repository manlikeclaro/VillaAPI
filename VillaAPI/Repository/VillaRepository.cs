﻿using System.Linq.Expressions;
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

    public new async Task CreateAsync(Villa entity)
    {
        entity.Created = DateTime.Now; // Set the Created date
        entity.Updated = null; // Set the Update date
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