namespace ChainTrainingNethereum
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOnlineBuyTicket = new System.Windows.Forms.Button();
            this.btnGenerateAcc = new System.Windows.Forms.Button();
            this.txtRecepientAddr = new System.Windows.Forms.TextBox();
            this.btnOfflineBuyTicket = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnSendRaw = new System.Windows.Forms.Button();
            this.txtRaw = new System.Windows.Forms.TextBox();
            this.bgRefreshWorker = new System.ComponentModel.BackgroundWorker();
            this.lblAtBlock = new System.Windows.Forms.Label();
            this.lblPeers = new System.Windows.Forms.Label();
            this.lblUpdated = new System.Windows.Forms.Label();
            this.lblCustomerCount = new System.Windows.Forms.Label();
            this.chkSendRaw = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblSeatingLimit = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtDepositEventLog = new System.Windows.Forms.TextBox();
            this.btnShowAllDeposit = new System.Windows.Forms.Button();
            this.btnShowFilteredDeposit = new System.Windows.Forms.Button();
            this.txtCustomerPaid = new System.Windows.Forms.TextBox();
            this.txtSeatingNumber = new System.Windows.Forms.TextBox();
            this.txtCustomerAccount = new System.Windows.Forms.TextBox();
            this.btnCustomerPaid = new System.Windows.Forms.Button();
            this.btnChangeSeating = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTxDetails = new System.Windows.Forms.TextBox();
            this.btnGetTxbyHash = new System.Windows.Forms.Button();
            this.txtTxHash = new System.Windows.Forms.TextBox();
            this.txtBinary = new System.Windows.Forms.TextBox();
            this.btnGetTxinBlock = new System.Windows.Forms.Button();
            this.txtBlockNumber = new System.Windows.Forms.TextBox();
            this.btnSendEth = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.lblHomeAcc = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.btnSendContract = new System.Windows.Forms.Button();
            this.txtAbi = new System.Windows.Forms.TextBox();
            this.txtContractBinary = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOnlineBuyTicket
            // 
            this.btnOnlineBuyTicket.Location = new System.Drawing.Point(27, 30);
            this.btnOnlineBuyTicket.Name = "btnOnlineBuyTicket";
            this.btnOnlineBuyTicket.Size = new System.Drawing.Size(123, 22);
            this.btnOnlineBuyTicket.TabIndex = 0;
            this.btnOnlineBuyTicket.Text = "Buy Ticket (Online)";
            this.btnOnlineBuyTicket.UseVisualStyleBackColor = true;
            this.btnOnlineBuyTicket.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnGenerateAcc
            // 
            this.btnGenerateAcc.Location = new System.Drawing.Point(6, 150);
            this.btnGenerateAcc.Name = "btnGenerateAcc";
            this.btnGenerateAcc.Size = new System.Drawing.Size(100, 23);
            this.btnGenerateAcc.TabIndex = 1;
            this.btnGenerateAcc.Text = "Generate Acc";
            this.btnGenerateAcc.UseVisualStyleBackColor = true;
            this.btnGenerateAcc.Click += new System.EventHandler(this.btnGenerateAcc_Click);
            // 
            // txtRecepientAddr
            // 
            this.txtRecepientAddr.Location = new System.Drawing.Point(90, 109);
            this.txtRecepientAddr.Name = "txtRecepientAddr";
            this.txtRecepientAddr.Size = new System.Drawing.Size(184, 20);
            this.txtRecepientAddr.TabIndex = 2;
            // 
            // btnOfflineBuyTicket
            // 
            this.btnOfflineBuyTicket.Location = new System.Drawing.Point(21, 42);
            this.btnOfflineBuyTicket.Name = "btnOfflineBuyTicket";
            this.btnOfflineBuyTicket.Size = new System.Drawing.Size(123, 22);
            this.btnOfflineBuyTicket.TabIndex = 3;
            this.btnOfflineBuyTicket.Text = "Buy Ticket ";
            this.btnOfflineBuyTicket.UseVisualStyleBackColor = true;
            this.btnOfflineBuyTicket.Click += new System.EventHandler(this.btnOfflineBuyTicket_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnSendRaw
            // 
            this.btnSendRaw.Location = new System.Drawing.Point(6, 234);
            this.btnSendRaw.Name = "btnSendRaw";
            this.btnSendRaw.Size = new System.Drawing.Size(66, 22);
            this.btnSendRaw.TabIndex = 5;
            this.btnSendRaw.Text = "SendRaw";
            this.btnSendRaw.UseVisualStyleBackColor = true;
            this.btnSendRaw.Click += new System.EventHandler(this.txtSendRaw_Click);
            // 
            // txtRaw
            // 
            this.txtRaw.Location = new System.Drawing.Point(6, 179);
            this.txtRaw.Multiline = true;
            this.txtRaw.Name = "txtRaw";
            this.txtRaw.Size = new System.Drawing.Size(268, 49);
            this.txtRaw.TabIndex = 6;
            // 
            // bgRefreshWorker
            // 
            this.bgRefreshWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgRefreshWorker_DoWork);
            // 
            // lblAtBlock
            // 
            this.lblAtBlock.AutoSize = true;
            this.lblAtBlock.Location = new System.Drawing.Point(9, 26);
            this.lblAtBlock.Name = "lblAtBlock";
            this.lblAtBlock.Size = new System.Drawing.Size(35, 13);
            this.lblAtBlock.TabIndex = 7;
            this.lblAtBlock.Text = "label1";
            // 
            // lblPeers
            // 
            this.lblPeers.AutoSize = true;
            this.lblPeers.Location = new System.Drawing.Point(9, 49);
            this.lblPeers.Name = "lblPeers";
            this.lblPeers.Size = new System.Drawing.Size(35, 13);
            this.lblPeers.TabIndex = 8;
            this.lblPeers.Text = "label2";
            // 
            // lblUpdated
            // 
            this.lblUpdated.AutoSize = true;
            this.lblUpdated.Location = new System.Drawing.Point(9, 79);
            this.lblUpdated.Name = "lblUpdated";
            this.lblUpdated.Size = new System.Drawing.Size(35, 13);
            this.lblUpdated.TabIndex = 9;
            this.lblUpdated.Text = "label3";
            // 
            // lblCustomerCount
            // 
            this.lblCustomerCount.AutoSize = true;
            this.lblCustomerCount.Location = new System.Drawing.Point(193, 16);
            this.lblCustomerCount.Name = "lblCustomerCount";
            this.lblCustomerCount.Size = new System.Drawing.Size(35, 13);
            this.lblCustomerCount.TabIndex = 10;
            this.lblCustomerCount.Text = "label3";
            // 
            // chkSendRaw
            // 
            this.chkSendRaw.AutoSize = true;
            this.chkSendRaw.Checked = true;
            this.chkSendRaw.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSendRaw.Location = new System.Drawing.Point(21, 19);
            this.chkSendRaw.Name = "chkSendRaw";
            this.chkSendRaw.Size = new System.Drawing.Size(128, 17);
            this.chkSendRaw.TabIndex = 11;
            this.chkSendRaw.Text = "Send raw immediately";
            this.chkSendRaw.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblSeatingLimit);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.btnOnlineBuyTicket);
            this.groupBox1.Controls.Add(this.lblCustomerCount);
            this.groupBox1.Location = new System.Drawing.Point(12, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(269, 433);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MyBilet";
            // 
            // lblSeatingLimit
            // 
            this.lblSeatingLimit.AutoSize = true;
            this.lblSeatingLimit.Location = new System.Drawing.Point(193, 44);
            this.lblSeatingLimit.Name = "lblSeatingLimit";
            this.lblSeatingLimit.Size = new System.Drawing.Size(35, 13);
            this.lblSeatingLimit.TabIndex = 17;
            this.lblSeatingLimit.Text = "label3";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtDepositEventLog);
            this.groupBox3.Controls.Add(this.btnShowAllDeposit);
            this.groupBox3.Controls.Add(this.btnShowFilteredDeposit);
            this.groupBox3.Controls.Add(this.txtCustomerPaid);
            this.groupBox3.Controls.Add(this.txtSeatingNumber);
            this.groupBox3.Controls.Add(this.chkSendRaw);
            this.groupBox3.Controls.Add(this.txtCustomerAccount);
            this.groupBox3.Controls.Add(this.btnOfflineBuyTicket);
            this.groupBox3.Controls.Add(this.btnCustomerPaid);
            this.groupBox3.Controls.Add(this.btnChangeSeating);
            this.groupBox3.Location = new System.Drawing.Point(6, 65);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(263, 362);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "OFFLINE";
            // 
            // txtDepositEventLog
            // 
            this.txtDepositEventLog.Location = new System.Drawing.Point(21, 246);
            this.txtDepositEventLog.Multiline = true;
            this.txtDepositEventLog.Name = "txtDepositEventLog";
            this.txtDepositEventLog.Size = new System.Drawing.Size(236, 116);
            this.txtDepositEventLog.TabIndex = 17;
            // 
            // btnShowAllDeposit
            // 
            this.btnShowAllDeposit.Location = new System.Drawing.Point(161, 202);
            this.btnShowAllDeposit.Name = "btnShowAllDeposit";
            this.btnShowAllDeposit.Size = new System.Drawing.Size(96, 38);
            this.btnShowAllDeposit.TabIndex = 19;
            this.btnShowAllDeposit.Text = "Show All Deposit Events";
            this.btnShowAllDeposit.UseVisualStyleBackColor = true;
            this.btnShowAllDeposit.Click += new System.EventHandler(this.btnShowAllDeposit_Click);
            // 
            // btnShowFilteredDeposit
            // 
            this.btnShowFilteredDeposit.Location = new System.Drawing.Point(21, 202);
            this.btnShowFilteredDeposit.Name = "btnShowFilteredDeposit";
            this.btnShowFilteredDeposit.Size = new System.Drawing.Size(123, 38);
            this.btnShowFilteredDeposit.TabIndex = 18;
            this.btnShowFilteredDeposit.Text = "Show Deposit Event Log";
            this.btnShowFilteredDeposit.UseVisualStyleBackColor = true;
            this.btnShowFilteredDeposit.Click += new System.EventHandler(this.btnCaptureDeposit_Click);
            // 
            // txtCustomerPaid
            // 
            this.txtCustomerPaid.Location = new System.Drawing.Point(21, 126);
            this.txtCustomerPaid.Multiline = true;
            this.txtCustomerPaid.Name = "txtCustomerPaid";
            this.txtCustomerPaid.ReadOnly = true;
            this.txtCustomerPaid.Size = new System.Drawing.Size(236, 72);
            this.txtCustomerPaid.TabIndex = 17;
            // 
            // txtSeatingNumber
            // 
            this.txtSeatingNumber.Location = new System.Drawing.Point(150, 72);
            this.txtSeatingNumber.Name = "txtSeatingNumber";
            this.txtSeatingNumber.Size = new System.Drawing.Size(107, 20);
            this.txtSeatingNumber.TabIndex = 16;
            // 
            // txtCustomerAccount
            // 
            this.txtCustomerAccount.Location = new System.Drawing.Point(150, 100);
            this.txtCustomerAccount.Name = "txtCustomerAccount";
            this.txtCustomerAccount.Size = new System.Drawing.Size(107, 20);
            this.txtCustomerAccount.TabIndex = 10;
            // 
            // btnCustomerPaid
            // 
            this.btnCustomerPaid.Location = new System.Drawing.Point(21, 98);
            this.btnCustomerPaid.Name = "btnCustomerPaid";
            this.btnCustomerPaid.Size = new System.Drawing.Size(123, 22);
            this.btnCustomerPaid.TabIndex = 13;
            this.btnCustomerPaid.Text = "How much did x pay";
            this.btnCustomerPaid.UseVisualStyleBackColor = true;
            this.btnCustomerPaid.Click += new System.EventHandler(this.btnCustomerPaid_Click);
            // 
            // btnChangeSeating
            // 
            this.btnChangeSeating.Location = new System.Drawing.Point(21, 70);
            this.btnChangeSeating.Name = "btnChangeSeating";
            this.btnChangeSeating.Size = new System.Drawing.Size(123, 22);
            this.btnChangeSeating.TabIndex = 12;
            this.btnChangeSeating.Text = "ChangeSeating (Offline)";
            this.btnChangeSeating.UseVisualStyleBackColor = true;
            this.btnChangeSeating.Click += new System.EventHandler(this.btnChangeSeating_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtContractBinary);
            this.groupBox2.Controls.Add(this.txtAbi);
            this.groupBox2.Controls.Add(this.btnSendContract);
            this.groupBox2.Controls.Add(this.txtTxDetails);
            this.groupBox2.Controls.Add(this.btnGetTxbyHash);
            this.groupBox2.Controls.Add(this.txtTxHash);
            this.groupBox2.Controls.Add(this.txtBinary);
            this.groupBox2.Controls.Add(this.btnGetTxinBlock);
            this.groupBox2.Controls.Add(this.txtBlockNumber);
            this.groupBox2.Controls.Add(this.btnSendEth);
            this.groupBox2.Controls.Add(this.btnGenerateAcc);
            this.groupBox2.Controls.Add(this.txtRecepientAddr);
            this.groupBox2.Controls.Add(this.txtRaw);
            this.groupBox2.Controls.Add(this.btnSendRaw);
            this.groupBox2.Controls.Add(this.lblUpdated);
            this.groupBox2.Controls.Add(this.lblAtBlock);
            this.groupBox2.Controls.Add(this.lblPeers);
            this.groupBox2.Location = new System.Drawing.Point(287, 48);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(633, 433);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "General";
            // 
            // txtTxDetails
            // 
            this.txtTxDetails.Location = new System.Drawing.Point(280, 277);
            this.txtTxDetails.Multiline = true;
            this.txtTxDetails.Name = "txtTxDetails";
            this.txtTxDetails.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtTxDetails.Size = new System.Drawing.Size(347, 151);
            this.txtTxDetails.TabIndex = 16;
            this.txtTxDetails.WordWrap = false;
            // 
            // btnGetTxbyHash
            // 
            this.btnGetTxbyHash.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnGetTxbyHash.Location = new System.Drawing.Point(280, 247);
            this.btnGetTxbyHash.Name = "btnGetTxbyHash";
            this.btnGetTxbyHash.Size = new System.Drawing.Size(100, 22);
            this.btnGetTxbyHash.TabIndex = 15;
            this.btnGetTxbyHash.Text = "Get Tx by Hash";
            this.btnGetTxbyHash.UseVisualStyleBackColor = true;
            this.btnGetTxbyHash.Click += new System.EventHandler(this.btnGetTxbyHash_Click);
            // 
            // txtTxHash
            // 
            this.txtTxHash.Location = new System.Drawing.Point(386, 249);
            this.txtTxHash.Name = "txtTxHash";
            this.txtTxHash.Size = new System.Drawing.Size(241, 20);
            this.txtTxHash.TabIndex = 14;
            // 
            // txtBinary
            // 
            this.txtBinary.Location = new System.Drawing.Point(280, 39);
            this.txtBinary.Multiline = true;
            this.txtBinary.Name = "txtBinary";
            this.txtBinary.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBinary.Size = new System.Drawing.Size(347, 204);
            this.txtBinary.TabIndex = 13;
            this.txtBinary.WordWrap = false;
            // 
            // btnGetTxinBlock
            // 
            this.btnGetTxinBlock.Location = new System.Drawing.Point(280, 11);
            this.btnGetTxinBlock.Name = "btnGetTxinBlock";
            this.btnGetTxinBlock.Size = new System.Drawing.Size(100, 23);
            this.btnGetTxinBlock.TabIndex = 12;
            this.btnGetTxinBlock.Text = "Get Tx In Block";
            this.btnGetTxinBlock.UseVisualStyleBackColor = true;
            this.btnGetTxinBlock.Click += new System.EventHandler(this.btnGetTxinBlock_Click);
            // 
            // txtBlockNumber
            // 
            this.txtBlockNumber.Location = new System.Drawing.Point(386, 13);
            this.txtBlockNumber.Name = "txtBlockNumber";
            this.txtBlockNumber.Size = new System.Drawing.Size(58, 20);
            this.txtBlockNumber.TabIndex = 11;
            this.txtBlockNumber.Text = "32012";
            // 
            // btnSendEth
            // 
            this.btnSendEth.Location = new System.Drawing.Point(6, 107);
            this.btnSendEth.Name = "btnSendEth";
            this.btnSendEth.Size = new System.Drawing.Size(78, 22);
            this.btnSendEth.TabIndex = 10;
            this.btnSendEth.Text = "Send 20 Eth";
            this.btnSendEth.UseVisualStyleBackColor = true;
            this.btnSendEth.Click += new System.EventHandler(this.btnSendEth_Click);
            // 
            // lblHomeAcc
            // 
            this.lblHomeAcc.AutoSize = true;
            this.lblHomeAcc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lblHomeAcc.Location = new System.Drawing.Point(15, 21);
            this.lblHomeAcc.Name = "lblHomeAcc";
            this.lblHomeAcc.Size = new System.Drawing.Size(53, 20);
            this.lblHomeAcc.TabIndex = 18;
            this.lblHomeAcc.Text = "label3";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lblBalance.Location = new System.Drawing.Point(563, 21);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(53, 20);
            this.lblBalance.TabIndex = 19;
            this.lblBalance.Text = "label3";
            // 
            // btnSendContract
            // 
            this.btnSendContract.Location = new System.Drawing.Point(152, 405);
            this.btnSendContract.Name = "btnSendContract";
            this.btnSendContract.Size = new System.Drawing.Size(122, 22);
            this.btnSendContract.TabIndex = 18;
            this.btnSendContract.Text = "Send Contract";
            this.btnSendContract.UseVisualStyleBackColor = true;
            this.btnSendContract.Click += new System.EventHandler(this.btnSendContract_Click);
            // 
            // txtAbi
            // 
            this.txtAbi.Location = new System.Drawing.Point(51, 300);
            this.txtAbi.Multiline = true;
            this.txtAbi.Name = "txtAbi";
            this.txtAbi.Size = new System.Drawing.Size(223, 49);
            this.txtAbi.TabIndex = 19;
            // 
            // txtContractBinary
            // 
            this.txtContractBinary.Location = new System.Drawing.Point(51, 355);
            this.txtContractBinary.Multiline = true;
            this.txtContractBinary.Name = "txtContractBinary";
            this.txtContractBinary.Size = new System.Drawing.Size(223, 44);
            this.txtContractBinary.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 358);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Binary";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 314);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Abi";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 493);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.lblHomeAcc);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOnlineBuyTicket;
        private System.Windows.Forms.Button btnGenerateAcc;
        private System.Windows.Forms.TextBox txtRecepientAddr;
        private System.Windows.Forms.Button btnOfflineBuyTicket;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnSendRaw;
        private System.Windows.Forms.TextBox txtRaw;
        private System.ComponentModel.BackgroundWorker bgRefreshWorker;
        private System.Windows.Forms.Label lblAtBlock;
        private System.Windows.Forms.Label lblPeers;
        private System.Windows.Forms.Label lblUpdated;
        private System.Windows.Forms.Label lblCustomerCount;
        private System.Windows.Forms.CheckBox chkSendRaw;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnChangeSeating;
        private System.Windows.Forms.Button btnCustomerPaid;
        private System.Windows.Forms.TextBox txtCustomerAccount;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtSeatingNumber;
        private System.Windows.Forms.Label lblSeatingLimit;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox txtCustomerPaid;
        private System.Windows.Forms.Button btnSendEth;
        private System.Windows.Forms.Label lblHomeAcc;
        private System.Windows.Forms.TextBox txtBinary;
        private System.Windows.Forms.Button btnGetTxinBlock;
        private System.Windows.Forms.TextBox txtBlockNumber;
        private System.Windows.Forms.TextBox txtTxDetails;
        private System.Windows.Forms.Button btnGetTxbyHash;
        private System.Windows.Forms.TextBox txtTxHash;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Button btnShowFilteredDeposit;
        private System.Windows.Forms.Button btnShowAllDeposit;
        private System.Windows.Forms.TextBox txtDepositEventLog;
        private System.Windows.Forms.Button btnSendContract;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtContractBinary;
        private System.Windows.Forms.TextBox txtAbi;
    }
}

