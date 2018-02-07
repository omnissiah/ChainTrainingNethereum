using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChainCore.UI
{
    public partial class frmPass : Form
    {
        private string previousPass = null;
        public string Pass { get; private set; }
        public bool IsMatch { get; private set; }
        private bool isAccountCreation = false;
        public frmPass(bool isAccountCreation)
        {
            InitializeComponent();
            lblPass.Text = "Password:";
            IsMatch = false;
            this.isAccountCreation = isAccountCreation;
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPass.Text))
                new frmMessageBox("Password cannot be empty").ShowDialog();
            else
            {
                if (previousPass != null)
                {
                    if (!previousPass.Equals(txtPass.Text))
                    {
                        new frmMessageBox("Passwords do not match. Please try again.").ShowDialog();
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                    }
                    else
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        Pass = previousPass;
                        IsMatch = true;
                    }
                }
                else
                {
                    if(!isAccountCreation)
                        Pass = txtPass.Text; 
                    previousPass = txtPass.Text;
                    txtPass.Text = string.Empty;
                    lblPass.Text = "Repeat:"; this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Dispose();
        }

        private void frmPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtPass.Text))
                    new frmMessageBox("Password cannot be empty").ShowDialog();
                else
                {
                    if (previousPass != null)
                    {
                        if (!previousPass.Equals(txtPass.Text))
                        {
                            new frmMessageBox("Passwords do not match. Please try again.").ShowDialog();
                            this.DialogResult = DialogResult.Cancel;
                            this.Close();
                        }
                        else
                        {
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                            Pass = previousPass;
                            IsMatch = true;
                        }
                    }
                    else
                    {
                        if (!isAccountCreation)
                            Pass = txtPass.Text;
                        previousPass = txtPass.Text;
                        txtPass.Text = string.Empty;
                        lblPass.Text = "Repeat:"; this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            } 
        }
    }
}
