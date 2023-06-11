using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model.CoreEntity
{
    public class ModelParameters
    {
        [JsonProperty("temperature")]
        public double? Temperature { get; set; }

        [JsonProperty("maxtokens")]
        public int? MaxTokens { get; set; }

        [JsonProperty("topp")]
        public double? TopP { get; set; }
    }
}
