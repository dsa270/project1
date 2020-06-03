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
    public partial class WebForm1 : System.Web.UI.Page
    {
      

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddl_PsC_Status.Items.Add("ACTIVE");
                ddl_PsC_Status.Items.Add("INACTIVE");
                ddl_PsC_Code.Visible = false;
                txt_PsC_Code.Visible = true;

                string selcectProduct_Category = "SELECT product_category_code FROM PRODUCT_CATEGORY where product_category_status='ACTIVE' order by product_category_id";
                SqlDataAdapter daPC_Code = new SqlDataAdapter(selcectProduct_Category, Ritika.CS);
                DataTable dtPC_Code = new DataTable();
                daPC_Code.Fill(dtPC_Code);

                ddl_pc_code.DataSource = dtPC_Code;
                ddl_pc_code.DataTextField = "product_category_code";
                ddl_pc_code.DataValueField = "product_category_code";
                ddl_pc_code.DataBind();

                ddl_pc_code.SelectedIndex = 0;

            }


        }


        protected void clearscreen()
        {

            txt_PsC_Code.Enabled = true;
            txt_PsC_Code.Text = "";
            txt_PsC_Details.Text = "";
            txt_PsC_EDate.Text = "";
            txt_PsC_Name.Text = "";
            txt_PsC_SDate.Text = "";
            Ritika.ctype = "";
            ddl_PsC_Code.Visible = false;
            txt_PsC_Code.Visible = true;
            ddl_PsC_Code.Items.Clear();




        }



        //       protected void btn_Add_Click(object sender, EventArgs e)
        //       {

        //           lbl_message.Text = "";
        //           string codeavailable = "N";

        //           using (SqlConnection con = new SqlConnection(Ritika.CS))
        //           {
        //               string cmdText = "SELECT product_sub_category_code FROM PRODUCT_sub_CATEGORY where product_sub_category_code= @product_sub_category_code";


        //               SqlCommand cmd = new SqlCommand(cmdText, con);
        //               cmd.Parameters.AddWithValue("@product_sub_category_code", txt_PsC_Code.Text);
        //               con.Open();
        //               SqlDataReader dr = cmd.ExecuteReader();

        //               if (dr.HasRows)
        //               {
        //                   string script = "alert(\"product sub category Already Exist.\");";
        //                   ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
        //                   codeavailable = "Y";
        //               }
        //           }


        //if (codeavailable =="N")
        //           {







        //           //loop of connection
        //           using (SqlConnection con = new SqlConnection(IGTMAIN.CS))
        //           {
        //               //Command to be executed on Sql Server 
        //               //values will be in the form of variable
        //               string cmdText = "INSERT INTO PRODUCT_Sub_CATEGORY (product_Sub_category_code, product_sub_category_name,product_category_code, product_Sub_category_details,product_Sub_category_status, product_Sub_category_start_date,product_Sub_category_end_date)VALUES (@product_Sub_category_code, @product_sub_category_name,@product_category_code, @product_Sub_category_details,@product_Sub_category_status, @product_Sub_category_start_date,@product_Sub_category_end_date)";
        //               //establish connection with DB
        //               SqlCommand cmd = new SqlCommand(cmdText, con);
        //               //taking Argument value of cmdText from different tools like textbox, ddl etc

        //               cmd.Parameters.AddWithValue("@product_Sub_category_code", txt_PsC_Code.Text.ToUpper());
        //               cmd.Parameters.AddWithValue("@product_category_code", ddl_pc_code.Text.ToUpper());
        //               cmd.Parameters.AddWithValue("@product_Sub_category_details", txt_PsC_Details.Text.ToUpper());
        //               cmd.Parameters.AddWithValue("@product_sub_category_name", txt_PsC_Name.Text.ToUpper());

        //               cmd.Parameters.AddWithValue("@product_sub_category_status", ddl_PsC_Status.Text.ToUpper());

        //               cmd.Parameters.AddWithValue("@product_sub_category_start_date", txt_PsC_SDate.Text.ToUpper());

        //               cmd.Parameters.AddWithValue("@product_sub_category_end_date", txt_PsC_EDate.Text.ToUpper());




        //               //it will open the connection 
        //               con.Open();
        //               //it will execute the cmd 
        //               cmd.ExecuteNonQuery();

        //                  }
        //                  }


        //           lbl_message.Text="data entered";

        //}


        protected void btn_Edit_Click(object sender, EventArgs e)
        {
            lbl_message.Text = "";

            string selcectsubProduct_Category = "SELECT   product_sub_category_code FROM PRODUCT_sub_CATEGORY order by product_sub_category_id";

            SqlDataAdapter daPC_Code = new SqlDataAdapter(selcectsubProduct_Category, Ritika.CS);
            DataTable dtPC_Code = new DataTable();
            daPC_Code.Fill(dtPC_Code);

            ddl_PsC_Code.DataSource = dtPC_Code;
            ddl_PsC_Code.DataTextField = "product_sub_category_code";
            ddl_PsC_Code.DataValueField = "product_sub_category_code";
            ddl_PsC_Code.DataBind();



            ddl_PsC_Code.SelectedIndex = 0;
            txt_PsC_Code.Visible = false;
            ddl_PsC_Code.Visible = true;
            //to show first data on the screen
            ddl_PsC_Code_SelectedIndexChanged(sender, e);
            Ritika.ctype = "edit";
        }

        protected void btn_Del_Click(object sender, EventArgs e)
        {
            lbl_message.Text = "";

            //loop of connection
            using (SqlConnection con = new SqlConnection(Ritika.CS))
            {
                //Command to be executed on Sql Server 
                //values will be in the form of variable
                string cmdText = "UPDATE product_sub_category SET product_sub_category_status ='INACTIVE' WHERE product_sub_category_code=@product_sub_category_code";
                //establish connection with DB
                SqlCommand cmd = new SqlCommand(cmdText, con);
                //taking Argument value of cmdText from different tools like textbox, ddl etc
                cmd.Parameters.AddWithValue("@product_sub_category_code", ddl_PsC_Code.Text.ToUpper());
                //it will open the connection 
                con.Open();
                //it will execute the cmd 
                cmd.ExecuteNonQuery();

            }
           
            lbl_message.Text = "data is inactive";
            clearscreen();
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
                    string cmdText = "UPDATE  product_Sub_category set product_category_code=@product_category_code,product_Sub_category_code=@product_Sub_category_code, product_Sub_category_name=@product_Sub_category_name, product_Sub_category_details=@product_Sub_category_details,product_Sub_category_status=@product_Sub_category_status, product_Sub_category_start_date=@product_Sub_category_start_date,product_Sub_category_end_date=@product_Sub_category_end_date where product_Sub_category_code=@product_Sub_category_code";
                    //establish connection with DB
                    SqlCommand cmd = new SqlCommand(cmdText, con);
                    //taking Argument value of cmdText from different tools like textbox, ddl etc
                    cmd.Parameters.AddWithValue("@product_Sub_category_code", ddl_PsC_Code.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@product_Sub_category_name", txt_PsC_Name.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@product_Sub_category_details", txt_PsC_Details.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@product_category_code", ddl_pc_code.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@product_Sub_category_status", ddl_PsC_Status.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@product_Sub_category_start_date", txt_PsC_SDate.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@product_Sub_category_end_date", txt_PsC_EDate.Text.ToUpper());
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
                    string cmdText = "SELECT product_sub_category_code FROM PRODUCT_sub_CATEGORY where product_sub_category_code= @product_sub_category_code";
                    SqlCommand cmd = new SqlCommand(cmdText, con);
                    cmd.Parameters.AddWithValue("@product_sub_category_code", txt_PsC_Code.Text);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        string script = "alert(\"product sub category Already Exist.\");";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                        codeavailable = "Y";
                        lbl_message.Text = "data already exist";
                    }
                }


                if (codeavailable == "N")
                {
                    //loop of connection
                    using (SqlConnection con = new SqlConnection(IGTMAIN.CS))
                    {
                        //Command to be executed on Sql Server 
                        //values will be in the form of variable
                        string cmdText = "INSERT INTO PRODUCT_Sub_CATEGORY (product_Sub_category_code, product_sub_category_name,product_category_code, product_Sub_category_details,product_Sub_category_status, product_Sub_category_start_date,product_Sub_category_end_date)VALUES (@product_Sub_category_code, @product_sub_category_name,@product_category_code, @product_Sub_category_details,@product_Sub_category_status, @product_Sub_category_start_date,@product_Sub_category_end_date)";
                        //establish connection with DB
                        SqlCommand cmd = new SqlCommand(cmdText, con);
                        //taking Argument value of cmdText from different tools like textbox, ddl etc

                        cmd.Parameters.AddWithValue("@product_Sub_category_code", txt_PsC_Code.Text.ToUpper());
                        cmd.Parameters.AddWithValue("@product_category_code", ddl_pc_code.Text.ToUpper());
                        cmd.Parameters.AddWithValue("@product_Sub_category_details", txt_PsC_Details.Text.ToUpper());
                        cmd.Parameters.AddWithValue("@product_sub_category_name", txt_PsC_Name.Text.ToUpper());

                        cmd.Parameters.AddWithValue("@product_sub_category_status", ddl_PsC_Status.Text.ToUpper());

                        cmd.Parameters.AddWithValue("@product_sub_category_start_date", txt_PsC_SDate.Text.ToUpper());

                        cmd.Parameters.AddWithValue("@product_sub_category_end_date", txt_PsC_EDate.Text.ToUpper());




                        //it will open the connection 
                        con.Open();
                        //it will execute the cmd 
                        cmd.ExecuteNonQuery();
                    }
                    lbl_message.Text = "data entered";
                    
                }
               
            }
            clearscreen();
        }



        protected void ddl_PsC_Code_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(Ritika.CS))
            {
                string cmdText = "SELECT product_category_code, product_Sub_category_name, product_Sub_category_details, product_Sub_category_status, product_Sub_category_start_date, product_Sub_category_end_date  FROM PRODUCT_Sub_CATEGORY where product_Sub_category_code= @product_Sub_category_code";
                SqlCommand cmd = new SqlCommand(cmdText, con);
                cmd.Parameters.AddWithValue("@product_Sub_category_code", ddl_PsC_Code.Text);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();
                  
                    txt_PsC_Name.Text = dr["product_Sub_category_name"].ToString();

                    ddl_pc_code.Text = dr["product_category_code"].ToString();
                    txt_PsC_Details.Text = dr["product_Sub_category_details"].ToString();
                    txt_PsC_SDate.Text = dr["product_Sub_category_start_date"].ToString();
                    txt_PsC_EDate.Text = dr["product_Sub_category_end_date"].ToString();
                    ddl_PsC_Status.Text = dr["product_Sub_category_status"].ToString();
                }



            }
        }

        protected void ddl_pc_code_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
        

        
       
    

        