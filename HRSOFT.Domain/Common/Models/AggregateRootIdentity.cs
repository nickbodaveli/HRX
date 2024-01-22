using Microsoft.AspNetCore.Identity;

namespace HRSOFT.Domain.Common.Models
{
    public abstract class AggregateRootIdentity : IdentityUser
    {
        public AggregateRootIdentity()
        {

        }
    }
}
