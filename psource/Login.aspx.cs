using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace JECRC_PMall
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string bt = IGTMAIN.IsMobileBrowser();
            string abv;
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            IGTMAIN.cmdtextAll = "Select * from User_Details ";

            string script = "Welcome!!!";
            if (txt_User_ID.Text.Length != 0 && txt_Password.Text.Length != 0)
            {
                using (SqlConnection con = new SqlConnection(IGTMAIN.CS))
                {
                    string cmdText = "SELECT * FROM User_Details where  User_Code=@Id";
                    SqlCommand cmd = new SqlCommand(cmdText, con);
                    cmd.Parameters.AddWithValue("@Id", txt_User_ID.Text.ToUpper());
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
                        if (txt_Password.Text.ToUpper() == _password)
                        {
                            Session.RemoveAll();
                            Session["User_ID"] = dr["User_Name"].ToString();
                            Session["Login_Time"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            Session["LActive_Time"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            Session["Status"] = "ACTIVE";
                            Response.Redirect("AdminDefault.aspx");
                        }
                        else
                        {
                            script = "alert(\" Wrong  Password entered.\");";
                            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                        }

                    }
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

    