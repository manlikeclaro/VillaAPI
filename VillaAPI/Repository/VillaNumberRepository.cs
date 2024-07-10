using VillaAPI.Data;
using VillaAPI.Models;
using VillaAPI.Repository.IRepository;

namespace VillaAPI.Repository;

public class VillaNumberRepository: Repository<VillaNumber>, IVillaNumberRepository
{
    private readonly ApplicationDbContext _db;

    public VillaNumberRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }

    public new async Task CreateAsync(VillaNumber entity)
    {
        entity.Created = DateTime.Now; // Set the Created date
        await _dbSet.AddAsync(entity);
        await SaveAsync();
    }

    public new async Task UpdateAsync(VillaNumber entity)
    {
        entity.Updated = DateTime.Now; // Update the Updated date
        _dbSet.Update(entity);
        await SaveAsync();
    }
}