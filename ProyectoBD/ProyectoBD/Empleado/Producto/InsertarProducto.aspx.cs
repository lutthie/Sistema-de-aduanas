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
    public partial class InsertarProducto : System.Web.UI.Page
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
        protected void txtdescrip_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand insertar = new OracleCommand("INSERT INTO PRODUCTO VALUES ('" + TextBox1.Text + "','" + txtnombrep.Text + "','" + txtdescrip.Text + "','" + TextBox2.Text + "','" + Label1.Text + "')", ora);
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
            Label1.Text = DropDownList1.SelectedValue.ToString();
        }
    }
}