<%@ Page Title="" Language="C#" MasterPageFile="~/Empleado/Producto/MPProducto.master" AutoEventWireup="true" CodeBehind="InsertarTProducto.aspx.cs" Inherits="ProyectoBD.Empleado.Producto.InsertarTProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenidoPrincipal" runat="server">
    <link href="../../App_Themes/estilo1.css" rel="stylesheet" />
    <h2>Insertar un tipo de producto</h2>

    <div>
         <div class="form-wrapper">
            <form action="">

                    <div class="inputBox">
                        
                        <asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>
                        
                        <asp:TextBox ID="txtnombrec" runat="server" Text = "Tipo del Producto" ForeColor = "Gray" onfocus = "clearWaterMark('Tipo del Producto',this);" onblur = "createWaterMark('Tipo del Producto',this);" onkeypress="return soloLetras(event);" Width="461px"></asp:TextBox>
                        
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
                        <br />
                        <div>
                            <br />
                        </div>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnInsertar" runat="server" Text="Insertar tipo de producto" Height="57px" Width="204px" OnClick="btnInsertar_Click" />
                        <br />
                        <br />
                        <div id ="eliminar">

                            <asp:DropDownList ID="DropDownList1" runat="server" Width="128px">
                            </asp:DropDownList>
                            <br />
                            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar tipo de producto" Height="57px" Width="204px" />

                        </div>

                        <div id ="table">
                            <asp:GridView ID="dataGridView1" runat="server" AutoGenerateColumns="false" Width="128px" >
                                <Columns>
                                    <asp:BoundField DataField="ID_T_PRO" HeaderText="Código" />
                                    <asp:BoundField DataField="TIPO" HeaderText="Tipo Producto" />
                                </Columns>
                            </asp:GridView>
                        </div>
                </div>
                
&nbsp;</form>
      </div>
    </div>
</asp:Content>
