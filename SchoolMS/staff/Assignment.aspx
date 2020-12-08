<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Assignment.aspx.cs" Inherits="SchoolMS.staff.Assignment"  MasterPageFile="~/Site.Master" MaintainScrollPositionOnPostback="True" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <div>
            <div>

                <div>
                    <br />
            <table border="0">
                <tr>
                    <td colspan="2">  <p>Assignment Title: </p> </td>
                    <td> <textarea id="title" runat="server" style="width: 182px; height: 60px"></textarea>  </td>
                </tr>
                <tr>
                      <td colspan="2">  <p>Due Date: </p> </td>
                      <td> <asp:TextBox ID="due" runat="server" Width="181px" TextMode="Date"></asp:TextBox>  </td>
                </tr>
                <tr>
                      <td colspan="2">  <p>Subject:</p> </td>
                      <td> <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="subjects" DataTextField="SUBJECT_NAME" DataValueField="SUBJECT_CODE" Height="25px" OnDataBinding="Page_Load" OnDataBound="Page_Load" Width="181px">
                          </asp:DropDownList>  
                          <asp:SqlDataSource ID="subjects" runat="server" ConnectionString="<%$ ConnectionStrings:SMS %>" SelectCommand="SELECT [SUBJECT NAME] AS SUBJECT_NAME, [SUBJECT CODE] AS SUBJECT_CODE FROM [SUBJECTS]"></asp:SqlDataSource>
                     <p></p>
                          </td>
                </tr>
                   <tr>
                      <td colspan="2">  <p>Upload Assignment:</p> </td>
                      <td colspan="2">
                          <asp:FileUpload ID="FileUpload1" runat="server" Height="25px" Width="217px" />
                      </td>
                </tr>
                  <tr>
                      <td colspan="2"> <asp:Button ID="Upload" runat="server" Text="Upload Assignment" Height="31px" OnClick="Upload_Click" /> 
                          <br />
                          <br />
                          <asp:Label ID="Status" runat="server" Text=""></asp:Label></td>

                </tr>
            </table>
                    </div>
            <div>
                <br />
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderWidth="2px" CellPadding="10" DataSourceID="assignments_staff" ForeColor="#333333" AllowPaging="True" CellSpacing="20" Font-Bold="False" Font-Names="Arial">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="ASSIGNMENT_CODE" HeaderText="ASSIGNMENT" SortExpression="ASSIGNMENT_CODE" />
                        <asp:BoundField DataField="ASSIGNMENT_TITLE" HeaderText="TITLE" SortExpression="ASSIGNMENT_TITLE" />
                        <asp:BoundField DataField="SUBJECT_CODE" HeaderText="SUBJECT" SortExpression="SUBJECT_CODE" />
                        <asp:BoundField DataField="CLASS_ID" HeaderText="CLASS" SortExpression="CLASS_ID" />
                        <asp:BoundField DataField="Name" HeaderText="NAME" SortExpression="Name" />
                        <asp:BoundField DataField="TERM" HeaderText="TERM" SortExpression="TERM" />
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="justify" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
                <asp:SqlDataSource ID="assignments_staff" runat="server" ConnectionString="<%$ ConnectionStrings:SMS %>" SelectCommand="SELECT [ASSIGNMENT CODE] AS ASSIGNMENT_CODE, [ASSIGNMENT TITLE] AS ASSIGNMENT_TITLE, [SUBJECT CODE] AS SUBJECT_CODE, [CLASS ID] AS CLASS_ID, [Name], [TERM] FROM [ASSIGNMENT_BY_STAFF] ORDER BY [ID] DESC"></asp:SqlDataSource>              
            </div>
                </div>
            <div>
                <h2>STUDENT SUBMISSIONS</h2>
                <div>
                    
                    <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="StudentsAssignmentSubmitted" DataTextField="SUBJECT_CODE" DataValueField="SUBJECT_CODE" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                    <asp:SqlDataSource ID="StudentsAssignmentSubmitted" runat="server" ConnectionString="<%$ ConnectionStrings:SMS %>" SelectCommand="SELECT [SUBJECT CODE] AS SUBJECT_CODE FROM [ASSIGNMENT_BY_STAFF]"></asp:SqlDataSource>
                    &nbsp;
                    
                    <asp:TextBox ID="txtMark" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    
                    <asp:Label ID="labelstudent" runat="server"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Label ID="lblA" runat="server"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                
                    <asp:Button ID="Mark" runat="server" Text="Submit Score" OnClick="Mark_Click" />
                &nbsp;<input type="hidden" id="infosub" runat="server" /><input type="hidden" id="infoclass" runat="server"/><br />
                    <br />
                    <hr />
                     <asp:GridView ID="GridView2" runat="server" BorderWidth="2px" CellPadding="10" ForeColor="#333333" AutoGenerateColumns="False" EmptyDataText="No records found!" AllowPaging="True"  CellSpacing="20" Font-Names="Arial" OnPageIndexChanging="GridView2_PageIndexChanging" OnRowCommand="GridView2_RowCommand">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="STUDENT_ID" HeaderText="STUDENT"  />
                        <asp:BoundField DataField="ASSIGNMENT_CODE" HeaderText="ASSIGNMENT"  />
                        <asp:BoundField DataField="ASSIGNMENT_TITLE" HeaderText="TITLE"  />
                        <asp:BoundField DataField="SUBJECT_CODE" HeaderText="SUBJECT"  />
                        <asp:BoundField DataField="CLASS_ID" HeaderText="CLASS"  />
                        <%-- <asp:BoundField DataField="MARK" HeaderText="SCORE" /> --%> 
                        <asp:BoundField DataField="DATE" HeaderText="SUBMITTED"  DataFormatString="{0:D}" />
                        <asp:BoundField DataField="DUE_DATE" HeaderText="DUE"  DataFormatString="{0:D}" />
                        <asp:BoundField DataField="Name" HeaderText="FILE NAME" />

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="LnkDownload" runat="server" CommandArgument='<%# Eval("ID") %>' Onclick="LnkDownload_Click" Text="Download"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ButtonType="Link" SelectText="SELECT" ShowSelectButton="true" />                   
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="justify" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>

                </div>
               
            </div>

        </div>
</asp:Content>