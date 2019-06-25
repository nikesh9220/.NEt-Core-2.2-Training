using CoreApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreApp.Services
{
    public class StudentServices : IService<Student, int>
    {
        ApplicationDbContext ctx;
        public StudentServices(ApplicationDbContext ctx)
        {
            this.ctx = ctx;
        }
        public async Task<Student> CreateAsync(Student entity)
        {
            var res = await ctx.Students.AddAsync(entity);
            await ctx.SaveChangesAsync();
            return res.Entity;
        }
        public async Task<Student> CreateAsync(List<Student> entity)
        {
            foreach (var student in entity)
            {
                await ctx.Students.AddAsync(student);
                await ctx.SaveChangesAsync();
            }
            
            return null;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            bool result = false;
            var record = await ctx.Students.FindAsync(id);
            if (record != null)
            {
                ctx.Students.Remove(record);
                await ctx.SaveChangesAsync();
                result = true;
            }
            return result;
        }

        public async Task<IEnumerable<Student>> GetAsync()
        {
            return await ctx.Students.ToListAsync();
        }

        public async Task<Student> GetAsync(int id)
        {
            var record = await ctx.Students.FindAsync(id);
            return record;
        }

        public async Task<Student> UpdateAsync(int id, Student entity)
        {
            var record = await ctx.Students.FindAsync(id);
            if (record != null)
            {
                ctx.Students.Update(entity);
                await ctx.SaveChangesAsync();
            }
            return record;
        }
    }
}
