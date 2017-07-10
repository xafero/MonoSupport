using NUnit.Framework;
using MonoSupport.ServiceModel;
using System.Security.Cryptography;

namespace MonoSupport.Test
{
    [TestFixture]
    public class RsaTest
    {
        [Test]
        public void ShouldGetRsaIdentity()
        {
            var provider = new RSACryptoServiceProvider();
            var pubKey = provider.ToXmlString(false);
            Assert.AreEqual(243, pubKey.Length);
            var rsa = new RsaEndpointIdentity(pubKey);
            Assert.IsNotNull(rsa.IdentityClaim);
            Assert.AreEqual("identity(http://schemas.xmlsoap.org/ws/2005/05/identity/right/possessproperty:" +
                            " http://schemas.xmlsoap.org/ws/2005/05/identity/claims/rsa)", rsa.ToString());
        }
    }
}