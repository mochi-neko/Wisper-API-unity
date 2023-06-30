#nullable enable
using Newtonsoft.Json;

namespace Mochineko.Whisper_API
{
    [JsonObject]
    public sealed class TranslationResponseBody
    {
        [JsonProperty("text"), JsonRequired]
        public string Text { get; private set; } = string.Empty;

        public string ToJson()
            => JsonConvert.SerializeObject(this, Formatting.Indented);

        public static TranslationResponseBody? FromJson(string json)
            => JsonConvert.DeserializeObject<TranslationResponseBody>(json, new JsonSerializerSettings());
    }
}