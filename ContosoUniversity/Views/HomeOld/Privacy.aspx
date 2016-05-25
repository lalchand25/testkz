@@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Home.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" 


    @Session["projectmetatags"]


 
    <div id="body-text">
        <div id="contactus">
            <div class="form">
                <h2>
                    Privacy</h2>
                @Html.Raw(ViewData["pagedescription"]
            </div>
            <div class="map">
                @Html.Raw(ViewData["PageLeftData"]
            </div>
        </div>
        <div id="result">
        </div>
        <input type="text" id="clock" />
        <input type="text" id="clock1" />
        <input type="text" id="clock2" />
        <script type="text/javascript">
            var int = self.setInterval(function () { clock() }, 1000);
            function clock() {
                var d = new Date();
                var mint1 = d.getMinutes();
                var iind1 = d.getSeconds();
                var hrs1 = d.getHours();

                var d1 = new Date('@Session["enddate"]');

                //d2 = d1.setHours(10);

                var mint2 = d1.getMinutes();
                var iind2 = d1.getSeconds();
                var hrs2 = d1.getHours();

                var t = d.toLocaleTimeString();
                var t1 = d1.toLocaleTimeString();

                document.getElementById('clock').value = t;
                document.getElementById('clock1').value = t1;

                totdiff = (iind2 + mint2 * 60 + hrs2 * 3600) - (iind1 + mint1 * 60 + hrs1 * 3600);
                var divisor_for_minutes = Math.floor(totdiff / 60);
                document.getElementById('clock2').value = "Time left " + divisor_for_minutes + ":" + Math.floor(totdiff % 60);

                if (totdiff <= 0) {
                    document.getElementById('clock2').value = "Time left : 0"
                    alert('Time is over')
                }

            }


            //@Html.Raw(ViewData["javascript"] 
            //    var int = self.setInterval(function () { clock() }, 1000);
            //    function clock() 
            //    {
            //        var d = new Date();
            //        //alert(d.getMinutes());
            //        var t = d.toLocaleTimeString();
            //        document.getElementById("clock").value = t;
            //    }
        </script>
    </div>
    @
        Response.Write(Session["servertime"]);
  
    
    

