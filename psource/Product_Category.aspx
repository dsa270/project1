<%@ Page Title="" Language="C#" MasterPageFile="~/ADMIN_Patna_Mall.Master" AutoEventWireup="true" CodeBehind="Product_Category.aspx.cs" Inherits="JECRC_PMall.Product_Category" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-sm-12"> 
       <div class="col-sm-12">
           <div class="col-sm-1"> Code</div>
           <div class="col-sm-5"> <asp:TextBox ID="txt_PC_Code" runat="server" Width="40%" ></asp:TextBox>
               
                   <asp:DropDownList id="ddl_pc_code"   Width="40%" runat ="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_pc_code_SelectedIndexChanged"></asp:DropDownList>

           </div>

           <div class="col-sm-1"> Status</div>
           <div class="col-sm-5"> <asp:DropDownList ID="ddl_PC_Status" runat="server" Width="100%" ></asp:DropDownList></div>
       </div>
        <div class="col-sm-12">
           <div class="col-sm-1"> Name</div>
           <div class="col-sm-11"> <asp:TextBox ID="txt_PC_Name" runat="server" Width="100%" ></asp:TextBox></div>

             </div>
        <div class="col-sm-12">
           <div class="col-sm-1"> Details</div>
           <div class="col-sm-11"> <asp:TextBox ID="txt_PC_Details" runat="server" Width="100%" ></asp:TextBox></div>

             </div>

        <div class="col-sm-12">
           <div class="col-sm-1"> Start Date</div>
           <div class="col-sm-11"> <asp:TextBox ID="txt_PC_SDate" runat="server" Width="100%" ></asp:TextBox></div>

             </div>
         <div class="col-sm-12">
           <div class="col-sm-1"> End Date</div>
           <div class="col-sm-11"> <asp:TextBox ID="txt_PC_EDate" runat="server" Width="100%" ></asp:TextBox></div>

           




             </div>

        <div class="col-sm-12">
            <div class="col-sm-6"><asp:Button ID="Button1" runat="server" Text="Button" /><asp:Label ID="lbl_message" runat="server" ForeColor="Red" Font-Bold="true" Font-Size ="Large"></asp:Label></div>
           
           <div class="col-sm-2"> <asp:Button ID="btn_Edit" runat="server" Text="EDIT" OnClick="btn_Edit_Click" ForeColor="LightGreen" Font-Bold="true"/></div>
             <div class="col-sm-2"> <asp:Button ID="btn_submit" runat="server" OnClick="btn_submit_Click" ForeColor="Blue" Text="SUBMIT" Font-Bold="true" /></div>
            <div class="col-sm-2"> <asp:Button ID="btn_Del" runat="server" Text="DELETE" ForeColor="Tomato" OnClick="btn_Del_Click" Font-Bold="true" /></div>
            
              </div>

    </div>
    

</asp:Content>
