using MediatR;

namespace Application.Person.Commands
{
    public class UpdatePerson : IRequest<Domain.Entities.Person>
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}
