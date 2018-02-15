using CorePOC.Model;
using Microsoft.Extensions.Configuration;

namespace CorePOC.DataLayer.InfraStructure
{
    public class AuthFactory : IAuthFactory
    {
        private string key = null;
        private string password = null;

        public AuthFactory(IConfiguration configuration)
        {
            key=configuration["Logging:Authoization:key"];
            password=configuration["Logging:Authoization:password"];

        }
        public Auth GetAuthDetails()
        {            
            Auth objauth = new Auth(){Username =key,Passowrd=password};
            return objauth;
        }
    }
}