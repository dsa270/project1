<%@ Page Title=" News4Nation, Hindi News - Breaking News, Bihar News, Latest News in Hindi,  Hindi Samachar, हिंदी में समाचार" Language="C#" MasterPageFile="~/Site.master"
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="IGTNewsfNation._Default" %>
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
    <div class="col-sm-12" style="background-color:white; color:black;  " runat="server" id="div_BADI_KHABAR" > 
         

      <!--     <div class="col-sm-3" runat="server" style="border: 5px solid #f5f5f5;background-color:white;"   id="ipyttv" >
            <div class="video-responsive">
   <iframe width="420" height="315"  src="https://www.youtube.com/embed/QY26if0I0Zc" frameborder="0" allow="autoplay; encrypted-media" allowfullscreen></iframe>  
</div>
             </div>-->


               
             </div>
    </div>     

    

    
         
         <div class="col-sm-12" runat="server" style="border: 5px solid #f5f5f5; background-color:white; color:black; "  id="STATE" >
             
             


                    </div>



    <div class="col-sm-12" runat="server" style="border: 5px solid #f5f5f5; background-color:white; color:#8b0101; "  id="CRIME" >
          


                    </div>

        
       <!--  <div class="col-sm-6" runat="server" style="border: 5px solid #f5f5f5;background-color:white; color:black; "  id="HOROSCOPE" >
             
             


                    </div>-->
             
    

      
    
        
          <div class="col-sm-12" runat="server" style="border: 5px solid #f5f5f5; background-color:white; color:black; "  id="POLITICS" >
             
             


                    </div>

     <div class="col-sm-12" runat="server" style="border: 5px solid #f5f5f5; background-color:white; color:black; "  id="N4NVideo" >
             
             


                    </div>



           <div class="col-sm-12" runat="server" style="border: 5px solid #f5f5f5;background-color:white; color:#ff4400; "  id="SPIRITUALITY" >
             
             


                    </div>

        
        <!-- <div class="col-sm-6" runat="server" style="border: 5px solid #f5f5f5;background-color:white; color:black; "  id="PHOTO" >
             
             <a style ="color: black;padding-left:20px;line-height:140%;font-size: xx-large;" href="Default.aspx">Photo<br/></a>


                    </div>-->
    
    
                	  
    

          

    
    
    
        		
         <div class="col-sm-12" runat="server" style="border: 5px solid  #f5f5f5;background-color:white; color:black; "  id="MOVIE_MIRCHI" >
             
             


                    </div>

           <div class="col-sm-12" runat="server" style="border: 5px solid #f5f5f5;background-color:white; color:black;"  id="SPORTS" >
             
             


                    </div>

        
       <!--   <div class="col-sm-6" runat="server" style="border: 5px solid #f5f5f5;background-color:white; color:black; "  id="N4N_COLUMNIST" >
             
             


                    </div>-->
          
    
    
    
    <div class="col-sm-12" > 
          <div class="col-sm-6" runat="server" style="border: 5px solid #f5f5f5;background-color:white; color:black; "  id="HEALTH_MANTRA" >
             
             


                    </div>

           <div class="col-sm-6" runat="server" style="border: 5px solid #f5f5f5;background-color:white; color:black; "  id="STRANGE_AMAZING" >
             
             


                    </div>

        
      <!--   <div class="col-sm-6" runat="server" style="border: 5px solid #f5f5f5;background-color:white; color:black; "  id="LITERATURE_WORLD" >
             
             


                    </div>-->

              
    </div>  
    
    
    
    
    <div class="col-sm-12" > 
         
         <div class="col-sm-6" runat="server" style="border: 5px solid #f5f5f5;background-color:white; color:black; "  id="CAREER" >
             
             


                    </div>

           <div class="col-sm-6" runat="server" style="border: 5px solid #f5f5f5;background-color:white; color:black; "  id="PROPERTY" >
             
             


                    </div>

        
    <!--     <div class="col-sm-6" runat="server" style="border: 5px solid #f5f5f5;background-color:white; color:black; "  id="GADGETS" >
             
             


                    </div>-->

        

          
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
