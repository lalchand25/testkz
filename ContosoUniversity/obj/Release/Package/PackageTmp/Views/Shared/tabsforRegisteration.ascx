@@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" 

@--<div id="steps">
<ul>
    	  
        
        @ if (Convert.ToInt32(Session["activestep"]) == 0)
           { 
          <li><img src="../../images/step_arrow_yl.png" width="9" height="32" /></li>
          <li class="brown">Offers</li>
          <li><img src="../../images/step_arrow_yb.png" width="19" height="32" /></li>
          <li class="black">Registeration</li>
          <li><img src="../../images/step_arrow_bb.png" width="19" height="32" /></li> 
          <li class="black">Confirmation</li>
          <li><img src="../../images/step_arrow_bb.png" width="19" height="32" /></li> 
          <li class="black">Payments</li>

          <li><img src="../../images/step_arrow_bb.png" width="19" height="32" /></li>
          <li class="black">Completed</li>
         <li><img src="../../images/step_arrow_br.png" width="9" height="32" /></li>

        }


        @ if (Convert.ToInt32(Session["activestep"]) == 2)
        { 
        <li><img src="../../images/step_arrow_bl.png" width="9" height="32" /></li>
        <li class="black">Offers</li>
        <li><img src="../../images/step_arrow_by.png" width="19" height="32" /></li>
        <li class="brown">Registeration</li>
        <li><img src="../../images/step_arrow_yb.png" width="19" height="32" /></li>
        <li class="black">Confirmation</li>
        <li><img src="../../images/step_arrow_bb.png" width="19" height="32" /></li> 
        <li class="black">Payments</li>
        <li><img src="../../images/step_arrow_bb.png" width="19" height="32" /></li>
        <li class="black">Completed</li>
        <li><img src="../../images/step_arrow_br.png" width="9" height="32" /></li>
        }




       @ if (Convert.ToInt32(Session["activestep"]) == 3)
         { 
         <li><img src="../../images/step_arrow_bl.png" width="9" height="32" /></li>
        <li class="black">Offers</li>
        <li><img src="../../images/step_arrow_bb.png" width="19" height="32" /></li>
        <li class="black">Registeration</li>
        <li><img src="../../images/step_arrow_by.png" width="19" height="32" /></li>
        <li class="brown">Confirmation</li>
        <li><img src="../../images/step_arrow_yb.png" width="19" height="32" /></li>
        <li class="black">Payments</li>
        <li><img src="../../images/step_arrow_bb.png" width="19" height="32" /></li>
        <li class="black">Completed</li>
        <li><img src="../../images/step_arrow_br.png" width="9" height="32" /></li>
      }


          @ if (Convert.ToInt32(Session["activestep"]) == 4)
         { 
         <li><img src="../../images/step_arrow_bl.png" width="9" height="32" /></li>
        <li class="black">Offers</li>
        <li><img src="../../images/step_arrow_bb.png" width="19" height="32" /></li>
        <li class="black">Registeration</li>
        <li><img src="../../images/step_arrow_bb.png" width="19" height="32" /></li>
        <li class="black">Confirmation</li>

        <li><img src="../../images/step_arrow_by.png" width="19" height="32" /></li>
        <li class="brown">Payments</li>
        <li><img src="../../images/step_arrow_yb.png" width="19" height="32" /></li>

        <li class="black">Completed</li>
        <li><img src="../../images/step_arrow_br.png" width="9" height="32" /></li>
      }


           @ if (Convert.ToInt32(Session["activestep"]) == 5)
         { 
         <li><img src="../../images/step_arrow_bl.png" width="9" height="32" /></li>
        <li class="black">Offers</li>
        <li><img src="../../images/step_arrow_bb.png" width="19" height="32" /></li>
        <li class="black">Registeration</li>
        <li><img src="../../images/step_arrow_bb.png" width="19" height="32" /></li>
        <li class="black">Confirmation</li>

        <li><img src="../../images/step_arrow_bb.png" width="19" height="32" /></li>
        <li class="black">Payments</li>
        <li><img src="../../images/step_arrow_by.png" width="19" height="32" /></li>
        <li class="brown">Completed</li>
        <li><img src="../../images/step_arrow_yr.png" width="9" height="32" /></li>
      }
       
    </ul>

</div>
  
--
