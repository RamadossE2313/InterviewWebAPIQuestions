using MediatR;

namespace InterviewWebAPIQuestions.Commands
{
    public record DeleteProductCommand(int Id) : IRequest<bool>;
}
