<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonList.aspx.cs" Inherits="ProjectTasks.Views.PersonList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
</head>
<body>
    <form id="form1" runat="server">

       <asp:Button runat="server" ID="CreateNewPerson" PostBackUrl="EnterPerson.aspx" Text="Create New Person" />

        <asp:GridView ID="ListPerson" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" >
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Surname" HeaderText="Surname" />
                <asp:BoundField DataField="Fathername" HeaderText="Fathername" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton Id="linkDelete" Text="Delete" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="DeletePerson"></asp:LinkButton>
                        <asp:LinkButton Id="LinkUpdate" Text="Update" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="UpdatePerson"></asp:LinkButton>
                    </ItemTemplate>
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
      </form>

         
</body>
</html>
