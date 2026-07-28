using MediatR;
using PetLar.Application.Common.Results;
using PetLar.Application.Pets.Commands;
using PetLar.Core.Entities;
using PetLar.Core.Enums;
using PetLar.Core.Interfaces;

namespace PetLar.Application.Pets.Handlers;

public class RegisterPetCommandHandler(IPetRepository _petRepository) : IRequestHandler<RegisterPetCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(RegisterPetCommand request, CancellationToken ct)
    {
        var pet = new Pet
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Age = request.Age,
            Gender = request.Gender,
            Species = request.Species,
            Size = request.Size,
            Status = EnumPetStatus.Available,
            OwnerId = request.OwnerId,
        };

        await _petRepository.AddAsync(pet, ct);

        return Result<Guid>.Success(pet.Id);
    }
}
