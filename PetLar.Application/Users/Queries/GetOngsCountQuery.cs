using MediatR;
using PetLar.Application.Common.Results;

namespace PetLar.Application.Users.Queries;

public record GetOngsCountQuery() : IRequest<Result<int>>;
