using MediatR;
using PetLar.Application.Pets.ViewModels;

namespace PetLar.Application.Pets.Queries;

public record GetPetByIdQuery(
    Guid Id
) : IRequest<PetViewModel?>;
