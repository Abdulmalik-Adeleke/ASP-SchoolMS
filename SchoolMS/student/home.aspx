<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="SchoolMS.student.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style>
        .timetable
        {
            overflow: auto;
            background-color:lightgray;
            font-family: Arial;
            text-transform: uppercase; 
            text-align: center;
            font-variant: small-caps; 
           
        }
        td{
            padding:0;
        }
        td > div{
            width:100px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/student/Assignment.aspx">LinkButton</asp:LinkButton>
            <div class="timetable">
                <asp:DataList ID="DataList1" runat="server" RepeatDirection="Horizontal" BackColor="white" BorderColor="white"  BorderStyle="None" BorderWidth="1px" CellPadding="10" GridLines="Vertical" CellSpacing="10" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False">
                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                    <ItemStyle BackColor="lightgray" ForeColor="Black" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Size="Medium" Font-Strikeout="False" Font-Underline="False" />
                    <ItemTemplate>
                        <div>


                        <p><asp:Label ID="SUBJECT_CODELabel" runat="server" Text='<%# Eval("SUBJECT_CODE") %>' /></p>
                                          
                                             
                        <asp:Label ID="DAYLabel" runat="server" Text='<%# Eval("DAY") %>' />
                        <br />
                     
                        <asp:Label ID="CLASS_BEGINSLabel" runat="server" Text='<%# Eval("CLASS_BEGINS") %>' />
                         <br />

                        <asp:Label ID="CLASS_ENDSLabel" runat="server" Text='<%# Eval("CLASS_ENDS") %>' />
                         <br />
                        
                      <%--  <br />
                        
                        <asp:Label ID="EXAM_BEGINSLabel" runat="server" Text='<%# Eval("EXAM_BEGINS") %>' />
                        <br />
                        <asp:Label ID="EXAM_ENDSLabel" runat="server" Text='<%# Eval("EXAM_ENDS") %>' />
                        
                        <br />
                      --%>
                            </div>
                    </ItemTemplate>
                    <SelectedItemStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                </asp:DataList>
               
            </div>
            <p>student home page</p>

        </div>
    </form>
</body>
</html>
