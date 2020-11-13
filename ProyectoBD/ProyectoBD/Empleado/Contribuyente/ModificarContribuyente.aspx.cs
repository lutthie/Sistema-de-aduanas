using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OracleClient;

namespace ProyectoBD.Empleado.Contribuyente
{
    public partial class ModificarContribuyente : System.Web.UI.Page
    {
        OracleConnection ora = new OracleConnection("DATA SOURCE = xe; PASSWORD = 123; USER ID = LU;");
        protected void Page_Load(object sender, EventArgs e)
        {
            ora.Open();
            if (!IsPostBack)
            {
                Combo2();
            }
        }
        private void Combo2()
        {
            string cadena = "SELECT * FROM CONTRIBUYENTE";
            OracleCommand comando = new OracleCommand(cadena, ora);
            OracleDataAdapter adaptador = new OracleDataAdapter(comando);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            //ddlcont.DataSource = Consultar("SELECT * FROM CONTRIBUYENTE");
            ComboBox1.DataSource = tabla;
            ComboBox1.DataTextField = "NOMBRE_CONT";
            ComboBox1.DataValueField = "ID_CONT";
            ComboBox1.DataBind();
        }

        protected void btnbuscar_Click(object sender, EventArgs e)
        {
            Label2.Text = ComboBox1.SelectedValue.ToString();
            OracleCommand comando = new OracleCommand("SELECT nombre_cont, apellido_cont, telefono, correo_electronico, direccion, nit, descripcion FROM CONTRIBUYENTE WHERE ID_CONT = " + Label2.Text, ora);
            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            GridView1.DataSource = tabla;
            GridView1.DataBind();
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand actualizar = new OracleCommand("UPDATE CONTRIBUYENTE SET nombre_cont ='" + txtnombre.Text + "',apellido_cont='" + txtapellido.Text + "',telefono='" + txttelefono.Text + "',correo_electronico='" + txtcorreo.Text + "',direccion='" + txtdireccion.Text + "',nit='" + txtnit.Text + "',descripcion='" + txtdescrip.Text + "' WHERE ID_CONT ='" + Label2.Text + "'", ora);
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