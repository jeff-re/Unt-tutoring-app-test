<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HoursOfOperation.aspx.cs" Inherits="Unt_tutoring_app_test.HoursOfOperation" %>

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
  <title>Hours of Operation</title>


</head>

<body>

 <form runat="server">
  <table align="left"  style="height:150px" border=1 bgcolor="lightgray">
    <tr align="center">
      <td align="center"> 

          <asp:Button ID="BtnBack" runat="server" Text="Go Back" style="width:100%;height:100%;" align="center" OnClick="BtnBack_Click"/>
        <%--<button style="width:100%;height:100%;" align="center" onclick="window.open('index.html', '_self')">Go Back</button>--%>
      </td>
    </tr>

  </table>
     </form>

  <table align="center"  style="height:400px"  border=1 bgcolor="lightgray">
    <tr>
      <td align="center"> 
        <h1 style="color:rgb(0, 123, 60);">University of North Texas</h1><h2>Eagle Tutoring</h2>
      </td>
    </tr>

    <p></p>
    <tr>
      <td >
        <center>

        <h1 align="center" >Hours of Operations</h1>
          <p align="center">Monaday to Friday</p>
          <p align="center">
            8:00 AM to 5:00 PM</p>

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

</html>
