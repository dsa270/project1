<%@ Page Title="" Language="C#" MasterPageFile="~/ADMIN_Patna_Mall.Master" AutoEventWireup="true" CodeBehind="product_sub_category.aspx.cs" Inherits="JECRC_PMall.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-sm-12"> 
       <div class="col-sm-12">
           <div class="col-sm-1"> SUB-CATEGORY Code</div>
           <div class="col-sm-3"> <asp:TextBox ID="txt_PsC_Code" runat="server" Width="40%" ></asp:TextBox>
            <asp:DropDownList ID="ddl_PsC_Code" runat="server" Width="40%" AutoPostBack="true" OnSelectedIndexChanged="ddl_PsC_Code_SelectedIndexChanged"></asp:DropDownList></div>
            <div class="col-sm-1"> CATEGORY Code</div>
           <div class="col-sm-3"> <asp:DropDownList ID="ddl_pc_code" runat="server" Width="100%" OnSelectedIndexChanged="ddl_pc_code_SelectedIndexChanged" ></asp:DropDownList></div>
           <div class="col-sm-1"> Status</div>
           <div class="col-sm-3"> <asp:DropDownList ID="ddl_PsC_Status" runat="server" Width="100%"></asp:DropDownList></div>
       </div>
        <div class="col-sm-12">
           <div class="col-sm-1"> Name</div>
           <div class="col-sm-11"> <asp:TextBox ID="txt_PsC_Name" runat="server" Width="100%" ></asp:TextBox></div>

             </div>
        <div class="col-sm-12">
           <div class="col-sm-1"> Details</div>
           <div class="col-sm-11"> <asp:TextBox ID="txt_PsC_Details" runat="server" Width="100%" ></asp:TextBox></div>

             </div>

        <div class="col-sm-12">
           <div class="col-sm-1"> Start Date</div>
           <div class="col-sm-11"> <asp:TextBox ID="txt_PsC_SDate" runat="server" Width="100%" ></asp:TextBox></div>

             </div>
         <div class="col-sm-12">
           <div class="col-sm-1"> End Date</div>
           <div class="col-sm-11"> <asp:TextBox ID="txt_PsC_EDate" runat="server" Width="100%" ></asp:TextBox></div>

             </div>
        <div class="col-sm-12">
            <div class="col-sm-6"><asp:Label ID="lbl_message" runat="server" ForeColor="Red" Font-Size="Large"></asp:Label></div>
           <div class="col-sm-2"> <asp:Button ID="btn_Edit" runat="server" Text="EDIT" ForeColor="LightSeaGreen" Font-Bold="true" OnClick="btn_Edit_Click" /></div>
            <div class="col-sm-2"> <asp:Button ID="btn_Del" runat="server" Text="DELETE" OnClick="btn_Del_Click" ForeColor="Tomato" Font-Bold="true" /></div>
            <div class="col-sm-2"> <asp:Button ID="btn_submit" runat="server" Text="SUBMIT" OnClick="btn_submit_Click" ForeColor="Blue" Font-Bold="true" /></div>
             </div>

    </div>

</asp:Content>
