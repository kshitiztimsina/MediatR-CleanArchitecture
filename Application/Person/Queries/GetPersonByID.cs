using MediatR;

namespace Application.Person.Queries
{
    public class GetPersonByID : IRequest<Domain.Entities.Person>
    {
        public int Id { get; set; }
    }
}
