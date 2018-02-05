using IngredientsInfo.DistSvc.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace IngredientsInfo.DistSvc
{
    [ServiceContract]
    public interface IAllergensService 
    {
        [OperationContract]
        IEnumerable<AllergenOutputDTO> GetAllergens();

        [OperationContract]
        AllergenOutputDTO GetAllergen(int id);
    }
}
