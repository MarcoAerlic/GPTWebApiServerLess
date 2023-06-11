using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model.CoreEntity
{
    public class GPTChatInput
    {
        public GPTChatInput(List<GPTMessage> gptMessages, ModelParameters modelParameters)
        {
            this.GptMessages = gptMessages;
            this.ModelParameters = modelParameters;
        }

        [JsonProperty("chatmessages")]
        public List<GPTMessage> GptMessages { get; set; }

        [JsonProperty("modelparameters")]
        public ModelParameters ModelParameters { get; set; }
    }
}
