using System;
using System.Xml.Serialization;

namespace facturasXML.EntidadNegocio
{
  /// <summary>
  /// Clase que representa un detalle de la factura
  /// </summary>
  [Serializable]
  public class Detalle
  {
    [XmlElement(ElementName = "actividadEconomica")]
    public string ActividadEconomica { get; set; }

    [XmlElement(ElementName = "codigoProductoSin")]
    public string CodigoProductoSin { get; set; }

    [XmlElement(ElementName = "codigoProducto")]
    public string CodigoProducto { get; set; }

    [XmlElement(ElementName = "descripcion")]
    public string Descripcion { get; set; }

    [XmlElement(ElementName = "cantidad")]
    public decimal Cantidad { get; set; }

    [XmlElement(ElementName = "unidadMedida")]
    public int UnidadMedida { get; set; }

    [XmlElement(ElementName = "precioUnitario")]
    public decimal PrecioUnitario { get; set; }

    [XmlElement(ElementName = "montoDescuento")]
    public decimal? MontoDescuento { get; set; }

    [XmlElement(ElementName = "subTotal")]
    public decimal SubTotal { get; set; }
  }
}
