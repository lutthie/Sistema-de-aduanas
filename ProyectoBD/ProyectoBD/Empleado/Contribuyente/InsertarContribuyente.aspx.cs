using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;
using System.Data;


namespace ProyectoBD.Empleado.Contribuyente
{
    public partial class InsertarContribuyente : System.Web.UI.Page
    {
        OracleConnection ora = new OracleConnection("DATA SOURCE = xe; PASSWORD = 123; USER ID = LU;");
        protected void Page_Load(object sender, EventArgs e)
        {
            ora.Open();
        }

        protected void txtnombrec_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand insertar = new OracleCommand("INSERT INTO CONTRIBUYENTE VALUES ('" + TextBox1.Text + "','" + txtnombrec.Text + "','" + txtapellido.Text + "','" + txttelefono.Text + "','" + txtcorreo.Text + "','" + txtdireccion.Text + "','" + txtnit.Text + "','" + txtdescrip.Text + "')", ora);
                OracleDataAdapter gtss = new OracleDataAdapter();
                gtss.InsertCommand = insertar;
                gtss.InsertCommand.ExecuteNonQuery();
                Response.Write("<script LANGUAGE='JavaScript' >alert('Guardado correctamente')</script>");
                Limpiar();
            }
            catch(Exception ex)
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Error al guardar')</script>");
                Limpiar();
            }
        }
        public void Limpiar()
        {
            txtnombrec.Text = "";
            txtapellido.Text = "";
            txttelefono.Text = "";
            txtcorreo.Text = "";
            txtdireccion.Text = "";
            txtnit.Text = "";
            txtdescrip.Text = "";
        }
    }
}