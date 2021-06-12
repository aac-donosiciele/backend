using Core.Entities;

namespace DonosServer.API.Authorization.Attributes
{
    public class UserAuthorizationAttribute : AuthorizationAttribute
    {
        public override Role Role => Role.User;
    }
}
