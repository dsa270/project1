<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="loginpage.aspx.cs" Inherits="JECRC_PMall.loginpage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-sm-12">
    <div class="col-sm-12">
        <div class="col-sm-4">email id</div>
        <div class="col-sm-4"><asp:TextBox ID="txt_email_id" runat="server" Width="100"></asp:TextBox></div>
     </div>


        <div class="col-sm-12">
        <div class="col-sm-4">password</div>
        <div class="col-sm-4"><asp:TextBox ID="txt_password" runat="server" Width="100"></asp:TextBox></div>
     </div>
      

        
        <div class="col-sm-12">
        <div class="col-sm-4">submit</div>
       <div class="col-sm-6"><asp:Button ID="btn_log" runat="server" Width="100" Text="LOGIN" BackColor="Yellow" ForeColor="DarkRed" Font-Bold="true"/></div>
            </div>

     </div>
    
   

</asp:Content>
