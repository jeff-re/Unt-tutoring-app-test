<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="landingPage.aspx.cs" Inherits="Unt_tutoring_app_test.WebForm2" %>

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
  <title>UNT Eagle Tutoring</title>
</head>

<body>
  <form id="form1" runat="server">
    <table align="left" style="height:150px" border="1" bgcolor="lightgray">
      <tr align="center">
        <td align="center">

            <asp:Button ID="btnContactUs" runat="server" Text="CONTACT US" OnClick="btnContactUs_Click" Width="100%" Height="100%" />
            <%--          <asp:Button ID="btnContactUs" runat="server" Text="CONTACT US" OnClientClick="window.open('contact us-page.html', '_blank')" Width="100%" Height="100%" />--%>
        </td>
      </tr>

      <tr>
        <td>

            <asp:Button ID="BtnHoursOfOperation" runat="server" Text="HOURS OF OPERATION" OnClick="BtnHoursOfOperation_Click" Width="100%" Height="100%" />
            <%--          <asp:Button ID="btnHoursOfOperation" runat="server" Text="HOURS OF OPERATION" OnClientClick="window.open('hours-of-operation.html', '_blank')" Width="100%" Height="100%" />--%>
        </td>
      </tr>
    </table>

    <table align="center" style="height:400px" border="1" bgcolor="lightgray">
      <tr>
        <td align="center">
          <h1 style="color:darkgreen;">University of North Texasle Tutoring</h1>
        </td>
      </tr>

      <tr>
        <td align="center">
          <asp:Button ID="btnStudentLogin" runat="server" Text="STUDENT LOGIN" Width="100%" Height="100%" OnClick="btnStudentLogin_Click1" />
        </td>
      </tr>

      <tr>
        <td align="center">
          <asp:Button ID="btnTutorLogin" runat="server" Text="TUTOR LOGIN"  Width="100%" Height="100%" OnClick="btnTutorLogin_Click1" />
        </td>
      </tr>

      <tr>
        <td align="center">
          <img src="https://upload.wikimedia.org/wikipedia/en/thumb/a/a2/North_Texas_Mean_Green_logo.svg/800px-North_Texas_Mean_Green_logo.svg.png" style="width:90px;height:100px;" />
        </td>
      </tr>
    </table>
  </form>
</body>

</html>
