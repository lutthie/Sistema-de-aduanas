<%@ Page Title="" Language="C#" MasterPageFile="~/Empleado/Contribuyente/MPContribuyente.master" AutoEventWireup="true" CodeBehind="InsertarContribuyente.aspx.cs" Inherits="ProyectoBD.Empleado.Contribuyente.InsertarContribuyente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenidoPrincipal" runat="server">
    <link href="../../App_Themes/estilo1.css" rel="stylesheet" />
    <h2>Insertar Contribuyente</h2>

    <div>
         <div class="form-wrapper">
            <form action="">

                    <div class="inputBox">
                        <asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>
                        <asp:TextBox ID="txtnombrec" runat="server" Text = "" ForeColor = "Gray" onfocus = "clearWaterMark('Nombre',this);" onblur = "createWaterMark('Nombre',this);" onkeypress="return soloLetras(event);" Width="461px"></asp:TextBox>
                        <asp:TextBox ID="txtapellido" runat="server" Text = "" ForeColor = "Gray" onfocus = "clearWaterMark('Apellido',this);" onblur = "createWaterMark('Apellido',this);" onkeypress="return soloLetras(event);" Width="461px"></asp:TextBox>
                        <asp:TextBox ID="txttelefono" runat="server" Text = "" ForeColor = "Gray" onfocus = "clearWaterMark('Telefono',this);" onblur = "createWaterMark('Telefono',this);" onkeypress="return justNumbers(event);" Width="461px"></asp:TextBox>
                        <asp:TextBox ID="txtcorreo" runat="server" Text = "" ForeColor = "Gray" onfocus = "clearWaterMark('Correo electrónico',this);" onblur = "createWaterMark('Correo electrónico',this);" Width="461px"></asp:TextBox>
                        <asp:TextBox ID="txtdireccion" runat="server" Text = "" ForeColor = "Gray" onfocus = "clearWaterMark('Dirección',this);" onblur = "createWaterMark('Dirección',this);" onkeypress="return soloLetras(event);" Width="461px"></asp:TextBox>
                        <asp:TextBox ID="txtnit" runat="server" Text = "" ForeColor = "Gray" onfocus = "clearWaterMark('Nit',this);" onblur = "createWaterMark('Nit',this);" onkeypress="return justNumbers(event);" Width="461px"></asp:TextBox>
                        <asp:TextBox ID="txtdescrip" runat="server" Text = "" ForeColor = "Gray" onfocus = "clearWaterMark('Descripción',this);" onblur = "createWaterMark('Descripción',this);" onkeypress="return soloLetras(event);" Width="461px"></asp:TextBox>
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
                        <br />

                    </div>
                      
                    <br />
                    <asp:Button ID="btnInsertar" runat="server" Text="Insertar Contribuyente" OnClick="btnInsertar_Click" />
&nbsp;</form>
             <br />
             <br />
             <br />
      </div>
    </div>
</asp:Content>
