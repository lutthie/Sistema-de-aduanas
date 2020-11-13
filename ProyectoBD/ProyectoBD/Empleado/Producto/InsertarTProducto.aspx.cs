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
    public partial class InsertarTProducto : System.Web.UI.Page
    {
        OracleConnection ora = new OracleConnection("DATA SOURCE = xe; PASSWORD = 123; USER ID = LU;");
        protected void Page_Load(object sender, EventArgs e)
        {
            ora.Open();
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand insertar = new OracleCommand("INSERT INTO TIPO_PRODUCTO VALUES ('" + TextBox1.Text + "','" + txtnombrec.Text + "')", ora);
                OracleDataAdapter gtss = new OracleDataAdapter();
                gtss.InsertCommand = insertar;
                gtss.InsertCommand.ExecuteNonQuery();
                Response.Write("<script LANGUAGE='JavaScript' >alert('Guardado correctamente')</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Error al guardar')</script>");
            }
        }
    }
}