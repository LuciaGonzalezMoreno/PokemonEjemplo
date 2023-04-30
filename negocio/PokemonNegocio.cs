using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
//agregar el using del otro proyecto
using Dominio;


namespace negocio
{
    public class PokemonNegocio
    {   //clase en la que voy a crear metodos para acecder a la base de datos
        //cada clase va a tener su clase de negocio de acceso a datos

        //lee registros en la base de datos
        public List<Pokemon> listar()
        {
            List<Pokemon> lista = new List<Pokemon>();
            SqlConnection conexion = new SqlConnection();

            //lo que me va a permitir realizar acciones
            SqlCommand comando = new SqlCommand();

            //donde se van a alojar los datos
            SqlDataReader lector;

            try
            {
                //configuracion de la cadena de conexion
                //motor de base de datos, si fuece remoto iria la IP.....
                //tmb funciona server=DESKTOP-I5\\SQLEXPRESS o server=(local)\\SQLEXPRESS
                //a donde me voy a conectar; a que base de datos quiero conectar; como me voy a conectar
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=POKEDEX_DB; integrated security=true";

                //comando para realizar la accion
                //3 tipos:Text(voy a inyectar una sentencia SQL)
                //        StoredProcedure(Peticion para que ejecute una funcion guardada en la BD)
                //        TableDirect
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select Numero, Nombre, P.Descripcion, UrlImagen, E.Descripcion Tipo, D.Descripcion Debilidad  from POKEMONS P, ELEMENTOS E, ELEMENTOS D  WHERE E.Id = P.IdTipo  AND D.Id = P.IdDebilidad"; //el texto es la consulta SQL
                comando.Connection = conexion; //donde se va a ejecutar el comando

                conexion.Open();
                lector = comando.ExecuteReader(); //ejecuto la lectura

                while(lector.Read()) //si hay una lectura me va a posicionar el puntero en la primer fila
                {
                    Pokemon aux = new Pokemon();
                    aux.Numero = lector.GetInt32(0); //le doy el indice en la tabla
                    aux.Nombre = (string)lector["Nombre"]; //le paso el nombr de la columna
                    aux.Descripcion = (string)lector["Descripcion"];
                    aux.UrlImagen = (string)lector["UrlImagen"];
                    aux.Tipo = new Elemento();
                    aux.Tipo.Descripcion = (string)lector["Tipo"];
                    aux.Debilidad = new Elemento();
                    aux.Debilidad.Descripcion = (string)lector["Debilidad"];

                    lista.Add(aux);
                }

                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void agregar(Pokemon nuevo)
        {
            
        }

        public void modificar(Pokemon modificar)
        {

        }
    }
}
