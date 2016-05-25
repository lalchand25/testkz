@@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" 

@@ Register src="../Shared/PopHeader.ascx" tagname="PopHeader" tagprefix="uc1" 

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >


<head id="Head1" runat="server">
    <title>HTMLAndSilverlight</title>
    <style type="text/css">
    html, body {
	    height: 100%;
	    overflow: auto;
    }
    body {
	    padding: 0;
	    margin: 0;
    }
    #silverlightControlHost {
	    height: 100%;
	    text-align:center;
    }
    #JobPlanDiv
    {
        position:absolute;
        background-color:#484848;
        overflow:hidden;
        left:0;
        top:0;
        height:100%;
        width:100%;
        display:none;
    }
    
    #RSSDiv
    {
        background-color:White;
        position:absolute;
        top:100px;
        left:300px;
        width:800px;
        height:600px;
        border:1px solid black;
        display:none;
    }
    
    </style>
    <script type="text/javascript" src="Silverlight.js"></script>
    <script type="text/javascript" src="Scripts/jquery-1.4.2.min.js"></script>   

    <script type="text/javascript">

        var jobPlanIFrameID = 'JobPlan_IFrame';
        var slHost = null;
        var jobPlanContainer = null;
        var jobPlanIFrameContainer = null;
        var rssDiv = null;

        $(document).ready(function () {
            slHost = $('#silverlightControlHost');
            jobPlanContainer = $('#JobPlanDiv');
            jobPlanIFrameContainer = $('#JobPlan_IFrame_Container');
            rssDiv = $('#RSSDiv');
        });

        function ShowJobPlanIFrame(url) {
            jobPlanContainer.css('display', 'block');
            $('<iframe id="' + jobPlanIFrameID + '" src="' + url + '" style="height:100%;width:100%;" />')
             .appendTo(jobPlanIFrameContainer);
            slHost.css('width', '0%');
        }

        function HideJobPlanIFrame() {
            jobPlanContainer.css('display', 'none');
            $('#' + jobPlanIFrameID).remove();
            slHost.css('width', '100%');
        }

        function ShowOverlay() {
            rssDiv.css('display', 'block');
        }

        function HideOverlay() {
            rssDiv.css('display', 'none');
        }

        function onSilverlightError(sender, args) {
            var appSource = "";
            if (sender != null && sender != 0) {
                appSource = sender.getHost().Source;
            }

            var errorType = args.ErrorType;
            var iErrorCode = args.ErrorCode;

            if (errorType == "ImageError" || errorType == "MediaError") {
                return;
            }

            var errMsg = "Unhandled Error in Silverlight Application " + appSource + "\n";

            errMsg += "Code: " + iErrorCode + "    \n";
            errMsg += "Category: " + errorType + "       \n";
            errMsg += "Message: " + args.ErrorMessage + "     \n";

            if (errorType == "ParserError") {
                errMsg += "File: " + args.xamlFile + "     \n";
                errMsg += "Line: " + args.lineNumber + "     \n";
                errMsg += "Position: " + args.charPosition + "     \n";
            }
            else if (errorType == "RuntimeError") {
                if (args.lineNumber != 0) {
                    errMsg += "Line: " + args.lineNumber + "     \n";
                    errMsg += "Position: " + args.charPosition + "     \n";
                }
                errMsg += "MethodName: " + args.methodName + "     \n";
            }

            throw new Error(errMsg);
        }
    </script>
</head>
<body> 

<uc1:PopHeader ID="PopHeader1" runat="server" />
<table width="90%" align="center">
<tr>
<td width="100%"></td>
</tr>

<tr>
<td style="height:600px">
    <form id="form1" runat="server" style="height:100%">
       <div id="silverlightControlHost" >
          
        <object data="data:application/x-silverlight-2," type="application/x-silverlight-2" width="100%" height="100%">
		 <param name="source" value="@Session["siteurl"] "/>
		  <param name="onError" value="onSilverlightError" />
		  <param name="background" value="white" />
          <param name="initParams" value="page=QuizEditor,para=@Session["QuizPagePara"] " />
		  <param name="minRuntimeVersion" value="4.0.50826.0" />
		    <param name="windowless" value="true" />
	      <param name="autoUpgrade" value="true" />
		  <a href="http://go.microsoft.com/fwlink/?LinkID=149156&v=4.0.50826.0" style="text-decoration:none">
 			  <img src="http://go.microsoft.com/fwlink/?LinkId=161376" alt="Get Microsoft Silverlight" style="border-style:none"/>
		  </a>
	    </object>
    <iframe id="_sl_historyFrame" style="visibility:hidden;height:0px;width:0px;border:0px"></iframe></div>
       
   
       

    </form>
    </td>
    </tr>
    </table>
</body>

 