﻿using Core.Model.CoreEntity;
using GPTWebApiServerLess.ApplicationService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPTWebApiServerLess.ApplicationService.GPTProduct
{
    public class GPTProductService : IGPTProductService
    {
        private readonly IGPTAPIService _gptAPIService;

        public GPTProductService(IGPTAPIService gptAPIService)
        {
            _gptAPIService = gptAPIService;

        }

        public async Task<GPTProductResponseModel> GenerateContentDaVinci(CustomerRequestModel gptGenerateRequestModel)
        {
            if (string.IsNullOrEmpty(gptGenerateRequestModel.Message))
            {
                return new GPTProductResponseModel
                {
                    Success = false,
                    GPTContent = null
                };
            }
            var userMessage = new GPTGenerateRequestModelDTO
            {
                prompt = gptGenerateRequestModel.Message
            };
            var generateGPTResponse = await _gptAPIService.GenerateContentDaVinciAPI(userMessage);

            if (generateGPTResponse.Count == 0)
            {
                return new GPTProductResponseModel
                {
                    Success = false,
                    GPTContent = null
                };
            }

            return new GPTProductResponseModel
            {
                Success = true,
                GPTContent = generateGPTResponse
            };
        }

        public async Task<GPTProductResponseModel> GenerateContentGptTurbo(GPTChatInput gptGenerateRequestModel)
        {
            if (!(gptGenerateRequestModel != null))
            {
                return new GPTProductResponseModel
                {
                    Success = false,
                    GPTContent = null
                };
            }

            var generateGPTResponse = await _gptAPIService.GenerateContentGptTurboAPI(gptGenerateRequestModel);

            if (generateGPTResponse.Count == 0)
            {
                return new GPTProductResponseModel
                {
                    Success = false,
                    GPTContent = null
                };
            }

            return new GPTProductResponseModel
            {
                Success = true,
                GPTContent = generateGPTResponse
            };
        }

        public async Task<GPTProductResponseModel> GenerateContentGpt4(GPTChatInput gptGenerateRequestModel)
        {
            if (!(gptGenerateRequestModel != null))
            {
                return new GPTProductResponseModel
                {
                    Success = false,
                    GPTContent = null
                };
            }

            var generateGPTResponse = await _gptAPIService.GenerateContentGpt4API(gptGenerateRequestModel);

            if (generateGPTResponse.Count == 0)
            {
                return new GPTProductResponseModel
                {
                    Success = false,
                    GPTContent = null
                };
            }

            return new GPTProductResponseModel
            {
                Success = true,
                GPTContent = generateGPTResponse
            };
        }
    }
}
