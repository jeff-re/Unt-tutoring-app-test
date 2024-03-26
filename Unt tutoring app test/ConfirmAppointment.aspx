<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConfirmAppointment.aspx.cs" Inherits="Unt_tutoring_app_test.ConfirmAppointment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

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
  <title>Confirm Appointment </title>


</head>

<body>


<%--  <table align="left"  style="height:150px" border=1 bgcolor="lightgray">
    <tr align="center">
      <td align="center"> 
        <button style="width:100%;height:100%;" align="center" onclick="window.open('math date time.html', '_self')">Go Back</button>
      </td>
    </tr>

  </table>--%>

  <table align="center"  style="height:400px"  border=1 bgcolor="lightgray">
    <tr>
      <td align="center"> 
        <h1 style="color:rgb(0, 123, 60);">University of North Texas</h1><h2>Eagle Tutoring</h2>
      </td>
    </tr>
    <p></p>
    <tr>
        <td align="center"> 
          <h1 style="color:rgb(0, 0, 0);">Confirm Math Appointment</h1>
        </td>
      </tr>
      <p></p>
      <p></p>
      <tr>
        <td 
          <center>
  
          <h1 align="center" >January 12th 1:00 PM</h1>
  
        </td>
      </tr>
   
      <p></p>
      <tr>
        <td align="center">
          <button style="width:100%;height:100%;" onclick="window.open('index.html', '_self')">CONFIRM</button>
        </td>
      </tr>
      <p></p>
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

</html>

</asp:Content>
