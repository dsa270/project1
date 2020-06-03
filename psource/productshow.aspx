<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="productshow.aspx.cs" Inherits="JECRC_PMall.productshow" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="col-sm-12"> 
      
        <div class="col-sm-12">
            <div class="col-sm-6">
           <div class="col-sm-1"> product Code</div>
       <div class="col-sm-3">  <asp:TextBox ID="txt_P_Code" ReadOnly="true" runat="server" Width="40%" ></asp:TextBox>
             </div>
            
                <br />
           
            
              <div class="col-sm-1"> product category code</div>
           <div class="col-sm-2"> <asp:TextBox ID="txt_pc_code" runat="server" ReadOnly="true" Width="100%"></asp:TextBox></div>
       </div>
                <br />
              
         <div class="col-sm-1"> product sub category code</div>
           <div class="col-sm-2"> <asp:TextBox ID="txt_PsC_code" ReadOnly="true" runat="server" Width="100%" ></asp:TextBox></div>
       
            <br />
           
           <div class="col-sm-1"> product Status</div>
           <div class="col-sm-1"> <asp:DropDownList ID="txt_P_Status" runat="server" Width="100%"></asp:DropDownList></div>
       </div>
            <br />
       
           <div class="col-sm-1">PRODUCT Name</div>
           <div class="col-sm-2"> <asp:TextBox ID="txt_P_Name" ReadOnly="true" runat="server" Width="100%" ></asp:TextBox></div>

             </div>

           

              
           <div class="col-sm-1">PRODUCT description</div>
           <div class="col-sm-2"> <asp:TextBox ID="txt_P_description" ReadOnly="true" runat="server" Width="100%" ></asp:TextBox></div>

         <br />


        
      
           <div class="col-sm-1">PRODUCT price</div>
           <div class="col-sm-3"> <asp:TextBox ID="txt_P_price" ReadOnly="true" runat="server" Width="100%" ></asp:TextBox></div>

             <br />

      
           <div class="col-sm-1">PRODUCT offer</div>
            <div class="col-sm-3"> <asp:TextBox ID="txt_P_offer" ReadOnly="true" runat="server" Width="100%" ></asp:TextBox></div>
            <br />
           
           
     
       
           <div class="col-sm-1">PRODUCT highlights</div>
           <div class="col-sm-2"> <asp:TextBox ID="txt_P_highlights" ReadOnly="true" runat="server" Width="100%" ></asp:TextBox></div>

             <br />
       
       
           <div class="col-sm-1">PRODUCT warranty</div>
           <div class="col-sm-2"> <asp:TextBox ID="txt_P_warranty" ReadOnly="true" runat="server" Width="100%" ></asp:TextBox></div>

            <br />
  

     <div class="col-sm-6" style="text-align:left;padding:10px; vertical-align: middle">    
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



</asp:Content>
