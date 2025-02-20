using Persons.API.Database.Entities;
using Persons.API.Dtos.Common;
using Persons.API.Dtos.Persons;

namespace Persons.API.Services.Interfaces
{
    public interface IPersonsService //Obliga a la clase que cumpla con un contrato definido en esta interfaz, reglas para el programador
    {
        Task<ResponseDto<PersonActionResponseDto>> CreateAsync (PersonCreateDto person);
        Task DeleteAsync(Guid id);
        Task<ResponseDto<PersonActionResponseDto>> EditAsync(PersonEditDto dto, Guid id);
        Task GetListAsync();
        Task<ResponseDto<PersonDto>> GetOnebyIdAsync(Guid id);
    }
}
