using MediatR;
using PetLar.Application.Pets.Queries;
using PetLar.Application.Pets.DTOs;
using PetLar.Core.Interfaces;
using PetLar.Application.Common.Results;
using PetLar.Application.Pets.Errors;

namespace PetLar.Application.Pets.Handlers;

public class GetPetByIdQueryHandler(IPetRepository _petRepository) : IRequestHandler<GetPetByIdQuery, Result<PetDto>>
{
    public async Task<Result<PetDto>> Handle(GetPetByIdQuery request, CancellationToken ct)
    {
        var pet = await _petRepository.GetByIdAsync(request.Id, ct);
        if (pet is null)
            return Result<PetDto>.Failure(PetErrors.PetNotFound);

        var petDto = new PetDto(
            pet.Id,
            pet.Name,
            pet.Age,
            pet.Gender,
            pet.Species,
            pet.Size,
            pet.Status,
            pet.OngId
        );

        return Result<PetDto>.Success(petDto);
    }
}
