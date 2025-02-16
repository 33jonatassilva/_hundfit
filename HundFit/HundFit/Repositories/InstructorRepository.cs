﻿using HundFit.Data;
using HundFit.Data.Models;
using HundFit.DTOs;
using HundFit.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace HundFit.Repositories;

public class InstructorRepository : IInstructorRepository
{
    
    
    
    private readonly AppDbContext _context;

    public InstructorRepository(AppDbContext context)
    {
        _context = context;
    }
    
    
    
    public async Task<Instructor> CreateAsync(Instructor instructor)
    {
        try
        {
            await _context.Instructors.AddAsync(instructor);
            await _context.SaveChangesAsync();
            return instructor;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }


    public async Task<IEnumerable<Instructor>> GetAllAsync()
    {
        try
        {
            return await _context.Instructors.ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }


    public async Task<Instructor> GetByIdAsync (Guid id)
    {
        try
        {
            var instructor = await _context.Instructors.FirstOrDefaultAsync(x => x.Id == id);
            
            if (instructor == null) throw new KeyNotFoundException("Instructor not found");
            
            return instructor;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Instructor> GetByIdWithStudentsAsync(Guid id)
    {
        try
        {
            var instructors = await _context.Instructors
                .Include(x => x.Students)
                .FirstOrDefaultAsync(x => x.Id == id);
            
            
            if (instructors == null) throw new KeyNotFoundException("Instructor not found");
            
            return instructors;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
    


    public async Task<Instructor> UpdateAsync(Instructor instructor)
    {
        try
        {
            var updatedInstructor = _context.Update(instructor).Entity;
            await _context.SaveChangesAsync();
            return updatedInstructor;
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
            var instructor = await _context.Instructors.FirstOrDefaultAsync(x => x.Id == id);
            if (instructor == null)
            {
                throw new KeyNotFoundException("Instructor not found");
            }

            _context.Instructors.Remove(instructor);
            await _context.SaveChangesAsync(); 
        }
        catch (Exception e)
        {
            throw new Exception($"Error deleting instructor: {e.Message}", e);
        }
    }

}