using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamleaderDotNet.Users;

namespace TeamleaderDotNet.Tests
{
    public abstract class TestBase
    {
        protected TeamleaderApi Client;
        protected User[] Users;

        [TestInitialize]
        public void Initialize()
        {
            Client = new TeamleaderApi("", "");

            Users = Client.Users.GetUsers()
                .GetAwaiter()
                .GetResult();
        }
    }
}
