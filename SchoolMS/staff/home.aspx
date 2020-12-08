<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="SchoolMS.staff.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/staff/Assignment.aspx">LinkButton</asp:LinkButton><asp:LinkButton ID="LinkButton2" runat="server">LinkButton</asp:LinkButton>
        <div>
            <p>staff home page</p>
        </div>
    </form>
</body>
</html>
