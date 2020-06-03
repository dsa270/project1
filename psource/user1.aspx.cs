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
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                ddl_user_status.Items.Add("ACTIVE");
                ddl_user_status.Items.Add("INACTIVE");

                ddl_user_type.Items.Add("CUSTOMER");
                ddl_user_type.Items.Add("ADMIN");
                ddl_user_type.Items.Add("USER");


            }
        }

        //protected void btn_add_Click(object sender, EventArgs e)
        //{
        //    //loop of connection
        //    using (SqlConnection con = new SqlConnection(Ritika.CS))
        //    {
        //        //Command to be executed on Sql Server 
        //        //values will be in the form of variable
        //        string cmdText = "INSERT INTO user_login (user_code,user_name,user_email,user_email2,user_phone,user_phone2,user_status,user_remark,user_password,user_type)VALUES (@user_code,@user_name,@user_email,@user_email2,@user_phone,@user_phone2,@user_status,@user_remark,@user_password,@user_type)";
        //        //establish connection with DB
        //        SqlCommand cmd = new SqlCommand(cmdText, con);
        //        //taking Argument value of cmdText from different tools like textbox, ddl etc
        //        cmd.Parameters.AddWithValue("@user_code", txt_user_code.Text.ToUpper());
        //        cmd.Parameters.AddWithValue("@user_name", txt_user_name.Text.ToUpper());
        //        cmd.Parameters.AddWithValue("@user_email", txt_user_email.Text.ToUpper());

        //        cmd.Parameters.AddWithValue("@user_email2", txt_user_email2.Text.ToUpper());

        //        cmd.Parameters.AddWithValue("@user_phone", txt_user_phone.Text.ToUpper());
        //        cmd.Parameters.AddWithValue("@user_type", ddl_user_type.Text.ToUpper());


        //        cmd.Parameters.AddWithValue("@user_phone2", txt_user_phone2.Text.ToUpper());
        //        cmd.Parameters.AddWithValue("@user_status", ddl_user_status.Text.ToUpper());
        //        cmd.Parameters.AddWithValue("@user_remark", txt_user_remark.Text.ToUpper());
        //        cmd.Parameters.AddWithValue("@user_password", txt_user_password.Text.ToUpper());




        //        //it will open the connection 
        //        con.Open();
        //        //it will execute the cmd 
        //        cmd.ExecuteNonQuery();

        //    }


        //}

        protected void btn_edit_Click(object sender, EventArgs e)
        {
            lbl_message.Text = "";
            string userdetail = "SELECT user_code FROM user_login order by user_id";

            SqlDataAdapter dau_Code = new SqlDataAdapter(userdetail, Ritika.CS);
            DataTable dtu_Code = new DataTable();
            dau_Code.Fill(dtu_Code);

            ddl_user_code.DataSource = dtu_Code;
            ddl_user_code.DataTextField = "user_code";
            ddl_user_code.DataValueField = "user_code";
            ddl_user_code.DataBind();

            ddl_user_code.SelectedIndex = 0;
            txt_user_code.Visible = false;
            ddl_user_code.Visible = true;
            //to show first data on screen
            ddl_user_code_SelectedIndexChanged(sender, e);
            Ritika.ctype = "edit";

        }

        protected void btn_delete_Click(object sender, EventArgs e)
        {

            lbl_message.Text = "";
            //loop of connection
            using (SqlConnection con = new SqlConnection(Ritika.CS))
            {
                //Command to be executed on Sql Server 
                //values will be in the form of variable
                string cmdText = "UPDATE user_login SET product_status ='INACTIVE' WHERE user_code=@user_code";
                //establish connection with DB
                SqlCommand cmd = new SqlCommand(cmdText, con);
                //taking Argument value of cmdText from different tools like textbox, ddl etc
                cmd.Parameters.AddWithValue("@user_code", ddl_user_code.Text.ToUpper());
                //it will open the connection 
                con.Open();
                //it will execute the cmd 
                cmd.ExecuteNonQuery();

                Ritika.ctype = "";
                ddl_user_code.Visible = false;
                txt_user_code.Visible = true;
                ddl_user_code.Items.Clear();

                lbl_message.Text = "data is inactive";
            }



        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {

            lbl_message.Text = "";
            if (Ritika.ctype == "edit")
            {
                //loop of connection
                using (SqlConnection con = new SqlConnection(Ritika.CS))
                {
                    //Command to be executed on Sql Server 
                    //values will be in the form of variable
                    string cmdText = "INSERT INTO user_login (user_code,user_name,user_email,user_email2,user_phone,user_phone2,user_status,user_remark,user_password,user_type)VALUES (@user_code,@user_name,@user_email,@user_email2,@user_phone,@user_phone2,@user_status,@user_remark,@user_password,@user_type)";
                    //establish connection with DB
                    SqlCommand cmd = new SqlCommand(cmdText, con);
                    //taking Argument value of cmdText from different tools like textbox, ddl etc
                    cmd.Parameters.AddWithValue("@user_code", txt_user_code.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@user_name", txt_user_name.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@user_email", txt_user_email.Text.ToUpper());

                    cmd.Parameters.AddWithValue("@user_email2", txt_user_email2.Text.ToUpper());

                    cmd.Parameters.AddWithValue("@user_phone", txt_user_phone.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@user_type", ddl_user_type.Text.ToUpper());


                    cmd.Parameters.AddWithValue("@user_phone2", txt_user_phone2.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@user_status", ddl_user_status.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@user_remark", txt_user_remark.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@user_password", txt_user_password.Text.ToUpper());




                    //it will open the connection 
                    con.Open();
                    //it will execute the cmd 
                    cmd.ExecuteNonQuery();


                }
                lbl_message.Text = "data is updated";
            }
            else
            {
                string codeavailable = "N";
                using (SqlConnection con = new SqlConnection(Ritika.CS))
                {
                    string cmdText = "SELECT user_code FROM user_login where user_code= @user_code";
                    SqlCommand cmd = new SqlCommand(cmdText, con);
                    cmd.Parameters.AddWithValue("@user_code", txt_user_code.Text);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        string script = "alert(\"product category Already Exist.\");";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                        codeavailable = "Y";
                        lbl_message.Text = "data Already Exist!!!";
                    }
                }

                if (codeavailable == "N")
                {
                    //loop of connection
                    using (SqlConnection con = new SqlConnection(Ritika.CS))
                    {
                        //Command to be executed on Sql Server 
                        //values will be in the form of variable
                        string cmdText = "INSERT INTO user_login (user_code,user_name,user_email,user_email2,user_phone,user_phone2,user_status,user_remark,user_password,user_type)VALUES (@user_code,@user_name,@user_email,@user_email2,@user_phone,@user_phone2,@user_status,@user_remark,@user_password,@user_type)";
                        //establish connection with DB
                        SqlCommand cmd = new SqlCommand(cmdText, con);
                        //taking Argument value of cmdText from different tools like textbox, ddl etc
                        cmd.Parameters.AddWithValue("@user_code", txt_user_code.Text.ToUpper());
                        cmd.Parameters.AddWithValue("@user_name", txt_user_name.Text.ToUpper());
                        cmd.Parameters.AddWithValue("@user_email", txt_user_email.Text.ToUpper());

                        cmd.Parameters.AddWithValue("@user_email2", txt_user_email2.Text.ToUpper());

                        cmd.Parameters.AddWithValue("@user_phone", txt_user_phone.Text.ToUpper());
                        cmd.Parameters.AddWithValue("@user_type", ddl_user_type.Text.ToUpper());


                        cmd.Parameters.AddWithValue("@user_phone2", txt_user_phone2.Text.ToUpper());
                        cmd.Parameters.AddWithValue("@user_status", ddl_user_status.Text.ToUpper());
                        cmd.Parameters.AddWithValue("@user_remark", txt_user_remark.Text.ToUpper());
                        cmd.Parameters.AddWithValue("@user_password", txt_user_password.Text.ToUpper());

                        //it will open the connection 
                        con.Open();
                        //it will execute the cmd 
                        cmd.ExecuteNonQuery();
                    }
                    lbl_message.Text = "data entered";
                }

            }
            Ritika.ctype = "";
            ddl_user_code.Visible = false;
            txt_user_code.Visible = true;
            ddl_user_code.Items.Clear();
        }
    
      
      
        
        protected void ddl_user_code_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(Ritika.CS))
            {
                string cmdText = "SELECT user_code,user_name,user_email,user_email2,user_phone,user_phone2,user_status,user_remark,user_password,user_type  FROM user_login where user_code= @user_code";


                SqlCommand cmd = new SqlCommand(cmdText, con);
                cmd.Parameters.AddWithValue("@user_code", ddl_user_code.Text);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();
                    txt_user_code.Text = dr["user_code"].ToString();
                    txt_user_name.Text = dr["user_name"].ToString();
                    txt_user_email.Text = dr["user_email"].ToString();
                    txt_user_email2.Text = dr["user_email2"].ToString();
                    txt_user_phone.Text = dr["user_phone"].ToString();
                    txt_user_phone2.Text = dr["user_phone2"].ToString();
                    ddl_user_status.Text = dr["user_status"].ToString();
                    txt_user_remark.Text = dr["user_remark"].ToString();
                    txt_user_password.Text = dr["user_password"].ToString();
                    ddl_user_type.Text = dr["user_type"].ToString();
                
                        }

            }
        }

}
}
        
           


























        

    
        
              
          
