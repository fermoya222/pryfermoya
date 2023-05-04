using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace pryfermoya
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // declaracion de variables para este formulario
        OleDbConnection conn = null;
        OleDbCommand cmd = null;
        OleDbDataReader LectorBD = null;

        private void btnConeccion_Click(object sender, EventArgs e)
        {
            conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=biblio.accdb;");
            conn.Open();

            MessageBox.Show("se conectooooo");

        }

        private void btnLeerTabla_Click(object sender, EventArgs e)
        {
            cmd = new OleDbCommand();

            cmd.Connection = conn;
            cmd.CommandType = CommandType.TableDirect;
            cmd.CommandText = "TITULO";

            MessageBox.Show("Conexion a " + cmd.CommandText, "mensaje de conexion");
            
            LectorBD = cmd.ExecuteReader();

            while (LectorBD.Read()) 
            {
                dgvDatos.Rows.Add(LectorBD[0]);
            }

        }
    }
}
