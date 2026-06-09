using MediatR;
using PetLar.Application.Pets.ViewModels;

namespace PetLar.Application.Pets.Queries;

public record GetAllPetsQuery(): IRequest<IEnumerable<PetViewModel>>;
