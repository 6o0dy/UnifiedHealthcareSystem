using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace UnifiedHealthcareSystem
{
    public partial class ResetPassword : Form
    {
        public ResetPassword()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            Reset(txtUsername.Text, textID.Text, textPhone.Text, txtPassword.Text);
        }

        // ميثود تغير كلمه المرور تقوم بالتحقق من البيانات المدخله ثم تغير كلمه المرور في حال كانت البيانات صحيحه
        private void Reset(string user, string id, string phone, string newPass)
        {
            GetAccountsFromFile all = new GetAccountsFromFile();

            CreatAccount[] account = all.AllAccounts();
            for (int i = 0; i < account.Length; i++)
            {
                if (account[i].username == user && account[i].id == id && account[i].info.phone == phone)
                {
                    if (newPass.Length > 5)
                    {
                        account[i].info.password = newPass;

                        Read_Write.WriteInFile("DoctorAccount.json", account);

                        MessageBox.Show("تم تغير كلمه المرور", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        return;
                    }
                    MessageBox.Show("كلمه المرور يجب ان تكون اكثر من 5 حروف", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            MessageBox.Show("عذرا البيانات غير صحيحه", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void backTologin_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
