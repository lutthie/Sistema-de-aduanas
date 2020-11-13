<%@ Page Title="" Language="C#" MasterPageFile="~/Empleado/Factura/MPFactura.master" AutoEventWireup="true" CodeBehind="SemaforoFactura.aspx.cs" Inherits="ProyectoBD.Empleado.Factura.SemaforoFactura" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenidoPrincipal" runat="server">
    <link href="../../App_Themes/estilo1.css" rel="stylesheet" />
    <h2>Semáforo Factura</h2>

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

                    function ValidaDecimal(dato) {
                        var valor = dato.indexOf(",");
                        if ((window.event.keyCode > 47 && window.event.keyCode < 58) || window.event.keyCode == 44) {
                            if (window.event.keyCode == 44) {
                                if (valor >= 0) {
                                    window.event.returnValue = false;
                                }
                            }
                        } else {
                            window.event.returnValue = false;
                        }
                    }
                        </script>
                    <div class="inputBox">
                        <asp:Image ID="semaforoimg" runat="server" Height="123px" Width="99px" />
                        <asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>
                        <asp:TextBox ID="txtnit" runat="server" Text = "Nit del cliente" ForeColor = "Gray" onfocus = "clearWaterMark('Nit del cliente',this);" onblur = "createWaterMark('Nit del cliente',this);" onkeypress="return justNumbers(event);" Width="461px"></asp:TextBox>
                        <asp:TextBox ID="txtnombre" runat="server" Text = "Nombre" ForeColor = "Gray" onfocus = "clearWaterMark('Nombre',this);" onblur = "createWaterMark('Nombre',this);" onkeypress="return soloLetras(event);" Width="461px"></asp:TextBox>
                        <asp:TextBox ID="txtpais" runat="server" Text = "País" ForeColor = "Gray" onfocus = "clearWaterMark('País',this);" onblur = "createWaterMark('País',this);" onkeypress="return soloLetras(event);" Width="461px"></asp:TextBox>
                        <asp:TextBox ID="txtdescrip" runat="server" Text = "Descripción" ForeColor = "Gray" onfocus = "clearWaterMark('Descripción',this);" onblur = "createWaterMark('Descripción',this);" onkeypress="return soloLetras(event);" Width="461px"></asp:TextBox>
                        <asp:TextBox ID="txtproduc" runat="server" Text = "Productos" ForeColor = "Gray" onfocus = "clearWaterMark('Productos',this);" onblur = "createWaterMark('Productos',this);" onkeypress="return soloLetras(event);" Width="461px"></asp:TextBox>
                        <asp:TextBox ID="txtcantidad" runat="server" Text = "Cantidad" ForeColor = "Gray" onfocus = "clearWaterMark('Cantidad',this);" onblur = "createWaterMark('Cantidad',this);" onkeypress="return justNumbers(event);" Width="461px"></asp:TextBox>
                        <asp:TextBox ID="txtprecio" runat="server" Text = "Precio" ForeColor = "Gray" onfocus = "clearWaterMark('Precio',this);" onblur = "createWaterMark('Precio',this);" onkeypress ="return ValidaDecimal(this.value);" Width="461px"></asp:TextBox>
                        <asp:TextBox ID="txtimpuesto" runat="server" Text = "Impuesto" ForeColor = "Gray" onfocus = "clearWaterMark('Impuesto',this);" onblur = "createWaterMark('Impuesto',this);" onkeypress ="return ValidaDecimal(this.value);" Width="461px"></asp:TextBox>
                        <asp:TextBox ID="txttotal" runat="server" Text = "Total" ForeColor = "Gray" onfocus = "clearWaterMark('Total',this);" onblur = "createWaterMark('Total',this);" Width="461px" Enabled="False"></asp:TextBox>
                        <br />
                        <br />
                        Importación:&nbsp;&nbsp;<asp:DropDownList runat="server" ID="ddlimp"><asp:ListItem Text="--Seleccionar--" Value="0"></asp:ListItem></asp:DropDownList>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label1" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="Button1" runat="server" Height="53px" OnClick="Button1_Click" Text="Mostrar código" />
                        <br />
                        
                        <br />

                    </div>
                      
                    <br />
                    <asp:Button ID="btnInsertar" runat="server" Text="Insertar Factura" OnClick="btnInsertar_Click" />
&nbsp;</form>
      </div>
    </div>
</asp:Content>
