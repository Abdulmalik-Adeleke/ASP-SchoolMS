<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Quiz.aspx.cs" Inherits="SchoolMS.staff.Quiz" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #txtdescription {
            height: 44px;
            width: 247px;
        }
        .auto-style1 {
            width: 300px;
            height: 100px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList id="DropDownList1" runat="server" DataSourceID="subjects" DataTextField="SUBJECT_NAME" DataValueField="SUBJECT_CODE"></asp:DropDownList>
            <asp:SqlDataSource ID="subjects" runat="server" ConnectionString="<%$ ConnectionStrings:SMS %>" SelectCommand="SELECT [SUBJECT CODE] AS SUBJECT_CODE, [SUBJECT NAME] AS SUBJECT_NAME FROM [SUBJECTS] ORDER BY [SUBJECT NAME]"></asp:SqlDataSource>
            <br />
            <br />
            <textarea id="txtdescription" runat="server" class="auto-style1"></textarea><br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Go" OnClick="Button1_Click" />

        </div>
    </form>
</body>
</html>
