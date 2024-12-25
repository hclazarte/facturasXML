using System;
using System.Collections.Generic;
using System.Data;
using facturasXML.EntidadNegocio;
using Oracle.DataAccess.Client;

namespace facturasXML.AccesoDatos
{
  /// <summary>
  /// Clase de acceso a datos para las órdenes.
  /// </summary>
  public class OrdenesAD
  {
    private readonly string _connectionString;

    public OrdenesAD()
    {
      _connectionString = System.Configuration.ConfigurationManager.AppSettings["OracleDB"];
    }

    /// <summary>
    /// Obtiene las últimas órdenes desde la base de datos.
    /// </summary>
    /// <param name="numeroOrdenes">Cantidad de órdenes a devolver.</param>
    /// <returns>Lista de órdenes.</returns>
    public List<Orden> GetUltimasOrdenes(int numeroOrdenes)
    {
      var ordenes = new List<Orden>();

      using (var connection = new OracleConnection(_connectionString))
      {
        connection.Open();
        var command = connection.CreateCommand();
        command.CommandText = $@"
                    SELECT * 
                    FROM (SELECT * FROM ORDERS ORDER BY CREATED_AT DESC) 
                    WHERE ROWNUM <= :NumeroOrdenes";
        command.Parameters.Add(new OracleParameter("NumeroOrdenes", numeroOrdenes));

        using (var reader = command.ExecuteReader())
        {
          while (reader.Read())
          {
            var orden = new Orden
            {
              Id = Convert.ToInt32(reader["ID"]),
              ProfileId = Convert.ToInt32(reader["PROFILE_ID"]),
              Status = reader["STATUS"].ToString(),
              Total = Convert.ToDecimal(reader["TOTAL"]),
              CreatedAt = Convert.ToDateTime(reader["CREATED_AT"]),
              UpdatedAt = Convert.ToDateTime(reader["UPDATED_AT"])
            };

            ordenes.Add(orden);
          }
        }
      }

      return ordenes;
    }
  }
}
