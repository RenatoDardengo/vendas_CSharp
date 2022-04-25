using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using salesSystem.BLL;
using salesSystem.DTO;
namespace salesSystem.UI
{
    public partial class Frm02_Login : Form
    {
        public Frm02_Login()
        {
            InitializeComponent();
        }

        private void Frm02_Login_Load(object sender, EventArgs e)
        {
            LoginBLL bll = new LoginBLL();
            bll.ConnectionTest();
            if (bll.retorno == true)
            {
                cboUser.DisplayMember = "name".TrimEnd();
                cboUser.DataSource = bll.LoadUser();
                cboUser.Text = "";
            }

            else
            {
                Application.Exit();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            // Validation of data
            if (cboUser.Text==string.Empty)
            {
                lblMessage.Text = " Informe seu usuário para continuar!";
                return;

            }
            else if (txtPassword.Text == string.Empty)
            {
                lblMessage.Text = " Informe sua senha para continuar!";
                 return;

            }

            var dto = new LoginDTO();
            var bll = new LoginBLL();
            dto.TypePassword = txtPassword.Text;
            dto.Username = cboUser.Text;
            dto.Password = "";
            
            bll.ValidateLogin(dto);


            if (dto.TypePassword == dto.Password)
            {
                pnlProgress.Width = 1;

                while (pnlProgress.Width < 540)
                {
                    pnlProgress.Width += 5;
                    Thread.Sleep(1);
                }

                this.Close();
                Thread frm = new Thread(OpenFrmMain);
                frm.SetApartmentState(ApartmentState.STA);
                frm.Start();
            }
            else
            {
                lblmsg.Text = "Senha Incorreta!!";
                txtPassword.Text = "";
            }
        }
        private void OpenFrmMain()
        {
            Application.Run(new Frm03_Principal());

        }
    }
}
