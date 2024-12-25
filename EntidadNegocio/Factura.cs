using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace facturasXML.EntidadNegocio
{
  /// <summary>
  /// Clase que representa una factura electrónica
  /// </summary>
  [Serializable]
  [XmlRoot(ElementName = "facturaElectronica")]
  public class Factura
  {
    [XmlElement(ElementName = "cabecera")]
    public Cabecera Cabecera { get; set; }

    [XmlArray(ElementName = "detalle")]
    [XmlArrayItem(ElementName = "item")]
    public List<Detalle> Detalle { get; set; }

    public Factura()
    {
      Cabecera = new Cabecera();
      Detalle = new List<Detalle>();
    }
  }
}
