<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Landing.aspx.cs" Inherits="SchoolMS.student.Landing" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:DataList ID="DataList1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="quiz" ForeColor="Black" GridLines="Horizontal">
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                <ItemTemplate>
                   
                    <asp:Label ID="SUBJECT_CODELabel" runat="server" Text='<%# Eval("SUBJECT_CODE") %>' />
                    <br />
                
                    <asp:Label ID="QUIZ_IDLabel" runat="server" Text='<%# Eval("QUIZ_ID") %>' />
                    <br />
                    
                    <asp:Label ID="DESCRIPTIONLabel" runat="server" Text='<%# Eval("DESCRIPTION") %>' />
                    <br />
                    <br />
                </ItemTemplate>
                <SelectedItemStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            </asp:DataList>
            <asp:SqlDataSource ID="quiz" runat="server" ConnectionString="<%$ ConnectionStrings:SMS %>" SelectCommand="SELECT DISTINCT [SUBJECT CODE] AS SUBJECT_CODE, [QUIZ ID] AS QUIZ_ID, [DESCRIPTION] FROM [QUIZ]"></asp:SqlDataSource>
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
