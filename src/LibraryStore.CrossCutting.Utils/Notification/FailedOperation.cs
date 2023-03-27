using System.Collections.Generic;
using System.Text.Json.Serialization;
using LibraryStore.CrossCutting.Utils.Notification.Enums;
using LibraryStore.CrossCutting.Utils.Notification.Interfaces;

namespace LibraryStore.CrossCutting.Utils.Notification
{
    public class FailedOperation : IOperation
    {
        public FailedOperation(ErrorCodes code, MessageDetail detail)
        {
            Messages = new Messages(code, detail);
        }

        public FailedOperation(ErrorCodes code, List<MessageDetail> detail)
        {
            Messages = new Messages(code, detail);
        }

        public FailedOperation(ErrorCodes code)
        {
            Messages = new Messages(code);
        }
        public FailedOperation(Messages messages)
        {
            Messages = messages;
        }

        [JsonPropertyName("messages")]
        public Messages Messages { get; }
    }

    public class FailedOperation<T> : FailedOperation, IOperation<T>
    {
        public FailedOperation(ErrorCodes code) : base(code)
        {
        }

        public FailedOperation(Messages messages) : base(messages)
        {
        }

        public FailedOperation(ErrorCodes code, MessageDetail detail) : base(code, detail)
        {
        }

        public FailedOperation(ErrorCodes code, List<MessageDetail> detail) : base(code, detail)
        {
        }
    }
}
