<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoadCA.aspx.cs" Inherits="SchoolMS.staff.LoadCA" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://netdna.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.css" rel="stylesheet"/>
    <style>

    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div>

            <h3>
                LOAD FIRST ASSESSMENT FROM ASSIGNMENTS
            </h3>
            <br />
            
            <asp:CheckBox ID="Load" runat="server" OnCheckedChanged="Load_CheckedChanged" Text="LOAD FIRST CA" AutoPostBack="true" CssClass="fancy-checkbox-toggle" />
            
            <br />
            <br />
            <br />
            <hr />
            <h3>UPDATE TERM SCORES</h3>
            <p>TERM SCORES</p>
            <p>
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem Selected="True">SELECT </asp:ListItem>
                    <asp:ListItem Value="CA">Second CA</asp:ListItem>
                    <asp:ListItem>Examination</asp:ListItem>
                </asp:DropDownList>
            </p>
            <p>

                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblstudent" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblsubject" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button1" runat="server" Text="Submit Score" OnClick="Button1_Click" />
            </p>
            <asp:GridView ID="GridView1" runat="server" EmptyDataText="NO RECORDS AVAILABLE" OnRowCommand="GridView1_RowCommand">
                <Columns>
                 <asp:CommandField ButtonType="Link" SelectText="SELECT" ShowSelectButton="true" />
                </Columns>
            </asp:GridView>
         
            <br />
        </div>
    </form>
</body>
</html>
