using MediatR;
using PetLar.Application.Common.Results;

namespace PetLar.Application.Adoption.Queries;

public record GetCompletedAdoptionsCountQuery : IRequest<Result<int>>;
