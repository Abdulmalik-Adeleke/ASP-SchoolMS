<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Videos.aspx.cs" Inherits="SchoolMS.student.Videos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     
        <div class="container">
           <asp:DataList runat="server" ID="Repeater1" RepeatLayout="Flow" RepeatDirection="Horizontal">
               <ItemTemplate>
                 <div class ="me">
                  <iframe id="frmUrl" src='<%# Eval("Url") %>' height="151" width="269" frameborder="0" allowfullscreen></iframe> 
                     <p><%# Eval("Url") %></p>
                  </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
        
    </form>
</body>
</html>
