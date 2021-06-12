using Core.Entities;

namespace DonosServer.API.Authorization.Attributes
{
    public class AdminAuthorizationAttribute : AuthorizationAttribute
    {
        public override Role Role => Role.Admin;
    }
}
