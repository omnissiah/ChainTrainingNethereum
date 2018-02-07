using ChainCore.Base;
using ChainCore.Extensions;
using ChainCore.Helpers;
using ChainCore.UI;
using Nethereum.Core.Signing.Crypto;
using Nethereum.Hex.HexTypes;
using Nethereum.KeyStore;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace ChainTrainingNethereum
{
    public partial class Form1 : Form
    {

        private DateTime lastUpdate = DateTime.MinValue;
        private long lastBlock = 0;


        public Form1()
        {
            InitializeComponent();
            bgRefreshWorker.RunWorkerAsync();
            lblHomeAcc.Text = Constants.AddressFrom;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (AccountHelper.Instance.UnlockAccount())
                {
                    MessageBox.Show("Account Unlocked");

                    var result = MyBiletService.Instance.BuyTicket();
                    if (!string.IsNullOrEmpty(result))
                        new frmMessageBox("Tx complete: " + result).ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata:" + ex.Message);
            }
        }

        private void btnGenerateAcc_Click(object sender, EventArgs e)
        {
            var pass = AccountHelper.Instance.GetPass();
            if (!string.IsNullOrEmpty(pass))
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                { 
                    AccountHelper.Instance.GenerateNewAccountFile(pass, folderBrowserDialog1.SelectedPath);
                }
            }
        }

        private void btnOfflineBuyTicket_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    var pass = AccountHelper.Instance.GetPass();
                    if (!string.IsNullOrEmpty(pass))
                    {
                        KeyStoreHelper keyStoreHelper = new KeyStoreHelper();
                        var key = keyStoreHelper.GetPrivateKey(openFileDialog1.FileName, pass);
                        if (key != null)
                        {
                            var result = MyBiletService.Instance.BuyTicketOffline(key, chkSendRaw.Checked);
                            if (!string.IsNullOrEmpty(result))
                                new frmMessageBox("Tx complete: " + result).ShowDialog();
                        }
                    } 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata:" + ex.Message);
            }
        }

        private void txtSendRaw_Click(object sender, EventArgs e)
        {
            try
            {
                ContractHelper.Instance.SendRawTx(txtRaw.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata:" + ex.Message);
            }
        }

        private async void BlinkOnce(Label lbl)
        {
            int i = 0;
            while (i < 2)
            {
                await Task.Delay(500);
                lbl.BackColor = lbl.BackColor == Color.Green ? Color.Transparent : Color.Green;
                ++i;
            }
        }

        private async void timer1_Tick(object sender, ElapsedEventArgs e)
        {
            try
            {
                Invoke(new Action(() => lblCustomerCount.Text = MyBiletService.Instance.GetCustomerAmount()+" customers"));
                Invoke(new Action(() => lblSeatingLimit.Text = MyBiletService.Instance.GetSeatingLimit() + " seats"));


                var blockNumberHex = await ContractHelper.Instance.Web3.Eth.Blocks.GetBlockNumber.SendRequestAsync();
                long blockNumber = long.Parse(blockNumberHex.Value.ToString());
                var accountBalance = await ContractHelper.Instance.Web3.Eth.GetBalance.SendRequestAsync(lblHomeAcc.Text);
                Invoke(new Action(() => lblBalance.Text = UnitConversion.Convert.FromWei(accountBalance.Value) + " ETH"));

                if (blockNumber > lastBlock)
                {
                    var peerCountHex = await ContractHelper.Instance.Web3.Net.PeerCount.SendRequestAsync();
                    long peerCount = long.Parse(peerCountHex.Value.ToString());


                    lastBlock = blockNumber;
                    Invoke(new Action(() => lblAtBlock.Text = lastBlock.ToString()));
                    Invoke(new Action(() => lblPeers.Text = peerCount.ToString()));

                    Invoke(new Action(() => BlinkOnce(lblAtBlock)));
                    Invoke(new Action(() => BlinkOnce(lblPeers)));
                    lastUpdate = DateTime.UtcNow;
                }
                Invoke(new Action(() => lblUpdated.Text = UtilityHelper.GetRemainingTime((Int32)(lastUpdate.Subtract(new DateTime(1970, 1, 1))).TotalSeconds)));
            }
            catch
            {
                Invoke(new Action(() => lblPeers.Text = "0"));
                Invoke(new Action(() => lblAtBlock.Text = "0"));

                if (lastUpdate > DateTime.MinValue) 
                    Invoke(new Action(() => lblUpdated.Text = UtilityHelper.GetRemainingTime((Int32)(lastUpdate.Subtract(new DateTime(1970, 1, 1))).TotalSeconds))); 
                else
                    Invoke(new Action(() => lblUpdated.Text = string.Empty));
            }
        }

        private void bgRefreshWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Timers.Timer timer1 = new System.Timers.Timer();
            timer1.Elapsed += timer1_Tick;
            timer1.Interval = 2000; // in miliseconds
            timer1.Start();
        }

        private void btnCustomerPaid_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtCustomerAccount.Text))
                {
                    txtCustomerPaid.Text = "Customer(" + txtCustomerAccount.Text + ") paid: " +UnitConversion.Convert.FromWei(MyBiletService.Instance.GetAmountCustomerPaid(txtCustomerAccount.Text)) + " ETH";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata:" + ex.Message);
            }
        }

        private void btnChangeSeating_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSeatingNumber.Text))
            {
                try
                {
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        var pass = AccountHelper.Instance.GetPass();
                        if (!string.IsNullOrEmpty(pass))
                        {
                            KeyStoreHelper keyStoreHelper = new KeyStoreHelper();
                            var key = keyStoreHelper.GetPrivateKey(openFileDialog1.FileName, pass);
                            if (key != null)
                            { 
                                string hexVal = int.Parse(txtSeatingNumber.Text).ToString("X");
                                var result = MyBiletService.Instance.ChangeSeatingOffline(key, chkSendRaw.Checked, hexVal);
                                if (!string.IsNullOrEmpty(result))
                                    new frmMessageBox("Tx complete: " + result).ShowDialog();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata:" + ex.Message);
                }
            } 
        }

        private void btnSendEth_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtRecepientAddr.Text))
            {
                try
                {
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        var pass = AccountHelper.Instance.GetPass();
                        if (!string.IsNullOrEmpty(pass))
                        {
                            KeyStoreHelper keyStoreHelper = new KeyStoreHelper();
                            var key = keyStoreHelper.GetPrivateKey(openFileDialog1.FileName, pass);
                            if (key != null)
                            {
                                var result = ContractHelper.Instance.SendEth(key, 20, txtRecepientAddr.Text);
                                if (!string.IsNullOrEmpty(result))
                                    new frmMessageBox("Tx complete: " + result).ShowDialog();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata:" + ex.Message);
                }
            }
        }

        private void btnGetTxinBlock_Click(object sender, EventArgs e)
        {
            var blockService = ContractHelper.Instance.Web3.Eth.Blocks;  
            txtBinary.Text= UtilityHelper.Dump(ServiceSync.Sync(blockService.GetBlockWithTransactionsByNumber.SendRequestAsync(new BlockParameter(ulong.Parse(txtBlockNumber.Text)))));
        }

        private void btnGetTxbyHash_Click(object sender, EventArgs e)
        {
            txtTxDetails.Text = ContractHelper.Instance.GetTxByHash(txtTxHash.Text);
        }

        private void btnCaptureDeposit_Click(object sender, EventArgs e)
        {
            try
            {
                txtDepositEventLog.Text = MyBiletService.Instance.ShowFilteredDepositEvent();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata:" + ex.Message);
            }
        }

        private void btnShowAllDeposit_Click(object sender, EventArgs e)
        {
            try
            {
                txtDepositEventLog.Text = MyBiletService.Instance.ShowAllDepositEvent();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata:" + ex.Message);
            }
        }

        private void btnSendContract_Click(object sender, EventArgs e)
        {
            try
            {
                if (AccountHelper.Instance.UnlockAccount())
                {
                    var result = ContractHelper.Instance.DeployContract(txtAbi.Text, txtBinary.Text, AccountHelper.AddressFrom);
                    new frmMessageBox("Tx complete: " + result).ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata:" + ex.Message);
            }
        }
    }
}
