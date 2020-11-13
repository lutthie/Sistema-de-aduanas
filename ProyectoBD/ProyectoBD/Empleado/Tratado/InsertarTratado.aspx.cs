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
    public partial class InsertarTratado : System.Web.UI.Page
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
            string cadena = "SELECT * FROM ADUANA";
            OracleCommand comando = new OracleCommand(cadena, ora);
            OracleDataAdapter adaptador = new OracleDataAdapter(comando);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            //ddlcont.DataSource = Consultar("SELECT * FROM CONTRIBUYENTE");
            ddladu.DataSource = tabla;
            ddladu.DataTextField = "UBICACION";
            ddladu.DataValueField = "ID_ADU";
            ddladu.DataBind();
        }
        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand insertar = new OracleCommand("INSERT INTO TRATADO VALUES ('" + TextBox1.Text + "','" + txtnombre.Text + "','" + txtdescrip.Text + "','" + txtfechae.Text + "','" + Label1.Text + "')", ora);
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Text = ddladu.SelectedValue.ToString();
        }
    }
}