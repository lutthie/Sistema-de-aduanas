using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OracleClient;

namespace ProyectoBD.Empleado.Importación
{
    public partial class ModificarImportacion : System.Web.UI.Page
    {
        OracleConnection ora = new OracleConnection("DATA SOURCE = xe; PASSWORD = 123; USER ID = LU;");
        protected void Page_Load(object sender, EventArgs e)
        {
            ora.Open();
            if (!IsPostBack)
            {
                ComboImp();
                ComboCont();
                ComboPais();
                ComboProducto();
            }
        }
        private void ComboImp()
        {
            string cadena = "SELECT * FROM IMPORTACION";
            OracleCommand comando = new OracleCommand(cadena, ora);
            OracleDataAdapter adaptador = new OracleDataAdapter(comando);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            ComboBox1.DataSource = tabla;
            ComboBox1.DataTextField = "NOMBRE_C";
            ComboBox1.DataValueField = "ID_IMP";
            ComboBox1.DataBind();
        }
        private void ComboCont()
        {
            string cadena = "SELECT * FROM CONTRIBUYENTE";
            OracleCommand comando = new OracleCommand(cadena, ora);
            OracleDataAdapter adaptador = new OracleDataAdapter(comando);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            ddlcont.DataSource = tabla;
            ddlcont.DataTextField = "NOMBRE_CONT";
            ddlcont.DataValueField = "ID_CONT";
            ddlcont.DataBind();
        }
        private void ComboPais()
        {
            string cadena = "SELECT * FROM PAIS";
            OracleCommand comando = new OracleCommand(cadena, ora);
            OracleDataAdapter adaptador = new OracleDataAdapter(comando);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            //ddlcont.DataSource = Consultar("SELECT * FROM CONTRIBUYENTE");
            ddlpais.DataSource = tabla;
            ddlpais.DataTextField = "NOMBRE";
            ddlpais.DataValueField = "ID_PAIS";
            ddlpais.DataBind();
        }
        private void ComboProducto()
        {
            string cadena = "SELECT * FROM TIPO_PRODUCTO";
            OracleCommand comando = new OracleCommand(cadena, ora);
            OracleDataAdapter adaptador = new OracleDataAdapter(comando);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            //ddlcont.DataSource = Consultar("SELECT * FROM CONTRIBUYENTE");
            ddlproduct.DataSource = tabla;
            ddlproduct.DataTextField = "TIPO";
            ddlproduct.DataValueField = "ID_T_PRO";
            ddlproduct.DataBind();
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Label2.Text = ComboBox1.SelectedValue.ToString();
            OracleCommand comando = new OracleCommand("SELECT nombre_c, cantidad, peso, fecha_entrega, fecha_pedido, descripcion, contribuyente_id_cont, pais_id_pais, tipo_producto_id_t_pro FROM IMPORTACION WHERE ID_IMP = " + Label2.Text, ora);
            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            GridView1.DataSource = tabla;
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Text = ddlcont.SelectedValue.ToString();
            Label3.Text = ddlpais.SelectedValue.ToString();
            Label4.Text = ddlproduct.SelectedValue.ToString();
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand actualizar = new OracleCommand("UPDATE IMPORTACION SET nombre_c ='" + txtnombre.Text + "',cantidad='" + txtcantidad.Text + "',peso='" + txtpeso.Text + "',fecha_entrega='" + txtfechae.Text + "',fecha_pedido='" + txtfechap.Text + "',descripcion='" + txtdescrip.Text + "',contribuyente_id_cont='" + Label1.Text  + "',pais_id_pais='"  + Label3.Text + "',tipo_producto_id_t_pro='" + Label4.Text + "' WHERE ID_IMP ='" + Label2.Text + "'", ora);
                OracleDataAdapter dtaa = new OracleDataAdapter();
                dtaa.UpdateCommand = actualizar;
                dtaa.UpdateCommand.ExecuteNonQuery();
                Response.Write("<script LANGUAGE='JavaScript' >alert('Modificado correctamente')</script>");
            }
            catch
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Error al modificar')</script>");
            }
        }
    }
}