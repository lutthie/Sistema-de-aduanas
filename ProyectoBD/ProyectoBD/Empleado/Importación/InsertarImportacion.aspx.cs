using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;
using System.Data;
using System.Windows;

namespace ProyectoBD.Empleado.Importación
{
    public partial class InsertarImportacion : System.Web.UI.Page
    {
        OracleConnection ora = new OracleConnection("DATA SOURCE = xe; PASSWORD = 123; USER ID = LU;");
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ora.Open();
                //Label4.Text = "Conectado";
                if (!IsPostBack)
                {
                    Combobox1();
                    Combobox2();
                    Combobox3();
                }
            }
            catch(Exception ex)
            {
                //Label4.Text = "Error";
            }
        }

        private void Combobox1()
        {
            string cadena = "SELECT * FROM CONTRIBUYENTE";
            OracleCommand comando = new OracleCommand(cadena, ora);
            OracleDataAdapter adaptador = new OracleDataAdapter(comando);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            //ddlcont.DataSource = Consultar("SELECT * FROM CONTRIBUYENTE");
            ddlcont.DataSource = tabla;
            ddlcont.DataTextField = "NOMBRE_CONT";
            ddlcont.DataValueField = "ID_CONT";
            ddlcont.DataBind();
        }

        private void Combobox2()
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

        private void Combobox3()
        {
            string cadena = "SELECT * FROM TIPO_PRODUCTO";
            OracleCommand comando = new OracleCommand(cadena, ora);
            OracleDataAdapter adaptador = new OracleDataAdapter(comando);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            //ddlcont.DataSource = Consultar("SELECT * FROM CONTRIBUYENTE");
            ddlproducid.DataSource = tabla;
            ddlproducid.DataTextField = "TIPO";
            ddlproducid.DataValueField = "ID_T_PRO";
            ddlproducid.DataBind();
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand insertar = new OracleCommand("INSERT INTO IMPORTACION VALUES ('" + TextBox1.Text + "','" + txtcantidad.Text + "','" + txtpeso.Text + "','" + txtfechae.Text + "','" + txtfechape.Text + "','" + txtdescrip.Text + "','" + lblCont.Text + "','" + lblpais.Text + "','" + lblproduc.Text + "','" + txtnombre.Text + "')", ora);
                OracleDataAdapter dtaa = new OracleDataAdapter();
                dtaa.InsertCommand = insertar;
                dtaa.InsertCommand.ExecuteNonQuery();
                Response.Write("<script LANGUAGE='JavaScript' >alert('Guardado correctamente')</script>");
            }
            catch(Exception ex)
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Error al guardar')</script>");
            }
        }
        protected void ddlcont_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblCont.Text = ddlcont.SelectedItem.ToString();
        }
        public DataSet Consultar(string strSQL)
        {
            string conn = "DATA SOURCE = xe; PASSWORD = 123; USER ID = LU;";
            OracleConnection con = new OracleConnection(conn);
            con.Open();
            OracleCommand cmd = new OracleCommand(strSQL, con);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            return ds;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            lblCont.Text = ddlcont.SelectedValue.ToString();
            lblpais.Text = ddlpais.SelectedValue.ToString();
            lblproduc.Text = ddlproducid.SelectedValue.ToString();
        }
    }
}