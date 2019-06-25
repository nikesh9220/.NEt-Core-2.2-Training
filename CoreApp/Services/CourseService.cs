using CoreApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Services
{
    public class CourseService : IService<Course, int>
    {
        ApplicationDbContext ctx;
        /// <summary>
        /// Injecting the ApplicationDbContext as Dependancy to Service Class 
        /// </summary>
        /// <param name="ctx"></param>
        public CourseService(ApplicationDbContext ctx)
        {
            this.ctx = ctx;
        }
        public async Task<Course> CreateAsync(Course entity)
        {
            var res =await ctx.Courses.AddAsync(entity);
            await ctx.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            bool result = false;
            var record = await ctx.Courses.FindAsync(id);
            if (record != null)
            {
                ctx.Courses.Remove(record);
                await ctx.SaveChangesAsync();
                result = true;
            }
            return result;
        }

        public async Task<IEnumerable<Course>> GetAsync()
        {
            try
            {
                return await ctx.Courses.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Course> GetAsync(int id)
        {
            var record = await ctx.Courses.FindAsync(id);
            return record;
        }

        public async Task<Course> UpdateAsync(int id, Course entity)
        {
            var record = await ctx.Courses.FindAsync(id);
            if (record != null)
            {
                //record.Update(entity);
                record.Capacity = entity.Capacity;
                record.CourseId = entity.CourseId;
                record.CourseName = entity.CourseName;
                await ctx.SaveChangesAsync();
            }
            return record;
        }
    }
}
