using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using negocio;

namespace winform_app
{
    public partial class Form1 : Form
    {
        private List<Pokemon> listaPokemon;
        public Form1()
        {
            InitializeComponent();
        }
        private void cargarImagen(string imagen)
        {
            try
            {
                pbPokemon.Load(imagen);
            }
            catch (Exception ex)
            {

                pbPokemon.Load("https://www.pngkey.com/png/detail/233-2332677_ega-png.png");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            listaPokemon = negocio.listar();

            //a la grilla de datos le voy a asignar, lo qe me traiga la lista de negocio
            //DataSourse: lee con una tecnica que se llama reflexion la estructura de la clase pokemon
            dgvPokemons.DataSource = listaPokemon;
            dgvPokemons.Columns["UrlImagen"].Visible = false;

            cargarImagen(listaPokemon[0].UrlImagen);
        }

        private void dgvPokemons_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Pokemon seleccionado = (Pokemon)dgvPokemons.CurrentRow.DataBoundItem;
            cargarImagen(seleccionado.UrlImagen);

            Elemento elem = new Elemento();                       
           }
    }
}
