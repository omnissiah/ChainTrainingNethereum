using ChainCore.Extensions;
using Nethereum.Core.Signing.Crypto;
using Nethereum.KeyStore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChainTrainingNethereum
{
    public class KeyStoreHelper
    {
        public string GetPrivateKey(string path, string pass)
        { 
            var file = File.OpenText(path);
            var json = file.ReadToEnd();

            //using the simple key store service
            var service = new KeyStoreService();
            return service.DecryptKeyStoreFromJson(pass, json).ToHex();
        }
    }
}
