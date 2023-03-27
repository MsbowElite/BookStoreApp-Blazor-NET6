using Microsoft.AspNetCore.Identity;

namespace LibraryStore.Domain.Entities
{
    public class ApiUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
