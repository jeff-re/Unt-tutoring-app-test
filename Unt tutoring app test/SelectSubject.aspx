<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SelectSubject.aspx.cs" Inherits="Unt_tutoring_app_test.SelectSubject" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!DOCTYPE html>
<html>

<head>
  <style>
    body {
      background-image: url('UNTpic2.png');
      background-repeat: no-repeat;
      background-attachment: fixed;
      background-size: cover;

    }
  </style>
  <title>Student Select Subject</title>


</head>

<body>

    
  <table align="left"  style="height:400px"  border=1 bgcolor="lightgray">
    <tr>
      <td align="center"> 
        <h1 style="color:rgb(0, 123, 60);">University of North Texas</h1><h2>Eagle Tutoring</h2>
      </td>
    </tr>
      <tr>
          <td align="center"> 
          <asp:GridView ID="GvSubjects" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" OnRowCommand="GvSubjects_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None" Width="283px" ShowHeader="False">
             <%-- <AlternatingRowStyle BackColor="White" />--%>
              <Columns>
                  <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" Visible="false" />
                  <asp:TemplateField HeaderText="SubjectName">
                      <ItemTemplate>
                          <asp:LinkButton ID="LinkButtonSubjects" Text='<%#Eval("SubjectName") %>' CommandArgument='<%# Eval("Id") %>' CommandName="Remove" runat="server">LinkButton</asp:LinkButton>
                      </ItemTemplate>

                  </asp:TemplateField>
                 <%-- <asp:BoundField DataField="SubjectName" HeaderText="Subjects" SortExpression="SubjectName" ShowHeader="False" >
                  <HeaderStyle Font-Bold="True" HorizontalAlign="right" />
                  <ItemStyle Font-Bold="True" HorizontalAlign="Center" BorderStyle="Double" BorderWidth="5px" />
                  </asp:BoundField>--%>
              </Columns>
              <EditRowStyle BackColor="#7C6F57" />
              <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
              <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
              <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
              <RowStyle BackColor="lightgray" />
              <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
              <SortedAscendingCellStyle BackColor="#F8FAFA" />
              <SortedAscendingHeaderStyle BackColor="#246B61" />
              <SortedDescendingCellStyle BackColor="#D4DFE1" />
              <SortedDescendingHeaderStyle BackColor="#15524A" />
          </asp:GridView>
              </td>
      </tr>
   
      <tr>
      <td align="center">
        <img
          src="https://upload.wikimedia.org/wikipedia/en/thumb/a/a2/North_Texas_Mean_Green_logo.svg/800px-North_Texas_Mean_Green_logo.svg.png"
           style="width:90px;height:100px;">
      </td>
    </tr>

  </table>
    


</body>

</html>

              <asp:SqlDataSource ID="SqlDataSourceSubjects" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [Id], [SubjectName] FROM [Subject]"></asp:SqlDataSource>


</asp:Content>
