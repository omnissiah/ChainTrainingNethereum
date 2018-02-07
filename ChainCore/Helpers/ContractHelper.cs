using ChainTrainingNethereum;
using Nethereum.Web3;
using System.Configuration;
using System.Numerics;
using System;
using Nethereum.Hex.HexTypes;
using System.Threading;
using ChainCore.Base;
using Newtonsoft.Json.Linq;

namespace ChainCore.Helpers
{
    public class ContractHelper
    {
        private static readonly ContractHelper instance = new ContractHelper();


        public Web3 Web3 { get; private set; }  
        public Personal Personal { get; private set; }
         
        static ContractHelper()
        {
        }

        private ContractHelper()
        {
            //var ipcClient = new Nethereum.JsonRpc.IpcClient("./geth.ipc");
            //var web3 = new Web3(ipcClient);
            Web3 = new Web3(ConfigurationManager.AppSettings["rpcEndpoint"]); 
            Personal = Web3.Personal; 
        }

        public static ContractHelper Instance
        {
            get
            {
                return instance;
            }
        }

        public BigInteger GetTransactionCount()
        {
            return ServiceSync.Sync(this.Web3.Eth.Transactions.GetTransactionCount.SendRequestAsync(Constants.AddressFrom)).Value;
        }

        public string SignTransactionOffline(string privateKey, string target, BigInteger txCount, string ticketFuncData, int etherToSend=0)
        { 
           return this.Web3.OfflineTransactionSigning.SignTransaction(privateKey, target, UnitConversion.Convert.ToWei(etherToSend), txCount, 1000000000000L, 900000, ticketFuncData);
        }
        public string SignTransactionOffline(string privateKey, string target, int etherToSend, BigInteger txCount)
        {
            return this.Web3.OfflineTransactionSigning.SignTransaction(privateKey, target, UnitConversion.Convert.ToWei(20), txCount);
        }

        public bool VerifyTransaction(string encodedTx)
        {
            if (this.Web3.OfflineTransactionSigning.VerifyTransaction(encodedTx))
                return true;
            else return false;
        }

        public string SendRawTx(string encodedTx)
        {
            if (!string.IsNullOrEmpty(encodedTx))
            {
                var transactionHash = ServiceSync.Sync(this.Web3.Eth.Transactions.SendRawTransaction.SendRequestAsync("0x" + encodedTx)); 
                return transactionHash; 
            }
            return null;
        }

        public string GetReceiptHash(string transactionHash)
        {
            if (transactionHash != null)
            {

                var receipt = ServiceSync.Sync(this.Web3.Eth.Transactions.GetTransactionReceipt.SendRequestAsync(transactionHash));

                while (receipt == null)
                {
                    Thread.Sleep(1000);
                    receipt = ServiceSync.Sync(this.Web3.Eth.Transactions.GetTransactionReceipt.SendRequestAsync(transactionHash));
                }
                return "Mined in block:" + receipt.BlockNumber.Value + Environment.NewLine+"tx hash:" + receipt.TransactionHash+ Environment.NewLine + "Contract Addr:" +receipt.ContractAddress;
            }
            return null;
        }

        public string GetTxByHash(string transactionHash)
        {
            if (transactionHash != null)
            {

                return UtilityHelper.Dump(ServiceSync.Sync(this.Web3.Eth.Transactions.GetTransactionByHash.SendRequestAsync(transactionHash)));
            }
            return null;
        }

        public bool HasError(JObject stack)
        {
            return !string.IsNullOrEmpty(GetError(stack));
        }

        public string GetError(JObject stack)
        {
            var structsLogs = (JArray)stack["structLogs"];
            if (structsLogs.Count > 0)
            {
                var lastCall = structsLogs[structsLogs.Count - 1];
                return lastCall["error"].Value<string>();
            }
            return null;
        }

        public string DeployContract(string abi,string byteCode,string senderAddress)
        {
            var txHash = ServiceSync.Sync(this.Web3.Eth.DeployContract.SendRequestAsync(abi, byteCode, senderAddress,
                Constants.MaxGas, 40,
                60, "0x6aa1210e1a0faa952b465b019f6a7554fc67b8e8"));
            return ContractHelper.Instance.GetReceiptHash(txHash);
        }


        public string SendEth(string privateKey, int amountToSend, string target)
        {
            var txCount = GetTransactionCount();
            string encodedTx = SignTransactionOffline(privateKey, target, amountToSend, txCount);
            if (VerifyTransaction(encodedTx))
                Console.WriteLine("OK");

            var offlineTransactionHash = SendRawTx(encodedTx);
            return GetReceiptHash(offlineTransactionHash);
        }
    }
}
