using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesSystem.UI
{
    public partial class Frm01_MsgResult : Form
    {

        public bool retorno;
        public Frm01_MsgResult()
        {
            InitializeComponent();
        }

        public Frm01_MsgResult(string titulo, string mensagem, Image imagem) : this()
        {
            lblMensagem.MaximumSize = new Size(360, 0);
            lblMensagem.AutoSize = true;
            picImagem.Image = imagem;
            lblTitulo.Text = titulo;
            lblMensagem.Text = mensagem;
            int largura = lblMensagem.Width;
            int altura = lblMensagem.Height;
            if (largura > 320)
            {
                this.Size = new Size(largura + 100, altura + 200);
            }


        }


        private void btnNao_Click(object sender, EventArgs e)
        {
            retorno = false;
            this.Close();

        }

        private void btnSim_Click(object sender, EventArgs e)
        {
            retorno = true;
            this.Close();
        }

        #region Método Mover Form

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wMsg, int wParam, int lParam);
        #endregion

        private void Frm01_MsgResult_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        
    }
}
