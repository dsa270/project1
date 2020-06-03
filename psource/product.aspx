<%@ Page Title="" Language="C#" MasterPageFile="~/ADMIN_Patna_Mall.Master" AutoEventWireup="true" CodeBehind="product.aspx.cs" Inherits="JECRC_PMall.product" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

   <div class="col-sm-12"> 
      
        <div class="col-sm-12">
           <div class="col-sm-1"> product Code</div>
       <div class="col-sm-3">  <asp:TextBox ID="txt_P_Code" runat="server" Width="40%" ></asp:TextBox>
 <asp:DropDownList ID="ddl_P_code" runat="server" Width="40%" AutoPostBack="true" OnSelectedIndexChanged="ddl_P_code_SelectedIndexChanged"></asp:DropDownList>
             </div>
             </div>

            <div class="col-sm-12">
            
              <div class="col-sm-1"> product category code</div>
           <div class="col-sm-2"> <asp:DropDownList ID="ddl_pc_code" runat="server" autopostback="true" Width="100%" OnSelectedIndexChanged="ddl_pc_code_SelectedIndexChanged"></asp:DropDownList></div>
       </div>
       <div class="col-sm-12">
              
         <div class="col-sm-1"> product sub category code</div>
           <div class="col-sm-2"> <asp:DropDownList ID="ddl_PsC_code" runat="server" Width="100%" ></asp:DropDownList></div>
       

           
           <div class="col-sm-1"> product Status</div>
           <div class="col-sm-1"> <asp:DropDownList ID="ddl_P_Status" runat="server" Width="100%"></asp:DropDownList></div>
       </div>
            
        <div class="col-sm-12">
           <div class="col-sm-1">PRODUCT Name</div>
           <div class="col-sm-11"> <asp:TextBox ID="txt_P_Name"  runat="server" Width="100%" ></asp:TextBox></div>

             </div>

            <div class="col-sm-12" style="text-align:left;padding:10px; vertical-align: middle">    
                    <div class="col-sm-1" style="text-align:right; vertical-align:central">  
                Images:
                    </div>
                     <div class="col-sm-2" style="text-align:left; padding-left:5px;" >
                         
                     
                   <asp:FileUpload AllowMultiple="false"  ID="fileuploadTitle" runat="server" />
                  
                </div>
                <div class="col-sm-2" style="text-align:left; padding-left:5px;" >
                                       
                       
                   <asp:FileUpload AllowMultiple="true"  ID="fileuploadimages" runat="server" />
                  
                </div>
              <div class="col-sm-2" style="text-align:left; padding-left:5px;" >
                  <asp:Button ID="btn_Upload" runat="server" Text="Upload"  BorderStyle="Outset" Font-Bold="True" Font-Names="Monotype Corsiva" Font-Size="Large" ForeColor="DeepPink" OnClick="btn_Upload_Click" CssClass="btn-default active" TabIndex="10" />
                  </div>
               <div class="col-sm-4" style="text-align:left; padding-left:5px;" >
                <asp:Label ID="lblImageMes" runat="server" Text="Message" ForeColor="Red"></asp:Label>
                    </div>
                    </div>

               <div class="col-sm-12">
           <div class="col-sm-1">PRODUCT description</div>
           <div class="col-sm-11"> <asp:TextBox ID="txt_P_description" runat="server" Width="100%" ></asp:TextBox></div>

             </div>

        <div class="col-sm-12">
           <div class="col-sm-1">PRODUCT price</div>
           <div class="col-sm-11"> <asp:TextBox ID="txt_P_price" runat="server" Width="100%" ></asp:TextBox></div>

             </div>

       <div class="col-sm-12">
           <div class="col-sm-1">PRODUCT offer</div>
            <div class="col-sm-11"> <asp:TextBox ID="txt_P_offer" runat="server" Width="100%" ></asp:TextBox></div>
            
           
           
       </div>
         <div class="col-sm-12">
           <div class="col-sm-1">PRODUCT highlights</div>
           <div class="col-sm-11"> <asp:TextBox ID="txt_P_highlights" runat="server" Width="100%" ></asp:TextBox></div>

             </div>
       
       <div class="col-sm-12">
           <div class="col-sm-1">PRODUCT warranty</div>
           <div class="col-sm-11"> <asp:TextBox ID="txt_P_warranty" runat="server" Width="100%" ></asp:TextBox></div>

             </div>
   
        <div class="col-sm-12">
           <div class="col-sm-1"> PRODUCT Start Date</div>
           <div class="col-sm-11"> <asp:TextBox ID="txt_P_SDate" runat="server" Width="100%" ></asp:TextBox></div>

             </div>
         <div class="col-sm-12">
           <div class="col-sm-1"> PRODUCT End Date</div>
           <div class="col-sm-11"> <asp:TextBox ID="txt_P_EDate" runat="server" Width="100%" /></div>

             </div>

      
           <div class="col-sm-12">
               <div class="col-sm-4"><asp:Label ID="lbl_message" runat="server" ForeColor="red" ></asp:Label></div>
           <div class="col-sm-2"> <asp:Button ID="btn_Edit" runat="server" Text="EDIT" ForeColor="Green" Font-Bold="true" OnClick="btn_Edit_Click" /></div>
            <div class="col-sm-2"> <asp:Button ID="btn_Del" runat="server" Text="DELETE" ForeColor="Tomato" Font-Bold="true" OnClick="btn_Del_Click" /></div>
            <div class="col-sm-2"> <asp:Button ID="btn_submit" runat="server" Text="SUBMIT" ForeColor="Blue" Font-Bold="true" OnClick="btn_submit_Click" /></div>
             </div>
    
         </div>
    
    
</asp:Content>

            







        

    





