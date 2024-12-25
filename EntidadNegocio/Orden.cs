using System;
using System.Xml.Serialization;

namespace facturasXML.EntidadNegocio
{
  /// <summary>
  /// Clase que representa la cabecera de una orden.
  /// </summary>
  [Serializable]
  [XmlRoot(ElementName = "orden")]
  public class Orden
  {
    /// <summary>
    /// ID de la orden.
    /// </summary>
    [XmlElement(ElementName = "id")]
    public int Id { get; set; }

    /// <summary>
    /// ID del perfil asociado.
    /// </summary>
    [XmlElement(ElementName = "profileId")]
    public int ProfileId { get; set; }

    /// <summary>
    /// Estado de la orden.
    /// </summary>
    [XmlElement(ElementName = "status")]
    public string Status { get; set; }

    /// <summary>
    /// Total de la orden.
    /// </summary>
    [XmlElement(ElementName = "total")]
    public decimal Total { get; set; }

    /// <summary>
    /// Fecha de creación de la orden.
    /// </summary>
    [XmlElement(ElementName = "createdAt")]
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Fecha de actualización de la orden.
    /// </summary>
    [XmlElement(ElementName = "updatedAt")]
    public DateTime UpdatedAt { get; set; }
  }
}
