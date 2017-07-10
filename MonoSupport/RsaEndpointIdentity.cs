using System.IdentityModel.Claims;
using System.Security.Cryptography;

namespace MonoSupport.ServiceModel
{
    public class RsaEndpointIdentity : System.ServiceModel.RsaEndpointIdentity
    {
        RSA rsa;

        public RsaEndpointIdentity(string publicKey) : base((Claim)null)
        {
            rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(publicKey);
            Initialize(Claim.CreateRsaClaim(rsa));
        }
    }
}