<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SelectTutorAndTime.aspx.cs" Inherits="Unt_tutoring_app_test.SelectTutorAndTime" %>
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
  <title>Select Math Tutor </title>


</head>

<body>

    <table class="table table-borderless table-dark">

  <tbody>
    <tr>
      <th scope="row">1</th>
      <td>Mark</td>
      <td>Otto</td>
      <td>@mdo</td>
    </tr>
    <tr>
      <th scope="row">2</th>
      <td>Jacob</td>
      <td>Thornton</td>
      <td>@fat</td>
    </tr>
    <tr>
      <th scope="row">3</th>
      <td colspan="2">Larry the Bird</td>
      <td>@twitter</td>
    </tr>
  </tbody>
</table>

  <table align="left"  style="height:400px"  border=1 bgcolor="lightgray">
    <tr>
      <td align="center"> 
        <h1 style="color:rgb(0, 123, 60);">University of North Texas</h1><h2>Eagle Tutoring</h2>
      </td>
    </tr>
    <tr>
        <td align="center"> 
          <h1 style="color:rgb(0, 0, 0);">Select Math Tutor</h1>
        </td>
      </tr>
    <tr>
      <td align="center">

          <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSourceAppData" ForeColor="#333333" GridLines="None">
              <AlternatingRowStyle BackColor="White" />
              <Columns>
                  <asp:BoundField DataField="AppointDate" HeaderText="AppointDate" SortExpression="AppointDate" />
                  <asp:BoundField DataField="Time" HeaderText="Time" ReadOnly="True" SortExpression="Time" />
              </Columns>
              <EditRowStyle BackColor="#2461BF" />
              <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
              <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
              <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
              <RowStyle BackColor="#EFF3FB" />
              <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
              <SortedAscendingCellStyle BackColor="#F5F7FB" />
              <SortedAscendingHeaderStyle BackColor="#6D95E1" />
              <SortedDescendingCellStyle BackColor="#E9EBEF" />
              <SortedDescendingHeaderStyle BackColor="#4870BE" />
          </asp:GridView>
       
          <asp:SqlDataSource ID="SqlDataSourceAppData" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT ta.AppointDate,t.TimeStart + ' - ' + t.TimeEnd As Time
FROM [dbo].[TutorAvailable] AS ta
INNER JOIN [dbo].[TutorSubject] AS ts
	ON ta.TutorId = ts.TutorID
INNER JOIN [dbo].[TimeSlots] AS t
	ON ta.TimeSlotId = t.Id
WHERE ts.SubjectID = 1"></asp:SqlDataSource>
       
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


</asp:Content>
