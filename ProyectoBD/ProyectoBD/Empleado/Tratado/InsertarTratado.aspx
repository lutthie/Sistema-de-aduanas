<%@ Page Title="" Language="C#" MasterPageFile="~/Empleado/Tratado/MPTratado.master" AutoEventWireup="true" CodeBehind="InsertarTratado.aspx.cs" Inherits="ProyectoBD.Empleado.Tratado.InsertarTratado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenidoPrincipal" runat="server">
    <link href="../../App_Themes/estilo1.css" rel="stylesheet" />
    <h2>Insertar Tratado</h2>

    <div>
         <div class="form-wrapper">
            <form action="">

                    <div class="inputBox">
                        <asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>
                        <asp:TextBox ID="txtnombre" runat="server" Text = "Nombre del tratado" ForeColor = "Gray" onfocus = "clearWaterMark('Nombre del tratado',this);" onblur = "createWaterMark('Nombre del tratado',this);" onkeypress="return soloLetras(event);" Width="461px"></asp:TextBox>
                        <asp:TextBox ID="txtdescrip" runat="server" Text = "Descripción" ForeColor = "Gray" onfocus = "clearWaterMark('Descripción',this);" onblur = "createWaterMark('Descripción',this);" onkeypress="return soloLetras(event);" Width="461px"></asp:TextBox>
                        <asp:TextBox ID="txtfechae" runat="server" Text = "Fecha de emisión" ForeColor = "Gray" onfocus = "clearWaterMark('Fecha de emisión',this);" onblur = "createWaterMark('Fecha de emisión',this);" Width="461px"></asp:TextBox>
                        <br />
                        <br />
                        Aduana: <asp:DropDownList ID="ddladu" runat="server"></asp:DropDownList>
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
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <br />
                        <asp:Label ID="Label1" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Mostrar código" />
                        <br />

                    </div>
                      
                    <br />
                    <asp:Button ID="btnInsertar" runat="server" Text="Insertar Tratado" OnClick="btnInsertar_Click" />
&nbsp;</form>
      </div>
    </div>
</asp:Content>
