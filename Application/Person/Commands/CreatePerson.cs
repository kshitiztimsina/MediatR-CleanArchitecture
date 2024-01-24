using MediatR;
namespace Application.Person.Commands
{
    public class CreatePerson : IRequest<Domain.Entities.Person>
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}
