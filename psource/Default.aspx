<%@ Page Title="welcome to PATNA MALL" Language="C#" MasterPageFile="~/Site.master"
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="JECRC_PMall._Default" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
  
    <style type="text/css">
.video-responsive{
    overflow:hidden;
    padding-bottom:56.25%;
    position:relative;
    height:0;
}
.video-responsive iframe{
    left:0;
    top:0;
    height:100%;
    width:100%;
    position:absolute;
}

    .hoverable {
      cursor:default;
      color:#000;
      text-decoration:none;
    }
    .hoverable .hover {
      display:none;
    }
    .hoverable:hover .normal {
      display:none;
    }
    .hoverable:hover .hover {
      display:inline;  /* CHANGE IF FOR BLOCK ELEMENTS */
    }
  </style>


</asp:Content>

      
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="MainContent">
    
  
<div  class="col-sm-12" style ="   background-color: white; padding:0px;margin:0px;">             
    <div class="col-sm-12" style="background-color:white; color:black;  " runat="server" id="div_SLIDING" > 
         
        <ul class="pgwSlider">
    <li> <img src="offerImages/SlideApple.jpeg" alt="Apple Offer"/></li>
    <li><img src="offerImages/SlideApple1.jpeg" alt="Apple Offer"/></li>
    <li><img src="offerImages/peripherals.jpg" alt="Apple Offer"/></li>
   <li> <img src="offerImages/slideimage.jpg" alt="Apple Offer"/> </li>

</ul>
               
             </div>
    </div>    

    

    
         
         <div class="col-sm-12" runat="server" style="border: 5px solid #f5f5f5; background-color:white; color:black; "  id="ELECTRONICS" >
             
             


                    </div>



    <div class="col-sm-12" runat="server" style="border: 5px solid #f5f5f5; background-color:white; color:#8b0101; "  id="CLOTHES" >
          


                    </div>

        
     
    

      
    
        
          <div class="col-sm-12" runat="server" style="border: 5px solid #f5f5f5; background-color:white; color:black; "  id="BOOKS" >
             
              


                    </div>

     <div class="col-sm-12" runat="server" style="border: 5px solid #f5f5f5; background-color:white; color:black; "  id="FURNITURE" >
             
             


                    </div>



           <div class="col-sm-12" runat="server" style="border: 5px solid #f5f5f5;background-color:white; color:#ff4400; "  id="WISHLIST" >
             
             


                    </div>

        
    
        

          
     
    
    

   
       
    <style type="text/css">
#containerVideo {
  position: relative;
  
  margin: 5px auto;
 
  text-align: center;
  white-space: nowrap;
  overflow-x: auto;
  overflow-y: hidden;
  vertical-align:middle;
}
#containerVideo div {
  display: inline-block;
 
  margin: 0.5em;
  border: 1px solid blue;
  padding: 5px;
  white-space: normal;
  text-align: center;
}
</style>
</asp:Content>
