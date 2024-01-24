using Application.Person.Queries;
using Application.Repository.Interface;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Person.QueryHandlers
{
    public class GetPersonByIDHandler : IRequestHandler<GetPersonByID, Domain.Entities.Person>
    {
        private readonly IPersonRepository _personRepository;
        public GetPersonByIDHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;   
        }
        public Task<Domain.Entities.Person> Handle(GetPersonByID request, CancellationToken cancellationToken)
        {
            return _personRepository.GetPersonById(request.Id); 
        }
    }
}

