using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SalesSystem.DAL;
using salesSystem.UI;
using salesSystem.DTO;
using System.Drawing;

namespace salesSystem.BLL
{
    internal class LoginBLL
    {
        int largura;
        int altura;
        public bool retorno;

        public DataTable LoadUser()
        {
            try
            {
                string query = "SELECT * FROM tbl02_users where status = 'Ativo'";
                ConnDataBase connect = new ConnDataBase();
                connect.OpenDataBase();
                var source = connect.DataReturn(query);
                return source;

            }
            catch (Exception ex)
            {

                using (var msg = new Frm00_MsgOK())
                {
                    msg.lblMensagem.MaximumSize = new Size(400, 0);
                    msg.lblMensagem.AutoSize = true;
                    msg.lblTitulo.Text = "Erro de Conexão!";
                    msg.lblMensagem.Text = String.Format("Não foi possível carregar os usuários do Banco de Dados: {0}." , ex.Message);
                    largura = msg.lblMensagem.Width;
                    altura = msg.lblMensagem.Height;
                    msg.Size = new Size(largura + 100, altura + 200);
                    msg.ShowDialog();
                    return null;

                }
            }
            

        }

        public void ConnectionTest()
        {
            ConnDataBase connect = new ConnDataBase();
           
            try
            {
                
                connect.OpenDataBase();
                retorno = true;
            }
            catch (Exception ex)
            {

               using (var msg = new Frm00_MsgOK())
                {
                    msg.lblMensagem.MaximumSize = new Size(400, 0);
                    msg.lblMensagem.AutoSize = true;
                    msg.lblTitulo.Text = "Erro de Conexão!";
                    msg.lblMensagem.Text = String.Format ("Não foi possível estabelecer a conexão com o Banco de Dados: {0}. O sistema Será encerrado automaticamente.", ex.Message);
                    largura = msg.lblMensagem.Width;
                    altura = msg.lblMensagem.Height;
                    msg.Size = new Size(largura + 100, altura + 200);
                    msg.ShowDialog();
                    retorno = false;

                }
                    
            }

        }

        public void ValidateLogin(LoginDTO dto)
        {
            ConnDataBase connect = new ConnDataBase();
            using (var cmdo = new SqlCommand())
            {
                cmdo.CommandText = "SELECT * FROM tbl02_users where name=@name";
                cmdo.Parameters.Clear();
                cmdo.Parameters.AddWithValue("@name", dto.Username);

                try
                {
                    cmdo.Connection = connect.OpenDataBase();
                    SqlDataReader dr = cmdo.ExecuteReader();
                    if (dr.Read())
                    {
                        dto.Password = dr["passwor"].ToString().Trim();
                        dto.Permission = Convert.ToInt32(dr["permission"]);
                    }
                   
                }
                catch (Exception ex)
                {
                    using (var msg = new Frm00_MsgOK())
                    {
                        msg.lblMensagem.MaximumSize = new Size(400, 0);
                        msg.lblMensagem.AutoSize = true;
                        msg.lblTitulo.Text = "Erro de Conexão!";
                        msg.lblMensagem.Text = String.Format("Não foi possível efetuar a validação do usuário: {0}.", ex.Message);
                        largura = msg.lblMensagem.Width;
                        altura = msg.lblMensagem.Height;
                        msg.Size = new Size(largura + 100, altura + 200);
                        msg.ShowDialog();
                        retorno = false;

                    }

                }

            }

        }
    }
}
