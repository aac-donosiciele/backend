using Core.Entities;

namespace DonosServer.API.Authorization.Attributes
{
    public class OfficialAuthorizationAttribute : AuthorizationAttribute
    {
        public override Role Role => Role.Official;
    }
}
