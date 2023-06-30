#nullable enable
using Newtonsoft.Json;

namespace Mochineko.Whisper_API
{
    [JsonObject]
    public sealed class TranscriptionResponseBody
    {
        [JsonProperty("text"), JsonRequired]
        public string Text { get; private set; } = string.Empty;

        public string ToJson()
            => JsonConvert.SerializeObject(this, Formatting.Indented);

        public static TranscriptionResponseBody? FromJson(string json)
            => JsonConvert.DeserializeObject<TranscriptionResponseBody>(json, new JsonSerializerSettings());
    }
}