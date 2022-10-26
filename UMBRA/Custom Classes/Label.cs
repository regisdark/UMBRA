namespace UMBRA.Custom_Classes
{
    /// <summary>
    /// A set contains X labels, with this class you can manage these
    /// </summary>
    public class Label
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
        public string ID_LABEL { get; set; }
        public string ID_SET { get; set; }
        public string DESCRIPTION { get; set; }
        /// <summary>
        /// (EN)
        /// This field can be used for training your model or performing needed operations.
        /// tip.- update this status once value used, this will improve query performance
        /// 
        /// (ES)
        /// Este campo puede ser usado para entrenar tu modelo o realizar operaciones
        /// Consejo.- una vez usado este campo, considera actualizarlo, esto mejorara el rendimiento de tus consultas
        /// </summary>
        public bool STATUS { get; set; }
    }
}
