using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using LibraryStore.CrossCutting.Utils.Notification.Enums;
using LibraryStore.CrossCutting.Utils.Notification.Interfaces;

namespace LibraryStore.CrossCutting.Utils.Notification
{
    public class InvalidOperation<T> : IOperation<T>
    {
        public InvalidOperation(ErrorCodes code, MessageDetail detail)
        {
            Messages = new Messages(code, detail);
        }

        public InvalidOperation(ErrorCodes code, List<MessageDetail> detail)
        {
            Messages = new Messages(code, detail);
        }

        public InvalidOperation(ErrorCodes code)
        {
            Messages = new Messages(code);
        }

        [JsonPropertyName("messages")]
        public Messages Messages { get; }
    }
}
