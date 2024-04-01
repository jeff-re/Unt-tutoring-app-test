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

        <div class="container text-center" style="background-color: lightgray; width: 65%;">
            <div class="row justify-content-md-center">
                <div class="col-md-auto">
                    <h1 style="color: rgb(0, 123, 60);">University of North Texas</h1>
                    <h2>Eagle Tutoring</h2>
                </div>
            </div>
            <div class="row justify-content-md-center">
                <div class="col-md-auto">
                    <h1 style="color: rgb(0, 0, 0);">Select Tutor</h1>
                </div>

            </div>
            <div class="row justify-content-md-center">
                <div class="col-md-auto">

                    <div class="row justify-content-md-center">
                        <div class="col">
                            <asp:Calendar ID="Cal_Appoitments" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="250px" NextPrevFormat="ShortMonth" ShowGridLines="True" Width="330px" OnDayRender="Cal_Appoitments_DayRender" OnSelectionChanged="Cal_Appoitments_SelectionChanged">
                                <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" Height="8pt" />
                                <DayStyle BackColor="#CCCCCC" BorderStyle="Outset" BorderWidth="2px" />
                                <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
                                <OtherMonthDayStyle ForeColor="#999999" />
                                <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                                <TitleStyle BackColor="#333399" BorderStyle="Solid" Font-Bold="True" Font-Size="12pt" ForeColor="White" Height="12pt" />
                                <TodayDayStyle BackColor="#999999" ForeColor="#999999" />
                            </asp:Calendar>
                        </div>
                    </div>
                    <div class="row justify-content-md-center">
                        <div class="col" style="padding-top:10px">
                            <asp:Label ID="LbTime" runat="server" Text="Select Time" Font-Bold="True"></asp:Label>
                            <asp:DropDownList ID="DdlTimes" runat="server" DataSourceID="SqlDataSourceTime" DataTextField="Time" DataValueField="id" Height="40px" Width="130px" BackColor="DarkGray" Font-Bold="True" style="border:1px solid black;width:100%" AutoPostBack="True" OnSelectedIndexChanged="DdlTimes_SelectedIndexChanged" ></asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSourceTime" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand=" SELECT id, TimeStart + ' - ' + TimeEnd As Time
 FROM [dbo].[TimeSlots] UNION SELECT '0','-- Any --'"></asp:SqlDataSource>
                        </div>
                    </div>
                    <div class="row justify-content-md-center">
                        <div class="col" style="padding-top:10px;" >

                            <asp:Label ID="Label1" runat="server" Text="Select Tutor" Font-Bold="True"></asp:Label>
                            <asp:DropDownList ID="DdlTutors" runat="server" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="Id" Height="40px" Width="130px" BackColor="DarkGray" Font-Bold="True" style="border:1px solid black;width:100%;" AutoPostBack="True" OnSelectedIndexChanged="DdlTutors_SelectedIndexChanged"></asp:DropDownList>



                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT Id,LEFT(Email, CHARINDEX('@', Email) - 1) AS Name FROM [dbo].[AspNetUsers] UNION SELECT '0','-- Any --';"></asp:SqlDataSource>

                        </div>
                    </div>


                </div>
                <div class="col-md-auto">
                    <asp:GridView ID="GvAppointment" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="380px" ShowHeaderWhenEmpty="True" OnRowCommand="GvAppointment_RowCommand">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="AppointDate" HeaderText="AppointDate" SortExpression="AppointDate" />
                            <asp:BoundField DataField="Time" HeaderText="Time" ReadOnly="True" SortExpression="Time" />
                            <asp:TemplateField HeaderText="Book">
                      <ItemTemplate>

                          <%--<asp:Button ID="Button1" CssClass="SubjectLink" CommandArgument='<%# Eval("AppointDate") %>' CommandName="Select" runat="server" Text="Button" />--%>
                          <asp:LinkButton ID="LinkButtonTimes" CssClass="SubjectLink" Text='Book' CommandArgument='<%# Eval("Id") %>' CommandName="Select" runat="server">Book</asp:LinkButton>
                      </ItemTemplate>

                     
                     <%-- <ItemStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" BorderStyle="Double" BorderWidth="5px" />--%>

                  </asp:TemplateField>
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
                </div>

            </div>

            <div class="row justify-content-md-center">

                <div class="col-md-auto">
                    <img
                        src="https://upload.wikimedia.org/wikipedia/en/thumb/a/a2/North_Texas_Mean_Green_logo.svg/800px-North_Texas_Mean_Green_logo.svg.png"
                        style="width: 90px; height: 100px;">
                </div>

            </div>

        </div>
        <br />


        <table align="center" style="height: 400px" border="1" bgcolor="lightgray">
            <tr>
                <td align="center">
                    <h1 style="color: rgb(0, 123, 60);">University of North Texas</h1>
                    <h2>Eagle Tutoring</h2>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <h1 style="color: rgb(0, 0, 0);">Select Math Tutor</h1>
                </td>
            </tr>
            <tr>
                <td align="center">

                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSourceAppData" ForeColor="#333333" GridLines="None" Width="291px">
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



                </td>
            </tr>
            <tr>
                <td align="center">
                    <img
                        src="https://upload.wikimedia.org/wikipedia/en/thumb/a/a2/North_Texas_Mean_Green_logo.svg/800px-North_Texas_Mean_Green_logo.svg.png"
                        style="width: 90px; height: 100px;">
                </td>
            </tr>

        </table>


    </body>

    <asp:SqlDataSource ID="SqlDataSourceAppData" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT ta.AppointDate,t.TimeStart + ' - ' + t.TimeEnd As Time
FROM [dbo].[TutorAvailable] AS ta
INNER JOIN [dbo].[TutorSubject] AS ts
	ON ta.TutorId = ts.TutorID
INNER JOIN [dbo].[TimeSlots] AS t
	ON ta.TimeSlotId = t.Id
WHERE ts.SubjectID = 1"></asp:SqlDataSource>

    </html>


</asp:Content>
