<%@ Page Language="C#"  MasterPageFile="~/StartPage.master" AutoEventWireup="true" CodeBehind="EnterPerson.aspx.cs" Inherits="ProjectTasks.Views.EnterPerson" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div>
            <asp:TextBox runat="server" type="hidden" id="id"/>
            <label>Name</label><br />
            <asp:TextBox id="name" type="text" runat="server" /><br />
            <asp:RequiredFieldValidator ForeColor="Red" ControlToValidate="name" ID="RequiredFieldValidatorName" runat="server" ErrorMessage="Name is not be empty"></asp:RequiredFieldValidator>
            <br />
            <label>Surname</label><br />
            <asp:TextBox id="surname" type="text"  runat="server"/><br />
            <asp:RequiredFieldValidator ForeColor="Red" ControlToValidate="surname" ID="RequiredFieldValidatorSurname" runat="server" ErrorMessage="Surname is not be empty"></asp:RequiredFieldValidator>
            <br />
            <label>Fathername</label><br />
            <asp:TextBox id="fathername" type="text"  runat="server"/><br />
            <asp:RequiredFieldValidator ForeColor="Red" ControlToValidate="fathername" ID="RequiredFieldValidatorFathername" runat="server" ErrorMessage="Fathername is not be empty"></asp:RequiredFieldValidator>
            <br />

            <asp:button ID="buttonAdd" type="button" runat="server" Text="Add person" OnClick="AddPerson" Width="107px" />
            <asp:button ID="buttonEdit" type="button" runat="server" Text="Edit person" OnClick="EditPerson" Width="107px" />
            <asp:Button runat="server" PostBackUrl="PersonList.aspx" Text="Cancel" CausesValidation="false" /><br /><br />

            <asp:Label id="status" runat="server"></asp:Label>
        </div>
</asp:Content>
