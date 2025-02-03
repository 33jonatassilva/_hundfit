using HundFit.Data;
using HundFit.Data.Models;
using HundFit.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HundFit.Repositories;

public class StudentRepository : IStudentRepository
{
    public readonly AppDbContext _context;


    public StudentRepository(AppDbContext context)
    {
        _context = context;
    }



    public async Task<Student> CreateAsync(Student student)
    {
        await _context.Students.AddAsync(student);
        await _context.SaveChangesAsync();
        return student;
    }


    public async Task<IEnumerable<Student>>GetAllAsync()
    {
        return await _context.Students.ToListAsync();
    }


    public async Task<Student> GetByIdAsync(Guid id)
    {
        return await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
    }


    public async Task<Student> UpdateAsync(Student student)
    {
        _context.Update(student);
        await _context.SaveChangesAsync();
        return student;
    }


    public async Task DeleteAsync(Guid id)
    {
        
        try
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (student == null)
            {
                throw new KeyNotFoundException("Student not found");
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync(); 
        }
        catch (Exception e)
        {
            throw new Exception($"Error deleting student: {e.Message}", e);
        }
        
        
        /*var student = _context.Students.FirstOrDefaultAsync(x => x.Id == id);
        _context.Remove(student);
        _context.SaveChanges();
        return student;*/


    }
}