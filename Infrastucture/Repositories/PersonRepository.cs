using Application.Repository.Interface;
using Domain.Entities;
using Infrastucture.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastucture.Repositories
{
    public class PersonRepository : IPersonRepository
    {

        private readonly AppDbContext _context;

        public PersonRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Person> AddPerson(Person toCreate)
        {
            _context.person.Add(toCreate);

            await _context.SaveChangesAsync();

            return toCreate;
        }

        public async Task DeletePerson(int personId)
        {
            var person = _context.person
                .FirstOrDefault(p => p.Id == personId);

            if (person is null) return;

            _context.person.Remove(person);

            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Person>> GetAll()
        {
            return await _context.person.ToListAsync();
        }

        public async Task<Person> GetPersonById(int personId)
        {
            return await _context.person.FirstOrDefaultAsync(p => p.Id == personId);
        }

        public async Task<Person> UpdatePerson(int personId, string name, string email)
        {
            var person = await _context.person.FirstOrDefaultAsync(p => p.Id == personId);
            person.Name = name;
            person.Email = email;

            await _context.SaveChangesAsync();
            return person;
        }
    }
}
