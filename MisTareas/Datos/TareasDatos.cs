using MisTareas.Models;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Http.HttpResults;

namespace MisTareas.Datos
{
    public class TareasDatos
    {
        public List<TareasModel> listarTareas()
        {
            var listaTareas = new List<TareasModel>();
            var conn = new Conexion();

            using (var conexion = new SqlConnection(conn.GetCadenaSQL())){
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_listar_tareas", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        listaTareas.Add(new TareasModel() {
                            idTarea = Convert.ToInt32(dr["idTarea"]),
                            fecha = dr["fecha"].ToString(),
                            descripcion = dr["descripcion"].ToString(),
                            estado = dr["estado"].ToString()
                        }) ;
                    }
                }

                return listaTareas;
            }
        }

        public  TareasModel obtenerTarea(int idTarea)
        {
            var resultTarea = new TareasModel();
            var conn = new Conexion();

            using (var conexion = new SqlConnection(conn.GetCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_obtener_tarea", conexion);
                cmd.Parameters.AddWithValue("idTarea",idTarea);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        resultTarea.idTarea = Convert.ToInt32(dr["idTarea"]);
                        resultTarea.descripcion = dr["descripcion"].ToString();
                    }
                }

                return resultTarea;
            }
        }

        public bool crearTarea(TareasModel objTarea)
        {
            bool resp;

            try
            {

                var conn = new Conexion();

                using (var conexion = new SqlConnection(conn.GetCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_crear_tarea", conexion);
                    cmd.Parameters.AddWithValue("descripcion", objTarea.descripcion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();

                }

                resp = true;

            }
            catch(Exception e){
                string error = e.Message;
                resp = false;
            }

            return resp;
        }

        public bool modificarTarea(TareasModel objTarea)
        {
            bool resp;

            try
            {

                var conn = new Conexion();

                using (var conexion = new SqlConnection(conn.GetCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_modificar_tarea", conexion);
                    cmd.Parameters.AddWithValue("idTarea", objTarea.idTarea);
                    cmd.Parameters.AddWithValue("descripcion", objTarea.descripcion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();

                }

                resp = true;

            }
            catch (Exception e)
            {
                string error = e.Message;
                resp = false;
            }

            return resp;
        }

        public bool eliminarTarea(int idTarea)
        {
            bool resp;

            try
            {

                var conn = new Conexion();

                using (var conexion = new SqlConnection(conn.GetCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_anular_tarea", conexion);
                    cmd.Parameters.AddWithValue("idTarea", idTarea);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();

                }

                resp = true;

            }
            catch (Exception e)
            {
                string error = e.Message;
                resp = false;
            }

            return resp;
        }
    }
}
