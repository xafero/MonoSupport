using System.IdentityModel.Claims;
using System.Security.Cryptography;

namespace MonoSupport.ServiceModel
{
    public class RsaEndpointIdentity : System.ServiceModel.RsaEndpointIdentity
    {
        static Claim claim;

        public RsaEndpointIdentity(string publicKey) : base(claim = Claim.CreateRsaClaim(CreateRsa(publicKey)))
        {
            if (IdentityClaim != null) return;
            Initialize(claim);
        }

        static RSA CreateRsa(string publicKey)
        {
            var rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(publicKey);
            return rsa;
        }
    }
}