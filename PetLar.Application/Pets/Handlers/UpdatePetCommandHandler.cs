using MediatR;
using PetLar.Application.Common.Results;
using PetLar.Application.Pets.Commands;
using PetLar.Application.Pets.Errors;
using PetLar.Core.Interfaces;

namespace PetLar.Application.Pets.Handlers;

public class UpdatePetCommandHandler(IPetRepository _petRepository) : IRequestHandler<UpdatePetCommand, Result>
{
    public async Task<Result> Handle(UpdatePetCommand request, CancellationToken ct)
    {
        var pet = await _petRepository.GetByIdAsync(request.Id, ct);
        if (pet is null)
            return Result.Failure(PetErrors.PetNotFound);

        if (pet.OwnerId != request.OwnerId)
            return Result.Failure(PetErrors.PetNotOwnedByUser);

        pet.Name = request.Name;
        pet.Age = request.Age;
        pet.Gender = request.Gender;
        pet.Species = request.Species;
        pet.Size = request.Size;
        pet.Status = request.Status;

        await _petRepository.UpdateAsync(pet, ct);
        return Result.Success();
    }
}
