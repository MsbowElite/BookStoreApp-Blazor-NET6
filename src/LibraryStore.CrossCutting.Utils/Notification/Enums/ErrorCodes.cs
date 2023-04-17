using System.ComponentModel;

namespace LibraryStore.CrossCutting.Utils.Notification.Enums
{
    public enum ErrorCodes
    {
        [Description("Internal processing failure")]
        InternalProcessingFailure = 200,

        [Description("Validation failure")]
        ValidationFailure = 400,
        [Description("Username or password are wrong.")]
        Unauthorized = 401,

        [Description("External processing failure")]
        ExternalProcessingFailure = 600,
    }
}
