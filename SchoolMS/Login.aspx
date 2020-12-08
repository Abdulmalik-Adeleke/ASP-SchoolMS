<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SchoolMS.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style>
        
    </style>
</head>

<body>
    <div>
        <div class="TermDiv">
                <h1 runat="server" id="myh1" />
         </div>

    <form id="form1" runat="server">   
   <div>
            <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
            <br />
            <asp:TextBox ID="txtid" runat="server" Height="22px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
            <br />
            <asp:TextBox ID="txtpass" runat="server" Height="22px" TextMode="Password"></asp:TextBox>
            <br />
            <br />
            <asp:CheckBox ID="remember" runat="server" Text="Remember me" />
            <br />
            <br />
            <asp:Button ID="Submit" runat="server" Text="Login" OnClick="Submit_Click" />
            <br />
            <br />
            <span><asp:Label ID="error" runat="server" ForeColor="Red"></asp:Label></span>   
       </div>
    </form>

  </div>

  
</body>
</html>
