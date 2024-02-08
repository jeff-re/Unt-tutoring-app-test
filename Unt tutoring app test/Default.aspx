<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Unt_tutoring_app_test._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
         <div>
        <!-- Your existing content goes here -->

        <!-- Button to schedule appointment -->
        <asp:Button ID="btnScheduleAppointment" runat="server" Text="Schedule Appointment" OnClick="btnScheduleAppointment_Click" />

        <!-- Button to cancel or change appointment -->
        <asp:Button ID="btnCancelChangeAppointment" runat="server" Text="Cancel/Change Appointment" OnClick="btnCancelChangeAppointment_Click" />
    </div>
    </main>

</asp:Content>
