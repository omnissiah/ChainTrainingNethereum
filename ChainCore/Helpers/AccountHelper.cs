using ChainCore.Base;
using ChainCore.Extensions;
using ChainCore.UI;
using ChainTrainingNethereum;
using Nethereum.Core.Signing.Crypto;
using Nethereum.KeyStore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChainCore.Helpers
{
    public class AccountHelper
    {
        private static readonly AccountHelper instance = new AccountHelper();
         
        static AccountHelper()
        {
        }

        private AccountHelper()
        {
        }
        public static AccountHelper Instance
        {
            get
            {
                return instance;
            }
        }
        public static string AddressFrom = ConfigurationManager.AppSettings["addressFrom"];
        public bool UnlockAccount()
        {
            var pass = GetPass();
            if (!String.IsNullOrEmpty(pass)) 
                return ServiceSync.Sync(ContractHelper.Instance.Web3.Personal.UnlockAccount.SendRequestAsync(Constants.AddressFrom, pass, 120)); 
            return false;
        }

        public string ConfirmAndGetPass()
        {
            frmPass newPassCheck = new frmPass(true);
            if (newPassCheck.ShowDialog() == DialogResult.OK)
            {
                if (newPassCheck.ShowDialog() == DialogResult.OK && newPassCheck.IsMatch)
                {
                    return newPassCheck.Pass;
                }
            }
            return null;
        }
        public string GetPass()
        {
            frmPass newPassCheck = new frmPass(false);
            if (newPassCheck.ShowDialog() == DialogResult.OK)
            {
                return newPassCheck.Pass;
            }
            return null;
        }

        public void GenerateNewAccountFileFromPrivateKey(string pass, string path, string address, string key)
        {
            var service = new KeyStoreService(); 
            var fileName = service.GenerateUTCFileName(address);
            using (var newfile = File.CreateText(Path.Combine(path, fileName)))
            { 
                var newJson = service.EncryptAndGenerateDefaultKeyStoreAsJson(pass, HexByteConvertorExtensions.HexToByteArray(key), address);
                newfile.Write(newJson);
                newfile.Flush();
            }
        }
        public void GenerateNewAccountFileMod(string pass, string path)
        {
            var ecKey = EthECKey.GenerateKey();
            var privateKey = ecKey.GetPrivateKeyAsBytes().ToHex();
           // var account = new Account(privateKey);

        }
        public void GenerateNewAccountFile(string pass,string path)
        { 

            var ecKey = EthECKey.GenerateKey();
            byte[] privateKey = null;
            while (true)
            {
                privateKey = ecKey.GetPrivateKeyAsBytes();
                if (privateKey.Length == 32)
                    break;
                ecKey = EthECKey.GenerateKey();
            }
            var genAddress = ecKey.GetPublicAddress();

            var service = new KeyStoreService();
            var fileName = service.GenerateUTCFileName(genAddress);

            //using (var newfile = File.CreateText(fileName))
            //{
            //    //generate the encrypted and key store content as json. (The default uses pbkdf2)
            //    var newJson = service.EncryptAndGenerateDefaultKeyStoreAsJson(password, privateKey, genAddress);
            //    newfile.Write(newJson);
            //    newfile.Flush();
            //}

            //instead of the default service we can use either
            //Scrypt
            using (var newfile = File.CreateText(Path.Combine(path, fileName)))
            {
                //generate the encrypted and key store content as json. (The default uses pbkdf2)
                var scryptService = new KeyStoreScryptService();
                var scryptResult = scryptService.EncryptAndGenerateKeyStoreAsJson(pass, privateKey, genAddress);
                newfile.Write(scryptResult);
                newfile.Flush();
            }

            Process.Start(path);

            //or pkbdf2
            //var pbkdf2Service = new KeyStorePbkdf2Service();
            //var pkbdf2Result = pbkdf2Service.EncryptAndGenerateKeyStoreAsJson(password, privateKey, genAddress);

            //File.WriteAllText("UTC--" + DateTime.UtcNow.ToString("o",
            //                                CultureInfo.InvariantCulture).Replace(':', '-') + "--" + genAddress, scryptResult);

            //Both services can be configured with a new IRandomBytesGenerator for the IV and Salt, currently uses SecureRandom for both.
            //also when encrypting we can pass custom KdfParameters
        }
    }
}
