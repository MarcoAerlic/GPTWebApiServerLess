using Core.Model.CoreEntity;
using GPTWebApiServerLess.ApplicationService.GPTProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPTWebApiServerLess.ApplicationService.Interfaces
{
    public interface IGPTProductService
    {
        Task<GPTProductResponseModel> GenerateContentDaVinci(CustomerRequestModel gptGenerateRequestModel);
        Task<GPTProductResponseModel> GenerateContentGptTurbo(List<GPTMessage> gptGenerateRequestModel);
        Task<GPTProductResponseModel> GenerateContentGpt4(List<GPTMessage> gptGenerateRequestModel);
    }
}
