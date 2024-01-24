using MediatR;

namespace Application.Person.Commands
{
    public class DeletePerson : IRequest<Domain.Entities.Person>
    {
        public int Id { get; set; }
    }
}
