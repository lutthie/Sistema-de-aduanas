using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OracleClient;

namespace ProyectoBD.Empleado.Aduana
{
    public partial class ModificarAduana : System.Web.UI.Page
    {
        OracleConnection ora = new OracleConnection("DATA SOURCE = xe; PASSWORD = 123; USER ID = LU;");
        protected void Page_Load(object sender, EventArgs e)
        {
            ora.Open();
            if (!IsPostBack)
            {
                Combo1();
                Combo2();
            }
        }
        private void Combo1()
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
        private void Combo2()
        {
            string cadena = "SELECT * FROM ADUANA";
            OracleCommand comando = new OracleCommand(cadena, ora);
            OracleDataAdapter adaptador = new OracleDataAdapter(comando);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            //ddlcont.DataSource = Consultar("SELECT * FROM CONTRIBUYENTE");
            ComboBox1.DataSource = tabla;
            ComboBox1.DataTextField = "UBICACION";
            ComboBox1.DataValueField = "ID_ADU";
            ComboBox1.DataBind();
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Label2.Text = ComboBox1.SelectedValue.ToString();
            OracleCommand comando = new OracleCommand("SELECT ubicacion, impuesto, tipo, descripcion, pais_id_pais FROM ADUANA WHERE ID_ADU = " + Label2.Text, ora);
            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            GridView1.DataSource = tabla;
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Text = ddlpais.SelectedValue.ToString();
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand actualizar = new OracleCommand("UPDATE ADUANA SET ubicacion ='" + txtubicacion.Text + "',impuesto='" + txtimpuesto.Text + "',tipo='" + txttipo.Text + "',descripcion='" + txtdescrip.Text + "',pais_id_pais='" + Label1.Text + "' WHERE ID_ADU ='" + Label2.Text + "'", ora);
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