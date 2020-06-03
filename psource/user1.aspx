<%@ Page Title="" Language="C#" MasterPageFile="~/ADMIN_Patna_Mall.Master" AutoEventWireup="true" CodeBehind="user1.aspx.cs" Inherits="JECRC_PMall.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="col-sm-12"> 
      
    
      <div class="col-sm-12">
           <div class="col-sm-1"> user_code</div>
           <div class="col-sm-5"> <asp:TextBox ID="txt_user_code" runat="server" Width="40%"></asp:TextBox></div>
         <asp:DropDownList ID="ddl_user_code" runat="server" Width="40%" AutoPostBack="true" OnSelectedIndexChanged="ddl_user_code_SelectedIndexChanged"></asp:DropDownList>
      
      </div>
             <div class="col-sm-12">
             <div class="col-sm-1"> user_type</div>
          <div class="col-sm-5"><asp:DropDownList ID="ddl_user_type" runat="server" autopostback="true" Width="40%"></asp:DropDownList> 
          </div><div class="col-sm-1"> user_status</div>
            <div class="col-sm-5"><asp:DropDownList ID="ddl_user_status" runat="server" Width="100%" ></asp:DropDownList>
               </div>
                    </div>
             <div class="col-sm-12">
           <div class="col-sm-1"> user_name</div>
           <div class="col-sm-11"> <asp:TextBox ID="txt_user_name" runat="server" Width="100%" ></asp:TextBox></div>

             </div>
        <div class="col-sm-12">
           <div class="col-sm-1"> user_email</div>
           <div class="col-sm-5"> <asp:TextBox ID="txt_user_email" runat="server" Width="100%" ></asp:TextBox></div>

           

       
           <div class="col-sm-1"> user_email2</div>
           <div class="col-sm-5"> <asp:TextBox ID="txt_user_email2" runat="server" Width="100%" ></asp:TextBox></div>

             </div>
         <div class="col-sm-12">
           <div class="col-sm-1"> user_phone</div>
           <div class="col-sm-5"> <asp:TextBox ID="txt_user_phone" runat="server" Width="100%" ></asp:TextBox></div>
            <div class="col-sm-1"> user_phone2</div>
           <div class="col-sm-5"> <asp:TextBox ID="txt_user_phone2" runat="server" Width="100%" ></asp:TextBox></div>
             </div>


            <div class="col-sm-12">
      
           <div class="col-sm-1"> user_password</div>
           <div class="col-sm-5"> <asp:TextBox ID="txt_user_password" runat="server" Width="100%" ></asp:TextBox></div>
            <div class="col-sm-1"> conform user_password</div>
           <div class="col-sm-5"> <asp:TextBox ID="txt_user_password_conform" runat="server" Width="100%" ></asp:TextBox></div>
            </div>
            <div class="col-sm-12">
           <div class="col-sm-1"> user_remark</div>
           <div class="col-sm-11"> <asp:TextBox ID="txt_user_remark" runat="server" Width="100%" ></asp:TextBox></div>

          
             </div>
              <div class="col-sm-12">
             <div class="col-sm-2"><asp:Label ID="lbl_message" runat="server" ForeColor="HotPink"></asp:Label></div>
                  <div class="col-sm-2"> <asp:Button ID="btn_edit" runat="server" Text="edit" OnClick="btn_edit_Click" /></div>
                   <div class="col-sm-2"> <asp:Button ID="btn_delete" runat="server" Text="delete" OnClick="btn_delete_Click" /></div>
                    <div class="col-sm-2"> <asp:Button ID="btn_submit" runat="server" Text="submit" OnClick="btn_submit_Click" /></div>
                  </div>
                  </div>

</asp:Content>



 