<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="Unt_tutoring_app_test.ContactUs" %>

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
  <title>Contact Us</title>


</head>

<body>

  <form runat="server">
  <table align="left"  style="height:150px" border=1 bgcolor="lightgray">
    <tr align="center">
      <td align="center"> 
         <asp:Button ID="btnBack" runat="server" Text="Go Back" OnClick="btnBack_Click" style="width:100%;height:100%;" align="center"  />
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
      <td> 
        <center>

        <h1 align="center" >Contact Information</h1>
          <p align="center">Email: unteagletutoring@my.unt.edu</p>
          <p align="center">
            Phone Number: (123) - 456 - 7890</p>

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
