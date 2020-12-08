<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Assignment.aspx.cs" Inherits="SchoolMS.student.Assignment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table border="0">
                <tr>
                    <td>  <p>Assignment Title :</p> </td>
                    <td> 
                        <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                      <td>  <p>Assignmet Code :</p> </td>
                      <td> 
                          <asp:Label ID="assignmentcode" runat="server"></asp:Label>
                      </td>
                </tr>
                <tr>
                      <td>  <p>Subject Code :</p> </td>
                      <td>

                          <asp:Label ID="subjectcode" runat="server"></asp:Label>

                      </td>
                </tr>
                   <tr>
                      <td>  <p>Upload Assignment :</p> </td>
                      <td>
                          <asp:FileUpload ID="FileUpload1" runat="server" />
                      </td>
                </tr>
                  <tr>
                      <td colspan="2"> <asp:Button ID="Upload" runat="server" Text="Upload Assignment" Height="31px" OnClick="Upload_Click" /> 
                          <br />
                          <br />
                          <asp:Label ID="Status" runat="server" Text=""></asp:Label></td>

                </tr>
            </table>

            <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="false" OnRowCommand="Gridview1_RowCommand">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                        <asp:BoundField DataField="ASSIGNMENT CODE" HeaderText="ASSIGNMENT CODE" SortExpression="ASSIGNMENT CODE" />
                        <asp:BoundField DataField="ASSIGNMENT TITLE" HeaderText="ASSIGNMENT TITLE" SortExpression="ASSIGNMENT TITLE"/>
                        <asp:BoundField DataField="CLASS ID" HeaderText="CLASS" SortExpression="CLASS ID" />
                        <asp:BoundField DataField="SUBJECT CODE" HeaderText="SUBJECT CODE" SortExpression="SUBJECT CODE" />
                        <asp:BoundField DataField="DUE DATE" HeaderText="DUE DATE" SortExpression="DUE DATE" DataFormatString="{0:d}" />
                        <asp:BoundField DataField="TERM" HeaderText="TERM" SortExpression="TERM" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="LnkDownload" runat="server" CommandArgument='<%# Eval("ID") %>' Onclick="LnkDownload_Click" Text="Download"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    <asp:CommandField ButtonType="Link" SelectText="SELECT" ShowSelectButton="true" />
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

            <asp:SqlDataSource ID="staffuploads" runat="server"></asp:SqlDataSource>

            <br />
            <br />

        </div>
    </form>
</body>
</html>
