using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OracleClient;

namespace ProyectoBD.Empleado.Importación
{
      public partial class MostrarImportación : System.Web.UI.Page
    {
        OracleConnection ora = new OracleConnection("DATA SOURCE = xe; PASSWORD = 123; USER ID = LU;");
        protected void Page_Load(object sender, EventArgs e)
        {
            ora.Open();
            OracleCommand comando = new OracleCommand("SELECT nombre_c, cantidad, peso, fecha_entrega, fecha_pedido, contribuyente_id_cont, pais_id_pais, tipo_producto_id_t_pro FROM IMPORTACION", ora);
            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dataGridView1.DataSource = tabla;
            dataGridView1.DataBind();
        }

        protected void Unnamed1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}