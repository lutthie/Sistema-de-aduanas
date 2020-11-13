using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OracleClient;

namespace ProyectoBD.Empleado.Tratado
{
    public partial class ModificarTratado : System.Web.UI.Page
    {
        OracleConnection ora = new OracleConnection("DATA SOURCE = xe; PASSWORD = 123; USER ID = LU;");
        protected void Page_Load(object sender, EventArgs e)
        {
            ora.Open();
            if (!IsPostBack)
            {
                ComboTratado();
                ComboAduana();
            }
        }
        private void ComboTratado()
        {
            string cadena = "SELECT * FROM TRATADO";
            OracleCommand comando = new OracleCommand(cadena, ora);
            OracleDataAdapter adaptador = new OracleDataAdapter(comando);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            ComboBox1.DataSource = tabla;
            ComboBox1.DataTextField = "NOMBRE";
            ComboBox1.DataValueField = "ID_TRATADO";
            ComboBox1.DataBind();
        }
        private void ComboAduana()
        {
            string cadena = "SELECT * FROM ADUANA";
            OracleCommand comando = new OracleCommand(cadena, ora);
            OracleDataAdapter adaptador = new OracleDataAdapter(comando);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            ddladuana.DataSource = tabla;
            ddladuana.DataTextField = "UBICACION";
            ddladuana.DataValueField = "ID_ADU";
            ddladuana.DataBind();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Text = ddladuana.SelectedValue.ToString();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Label2.Text = ComboBox1.SelectedValue.ToString();
            OracleCommand comando = new OracleCommand("SELECT nombre, descripcion, fecha_emision, aduana_id_adu FROM TRATADO WHERE ID_TRATADO = " + Label2.Text, ora);
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
                OracleCommand actualizar = new OracleCommand("UPDATE TRATADO SET nombre ='" + txtnombre.Text + "',descripcion='" + txtdescrip.Text + "',fecha_emision='" + txtfechae.Text + "',aduana_id_adu='" + Label1.Text + "' WHERE ID_TRATADO ='" + Label1.Text + "'", ora);
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