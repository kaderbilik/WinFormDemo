using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectOne
{
    public partial class FLogin : Form
    {
        public FLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            bool girisYapildiMi = false;


            var userName = txtUsername.Text;
            var password = txtPassword.Text;


            var lines = File.ReadAllLines("users.txt");


            foreach (var line in lines)
            {
                var kullaniciAdi = line.Split(';')[0].ToString();
                var sifre = line.Split(';')[1].ToString();

                if (kullaniciAdi == userName && sifre == password)
                {
                    FMain fMain = new FMain();
                    fMain.Show();
                    fMain.BringToFront();
                    girisYapildiMi = true;
                    this.Hide();
                    break;
                }

            }

            if (!girisYapildiMi)
            {

                MessageBox.Show("Hesap bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Text = null;
                txtPassword.Text = null;

            }

        }
    }
}
