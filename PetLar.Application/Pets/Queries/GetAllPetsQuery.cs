using MediatR;
using PetLar.Application.Common.Results;
using PetLar.Application.Pets.DTOs;

namespace PetLar.Application.Pets.Queries;

public record GetAllPetsQuery() : IRequest<Result<IEnumerable<PetDto>>>;
