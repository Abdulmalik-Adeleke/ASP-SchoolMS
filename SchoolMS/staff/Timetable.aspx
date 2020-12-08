<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Timetable.aspx.cs" Inherits="SchoolMS.staff.Timetable" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>SET CLASS/EXAM TIMETABLE</h3>
            <p>SUBJECT</p>
            <asp:DropDownList ID="subjects" runat="server" DataSourceID="timetablesubjects" DataTextField="SUBJECT NAME" DataValueField="SUBJECT CODE"></asp:DropDownList>
            <asp:SqlDataSource ID="timetablesubjects" runat="server" ConnectionString="<%$ ConnectionStrings:SMS %>" SelectCommand="SELECT DISTINCT * FROM [SUBJECTS]"></asp:SqlDataSource>
            <p>
                <asp:RadioButton ID="Isexam" runat="server" Text="Examination" AutoPostBack="true" OnCheckedChanged="Isexam_CheckedChanged"/></p>
            <p>DAY</p>
            <asp:DropDownList ID="day" runat="server">
                <asp:ListItem Value="1">Monday</asp:ListItem>
                <asp:ListItem Value="2">Tuesday</asp:ListItem>
                <asp:ListItem Value="3">Wednesday</asp:ListItem>
                <asp:ListItem Value="4">Thursday</asp:ListItem>
                <asp:ListItem Value="5">Friday</asp:ListItem>
            </asp:DropDownList>
            <p>CLASS BEGINS</p>
            <asp:TextBox ID="start" runat="server" TextMode="Time" ></asp:TextBox>
            <p>CLASS ENDS</p>
            <asp:TextBox ID="end" runat="server" TextMode="Time" ></asp:TextBox>
            <br />
           <p> <asp:Label ID="message" runat="server" Text=""></asp:Label></p>
            
            <asp:Button ID="btnpublish" runat="server" Text="Publish" OnClick="btnpublish_Click" />

        </div>
    </form>
</body>
</html>
