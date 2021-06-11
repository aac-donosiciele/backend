using Core.Entities;
using System;

namespace DonosServer.API.Authorization.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public abstract class AuthorizationAttribute : Attribute
    {
        public abstract Role Role { get; }
    }
}
