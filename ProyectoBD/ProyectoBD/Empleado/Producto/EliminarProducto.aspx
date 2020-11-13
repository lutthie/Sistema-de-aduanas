<%@ Page Title="" Language="C#" MasterPageFile="~/Empleado/Producto/MPProducto.master" AutoEventWireup="true" CodeBehind="EliminarProducto.aspx.cs" Inherits="ProyectoBD.Empleado.Producto.EliminarProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenidoPrincipal" runat="server">
    <link href="../../App_Themes/estilo1.css" rel="stylesheet" />
    <div class="form-wrapper">
        <form action="">
            <div class="inputBox">
                <h2>Eliminar producto</h2>
                    <div>
                        País a eliminar:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  <asp:DropDownList ID="DropDownList1" runat="server">
                            <asp:ListItem Text="--Seleccionar--" Value="0"></asp:ListItem>
                                                                          </asp:DropDownList>
                        <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
                        <asp:Button ID="btnBuscar" runat="server" Height="56px" OnClick="btnBuscar_Click" Text="Buscar" />
                        <br />
                        <br />
                        <br />
                        <div>
                            <asp:GridView ID="dataGridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView>
                        </div>
                        <div>
                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
                        </div>
                    </div>
                </p>

            </div>
        </form>
    </div>
</asp:Content>
