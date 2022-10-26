namespace UMBRA.Custom_Classes
{
    /// <summary>
    /// (EN)
    /// A set is the main repository, every row in csv field is a set, every row contains labels & images that can be managed by included classes at this project.
    /// (ES)
    /// Un set es el repositorio principal, cada fila en el archivo csv es un set, cada fila contiene etiquetas e imágenes que pueden ser manejadas por las clases incluidas en este proyecto.
    /// </summary>
    public class Set
    {
        public string ID_SET { get; set; }
        public bool STATUS { get; set; }
        /// <summary>
        /// (EN)
        /// this field is taken by every row, can include special characters and some nasty words
        /// tip.- If you are saving into a database, consider nvarchar type field & maxlength (250)
        /// 
        /// (ES)
        /// Este campo es tomado de cada fila, puede incluir caracteres especiales y algunas palabras sucias
        /// Consejo.- Si esta guardando en una base de datos, considera usar el tipo nvarchar, con maxlength 250.
        /// </summary>
        public string TITLE { get; set; }
        public System.Collections.Generic.List<Label> LABELS { get; set; }
        public System.Collections.Generic.List<Image> IMAGES { get; set; }
    }
}
