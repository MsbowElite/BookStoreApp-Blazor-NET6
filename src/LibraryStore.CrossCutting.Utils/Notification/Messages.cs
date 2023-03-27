using Microsoft.OpenApi.Extensions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json.Serialization;
using LibraryStore.CrossCutting.Utils.Notification.Enums;

namespace LibraryStore.CrossCutting.Utils.Notification
{
    public class Messages
    {
        [JsonPropertyName("code")]
        public ErrorCodes Code { get; }
        private string _message { get; set; }
        [JsonPropertyName("message")]
        public string Message { get => string.IsNullOrEmpty(_message) ? Code.GetAttributeOfType<DescriptionAttribute>().Description : _message; set => _message = value; }
        [JsonPropertyName("fields")]
        public List<MessageDetail> Fields { get; private set; }

        public Messages(ErrorCodes code, MessageDetail field)
        {
            Code = code;
            AddField(field);
        }

        public Messages(ErrorCodes code, List<MessageDetail> field)
        {
            Code = code;
            Fields = field;
        }

        public Messages(ErrorCodes code)
        {
            Code = code;
        }

        public void AddField(MessageDetail detail)
        {
            if (detail is object)
                Fields.Add(detail);
        }
    }
}
