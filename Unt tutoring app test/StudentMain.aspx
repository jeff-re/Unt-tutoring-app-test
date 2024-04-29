<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentMain.aspx.cs" Inherits="Unt_tutoring_app_test.StudentMain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <!DOCTYPE html>


<head>
  <style>
    body {
      background-image: url('UNTpic2.png');
      background-repeat: no-repeat;
      background-attachment: fixed;
      background-size: cover;

    }
      .auto-style1 {
          width: 6px;
      }
  </style>
  <title>Student Schedule</title>


</head>

<body>


  <table align="center"  style="height:400px"  border=1 bgcolor="lightgray">
    <tr>
      <td align="center"> 
        <h1 style="color:rgb(0, 123, 60);">University of North Texas</h1><h2>Eagle Tutoring</h2>
      </td>
    </tr>

    <tr>
      <td align="center">
<%--        <button style="width:100%;height:100%;" onclick="window.open('student select subject.html', '_self')">Schedule Appointment</button>--%>
          <asp:Button style="width:100%;height:100%;" ID="BtnSchedule_Appointment" runat="server" OnClick="BtnSchedule_Appointment_Click" Text="Schedule Appointment" />
      </td>
    </tr>

    <tr>
      <td align="center">
<%--        <button style="width:100%;height:100%;" onclick="window.open('change or cancel.html', '_self')">Change or Cancel Appointment</button>--%>
          <asp:Button style="width:100%;height:100%;" ID="BtnChange_Cancel" runat="server" OnClick="BtnChange_Cancel_Click" Text="Change or Cancel Appointment" />
      </td>
    </tr>
<p></p>
    <tr>
      <td align="center">
        <img
          src="https://upload.wikimedia.org/wikipedia/en/thumb/a/a2/North_Texas_Mean_Green_logo.svg/800px-North_Texas_Mean_Green_logo.svg.png"
           style="width:90px;height:100px;">
      </td>
    </tr>
    
  </table>


</body>


</asp:Content>
