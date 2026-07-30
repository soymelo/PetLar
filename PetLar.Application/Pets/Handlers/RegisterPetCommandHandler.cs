using MediatR;
using PetLar.Application.Common.Results;
using PetLar.Application.Pets.Commands;
using PetLar.Application.Pets.Errors;
using PetLar.Core.Entities;
using PetLar.Core.Enums;
using PetLar.Core.Interfaces;

namespace PetLar.Application.Pets.Handlers;

public class RegisterPetCommandHandler(IPetRepository _petRepository, IUserRepository _userRepository) : IRequestHandler<RegisterPetCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(RegisterPetCommand request, CancellationToken ct)
    {
        var user = await _userRepository.GetByIdAsync(request.OngId, ct);
        if (user is null)
            return Result<Guid>.Failure(PetErrors.OngNotFound);

        if (user.Type != EnumType.Ong)
            return Result<Guid>.Failure(PetErrors.UserIsNotOng);

        var pet = new Pet
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Age = request.Age,
            Gender = request.Gender,
            Species = request.Species,
            Size = request.Size,
            Status = EnumPetStatus.Available,
            OngId = request.OngId,
        };

        await _petRepository.AddAsync(pet, ct);

        return Result<Guid>.Success(pet.Id);
    }
}
