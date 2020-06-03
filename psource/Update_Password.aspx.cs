using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Net;
using System.Text.RegularExpressions;
using System.Drawing.Drawing2D;





namespace JECRC_PMall
{
    public partial class Update_Password : System.Web.UI.Page
    {
        string script = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public static string Encryptdata(string password)
        {
            string strmsg = string.Empty;
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            strmsg = Convert.ToBase64String(encode);
            return strmsg;
        }
        protected void updatepassword()
        {
            using (SqlConnection con = new SqlConnection(IGTMAIN.CS))
            {

                string cmdText = "UPDATE User_Details SET User_pass =@User_pass  where User_Name=@User_Name";
                SqlCommand cmd = new SqlCommand(cmdText, con);
                cmd.Parameters.AddWithValue("@User_Name", Session["User_ID"]);
                cmd.Parameters.AddWithValue("@User_pass",IGTMAIN.Encryptdata( txt_NewPass.Text));
                con.Open();
                cmd.ExecuteNonQuery();

                script = "alert(\" Password Succesfully Updated.\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                

            }



        }
        protected void btn_Submit_Click(object sender, EventArgs e)
        {

            if (txt_CPass.Text.Length > 0 && txt_NCPass.Text.Length > 0 && txt_NewPass.Text.Length > 0)
            {
                using (SqlConnection con = new SqlConnection(IGTMAIN.CS))
                {
                    string cmdText = "SELECT * FROM User_Details where  User_Code='" + Session["User_ID"] + "'";
                    SqlCommand cmd = new SqlCommand(cmdText, con);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows == false)
                    {
                        script = "alert(\" Wrong User Name Entered.\");";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                    }

                    else if (dr.HasRows == true)
                    {
                        dr.Read();

                        string _password = dr["User_pass"].ToString();
                        _password = IGTMAIN.Decryptdata(_password);
                        if (txt_CPass.Text == _password)
                        {

                            if (txt_NCPass.Text == txt_NewPass.Text)
                            {
                                updatepassword();

                            }

                            else
                            {
                                script = "alert(\"New Password and Confirm Password not Matching.\");";
                                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);

                            }


                        }
                        else
                        {
                            script = "alert(\" Wrong Current Password entered.\");";
                            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                        }



                    }
                    else
                    {
                        script = "alert(\" All Fields are Manadatory. Please fill and Submit again.\");";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);

                    }

                }
            }
        }
    }
}
