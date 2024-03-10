<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tutormanage.aspx.cs" Inherits="Unt_tutoring_app_test.Tutormanage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



    <p class="text-success">
        <asp:Literal runat="server" ID="SuccessMessage" />
    </p>

   
  <div class="row justify-content-start">
    <div class="col-4" >  <%--align="center"--%>
        <div class="subject-date" style="padding: 10px; margin: 0px; background-color: darkgray;">
       
        <asp:TextBox ID="TextBox1" runat="server"> </asp:TextBox>
    <asp:Button ID="Btn_selectDate" runat="server" OnClick="Btn_selectDate_Click" Text="Select Date" />
    <asp:Button ID="Btn_addDate" runat="server" OnClick="Btn_addDate_Click" Text="Add Date" />
    <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" OnSelectionChanged="Calendar1_SelectionChanged" Width="220px">
        <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
        <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
        <OtherMonthDayStyle ForeColor="#999999" />
        <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
        <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
        <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
        <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
        <WeekendDayStyle BackColor="#CCCCFF" />
    </asp:Calendar>
  

        <br />
        <asp:Label ID="Label2" runat="server" BackColor="#99FF66" Text="PreferedTutoringSubjects" style="align-content:center" >Prefered Tutoring Subjects</asp:Label>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="gvCurentTutoringSubjects" GridLines="Horizontal">
            <AlternatingRowStyle BackColor="#F7F7F7" />
            <Columns>
                <asp:BoundField DataField="Subject Name" HeaderText="Subject Name" SortExpression="Subject Name" />
            </Columns>
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <SortedAscendingCellStyle BackColor="#F4F4FD" />
            <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
            <SortedDescendingCellStyle BackColor="#D8D8F0" />
            <SortedDescendingHeaderStyle BackColor="#3E3277" />
        </asp:GridView>
        
        <br />
        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="ddlsubject" DataTextField="SubjectName" DataValueField="Id">
        </asp:DropDownList>
        <asp:Button ID="Button1" runat="server" Text="Add Subject" />
        <asp:SqlDataSource ID="ddlsubject" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [Id], [SubjectName] FROM [Subject]"></asp:SqlDataSource>
        </div>
       
      
    </div>
    <div class="col-4">
       <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" HorizontalAlign="Center" Width="564px" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" AutoGenerateColumns="False">
        <AlternatingRowStyle BackColor="#F7F7F7" />
           <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" Visible="False" />
            <asp:BoundField DataField="AppointDate" HeaderText="AppointDate" DataFormatString="{0:MM/dd/yyyy}" SortExpression="AppointDate" />
            <asp:BoundField DataField="TimeSlot" HeaderText="TimeSlot" ReadOnly="True" SortExpression="TimeSlot" />
            <asp:CommandField ButtonType="Button" ShowDeleteButton="True">
            <ControlStyle BackColor="#4A3C8C" ForeColor="#F7F7F7" />
            </asp:CommandField>
        </Columns>
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
        <SortedAscendingCellStyle BackColor="#F4F4FD" />
        <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
        <SortedDescendingCellStyle BackColor="#D8D8F0" />
        <SortedDescendingHeaderStyle BackColor="#3E3277" />
    </asp:GridView>
        <br />
        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" Visible="False" />
                <asp:BoundField DataField="AppointDate" HeaderText="AppointDate" SortExpression="AppointDate" />
                <asp:BoundField DataField="TimeSlot" HeaderText="TimeSlot" ReadOnly="True" SortExpression="TimeSlot" />
            </Columns>
        </asp:GridView>
    </div>
  </div>



<%--    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:Button ID="Btn_selectDate" runat="server" OnClick="Btn_selectDate_Click" Text="Select Date" />
    <asp:Button ID="Btn_addDate" runat="server" OnClick="Btn_addDate_Click" Text="Add Date" />
    <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" OnSelectionChanged="Calendar1_SelectionChanged" Width="220px">
        <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
        <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
        <OtherMonthDayStyle ForeColor="#999999" />
        <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
        <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
        <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
        <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
        <WeekendDayStyle BackColor="#CCCCFF" />
    </asp:Calendar>

    <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" HorizontalAlign="Center" Width="564px" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing">
        <AlternatingRowStyle BackColor="#F7F7F7" />
        <Columns>
            <asp:BoundField DataField="AppointDate" HeaderText="AppointDate" DataFormatString="{0:MM/dd/yyyy}" SortExpression="AppointDate" />
            <asp:BoundField DataField="TimeSlot" HeaderText="TimeSlot" ReadOnly="True" SortExpression="TimeSlot" />
            <asp:CommandField ButtonType="Button" ShowDeleteButton="True">
            <ControlStyle BackColor="#4A3C8C" ForeColor="#F7F7F7" />
            </asp:CommandField>
        </Columns>
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
        <SortedAscendingCellStyle BackColor="#F4F4FD" />
        <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
        <SortedDescendingCellStyle BackColor="#D8D8F0" />
        <SortedDescendingHeaderStyle BackColor="#3E3277" />
    </asp:GridView>--%>


    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT ta.Id,ta.AppointDate, ts.TimeStart + ' - ' + ts.TimeEnd As TimeSlot FROM [dbo].[TutorAvailable] AS ta INNER JOIN [dbo].[TimeSlots] AS ts ON ta.TimeSlotId = ts.Id"></asp:SqlDataSource>


    <asp:SqlDataSource ID="gvCurentTutoringSubjects" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT s.SubjectName AS  'Subject Name'
FROM [dbo].[TutorSubject] AS ts
INNER JOIN [dbo].[Subject] AS s
	ON ts.SubjectID = s.Id"></asp:SqlDataSource>


</asp:Content>
