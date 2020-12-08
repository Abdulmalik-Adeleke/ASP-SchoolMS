<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="coursecontent.aspx.cs" Inherits="SchoolMS.staff.coursecontent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Upload Course Content</h2>
            <p>use ul. li tags</p>
            <asp:TextBox ID="name" runat="server" CssClass="input" Width="200px" placeholder="Specify a name"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="url" runat="server" CssClass="input" Width="200px" placeholder="Content link"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="subject" DataTextField="SUBJECT_NAME" DataValueField="SUBJECT_CODE">
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="Save" OnClick="Button1_Click" />
            <asp:SqlDataSource ID="subject" runat="server" ConnectionString="<%$ ConnectionStrings:SMS %>" SelectCommand="SELECT DISTINCT [SUBJECT CODE] AS SUBJECT_CODE, [SUBJECT NAME] AS SUBJECT_NAME FROM [SUBJECTS]"></asp:SqlDataSource>
            <asp:Label ID="message" runat="server" Text=""></asp:Label>
            <br />                      

            <hr/>
            <h3>Uploaded Content</h3>
            <p>
                <asp:DataList ID="DataList1" runat="server" CellPadding="4" DataSourceID="Content" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" ForeColor="#333333" ShowFooter="False" ShowHeader="False" >
                    <AlternatingItemStyle BackColor="White" />
                    <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <ItemStyle BackColor="#EFF3FB" />
                    <ItemTemplate>
                        <p>
                        <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="UrlLabel" runat="server" Text='<%# Eval("Url") %>' />
                        &nbsp;&nbsp;&nbsp;&nbsp;           
                        <asp:Label ID="ContentTypeLabel" runat="server" Text='<%# Eval("ContentType") %>' />
                        &nbsp;&nbsp;&nbsp;&nbsp;                        
                        <asp:Label ID="SubjectLabel" runat="server" Text='<%# Eval("Subject") %>' />
                        
                        </p>
                    </ItemTemplate>
                    <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                </asp:DataList>
                <asp:SqlDataSource ID="Content" runat="server" ConnectionString="<%$ ConnectionStrings:SMS %>" SelectCommand="SELECT [Name], [Url], [ContentType], [Subject] FROM [Content]">
                  
                </asp:SqlDataSource>
            </p>
        </div>      
    </form>
</body>
</html>
