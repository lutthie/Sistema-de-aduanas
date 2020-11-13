<%@ Page Title="" Language="C#" MasterPageFile="~/Inicial.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="ProyectoBD.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="App_Themes/stilee.css" rel="stylesheet" />
      <div class="container">
          <button><asp:Button runat="server" Text="Cliente" ID="btnCliente" BackColor="#FE2636" BorderStyle="None" Font-Bold="True" ForeColor="White" /></button>      
          <button><asp:Button runat="server" Text="Empleado" ID="btnEmpleado" BackColor="#F5DD33" BorderStyle="None" Font-Bold="True" ForeColor="White" OnClick="btnEmpleado_Click" /></button>
        <!--<button>JELLY</button>
        <button>JELLY</button>-->
      </div>
</asp:Content>
