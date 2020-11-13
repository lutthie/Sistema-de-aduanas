using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OracleClient;

namespace ProyectoBD.Empleado.Factura
{
    public partial class SemaforoFactura : System.Web.UI.Page
    {
        OracleConnection ora = new OracleConnection("DATA SOURCE = xe; PASSWORD = 123; USER ID = LU;");
        private void PR_OFF()
        {
            semaforoimg.ImageUrl = "https://i.pinimg.com/originals/7c/69/44/7c69449d65842b804cf88ac59178a8e1.png";
        }
        private void PR_Rojo()
        {
            semaforoimg.ImageUrl = "https://i.pinimg.com/originals/9f/3f/fc/9f3ffc84c3e7016b817dbbdada7e03a4.png";
        }
        private void PR_Ved()
        {
            semaforoimg.ImageUrl = "https://i.pinimg.com/originals/66/54/e5/6654e5de9d37971f48dda9b58e8cb6c3.png";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ora.Open();
            PR_OFF();
            if (!IsPostBack)
            {
                Combobox1();
            }
        }
        private void Combobox1()
        {
            string cadena = "SELECT * FROM IMPORTACION";
            OracleCommand comando = new OracleCommand(cadena, ora);
            OracleDataAdapter adaptador = new OracleDataAdapter(comando);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            //ddlcont.DataSource = Consultar("SELECT * FROM CONTRIBUYENTE");
            ddlimp.DataSource = tabla;
            ddlimp.DataTextField = "NOMBRE_C";
            ddlimp.DataValueField = "ID_IMP";
            ddlimp.DataBind();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Text = ddlimp.SelectedValue.ToString();
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            int cantidad = Convert.ToInt32(txtcantidad.Text);
            int produc = Convert.ToInt32(txtprecio.Text);
            double impuesto = Convert.ToDouble(txtimpuesto.Text);
            int total1 = cantidad * produc;
            double total = total1 + impuesto;
            txttotal.Text = Convert.ToString(total);
            try
            {
                OracleCommand insertar = new OracleCommand("INSERT INTO FACTURA VALUES ('" + TextBox1.Text + "','" + txtnit.Text + "','" + txtnombre.Text + "','" + txtpais.Text + "','" + txtdescrip.Text + "','" + txtproduc.Text + "','" + txtcantidad.Text + "','" + txtprecio.Text + "','" + txtimpuesto.Text + "','" + txttotal.Text + "','" + Label1.Text + "')", ora);
                OracleDataAdapter gtss = new OracleDataAdapter();
                gtss.InsertCommand = insertar;
                gtss.InsertCommand.ExecuteNonQuery();
                PR_Ved();
                Response.Write("<script LANGUAGE='JavaScript' >alert('Guardado correctamente')</script>");
            }
            catch (Exception ex)
            {
                PR_Rojo();
                Response.Write("<script LANGUAGE='JavaScript' >alert('Error al guardar')</script>");
            }
        }
    }
}