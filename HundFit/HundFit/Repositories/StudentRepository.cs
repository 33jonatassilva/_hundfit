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


    public Task<Student> DeleteAsync(Guid id)
    {
        var student = _context.Students.FirstOrDefaultAsync(x => x.Id == id);
        _context.Remove(student);
        _context.SaveChanges();
        return student;
    }
}