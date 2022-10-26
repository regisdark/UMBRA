using System.Collections.Generic;

namespace UMBRA.Custom_Classes
{
    /// <summary>
    /// (EN)
    /// A set is the main repository, every row in csv field is a set, every row contains labels & imagesthat can be managed by included classes at this project.
    /// (ES)
    /// Un set es el repositorio principal, cada fila en el archivo csv es un set, cada fila contiene etiquetas e imagenes que pueden ser manejadas por las clases incluidad en este proyecto.
    /// </summary>
    public class Set
    {
        public string ID_SET { get; set; }
        public bool STATUS { get; set; }
        public string TITLE { get; set; }
        public List<Label> LABELS { get; set; }
        public List<Image> IMAGES { get; set; }
    }
}
