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

    public partial class Product_Category : System.Web.UI.Page
    {
             
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddl_PC_Status.Items.Add("ACTIVE");
                ddl_PC_Status.Items.Add("INACTIVE");
                ddl_pc_code.Visible = false;
                txt_PC_Code.Visible = true;

            }
         
        }


        protected void clearscreen()
        {
            txt_PC_Code.Enabled = true;
            txt_PC_Code.Text = "";
            txt_PC_Details.Text = "";
            txt_PC_EDate.Text = "";
            txt_PC_Name.Text = "";
            txt_PC_SDate.Text = "";

            Ritika.ctype = "";
            ddl_pc_code.Visible = false;
           
            ddl_pc_code.Items.Clear();



        }



        protected void btn_Edit_Click(object sender, EventArgs e)
        {
            lbl_message.Text = "";

            string selcectProduct_Category = "SELECT   product_category_code FROM PRODUCT_CATEGORY order by product_category_id";
            SqlDataAdapter daPC_Code = new SqlDataAdapter(selcectProduct_Category, Ritika.CS);
            DataTable dtPC_Code = new DataTable();
            daPC_Code.Fill(dtPC_Code);
            ddl_pc_code.DataSource = dtPC_Code;
            ddl_pc_code.DataTextField = "product_category_code";
            ddl_pc_code.DataValueField = "product_category_code";
            ddl_pc_code.DataBind();

            ddl_pc_code.SelectedIndex = 0;
             txt_PC_Code.Visible = false;
             ddl_pc_code.Visible = true;
        //to show first data on the screen
           ddl_pc_code_SelectedIndexChanged(sender, e);

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
                string cmdText = "UPDATE product_category SET product_category_status ='INACTIVE' WHERE product_category_code=@product_category_code";
                //establish connection with DB
                SqlCommand cmd = new SqlCommand(cmdText, con);
                //taking Argument value of cmdText from different tools like textbox, ddl etc
                cmd.Parameters.AddWithValue("@product_category_code", ddl_pc_code.Text.ToUpper());
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
            if(Ritika.ctype == "edit")
            {       
            //loop of connection
               using (SqlConnection con = new SqlConnection(Ritika.CS))
                   {
                //Command to be executed on Sql Server 
                //values will be in the form of variable
                string cmdText = "UPDATE  product_category set product_category_name=@product_category_name, product_category_details=@product_category_details,product_category_status=@product_category_status, product_category_start_date=@product_category_start_date,product_category_end_date=@product_category_end_date where product_category_code=@product_category_code";
                //establish connection with DB
                SqlCommand cmd = new SqlCommand(cmdText, con);
                //taking Argument value of cmdText from different tools like textbox, ddl etc
                cmd.Parameters.AddWithValue("@product_category_code", ddl_pc_code.Text.ToUpper());
                cmd.Parameters.AddWithValue("@product_category_name", txt_PC_Name.Text.ToUpper());
                cmd.Parameters.AddWithValue("@product_category_details", txt_PC_Details.Text.ToUpper());
                cmd.Parameters.AddWithValue("@product_category_status", ddl_PC_Status.Text.ToUpper());
                cmd.Parameters.AddWithValue("@product_category_start_date", txt_PC_SDate.Text.ToUpper());
                cmd.Parameters.AddWithValue("@product_category_end_date", txt_PC_EDate.Text.ToUpper());                
                con.Open();           
                cmd.ExecuteNonQuery();

                 }
                lbl_message.Text = "data is updated";
            }
            else
            {
                string codeavailable = "N";
                using (SqlConnection con = new SqlConnection(Ritika.CS))
                {
                    string cmdText = "SELECT product_category_code FROM PRODUCT_CATEGORY where product_category_code= @product_category_code";
                    SqlCommand cmd = new SqlCommand(cmdText, con);
                    cmd.Parameters.AddWithValue("@product_category_code", txt_PC_Code.Text);
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
                        string cmdText = "INSERT INTO product_category (product_category_code,product_category_name, product_category_details,product_category_status, product_category_start_date,product_category_end_date)VALUES (@product_category_code, @product_category_name,@product_category_details, @product_category_status,@product_category_start_date,@product_category_end_date)";
                        //establish connection with DB
                        SqlCommand cmd = new SqlCommand(cmdText, con);
                        //taking Argument value of cmdText from different tools like textbox, ddl etc
                        cmd.Parameters.AddWithValue("@product_category_code", txt_PC_Code.Text.ToUpper());
                        cmd.Parameters.AddWithValue("@product_category_name", txt_PC_Name.Text.ToUpper());
                        cmd.Parameters.AddWithValue("@product_category_details", txt_PC_Details.Text.ToUpper());
                        cmd.Parameters.AddWithValue("@product_category_status", ddl_PC_Status.Text.ToUpper());
                        cmd.Parameters.AddWithValue("@product_category_start_date", txt_PC_SDate.Text.ToUpper());
                        cmd.Parameters.AddWithValue("@product_category_end_date", txt_PC_EDate.Text.ToUpper());
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

        protected void ddl_pc_code_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(Ritika.CS))
            {
                string cmdText = "SELECT product_category_name, product_category_details, product_category_status, product_category_start_date, product_category_end_date  FROM PRODUCT_CATEGORY where product_category_code= @product_category_code";


                SqlCommand cmd = new SqlCommand(cmdText, con);
                cmd.Parameters.AddWithValue("@product_category_code", ddl_pc_code.Text);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();
                    txt_PC_Name.Text = dr["product_category_name"].ToString();
                    txt_PC_Details.Text = dr["product_category_details"].ToString();
                    txt_PC_SDate.Text = dr["product_category_start_date"].ToString();
                    txt_PC_EDate.Text = dr["product_category_end_date"].ToString();
                    ddl_PC_Status.Text = dr["product_category_status"].ToString();
                }


            }
        }
}
}