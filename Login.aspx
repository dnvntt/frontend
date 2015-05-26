<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Login.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>    
        Well come to Social Trading</div>
    <br />
    <asp:Login ID="Login1" runat="server" DestinationPageUrl="~/Member.aspx" 
        onauthenticate="Login1_Authenticate" TitleText="">
    </asp:Login>
    <asp:Label ID="Label1" runat="server" Text=" "></asp:Label>
    <br />
    </form>
</body>
</html>
