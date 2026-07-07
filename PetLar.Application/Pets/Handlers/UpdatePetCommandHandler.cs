using MediatR;
using PetLar.Application.Pets.Commands;
using PetLar.Core.Interfaces;

namespace PetLar.Application.Pets.Handlers;

public class UpdatePetCommandHandler(IPetRepository _petRepository) : IRequestHandler<UpdatePetCommand, bool>
{
    public async Task<bool> Handle(UpdatePetCommand request, CancellationToken cancellationToken)
    {
        var pet = await _petRepository.GetByIdAsync(request.Id);
        if (pet is null)
            return false;

        if (pet.OwnerId != request.OwnerId)
            return false;

        pet.Name = request.Name;
        pet.Age = request.Age;
        pet.Gender = request.Gender;
        pet.Species = request.Species;
        pet.Size = request.Size;
        pet.Status = request.Status;

        await _petRepository.UpdateAsync(pet);
        return true;
    }
}
