using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using IngredientsInfo.DistSvc.DTO;

namespace IngredientsInfo.DistSvc
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código y en el archivo de configuración a la vez.
    public class AllergensService : IAllergensService
    {
        private readonly IAllergensService allergensService;
        public AllergensService(IAllergensService newAllergensService)
        {
            this.allergensService = newAllergensService;
        }
        public DTO.AllergenOutputDTO GetAllergen(int id)
        {
            return this.allergensService.GetAllergen(id);
        }

        public IEnumerable<DTO.AllergenOutputDTO> GetAllergens()
        {
            var result = this.allergensService.GetAllergens();
            if(result != null)
            {
                return AutoMapper.Mapper.Map<IEnumerable<DTO.AllergenOutputDTO>>(result);
            }
            return null;
        }
    }
}
