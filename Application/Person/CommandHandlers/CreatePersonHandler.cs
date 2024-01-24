using Application.Person.Commands;
using Application.Repository.Interface;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Person.CommandHandlers
{
    public class CreatePersonHandler : IRequestHandler<CreatePerson, Domain.Entities.Person>
    {
        private readonly IPersonRepository _personRepository;
        public CreatePersonHandler(IPersonRepository personRepository)
        {
                _personRepository = personRepository;
        }
        public async Task<Domain.Entities.Person> Handle(CreatePerson request, CancellationToken cancellationToken)
        {
            Domain.Entities.Person person = new Domain.Entities.Person
            {
                Name = request.Name,
                Email = request.Email
            };
            return await _personRepository.AddPerson(person);
        }
    }
}
