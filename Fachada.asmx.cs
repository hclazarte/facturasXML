using System;
using System.Collections.Generic;
using System.Web.Services;
using facturasXML.AccesoDatos;
using facturasXML.EntidadNegocio;
using System.Web.Services.Protocols;


namespace facturasXML
{
  /// <summary>
  /// Servicio web para gestionar facturas electrónicas.
  /// </summary>
  [WebService(Namespace = "http://tempuri.org/")]
  [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
  [System.ComponentModel.ToolboxItem(false)]
  public class WebServiceFacturas : WebService
  {
    /// <summary>
    /// Obtiene una colección de las últimas órdenes.
    /// </summary>
    /// <param name="cantidad">Número de órdenes a devolver.</param>
    /// <returns>Lista de las últimas órdenes en XML.</returns>
    [WebMethod]
    public List<Orden> GetUltimasOrdenes(int cantidad)
    {
      try
      {
        OrdenesAD _ordenesAd = new OrdenesAD();

        if (cantidad <= 0)
        {
          throw new ArgumentException("La cantidad debe ser un número positivo.");
        }

        var ordenes = _ordenesAd.GetUltimasOrdenes(cantidad);
        return ordenes;
      }
      catch (Exception ex)
      {
        throw new SoapException("Error al obtener las órdenes: " + ex.Message, SoapException.ClientFaultCode);
      }
    }
    /// <summary>
    /// Obtiene una factura completa (cabecera y detalle) por el ID de la orden.
    /// </summary>
    /// <param name="orderId">ID de la orden asociada a la factura.</param>
    /// <returns>Una instancia de Factura en XML.</returns>
    [WebMethod]
    public Factura GetFacturaByOrderId(int orderId)
    {
      try
      {
        FacturasAD _facturasAd = new FacturasAD();

        var factura = _facturasAd.GetFacturaByOrderId(orderId);
        if (factura == null)
        {
          throw new Exception($"No se encontró una factura asociada al ID de orden {orderId}.");
        }

        return factura;
      }
      catch (Exception ex)
      {
        throw new SoapException("Error al obtener la factura: " + ex.Message, SoapException.ClientFaultCode);
      }
    }

    /// <summary>
    /// Método de prueba para verificar la conectividad del servicio.
    /// </summary>
    /// <returns>Mensaje de saludo.</returns>
    [WebMethod]
    public string HelloWorld()
    {
      return "Hola a todos, el servicio de facturas está activo.";
    }
  }
}
