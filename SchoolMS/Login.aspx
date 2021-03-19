<%@ Page  Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SchoolMS.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SchoolMs - Login</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <style>
        body{
            height:100%;
        }
        .wrapper{
            width: 300px;
            padding: 30px;
            margin: 0 auto;  
            transform: translateY(50%);
            background-color:lightgray;
        }
        .formcontainer{
            margin: 0 auto;
            display: flex;
            justify-content: center;
        }
        .formcontainer span{
           font-weight:bold;
        }
        .inputField{
            height:30px;
            margin-top:10px;
        }
        h1{
            text-align:center;
        }
    </style>
</head>

<body>
<div class="wrapper">
        <div class="TermDiv">
                <h1 runat="server" id="myh1" />
         </div>
    <div class="formcontainer">
    <form id="form1" runat="server">   
      <div>
            <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
            <br />
            <asp:TextBox ID="txtid" runat="server" class="inputField"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
            <br />
            <asp:TextBox ID="txtpass" runat="server"  class="inputField" TextMode="Password"></asp:TextBox>
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

</div>  
</body>
</html>
