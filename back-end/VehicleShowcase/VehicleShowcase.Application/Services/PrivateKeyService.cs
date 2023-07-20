using System.Text;

namespace VehicleShowcase.Application.Services
{
    public static class PrivateKeyService
    {
        public readonly static byte[] privateKey = GetPrivateKey();

        private static byte[] GetPrivateKey()
        {
            return Encoding.UTF8.GetBytes("testeprivatekey9090909090909090");
        }
    }
}