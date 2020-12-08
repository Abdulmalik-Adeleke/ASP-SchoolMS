<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Meetings.aspx.cs" Inherits="SchoolMS.staff.Meetings" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 293px;
            height: 104px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1> SCHEDULE A VIDEO MEETING FOR YOUR CLASS </h1>  
            <hr />
            <br />
            <textarea id="meeting" runat="server" class="auto-style1"></textarea>
            <br />
            <br />
            <asp:Button ID="Btn" runat="server" Text="Send Link" OnClick="Btn_Click" />
            <br />
            <br />
            <asp:Label ID="lblmessage" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
