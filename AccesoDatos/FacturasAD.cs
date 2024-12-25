using System;
using System.Collections.Generic;
using System.Data;
using facturasXML.EntidadNegocio;
using Oracle.DataAccess.Client;

namespace facturasXML.AccesoDatos
{
  /// <summary>
  /// Clase para acceso a datos de facturas.
  /// </summary>
  public class FacturasAD
  {
    private readonly string _connectionString;

    /// <summary>
    /// Constructor para inicializar la cadena de conexión.
    /// </summary>
    public FacturasAD()
    {
      _connectionString = System.Configuration.ConfigurationManager.AppSettings["OracleDB"];
    }

    /// <summary>
    /// Obtiene una factura desde la base de datos por el ID de la orden.
    /// </summary>
    /// <param name="orderId">ID de la orden.</param>
    /// <returns>Una instancia de la factura o null si no se encuentra.</returns>
    public Factura GetFacturaByOrderId(int orderId)
    {
      Factura factura = null;

      using (var connection = new OracleConnection(_connectionString))
      {
        connection.Open();
        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM INVOICES WHERE ORDER_ID = :OrderId";
        command.Parameters.Add(new OracleParameter("OrderId", orderId));

        using (var reader = command.ExecuteReader())
        {
          if (reader.Read())
          {
            factura = MapFactura(reader);
          }
        }
      }

      return factura;
    }

    /// <summary>
    /// Mapea los datos del lector a una instancia de Factura.
    /// </summary>
    /// <param name="reader">Lector de datos de Oracle.</param>
    /// <returns>Una instancia de Factura.</returns>
    private Factura MapFactura(IDataReader reader)
    {
      var factura = new Factura
      {
        Cabecera = new Cabecera
        {
          NitEmisor = reader["NIT_EMISOR"].ToString(),
          RazonSocialEmisor = reader["RAZON_SOCIAL_EMISOR"].ToString(),
          Municipio = reader["MUNICIPIO"].ToString(),
          Telefono = reader["TELEFONO"].ToString(),
          NumeroFactura = reader["NUMERO_FACTURA"].ToString(),
          Cuf = reader["CUF"].ToString(),
          Cufd = reader["CUFD"].ToString(),
          CodigoSucursal = Convert.ToInt32(reader["CODIGO_SUCURSAL"]),
          Direccion = reader["DIRECCION"].ToString(),
          CodigoPuntoVenta = Convert.ToInt32(reader["CODIGO_PUNTO_VENTA"]),
          FechaEmision = Convert.ToDateTime(reader["FECHA_EMISION"]),
          NombreRazonSocial = reader["NOMBRE_RAZON_SOCIAL"].ToString(),
          CodigoTipoDocumentoIdentidad = Convert.ToInt32(reader["CODIGO_TIPO_DOCUMENTO_IDENTIDAD"]),
          NumeroDocumento = reader["NUMERO_DOCUMENTO"].ToString(),
          Complemento = reader["COMPLEMENTO"] as string,
          CodigoCliente = reader["CODIGO_CLIENTE"] as string
        },
        Detalle = GetDetallesFactura(Convert.ToInt32(reader["ID"]))
      };

      return factura;
    }

    /// <summary>
    /// Obtiene los detalles de una factura desde la base de datos.
    /// </summary>
    /// <param name="facturaId">ID de la factura.</param>
    /// <returns>Lista de detalles de factura.</returns>
    private List<Detalle> GetDetallesFactura(int facturaId)
    {
      var detalles = new List<Detalle>();

      using (var connection = new OracleConnection(_connectionString))
      {
        connection.Open();
        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM INVOICE_DETAILS WHERE INVOICE_ID = :InvoiceId";
        command.Parameters.Add(new OracleParameter("InvoiceId", facturaId));

        using (var reader = command.ExecuteReader())
        {
          while (reader.Read())
          {
            var detalle = new Detalle
            {
              ActividadEconomica = reader["ACTIVIDAD_ECONOMICA"].ToString(),
              CodigoProductoSin = reader["CODIGO_PRODUCTO_SIN"].ToString(),
              CodigoProducto = reader["CODIGO_PRODUCTO"].ToString(),
              Descripcion = reader["DESCRIPCION"].ToString(),
              Cantidad = Convert.ToDecimal(reader["CANTIDAD"]),
              UnidadMedida = Convert.ToInt32(reader["UNIDAD_MEDIDA"]),
              PrecioUnitario = Convert.ToDecimal(reader["PRECIO_UNITARIO"]),
              MontoDescuento = reader["MONTO_DESCUENTO"] as decimal?,
              SubTotal = Convert.ToDecimal(reader["SUB_TOTAL"])
            };

            detalles.Add(detalle);
          }
        }
      }

      return detalles;
    }
  }
}
