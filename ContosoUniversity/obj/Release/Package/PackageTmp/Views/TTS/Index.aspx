@@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Home.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" 


    Index




<!-- /TinyMCE -->
<script src="../../jscripts/jquery-1.5.1.min.js" type="text/javascript"></script>
 <script type="text/javascript">
     function MyFunction() {
         destElement = document.getElementById("tts");
         document.getElementById("tasklistResult1").innerHTML = "<audio autoplay='true' controls><source src='http://tts-api.com/tts.mp3?q=" + destElement.value + "'  type='audio/mpeg'> Your browser does not support this audio format.</audio>"; ;
         document.getElementById("tasklistResult1").style.display = 'none'
     }
     
     </script>
  




<form action="/tts/index" Method="POST">
 <div id="body-text">
<div class="left">
<h2>Text to Speech Plugin</h2>

<textarea id="tts" name="tts" style="height: 268px; width: 643px"></textarea><br />


<a id="myLink" href="#" onclick="MyFunction();return false;">Listen</a>



<br />
 <div id="tasklistResult1" title="Inner Container">

 </div>  

 </div>
</div>

</form>

