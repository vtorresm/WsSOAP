using System.Collections.Generic;
using System.Data.SqlClient;
using WsSOAP.Domain;

namespace WsSOAP.Persintence
{
    public class PeliculaDAO
    {
        //private string CadenaConexion = "Data Source=(local);Initial Catalog=DBCine;Trusted_Connection=True;";
        private string CadenaConexion = "Server=(localdb)\\MSSQLLocalDB;Database=DBCine;Trusted_Connection=True;MultipleActiveResultSets=true";
        

        public Pelicula Crear(Pelicula peliculaACrear)
        {
            Pelicula peliculaCreado = null;
            string sql = "Insert into pelicula values(@titulo, @duracion, @genero, @clasificacion, @formato, @estado)";

            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@idPelicula", peliculaACrear.idPelicula));
                    comando.Parameters.Add(new SqlParameter("@titulo", peliculaACrear.titulo));
                    comando.Parameters.Add(new SqlParameter("@duracion", peliculaACrear.duracion));
                    comando.Parameters.Add(new SqlParameter("@genero", peliculaACrear.genero));
                    comando.Parameters.Add(new SqlParameter("@clasificacion", peliculaACrear.clasificacion));
                    comando.Parameters.Add(new SqlParameter("@formato", peliculaACrear.formato));
                    comando.Parameters.Add(new SqlParameter("@estado", peliculaACrear.estado));
                    comando.ExecuteNonQuery();
                }
            }
            peliculaCreado = Obtener(peliculaACrear.idPelicula);
            return peliculaCreado;
        }

        public Pelicula Obtener(int idPelicula)
        {
            Pelicula peliculaEncontrado = null;
            string sql = "SELECT * FROM Pelicula WHERE genero = @idPelicula";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@idPelicula", idPelicula));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            peliculaEncontrado = new Pelicula
                            {
                                idPelicula = (int)resultado["idPelicula"],
                                titulo = (string)resultado["titulo"],
                                duracion = (string)resultado["duracion"],
                                genero = (string)resultado["genero"],
                                clasificacion = (string)resultado["clasificacion"],
                                formato = (string)resultado["formato"],
                                estado = (string)resultado["estado"]
                            };
                        }
                    }
                }
            }
            return peliculaEncontrado;
        }

        public Pelicula Modificar(Pelicula peliculaAModificar)
        {
            Pelicula peliculaModificado = null;
            var sql = "update pelicula set titulo = @titulo, duracion = @duracion, genero = @genero, clasificacion = @clasificacion, formato = @formato where idPelicula = @idPelicula";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@titulo", peliculaAModificar.titulo));
                    comando.Parameters.Add(new SqlParameter("@duracion", peliculaAModificar.duracion));
                    comando.Parameters.Add(new SqlParameter("@genero", peliculaAModificar.genero));
                    comando.Parameters.Add(new SqlParameter("@clasificacion", peliculaAModificar.clasificacion));
                    comando.Parameters.Add(new SqlParameter("@formato", peliculaAModificar.formato));
                    comando.ExecuteNonQuery();
                }
            }
            peliculaModificado = Obtener(peliculaAModificar.idPelicula);
            return peliculaModificado;
        }

        public void Eliminar(int id)
        {
            var sql = "DELETE FROM pelicula WHERE idPelicula = @idPelicula";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@idPelicula", id));
                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<Pelicula> Listar()
        {
            List<Pelicula> peliculasEncontrados = new List<Pelicula>();
            Pelicula peliculaEncontrado = null;
            var sql = "SELECT * FROM pelicula";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            peliculaEncontrado = new Pelicula()
                            {
                                idPelicula = (int)resultado["idPelicula"],
                                titulo = (string)resultado["titulo"],
                                duracion = (string)resultado["duracion"],
                                genero = (string)resultado["genero"],
                                clasificacion = (string)resultado["clasificacion"],
                                formato = (string)resultado["formato"],
                                estado = (string)resultado["estado"]
                            };

                            peliculasEncontrados.Add(peliculaEncontrado);
                        }
                    }
                }
                return peliculasEncontrados;
            }
        }


    }
}