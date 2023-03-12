using BankTizimlari.Domain.Entities.Products;
using BankTIzimlati.Data.BankDBContexts;
using BankTIzimlati.Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace BankTIzimlati.Data.Repositories
{

    public class ApiUserRepositorie : IApiUserRepositorie
    {
        AppDbContext context;
        public ApiUserRepositorie(AppDbContext _context)
        {
            context = _context;
        }

        public async Task Add(ApiUser user)
        {
           await context.users.AddAsync(user);
           await context.SaveChangesAsync();
        }

        public async Task Delete(Guid Id)
        {
           var User = await context.users.FirstOrDefaultAsync(p => p.Id== Id); 
            context.users.Remove(User);
            await context.SaveChangesAsync();
        }

        public async Task<IList<ApiUser>> GetAll()
        {
            return await context.users.Include(p => p.bankName).ToListAsync();
        }

        public async Task<ApiUser> GetById(Guid Id)
        {
            return await context.users.Include(p => p.bankName).FirstOrDefaultAsync(p => p.Id == Id);
        }

        public async Task Update(Guid Id, ApiUser user)
        {
            var OldUser = await context.users.FirstOrDefaultAsync(p => p.Id == Id);
            user.Id = Id;
            context.users.Attach(OldUser).CurrentValues
                         .SetValues(user);
            await context.SaveChangesAsync();
        }
    }
}
