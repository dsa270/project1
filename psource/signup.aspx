<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="JECRC_PMall.signup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="col-sm-12">


        <div class="col-sm-12">

            <div class="col-sm-4">ENTER YOUR NAME</div>
            <div class="col-sm-4"><asp:TextBox ID="txt_user_name" runat="server" Width="100"></asp:TextBox></div>
            </div>


        <div class="col-sm-12">

            <div class="col-sm-4">EMAIL ADDRESS</div>
            <div class="col-sm-4"><asp:TextBox ID="txt_user_email" runat="server" Width="100"></asp:TextBox></div>
            </div>



        <div class="col-sm-12">

            <div class="col-sm-4">ALTERNATIVE EMAIL ADDRESS</div>
            <div class="col-sm-4"><asp:TextBox ID="txt_user_email2" runat="server" Width="100"></asp:TextBox></div>
            </div>




        <div class="col-sm-12">

            <div class="col-sm-4">CONTACT NUMBER</div>
            <div class="col-sm-4"><asp:TextBox ID="txt_user_phone" runat="server" Width="100"></asp:TextBox></div>
            </div>




        <div class="col-sm-12">

            <div class="col-sm-4">ALTERNATIVE CONTACT NUMBER</div>
            <div class="col-sm-4"><asp:TextBox ID="txt_user_phone2" runat="server" Width="100"></asp:TextBox></div>
            </div>





        <div class="col-sm-12">

            <div class="col-sm-4">SEX</div>
            <div class="col-sm-4"><asp:TextBox ID="txt_sex" runat="server" Width="100"></asp:TextBox></div>
            </div>





        <div class="col-sm-12">

            <div class="col-sm-4">AGE</div>
            <div class="col-sm-4"><asp:TextBox ID="txt_age" runat="server" Width="100"></asp:TextBox></div>
            </div>


         <div class="col-sm-6">

           
            <div class="col-sm-6"><asp:Button ID="btn_signup" runat="server" Width="100" Text="SIGN-UP" BackColor="Yellow" ForeColor="DarkRed" Font-Bold="true"/></div>
            </div>


      
        
        
        
        
        
        
        
          </div>



   
</asp:Content>
