using HundFit.Data;
using HundFit.Data.Models;
using HundFit.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HundFit.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly AppDbContext _context;
    private IStudentRepository _studentRepositoryImplementation;


    public StudentRepository(AppDbContext context)
    {
        _context = context;
    }



    public async Task<Student> CreateAsync(Student student)
    {
        try
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return student;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }


    public async Task<IEnumerable<Student>>GetAllAsync()
    {
        try
        {
            return await _context.Students.ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }


    public async Task<Student> GetByIdAsync(Guid id)
    {
        try
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
            
            if (student == null) throw new KeyNotFoundException("Student not found");
            
            return student;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    


    public async Task<Student> GetByIdWithStudentStatsAsync(Guid id)
    {
        var student = await _context.Students
            .Include(s => s.StudentStats)
            .FirstOrDefaultAsync(x => x.Id == id);
        
        if (student == null) throw new KeyNotFoundException("Student not found");
        
        return student;
    }


    public async Task<Student> UpdateAsync(Student student)
    {
        try
        {
            _context.Update(student);
            await _context.SaveChangesAsync();
            return student;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }


    public async Task DeleteAsync(Guid id)
    {
        
        try
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
            
            if (student == null) throw new KeyNotFoundException("Student not found");
            

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