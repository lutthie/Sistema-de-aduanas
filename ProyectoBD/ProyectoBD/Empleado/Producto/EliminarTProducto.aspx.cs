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
    public partial class EliminarTProducto : System.Web.UI.Page
    {
        OracleConnection ora = new OracleConnection("DATA SOURCE = xe; PASSWORD = 123; USER ID = LU;");
        protected void Page_Load(object sender, EventArgs e)
        {
            ora.Open();
            if (!IsPostBack)
            {
                Combobox1();
            }
        }
        private void Combobox1()
        {
            string cadena = "SELECT * FROM TIPO_PRODUCTO";
            OracleCommand comando = new OracleCommand(cadena, ora);
            OracleDataAdapter adaptador = new OracleDataAdapter(comando);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            //ddlcont.DataSource = Consultar("SELECT * FROM CONTRIBUYENTE");
            DropDownList1.DataSource = tabla;
            DropDownList1.DataTextField = "TIPO";
            DropDownList1.DataValueField = "ID_T_PRO";
            DropDownList1.DataBind();
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Label1.Text = DropDownList1.SelectedValue.ToString();
            OracleCommand comando = new OracleCommand("SELECT tipo FROM TIPO_PRODUCTO WHERE ID_T_PRO = " + Label1.Text, ora);
            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dataGridView1.DataSource = tabla;
            dataGridView1.DataBind();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand eliminar = new OracleCommand("DELETE FROM TIPO_PRODUCTO WHERE ID_T_PRO ='" + Label1.Text + "'", ora);
                OracleDataAdapter dtaa = new OracleDataAdapter();
                dtaa.DeleteCommand = eliminar;
                dtaa.DeleteCommand.ExecuteNonQuery();
                Response.Write("<script LANGUAGE='JavaScript' >alert('Eliminado correctamente')</script>");
            }
            catch(Exception ex)
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('No se pudo eliminar')</script>");
            }
        }
    }
}