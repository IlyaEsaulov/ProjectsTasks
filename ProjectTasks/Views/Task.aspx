<%@ Page Language="C#" MasterPageFile="~/StartPage.master" AutoEventWireup="true" CodeBehind="Task.aspx.cs" Inherits="ProjectTasks.Views.Task" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div>
            <asp:TextBox runat="server" type="hidden" id="id"/>
            <label>Title</label><br />
            <asp:TextBox id="title" type="text" runat="server" Width="150px" /><br />
            <asp:RequiredFieldValidator ControlToValidate="title" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Title is not be empty" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <label>Workload</label><br />
            <asp:TextBox id="workload" type="int"  runat="server" Width="150px"/><br />
            <asp:RangeValidator ControlToValidate="workload" ID="RangeValidator1" runat="server" ErrorMessage="Workload must be a number" ForeColor="Red" MaximumValue="9999999" MinimumValue="0"></asp:RangeValidator>
            <br />
            <label>Date Start</label><br />
            <asp:TextBox id="dateStart" type="date" runat="server" Width="150px"/><br />
            <asp:RequiredFieldValidator ControlToValidate="dateStart" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Date start is not be empty" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <label>Date Finish</label><br />
            <asp:TextBox id="dateFinish" type="date"  runat="server" Width="150px"/><br />
            <asp:RequiredFieldValidator ControlToValidate="dateFinish" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Date finish is not be empty" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <label>Status</label><br />
            <asp:DropDownList ID="StatusList" runat="server" Width="150px">
                <asp:ListItem Text="" Value=""></asp:ListItem>
                <asp:ListItem Text="Not started" Value="1"></asp:ListItem>
                <asp:ListItem Text="In the process" Value="2"></asp:ListItem>
                <asp:ListItem Text="Complited" Value="3"></asp:ListItem>
                <asp:ListItem Text="Delayed" Value="4"></asp:ListItem>
            </asp:DropDownList><br />
            <asp:RequiredFieldValidator ControlToValidate="StatusList" ID="RequiredFieldValidator5" runat="server" ErrorMessage="Status is not be empty" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <label>Persons<br />
            </label>
            <asp:DropDownList ID="PersonsList" runat="server" Width="150px">
                <asp:ListItem Text="" Value=""></asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:RequiredFieldValidator ControlToValidate="PersonsList" ID="RequiredFieldValidator6" runat="server" ErrorMessage="Persons is not be empty" ForeColor="Red" ></asp:RequiredFieldValidator>
            <br />
            <br />


            <asp:button ID="buttonAdd" type="button" runat="server" Text="Add Task" OnClick="AddTask" Width="107px" />
            <asp:button ID="buttonEdit" type="button" runat="server" Text="Edit Task" OnClick="EditTask" Width="107px" />
            <asp:Button runat="server" PostBackUrl="TaskList.aspx" Text="Cancel" CausesValidation="false" /><br /><br />
            <asp:Label id="status" runat="server"></asp:Label>
        </div>
</asp:Content>