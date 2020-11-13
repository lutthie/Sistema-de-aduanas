using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OracleClient;

namespace ProyectoBD.Empleado.Producto
{
    public partial class ModificarProducto : System.Web.UI.Page
    {
        OracleConnection ora = new OracleConnection("DATA SOURCE = xe; PASSWORD = 123; USER ID = LU;");
        protected void Page_Load(object sender, EventArgs e)
        {
            ora.Open();
            if (!IsPostBack)
            {
                ComboPro();
                ComboTipo();
            }
        }
        private void ComboPro()
        {
            string cadena = "SELECT * FROM PRODUCTO";
            OracleCommand comando = new OracleCommand(cadena, ora);
            OracleDataAdapter adaptador = new OracleDataAdapter(comando);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            ComboBox1.DataSource = tabla;
            ComboBox1.DataTextField = "NOMBRE";
            ComboBox1.DataValueField = "ID_PRODUCTO";
            ComboBox1.DataBind();
        }
        private void ComboTipo()
        {
            string cadena = "SELECT * FROM TIPO_PRODUCTO";
            OracleCommand comando = new OracleCommand(cadena, ora);
            OracleDataAdapter adaptador = new OracleDataAdapter(comando);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            ddltipo.DataSource = tabla;
            ddltipo.DataTextField = "TIPO";
            ddltipo.DataValueField = "ID_T_PRO";
            ddltipo.DataBind();
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Label2.Text = ComboBox1.SelectedValue.ToString();
            OracleCommand comando = new OracleCommand("SELECT nombre, descripcion, tipo, tipo_producto_id_t_pro FROM PRODUCTO WHERE ID_PRODUCTO = " + Label2.Text, ora);
            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            GridView1.DataSource = tabla;
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Text = ddltipo.SelectedValue.ToString();
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand actualizar = new OracleCommand("UPDATE PRODUCTO SET nombre='" + txtnombre.Text + "',descripcion='" + txtdescrip.Text + "',tipo='" + TextBox2.Text + "',tipo_producto_id_t_pro='" + Label1.Text + "' WHERE ID_PRODUCTO ='" + Label2.Text + "'", ora);
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