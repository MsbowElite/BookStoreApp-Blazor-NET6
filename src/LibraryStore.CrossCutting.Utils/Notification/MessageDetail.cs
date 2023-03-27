using System.Text.Json.Serialization;

namespace LibraryStore.CrossCutting.Utils.Notification
{
    public class MessageDetail
    {
        [JsonPropertyName("field")]
        public string Field { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}
