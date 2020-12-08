<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Startquiz.aspx.cs" Inherits="SchoolMS.staff.Startquiz" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #txtquestion {
            height: 91px;
            width: 281px;
        }
        .auto-style1 {
            height: 64px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <textarea id="txtquestion" runat="server"></textarea>
            <br />
        
            <br />

            <table>
            <tr> 
                <td colspan="2" class="auto-style1">
            <p>Option 1 </p>
            <asp:TextBox ID="option1" runat="server"></asp:TextBox>
               </td>
                <td colspan="2" class="auto-style1" >
            <p>Option 2</p>
            <asp:TextBox ID="option2" runat="server"></asp:TextBox>
                </td>
            </tr>
                <tr>
                    <td colspan="2" class="auto-style1">
            <p>Option 3</p>
            <asp:TextBox ID="option3" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2" class="auto-style1">
            <p>Option 4</p>
            <asp:TextBox ID="option4" runat="server"></asp:TextBox>
                    </td>
                </tr>               
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td colspan="2" >
                        <p>Correct Answer:</p>
                        <asp:DropDownList ID="selected" runat="server">
                            <asp:ListItem Value="0">SELECT CORRECT ANSWER</asp:ListItem>
                            <asp:ListItem Value="Option1">Option 1</asp:ListItem>
                            <asp:ListItem Value="Option2">Option 2</asp:ListItem>
                            <asp:ListItem Value="Option3">Option 3</asp:ListItem>
                            <asp:ListItem Value="Option4">Option 4</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>

            </table>

            <br />
            <asp:HiddenField ID="HiddenField1" runat="server" />
            <asp:Label ID="Label1" runat="server" ForeColor="Red" Visible="False"></asp:Label>
            <br />
            <asp:Button ID="Button1" runat="server" Text="ADD" OnClick="Button1_Click" />

            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

            <br />
            <br />
            <h2>QUIZ QUESTIONS</h2>
            <asp:GridView ID="QuestionsView" runat="server">
            </asp:GridView>
            <br />
            <asp:Button ID="Button2" runat="server" Text="SAVE QUIZ" OnClick="Button2_Click" />
            <br />

        </div>
    </form>
</body>
</html>
