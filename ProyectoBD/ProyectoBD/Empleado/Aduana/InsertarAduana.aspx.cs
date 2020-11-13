using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;
using System.Data;

namespace ProyectoBD.Empleado.Aduana
{
    public partial class InsertarAduana : System.Web.UI.Page
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

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand insertar = new OracleCommand("INSERT INTO ADUANA VALUES ('" + TextBox1.Text + "','" + txtubicacion.Text + "','" + txtimpuesto.Text + "','" + txttipo.Text + "','" + txtdescrip.Text + "','" + Label1.Text + "')", ora);
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
        private void Combobox1()
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
        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Text = ddlpais.SelectedValue.ToString();
        }
    }
}