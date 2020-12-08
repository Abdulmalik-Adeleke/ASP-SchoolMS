<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterStudent.aspx.cs" Inherits="SchoolMS.Admin.RegisterStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Surname"></asp:Label>  &nbsp;<asp:TextBox ID="surname" runat="server" ValidationGroup="validate" AutoCompleteType="Disabled" Height="22px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="surname" Display="Dynamic" ErrorMessage="* Required" ForeColor="Red" SetFocusOnError="True" ValidationGroup="validate"></asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Firstname"></asp:Label>
&nbsp;<asp:TextBox ID="firstname" runat="server" ValidationGroup="validate" AutoCompleteType="Disabled" Height="22px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="firstname" Display="Dynamic" ErrorMessage="* Required" ForeColor="Red" ValidationGroup="validate"></asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Email"></asp:Label>
&nbsp;<asp:TextBox ID="email" runat="server" TextMode="Email" ValidationGroup="validate" AutoCompleteType="Disabled" Height="22px"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="email" Display="Dynamic" ErrorMessage="* Required" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="validate"></asp:RegularExpressionValidator>
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Mobile"></asp:Label>
&nbsp;<asp:TextBox ID="mobile" runat="server" TextMode="Phone" AutoCompleteType="Disabled" Height="22px"></asp:TextBox>
            <br />
            <br />
          
            <asp:Label ID="Label5" runat="server" Text="Date Of Birth"></asp:Label>
          
                  
                    <asp:TextBox ID="DOB" runat="server" TextMode="Date" ValidationGroup="validate" AutoCompleteType="Disabled" Height="22px"></asp:TextBox>
                 
                    
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DOB" Display="Dynamic" ErrorMessage="* Required" ForeColor="Red" ValidationGroup="validate"></asp:RequiredFieldValidator>
            <br />
            <br />
            Class of Entry <asp:TextBox ID="txtclass" runat="server" TextMode="Number" ValidationGroup="validate" Height="22px" AutoCompleteType="Disabled"></asp:TextBox>
                 
                    
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtclass" Display="Dynamic" ErrorMessage="* Required" ForeColor="Red" ValidationGroup="validate"></asp:RequiredFieldValidator>
            <br />
          
                  
            <br />
            <asp:Button ID="BtnSubmit" runat="server" Text="Submit" OnClick="BtnSubmit_Click" ValidationGroup="validate" />
            <br />
            <br />
            <div>
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="bindregistration" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" AllowSorting="True">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="USERID" HeaderText="USERID" ReadOnly="True" SortExpression="USERID" />
                    <asp:BoundField DataField="LASTNAME" HeaderText="LASTNAME" SortExpression="LASTNAME" />
                    <asp:BoundField DataField="FIRSTNAME" HeaderText="FIRSTNAME" SortExpression="FIRSTNAME" />
                    <asp:BoundField DataField="DOB" HeaderText="DOB" SortExpression="DOB" DataFormatString="{0:d}" HtmlEncode="false"/>
                    <asp:BoundField DataField="EMAIL" HeaderText="EMAIL" SortExpression="EMAIL" />
                    <asp:BoundField DataField="MOBILE" HeaderText="MOBILE" SortExpression="MOBILE" />
                    <asp:BoundField DataField="CLASS_ID" HeaderText="CLASS_ID" SortExpression="CLASS_ID" />
                    <asp:BoundField DataField="REGISTRATION_DATE" HeaderText="REGISTRATION_DATE" DataFormatString="{0:d}" SortExpression="REGISTRATION_DATE" />
                </Columns>
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#F7F7DE" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                <SortedAscendingHeaderStyle BackColor="#848384" />
                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                <SortedDescendingHeaderStyle BackColor="#575357" />
            </asp:GridView>
            <asp:SqlDataSource ID="bindregistration" runat="server" ConnectionString="<%$ ConnectionStrings:SMS %>" SelectCommand="SELECT [USERID], [LASTNAME], [FIRSTNAME], [DOB], [EMAIL], [MOBILE], [CLASS ID] AS CLASS_ID, [REGISTRATION DATE] AS REGISTRATION_DATE FROM [STUDENTS] ORDER BY [ID] DESC"></asp:SqlDataSource>
             </div>
            <br />
        </div>
    </form>
</body>
</html>
