using BankTizimlari.Domain.Entities.Products;
using BankTIzimlati.Data.BankDBContexts;
using BankTIzimlati.Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace BankTIzimlati.Data.Repositories
{
    public class BankRepasitories : IBankRepositories
    {
        AppDbContext context;
        public BankRepasitories(AppDbContext context)
        {
            this.context = context;
        }

        public async Task Add(Bank bank)
        {
            await context.banks.AddAsync(bank);
            await context.SaveChangesAsync();
        }

        public async Task AddUseerBank(Guid IdUser, Guid IdBank)
        {
            var Addbank = await context.banks.FirstOrDefaultAsync(p => p.Id == IdBank);
            var Adduser = await context.users.FirstOrDefaultAsync(u => u.Id == IdUser);

            Addbank.userName.Add(Adduser);
            await context.SaveChangesAsync();
        }

        public async Task DeleteById(Guid Id)
        {
            var Bank = await context.banks.Include(p => p.userName).FirstOrDefaultAsync(p => p.Id == Id);
            context.banks.Remove(Bank);
            await context.SaveChangesAsync();
        }

        public async Task<IList<Bank>> GetAll()
        {
            return await context.banks.Include(p => p.userName).ToListAsync();
        }

        public async Task<Bank> GetById(Guid Id)
        {
            return await context.banks.FirstOrDefaultAsync(p => p.Id == Id);
        }

        public async Task Update(Guid Id, Bank bank)
        {
            var OldBank = await context.banks.FirstOrDefaultAsync(p => p.Id == Id);
            bank.Id = Id;
            context.banks.Attach(OldBank).CurrentValues
                .SetValues(bank);
            await context.SaveChangesAsync();
        }
    }
}
