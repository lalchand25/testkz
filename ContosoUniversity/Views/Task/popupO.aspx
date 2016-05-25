<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>popup</title>
    <link href="../../css/NewStyle.css" rel="stylesheet" type="text/css" />

</head>
<body>
  <table width="95%" align="center">
  <tr>
  <td width="100%">
    <%=ViewData["taskname"]%></td> 
  </tr>
  <tr>
  <td width="100%"> <%=ViewData["instructions"]%> </td> 
  </tr>
  
  </table>
    
   
            
  
</body>
</html>
