using System.Data;
using System.Windows.Forms;

namespace AppCodigosPostalesCSharp
{
    public partial class Form1 : Form
    {
        private string query;
        private bool auto;
        public Form1()
        {
            auto = true;
            InitializeComponent();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            // Add any initialization after the InitializeComponent() call.
            // Create a new instance of the Connection class
            query = "select id, nombre from estado";
            cboEstado.DataSource = Connection.SelectQuery(query);
            cboEstado.DisplayMember = "nombre";
            cboEstado.ValueMember = "id";
            auto = false;
            FillComboBoxFiltrar();
            dataGridView1.ReadOnly = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void FillComboBoxFiltrar()
        {
            ComboBoxFiltrar.Items.Add("Nombre del Asentamiento");
            ComboBoxFiltrar.Items.Add("Código Postal");
            ComboBoxFiltrar.Items.Add("Tipo de Asentamiento");
        }


        private void cboMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cboMunicipio.Text))
            {
                return;
            }

            query = "select * from VnombreBUSQUEDA where [Nombre Municipio]='" + cboMunicipio.Text + "'";
            dataGridView1.DataSource = Connection.SelectQuery(query);
        }

        private void cboEstado_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (auto)
            {
                return;
            }

            query = "select id, nombre from municipio where idEstado=" + cboEstado.SelectedValue;
            cboMunicipio.DataSource = Connection.SelectQuery(query);
            cboMunicipio.DisplayMember = "nombre";
            cboMunicipio.ValueMember = "id";
        }

        private void ButtonBuscar_Click(object sender, EventArgs e)
        {
            string buscarTexto = TextBoxBuscar.Text.Trim();

            // Verificar si se ha seleccionado un filtro
            if (ComboBoxFiltrar.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione una opción de filtro.", "Filtro no seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string filtroSeleccionado = ComboBoxFiltrar.SelectedItem?.ToString();

            // Construir la consulta SQL basada en el filtro seleccionado y el ID del municipio
            string query = "";

            switch (filtroSeleccionado)
            {
                case "Nombre del Asentamiento":
                    query = "SELECT * FROM VnombreBUSQUEDA WITH (NOLOCK) WHERE [Nombre Asentamiento] LIKE '%" + buscarTexto + "%' AND [Nombre Municipio]='" + cboMunicipio.Text + "'";
                    break;
                case "Código Postal":
                    query = "SELECT * FROM VnombreBUSQUEDA WITH (NOLOCK) WHERE CodigoPostal LIKE '%" + buscarTexto + "%'";
                    break;
                case "Tipo de Asentamiento":
                    query = "SELECT * FROM VnombreBUSQUEDA WITH (NOLOCK) WHERE [Tipo de Asentamiento] LIKE '%" + buscarTexto + "%' AND [Nombre Municipio]='" + cboMunicipio.Text + "'";
                    break;
            }

            // Ejecutar la consulta SQL y mostrar los resultados en el DataGridView
            DataTable dt = Connection.SelectQuery(query);

            dataGridView1.DataSource = dt;
        }

        private void ComboBoxFiltrar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}