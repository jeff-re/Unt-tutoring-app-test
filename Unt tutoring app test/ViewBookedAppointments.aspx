<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewBookedAppointments.aspx.cs" Inherits="Unt_tutoring_app_test.ViewBookedAppointments" %>

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
        <title>Student Schedule</title>


    </head>

    <body>


        <table align="left" style="height: 150px" border="1" bgcolor="lightgray">
            <tr align="center">
                <td align="center">
                    <button style="width: 100%; height: 100%;" align="center" onclick="window.open('student-login.html', '_self')">Go Back</button>
                </td>
            </tr>

        </table>

        <table align="center" style="height: 400px" border="1" bgcolor="lightgray">
            <tr>
                <td align="center">
                    <h1 style="color: rgb(0, 123, 60);">University of North Texas</h1>
                    <h2>Eagle Tutoring</h2>
                </td>
            </tr>

            <tr>
                <td align="center">
                    <%--<button style="width: 100%; height: 100%;" onclick="window.open('student select subject.html', '_self')">Schedule Appointment</button>--%>
                </td>
            </tr>

            <tr>
                <td align="center">
                    <%--<button style="width: 100%; height: 100%;" onclick="window.open('change or cancel.html', '_self')">Change or Cancel Appointment</button>--%>
                </td>
            </tr>
            <p></p>
            <tr>
                <td align="center">
                    <img
                        src="https://upload.wikimedia.org/wikipedia/en/thumb/a/a2/North_Texas_Mean_Green_logo.svg/800px-North_Texas_Mean_Green_logo.svg.png"
                        style="width: 90px; height: 100px;">
                </td>
            </tr>

        </table>


    </body>

    </html>
</asp:Content>
