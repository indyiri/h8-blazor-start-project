using Microsoft.EntityFrameworkCore;
using TodoApp.Application.Interfaces;
using TodoApp.Domain.Entities;
using TodoApp.Infrastructure.Data;

namespace TodoApp.Infrastructure.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public TodoRepository(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<List<TodoItem>> GetAllAsync()
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            return await context.TodoItems.ToListAsync();
        }

        public async Task<TodoItem?> GetByIdAsync(int id)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            return await context.TodoItems.FindAsync(id);
        }

        public async Task AddAsync(TodoItem item)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();

            context.TodoItems.Add(item);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TodoItem item)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();

            context.TodoItems.Update(item);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();

            var item = await context.TodoItems.FindAsync(id);
            if (item != null)
            {
                context.TodoItems.Remove(item);
                await context.SaveChangesAsync();
            }
        }
    }
}
