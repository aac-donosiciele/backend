using System;

namespace DonosServer.API.Authorization
{
    public class UserContext
    {
        private bool isSet;
        
        public Guid Id { get; private set; }

        public void SetOnce(Guid id)
        {
            if (isSet)
                throw new InvalidOperationException();

            Id = id;
            isSet = true;
        }
    }
}
