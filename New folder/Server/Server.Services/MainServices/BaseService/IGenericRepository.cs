using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vino.Server.Services.MainServices.BaseService
{
    public interface IGenericRepository<TEntity, TDto, TCreationDto>
    {
       Task<IEnumerable<TDto>> GetAllAsync();

        Task<TDto> GetSingleAsync(int id);

        Task<int> CreateAsync(TCreationDto creationDto);

        Task<int> EditAsync(int id, TCreationDto creationDto);

        Task<int> DeleteAsync(int id);

        Task<int> GetNumberEntry();

    }
}
