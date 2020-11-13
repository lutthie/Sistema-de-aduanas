<%@ Page Title="" Language="C#" MasterPageFile="~/Empleado/Contribuyente/MPContribuyente.master" AutoEventWireup="true" CodeBehind="ModificarContribuyente.aspx.cs" Inherits="ProyectoBD.Empleado.Contribuyente.ModificarContribuyente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenidoPrincipal" runat="server">
    <link href="../../App_Themes/estilo1.css" rel="stylesheet" />
    <h2>Modificar Contribuyente</h2>

    <div>
         <div class="form-wrapper">
            <form action="">
                <script type ="text/javascript">
                    function clearWaterMark(defaultText, textBoxControl) {
                        if (textBoxControl.value == defaultText) {
                            textBoxControl.value = "";
                            textBoxControl.style.color = "Black";
                        }
                    }
                    function createWaterMark(defaultText, textBoxControl) {
                        if (textBoxControl.value.length == 0) {
                            textBoxControl.value = defaultText;
                            textBoxControl.style.color = "Gray";
                        }
                    }
                    function onKeyDecimal(e, thix) {
                        var keynum = window.event ? window.event.keyCode : e.which;
                        if (document.getElementById(thix.id).value.indexOf('.') != -1 && keynum == 46)
                            return false;
                        if ((keynum == 8 || keynum == 48 || keynum == 46))
                            return true;
                        if (keynum <= 47 || keynum >= 58) return false;
                        return /\d/.test(String.fromCharCode(keynum));
                    }

                    function justNumbers(e) {
                        var keynum = window.event ? window.event.keyCode : e.which;
                        if ((keynum == 8 || keynum == 48))
                            return true;
                        if (keynum <= 47 || keynum >= 58) return false;
                        return /\d/.test(String.fromCharCode(keynum));
                    }

                    function soloLetras(evt) {
                        var charCode = (evt.which) ? evt.which : event.keyCode
                        if (charCode > 31 && (charCode < 48 || charCode > 57))
                            return true;

                        return false;
                    }
                        </script>
                    <div class="inputBox">
                        Seleccione aduana:
                        <asp:DropDownList ID="ComboBox1" runat="server">
                            <asp:ListItem Text="--Seleccionar--" Value="0"></asp:ListItem>
                        </asp:DropDownList>
&nbsp;<asp:Label ID="Label2" runat="server" Visible="False"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnbuscar" runat="server" Height="53px" Text="Buscar" OnClick="btnbuscar_Click" />
                        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
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
                        <br />
                        <asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>
                        <asp:TextBox ID="txtnombre" runat="server" Text = "Nombre" ForeColor = "Gray" onfocus = "clearWaterMark('Nombre',this);" onblur = "createWaterMark('Nombre',this);" onkeypress="return soloLetras(event);" Width="461px"></asp:TextBox>
                        <asp:TextBox ID="txtapellido" runat="server" Text = "Apellido" ForeColor = "Gray" onfocus = "clearWaterMark('Apellido',this);" onblur = "createWaterMark('Apellido',this);" onkeypress="return soloLetras(event);" Width="461px"></asp:TextBox>
                        <asp:TextBox ID="txttelefono" runat="server" Text = "Telefono" ForeColor = "Gray" onfocus = "clearWaterMark('Teléfono',this);" onblur = "createWaterMark('Teléfono',this);" onkeypress="return justNumbers(event);" Width="461px"></asp:TextBox>
                        <asp:TextBox ID="txtcorreo" runat="server" Text = "Correo electrónico" ForeColor = "Gray" onfocus = "clearWaterMark('Correo electrónico',this);" onblur = "createWaterMark('Correo electrónico',this);" Width="461px"></asp:TextBox>
                        <asp:TextBox ID="txtdireccion" runat="server" Text = "Dirección" ForeColor = "Gray" onfocus = "clearWaterMark('Dirección',this);" onblur = "createWaterMark('Dirección',this);" onkeypress="return soloLetras(event);" Width="461px"></asp:TextBox>
                        <asp:TextBox ID="txtnit" runat="server" Text = "Nit" ForeColor = "Gray" onfocus = "clearWaterMark('Nit',this);" onblur = "createWaterMark('Nit',this);" onkeypress="return justNumbers(event);" Width="461px"></asp:TextBox>
                        <asp:TextBox ID="txtdescrip" runat="server" Text = "Descripción" ForeColor = "Gray" onfocus = "clearWaterMark('Descripción',this);" onblur = "createWaterMark('Descripción',this);" onkeypress="return soloLetras(event);" Width="461px"></asp:TextBox>
                        <br />
                        <br />
                        
                        <br />

                    </div>
                      
                    <br />
                    <asp:Button ID="btnInsertar" runat="server" Text="Modificar contribuyente" OnClick="btnInsertar_Click" />
&nbsp;</form>
      </div>
    </div>
</asp:Content>
