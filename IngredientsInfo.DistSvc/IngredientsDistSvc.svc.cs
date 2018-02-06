using IngredientsInfo.DistSvc.DTO;
using IngredientsService.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace IngredientsInfo.DistSvc
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class IngredientsDistSvc : IIngredientsDistSvc
    {
        private readonly IIngredientsService ingredientsService;

        public IngredientsDistSvc(IIngredientsService newIngredientsService)
        {
            this.ingredientsService = newIngredientsService;
        }

        public IngredientOutputDTO GetIngredient(int id)
        {
            var result = AutoMapper.Mapper.Map<IngredientOutputDTO>(this.ingredientsService.GetIngredient(id));
            return result;
        }
    }
}
