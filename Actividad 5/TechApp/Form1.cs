using System;
using System.Drawing;
using System.Windows.Forms;
using TechApp.Models;
using TechApp.Controllers;

namespace TechApp
{
    public partial class Form1 : Form
    {
        // Se declaran como nullable para evitar CS8618
        private TextBox? txtNombre, txtMarca, txtPrecio, txtStock;
        private Button? btnGuardar; 
        private DataGridView? dgvDatos;
        private EquipoController _controller;

        public Form1()
        {
            _controller = new EquipoController();
            ConfigurarComponentes();
            CargarGrid();
        }

        private void ConfigurarComponentes()
        {
            this.Text = "Laboratorio CRUD C#";
            this.Size = new Size(600, 500);

            txtNombre = new TextBox { Location = new Point(120, 20), Size = new Size(200, 25) };
            this.Controls.Add(new Label { Text = "Nombre:", Location = new Point(20, 20) });
            this.Controls.Add(txtNombre);

            txtMarca = new TextBox { Location = new Point(120, 50), Size = new Size(200, 25) };
            this.Controls.Add(new Label { Text = "Marca:", Location = new Point(20, 50) });
            this.Controls.Add(txtMarca);

            txtPrecio = new TextBox { Location = new Point(120, 80), Size = new Size(100, 25) };
            this.Controls.Add(new Label { Text = "Precio:", Location = new Point(20, 80) });
            this.Controls.Add(txtPrecio);

            txtStock = new TextBox { Location = new Point(120, 110), Size = new Size(100, 25) };
            this.Controls.Add(new Label { Text = "Stock:", Location = new Point(20, 110) });
            this.Controls.Add(txtStock);

            btnGuardar = new Button { Text = "Guardar", Location = new Point(120, 150) };
            btnGuardar.Click += BtnGuardar_Click;
            this.Controls.Add(btnGuardar);

            dgvDatos = new DataGridView { Location = new Point(20, 200), Size = new Size(540, 250) };
            this.Controls.Add(dgvDatos);
        }

        // Ajuste de la firma para evitar CS8622
        private void BtnGuardar_Click(object? sender, EventArgs e)
        {
            try
            {
                var nuevoEquipo = new Equipo
                {
                    Nombre = txtNombre?.Text ?? string.Empty,
                    Marca = txtMarca?.Text ?? string.Empty,
                    Precio = decimal.Parse(txtPrecio?.Text ?? "0"),
                    Stock = int.Parse(txtStock?.Text ?? "0")
                };

                _controller.InsertarEquipo(nuevoEquipo);
                MessageBox.Show("Datos guardados correctamente.");
                CargarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

        private void CargarGrid()
        {
            if (dgvDatos != null)
                dgvDatos.DataSource = _controller.ObtenerTodos();
        }
    }
}
