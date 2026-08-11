using MediatR;
using PetLar.Application.Common.Results;

namespace PetLar.Application.Pets.Queries;

public record GetAvailablePetsCountQuery : IRequest<Result<int>>;
