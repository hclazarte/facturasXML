using System;
using System.Xml.Serialization;

namespace facturasXML.EntidadNegocio
{
  /// <summary>
  /// Clase que representa la cabecera de una factura
  /// </summary>
  [Serializable]
  public class Cabecera
  {
    [XmlElement(ElementName = "nitEmisor")]
    public string NitEmisor { get; set; }

    [XmlElement(ElementName = "razonSocialEmisor")]
    public string RazonSocialEmisor { get; set; }

    [XmlElement(ElementName = "municipio")]
    public string Municipio { get; set; }

    [XmlElement(ElementName = "telefono")]
    public string Telefono { get; set; }

    [XmlElement(ElementName = "numeroFactura")]
    public string NumeroFactura { get; set; }

    [XmlElement(ElementName = "cuf")]
    public string Cuf { get; set; }

    [XmlElement(ElementName = "cufd")]
    public string Cufd { get; set; }

    [XmlElement(ElementName = "codigoSucursal")]
    public int CodigoSucursal { get; set; }

    [XmlElement(ElementName = "direccion")]
    public string Direccion { get; set; }

    [XmlElement(ElementName = "codigoPuntoVenta")]
    public int CodigoPuntoVenta { get; set; }

    [XmlElement(ElementName = "fechaEmision")]
    public DateTime FechaEmision { get; set; }

    [XmlElement(ElementName = "nombreRazonSocial")]
    public string NombreRazonSocial { get; set; }

    [XmlElement(ElementName = "codigoTipoDocumentoIdentidad")]
    public int CodigoTipoDocumentoIdentidad { get; set; }

    [XmlElement(ElementName = "numeroDocumento")]
    public string NumeroDocumento { get; set; }

    [XmlElement(ElementName = "complemento")]
    public string Complemento { get; set; }

    [XmlElement(ElementName = "codigoCliente")]
    public string CodigoCliente { get; set; }
  }
}
