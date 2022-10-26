namespace UMBRA.Custom_Classes
{
    /// <summary>
    /// A set contains X images, with this class you can manage these
    /// </summary>
    public class Image
    {
        /// <summary>
        /// (EN)
        /// this will be used by your convenience, if you want to save in a database, you can use this
        /// tip.- use a guid 
        /// 
        /// (ES)
        /// Este campo puede ser usado a tu conveniencia, si quieres guardar en una base de datos, puedes usar este
        /// Consejo.- usa un Guid 
        /// </summary>
        public string ID_IMAGE { get; set; }
        public string ID_SET { get; set; }
        public string URL { get; set; }
        /// <summary>
        /// (EN)
        /// Some AI models can use dates for predictions, saving exact datetime when this field was saved you can improve you prediction score
        /// tip.- If a database used, consider to create a different table including: id, date, image file 
        /// 
        /// (ES)
        /// Algunos modelos de IA pueden usar fechas para predicciones, guardar la fecha exacta cuando este campo es guardado puede mejorar tu predicción
        /// Consejo.- Si usas una base de datos, considera crear una tabla diferente que incluya: id, fecha, archivo de imagen
        /// </summary>
        public System.DateTime DATE { get; set; }
        public bool STATUS { get; set; }
        /// <summary>
        /// (EN) This field will save downloaded image from server, and can be used as your requeriments.
        /// (ES) Este campo guardara el archivo de imagen descargado del servidor, y puede ser usado acorde a tus requerimientos.
        /// </summary>
        public byte[] IMAGE_FILE { get; set; }

    }
}
