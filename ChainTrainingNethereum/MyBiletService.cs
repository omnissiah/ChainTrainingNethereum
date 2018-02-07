using ChainCore.Base;
using ChainCore.Helpers;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChainTrainingNethereum
{
    public sealed class MyBiletService
    {
        private static readonly MyBiletService instance = new MyBiletService();

        private string abi = @"[ { ""constant"": true, ""inputs"": [ { ""name"": """", ""type"": ""address"" } ], ""name"": ""customerPaid"", ""outputs"": [ { ""name"": """", ""type"": ""uint256"", ""value"": ""11000000000000000000"" } ], ""payable"": false, ""type"": ""function"" }, { ""constant"": false, ""inputs"": [ { ""name"": ""customerAddr"", ""type"": ""address"" }, { ""name"": ""amount"", ""type"": ""uint256"" } ], ""name"": ""refundTicket"", ""outputs"": [], ""payable"": false, ""type"": ""function"" }, { ""constant"": false, ""inputs"": [ { ""name"": ""newseatingLimit"", ""type"": ""uint256"" } ], ""name"": ""changeSeatingLimit"", ""outputs"": [], ""payable"": false, ""type"": ""function"" }, { ""constant"": false, ""inputs"": [], ""name"": ""destroy"", ""outputs"": [], ""payable"": false, ""type"": ""function"" }, { ""constant"": true, ""inputs"": [], ""name"": ""numCustomers"", ""outputs"": [ { ""name"": """", ""type"": ""uint256"", ""value"": ""2"" } ], ""payable"": false, ""type"": ""function"" }, { ""constant"": true, ""inputs"": [], ""name"": ""seatingLimit"", ""outputs"": [ { ""name"": """", ""type"": ""uint256"", ""value"": ""123"" } ], ""payable"": false, ""type"": ""function"" }, { ""constant"": false, ""inputs"": [], ""name"": ""buyTicket"", ""outputs"": [ { ""name"": ""success"", ""type"": ""bool"" } ], ""payable"": true, ""type"": ""function"" }, { ""constant"": true, ""inputs"": [], ""name"": ""cinemaOwner"", ""outputs"": [ { ""name"": """", ""type"": ""address"", ""value"": ""0x6aa1210e1a0faa952b465b019f6a7554fc67b8e8"" } ], ""payable"": false, ""type"": ""function"" }, { ""inputs"": [ { ""name"": ""seatingLimitInput"", ""type"": ""uint256"", ""index"": 0, ""typeShort"": ""uint"", ""bits"": ""256"", ""displayName"": ""seating Limit Input"", ""template"": ""elements_input_uint"", ""value"": ""123"" }, { ""name"": ""cinemaOwnerInput"", ""type"": ""address"", ""index"": 1, ""typeShort"": ""address"", ""bits"": """", ""displayName"": ""cinema Owner Input"", ""template"": ""elements_input_address"", ""value"": ""0x6Aa1210e1A0FAA952B465b019f6a7554Fc67b8e8"" } ], ""payable"": false, ""type"": ""constructor"" }, { ""anonymous"": false, ""inputs"": [ { ""indexed"": false, ""name"": ""_from"", ""type"": ""address"" }, { ""indexed"": false, ""name"": ""_amount"", ""type"": ""uint256"" } ], ""name"": ""Deposit"", ""type"": ""event"" }, { ""anonymous"": false, ""inputs"": [ { ""indexed"": false, ""name"": ""_to"", ""type"": ""address"" }, { ""indexed"": false, ""name"": ""_amount"", ""type"": ""uint256"" } ], ""name"": ""Refund"", ""type"": ""event"" } ]";
        private string contractAddress = "0x4D5490b8b2F31dD834BE571dF25e803De6fb33cF";
        private Contract contract;

        private HexBigInteger depositFilter;
        private Event depositEvent;
         
        static MyBiletService()
        {
        }

        private MyBiletService()
        {
            contract = ContractHelper.Instance.Web3.Eth.GetContract(abi, contractAddress);
            createFilters();
        }

        public static MyBiletService Instance
        {
            get
            {
                return instance;
            }
        }

        public long GetCustomerAmount()
        {
            return ServiceSync.Sync(contract.GetFunction("numCustomers").CallAsync<long>());
        }

        public long GetSeatingLimit()
        {
            return ServiceSync.Sync(contract.GetFunction("seatingLimit").CallAsync<long>());
        }

        public string BuyTicket()
        {
            var buyTicketFunction = contract.GetFunction("buyTicket");
            var transactionHash = ServiceSync.Sync(buyTicketFunction.SendTransactionAsync(Constants.AddressFrom, Constants.MaxGas, new HexBigInteger(5)));

            return ContractHelper.Instance.GetReceiptHash(transactionHash); 
        }

        private void createFilters()
        {
            depositEvent = contract.GetEvent("Deposit");
            depositFilter = ServiceSync.Sync(depositEvent.CreateFilterAsync()); 
        }

        public string BuyTicketOffline(string privateKey,bool canSend,int etherToSend=5)
        {
            var buyTicketFunction = contract.GetFunction("buyTicket");
            var ticketFuncData = buyTicketFunction.GetData();

            var txCount = ContractHelper.Instance.GetTransactionCount();
            string encodedTx = ContractHelper.Instance.SignTransactionOffline(privateKey, contractAddress, txCount, ticketFuncData, etherToSend);
            if (ContractHelper.Instance.VerifyTransaction(encodedTx))
                Console.WriteLine("OK");


            if (canSend)
            {
                var offlineTransactionHash = ContractHelper.Instance.SendRawTx(encodedTx);
                return ContractHelper.Instance.GetReceiptHash(offlineTransactionHash);
            }
            else
                return encodedTx; 
        }

        public long GetAmountCustomerPaid(string customerAcc)
        {
            var customerPaidFunc = contract.GetFunction("customerPaid");
            return ServiceSync.Sync(customerPaidFunc.CallAsync<long>(customerAcc)); 
        }

        public string ChangeSeatingOffline(string privateKey, bool canSend, string newSeatingNumber)
        {
            var changeSeatingLimitFunction = contract.GetFunction("changeSeatingLimit");
            var data = changeSeatingLimitFunction.GetData(newSeatingNumber);

            var potentialGasCost = ServiceSync.Sync(changeSeatingLimitFunction.EstimateGasAsync(69));

            var txCount = ContractHelper.Instance.GetTransactionCount();
            string encodedTx = ContractHelper.Instance.SignTransactionOffline(privateKey, contractAddress, txCount, data);
            if (ContractHelper.Instance.VerifyTransaction(encodedTx))
                Console.WriteLine("OK");
             
            if (canSend)
            {
                var offlineTransactionHash = ContractHelper.Instance.SendRawTx(encodedTx);
                return ContractHelper.Instance.GetReceiptHash(offlineTransactionHash);
            }
            else
                return encodedTx;
        }

        public string ShowFilteredDepositEvent()
        {  
            var log = ServiceSync.Sync(depositEvent.GetFilterChanges<DepositEvent>(depositFilter));
            return UtilityHelper.Dump(log);
        }

        public string ShowAllDepositEvent()
        {
            var log = ServiceSync.Sync(depositEvent.GetAllChanges<DepositEvent>(depositFilter));
            return UtilityHelper.Dump(log) ;
        }


    }
}
