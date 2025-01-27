using HundFit.Data;
using HundFit.Models;
using HundFit.Repositories.Interfaces;

namespace HundFit.Repositories;

public class InstructorRepository : IInstructorRepository
{
    
    
    
    private readonly AppDbContext _context;

    public InstructorRepository(AppDbContext context)
    {
        _context = context;
    }
    
    
    
    public Instructor CreateInstructor(Instructor instructor)
    {
        _context.Instructors.Add(instructor);
        _context.SaveChanges();
        return instructor;
    }


    public List<Instructor> GetInstructors()
    {
        return _context.Instructors.ToList();
    }


    public Instructor GetInstructorById(Guid id)
    {
        return _context.Instructors.FirstOrDefault(x => x.Id == id);
    }


    public Instructor Update(Instructor instructor)
    {
        var updatedInstructor = _context.Update(instructor).Entity;
        _context.SaveChanges();
        return updatedInstructor;
    }


    public Instructor DeleteInstructor(Instructor instructor)
    {
        _context.Remove(instructor);
        _context.SaveChanges();
        return instructor;
    }
}