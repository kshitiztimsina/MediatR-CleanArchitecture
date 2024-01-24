using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Repository.Interface
{
    public interface IPersonRepository
    {
        Task<ICollection<Domain.Entities.Person>> GetAll();
        Task<Domain.Entities.Person> GetPersonById(int personId);
        Task<Domain.Entities.Person> AddPerson(Domain.Entities.Person toCreate);
        Task<Domain.Entities.Person> UpdatePerson(int personId, string name, string email);
        Task DeletePerson(int personId);
    };
}
