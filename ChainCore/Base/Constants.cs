using Nethereum.Hex.HexTypes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainCore.Base
{
    public class Constants
    {
        public static string EmptyAddress = "0x0000000000000000000000000000000000000000";
        public static HexBigInteger MaxGas = new HexBigInteger(1232805);
        public static HexBigInteger UnlockDuration = new HexBigInteger(120);
        public static string AddressFrom = ConfigurationManager.AppSettings["addressFrom"];
    }
}
