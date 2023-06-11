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
        Task<GPTProductResponseModel> GenerateContentGptTurbo(GPTChatInput gptGenerateRequestModel);
        Task<GPTProductResponseModel> GenerateContentGpt4(GPTChatInput gptGenerateRequestModel);
    }
}
