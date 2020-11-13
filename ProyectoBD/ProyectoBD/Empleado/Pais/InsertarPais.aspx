<%@ Page Title="" Language="C#" MasterPageFile="~/Empleado/Pais/MPPais.master" AutoEventWireup="true" CodeBehind="InsertarPais.aspx.cs" Inherits="ProyectoBD.Empleado.Pais.InsertarPais" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenidoPrincipal" runat="server">
    <link href="../../App_Themes/estilo1.css" rel="stylesheet" />
    <h2>Insertar País</h2>

    <div>
         <div class="form-wrapper">
            <form action="">

                    <div class="inputBox">
                        <asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>
                        <asp:TextBox ID="txtnombrep" runat="server" Text = "País" ForeColor = "Gray" onfocus = "clearWaterMark('País',this);" onblur = "createWaterMark('País',this);" onkeypress="return soloLetras(event);" Width="456px"></asp:TextBox>
                        <asp:TextBox ID="txtregion" runat="server" Text = "Región" ForeColor = "Gray" onfocus = "clearWaterMark('Región',this);" onblur = "createWaterMark('Región',this);" onkeypress="return soloLetras(event);" Width="456px"></asp:TextBox>
                        
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
                    <asp:Button ID="btnInsertar" runat="server" Text="Insertar País" OnClick="btnInsertar_Click" />
&nbsp;</form>
      </div>
    </div>
</asp:Content>
