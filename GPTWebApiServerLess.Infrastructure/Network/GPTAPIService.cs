﻿using Core.Model.CoreEntity;
using GPTWebApiServerLess.ApplicationService.GPTProduct;
using GPTWebApiServerLess.ApplicationService.Interfaces;
using Microsoft.Extensions.Configuration;
using OpenAI_API;
using OpenAI_API.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPTWebApiServerLess.Infrastructure.Network
{
    public class GPTAPIService : IGPTAPIService
    {
        private readonly IConfiguration _configuration;

        public GPTAPIService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<string>> GenerateContentDaVinciAPI(GPTGenerateRequestModelDTO generateRequestModel)
        {
            var apiKey = "";
            var apiModel = "text-davinci-003";
            List<string> rq = new List<string>();
            string rs = "";
            OpenAIAPI api = new OpenAIAPI(new APIAuthentication(apiKey));

            var completionRequest = new OpenAI_API.Completions.CompletionRequest()
            {
                Prompt = generateRequestModel.prompt,
                Model = apiModel,
                Temperature = 0.5,
                MaxTokens = 500,
                TopP = 1.0,
                FrequencyPenalty = 0.0,
                PresencePenalty = 0.0,

            };

            var result = await api.Completions.CreateCompletionsAsync(completionRequest);
            foreach (var choice in result.Completions)
            {
                rq.Add(choice.Text);
                rq.Distinct();
            }

            return rq;
        }

        public async Task<List<string>> GenerateContentGptTurboAPI(GPTChatInput generateRequestModel)
        {
            var apiKey = "";
            var apiModel = "gpt-3.5-turbo";
            List<string> rq = new List<string>();
            string rs = "";
            OpenAIAPI api = new OpenAIAPI(new APIAuthentication(apiKey));

            //GPT models use a different strusture when formatting the request (in comparison to davinci model)
            //because of this our input, and the way we query the model changes.
            List<ChatMessage> messages = new List<ChatMessage>();

            foreach (var gptm in generateRequestModel.GptMessages)
            {
                messages.Add(new ChatMessage(InternalConsistencyCheck(gptm.Role), gptm.Content));
            }

            var chatRequest = new ChatRequest()
            {
                Messages = messages,
                Model = apiModel,
                Temperature = generateRequestModel.ModelParameters.Temperature,
                MaxTokens = generateRequestModel.ModelParameters.MaxTokens,
                TopP = generateRequestModel.ModelParameters.TopP,
                FrequencyPenalty = 0.0,
                PresencePenalty = 0.0,

            };

            var result = await api.Chat.CreateChatCompletionAsync(chatRequest);

            foreach (var choice in result.Choices)
            {
                rq.Add(choice.Message.Content);
                rq.Distinct();
            }

            return rq;
        }

        public async Task<List<string>> GenerateContentGpt4API(GPTChatInput generateRequestModel)
        {
            var apiKey = "";
            var apiModel = "gpt-4";

            List<string> rq = new List<string>();
            string rs = "";
            OpenAIAPI api = new OpenAIAPI(new APIAuthentication(apiKey));

            //GPT models use a different strusture when formatting the request (in comparison to davinci model)
            //because of this our input, and the way we query the model changes.
            List<ChatMessage> messages = new List<ChatMessage>();

            foreach (var gptm in generateRequestModel.GptMessages)
            {
                messages.Add(new ChatMessage(InternalConsistencyCheck(gptm.Role), gptm.Content));
            }

            var chatRequest = new ChatRequest()
            {
                Messages = messages,
                Model = apiModel,
                Temperature = generateRequestModel.ModelParameters.Temperature,
                MaxTokens = generateRequestModel.ModelParameters.MaxTokens,
                TopP = generateRequestModel.ModelParameters.TopP,
                FrequencyPenalty = 0.0,
                PresencePenalty = 0.0,

            };

            var result = await api.Chat.CreateChatCompletionAsync(chatRequest);

            foreach (var choice in result.Choices)
            {
                rq.Add(choice.Message.Content);
                rq.Distinct();
            }

            return rq;
        }

        private ChatMessageRole InternalConsistencyCheck(string roleName)
        {
            switch (roleName)
            {
                case "system":
                    return ChatMessageRole.System;
                case "user":
                    return ChatMessageRole.User;
                case "assistant":
                    return ChatMessageRole.Assistant;
                default:
                    return ChatMessageRole.User;
            }
        }
    }
}
