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
                            idTareas = Convert.ToInt32(dr["idTarea"]),
                            fecha = dr["fecha"].ToString(),
                            descripcion = dr["descripcion"].ToString(),
                            estado = Convert.ToInt32(dr["estado"]),
                            createdAt = dr["createdAt"].ToString(),
                            updatedAt = dr["updatedAt"].ToString()

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
                        resultTarea.idTareas = Convert.ToInt32(dr["idTarea"]);
                        resultTarea.fecha = dr["fecha"].ToString();
                        resultTarea.descripcion = dr["descripcion"].ToString();
                        resultTarea.estado = Convert.ToInt32(dr["estado"]);
                        resultTarea.createdAt = dr["createdAt"].ToString();
                        resultTarea.updatedAt = dr["updatedAt"].ToString();
                    }
                }

                return resultTarea;
            }
        }

    }
}
