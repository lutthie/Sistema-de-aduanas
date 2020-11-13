<%@ Page Title="" Language="C#" MasterPageFile="~/Empleado/Producto/MPProducto.master" AutoEventWireup="true" CodeBehind="InsertarProducto.aspx.cs" Inherits="ProyectoBD.Empleado.Producto.InsertarProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenidoPrincipal" runat="server">
    <link href="../../App_Themes/estilo1.css" rel="stylesheet" />
    <h2>Insertar Producto</h2>

    <div>
        <div class="form-wrapper">
            <form action="">
                <div class="inputBox">
                    <asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>
                    <asp:TextBox ID="txtnombrep" runat="server" Text = "Nombre del producto" ForeColor = "Gray" onfocus = "clearWaterMark('Nombre del producto',this);" onblur = "createWaterMark('Nombre del producto',this);" onkeypress="return soloLetras(event);" Width="457px"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="txtdescrip" runat="server" Text = "Descripción" ForeColor = "Gray" onfocus = "clearWaterMark('Descripción',this);" onblur = "createWaterMark('Descripción',this);" OnTextChanged="txtdescrip_TextChanged" onkeypress="return soloLetras(event);" Width="458px"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="TextBox2" runat="server" Visible="False"></asp:TextBox>
                    <br />
                    Tipo de producto:<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="17px" Width="131px"></asp:DropDownList>
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
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Mostrar código" />
                    <br />
                    <br />
                    <asp:Button ID="btnInsertar" runat="server" Text="Insertar Producto" Width="217px" OnClick="btnInsertar_Click" />
                    <br />
                    <br />
                </div>   
                <br />
                
            </form>

        </div>
    </div>
</asp:Content>
