using System.Linq;
namespace UMBRA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Import("file directory (obtained when descompressed zip)");
        }

        private static void Import(string filedirectory)
        {
            try
            {
                System.IO.StreamReader csvreader = new System.IO.StreamReader(filedirectory);
                string inputLine = "";
                var _set = new Custom_Classes.Set();
                while ((inputLine = csvreader.ReadLine()) != null)
                {
                    //(EN).- separate row values for accesing individual values.
                    //(ES).- separa los valores de la fila para acceder a los valores individuales.
                    string[] csvArray = inputLine.Split(new char[] { '|' });

                    //(EN).- extract labels & add them to custom class (2 columns have label values)
                    //(ES).- extrae las etiquetas y agrégalas a la clase personalizada (hay 2 columnas que contienen etiquetas)
                    var _labels = new System.Collections.Generic.List<Custom_Classes.Label>();
                    _labels.AddRange(csvArray[4].Split(';').Select(_l => new Custom_Classes.Label()
                    {
                        STATUS = true,
                        DESCRIPTION = _l
                    }));

                    _labels.AddRange(csvArray[5].Split(';').Select(_l => new Custom_Classes.Label()
                    {
                        STATUS = true,
                        DESCRIPTION = _l
                    }));

                    var _images = new System.Collections.Generic.List<Custom_Classes.Image>();
                    _images.AddRange(csvArray[2].Split(';').Select(x => new Custom_Classes.Image()
                    {
                        STATUS = true,
                        URL = x
                    }));

                    _images.AddRange(csvArray[12].Split(';').Select(x => new Custom_Classes.Image()
                    {
                        STATUS = true,
                        URL = x
                    }));

                    _set = new Custom_Classes.Set()
                    {
                        TITLE = csvArray[3],
                        STATUS = true,
                        IMAGES = _images,
                        LABELS = _labels
                    };

                    /*
                        (EN).- Set is completed, at this level contains: title (extracted from csv file), images (extracted from csv file) & labels (extracted from csv file)
                        (ES).- El Set está completo, en este nivel contiene: titulo (extraído del archivo csv), URL de las imágenes (extraído del archivo csv) y etiquetas (extraído del archivo csv)
                     */

                    //(EN).- save to your database
                    //(ES).- guarda en tu base de datos
                }

            }
            catch (System.Exception exc)
            {
                throw exc;
            }
        }

        /// <summary>
        /// (EN)
        /// Once image URL site is saved at your database, next step is download image file, use this method for sending site URL image, this will return Image as byte[], using Image class you can manage this
        /// (ES)
        /// Una vez que la URL del sitio esta guardada, el siguiente paso es descargar el archivo de imagen, usa este método para enviar la URL del archivo, este te regresara el archivo de imagen como byte[], usando la clase Image puedes manejarlo
        /// </summary>
        /// <param name="_url">WebSite URL</param>
        /// <returns>Image as array byte</returns>
        private static byte[] DownloadImage(string _url)
        {
            try
            {
                using (var webClient = new System.Net.WebClient())
                {
                    var _imageFromWebSite = webClient.DownloadData(new System.Uri(_url));
                    return _imageFromWebSite;
                }
            }
            catch (System.Exception exc)
            {
                throw exc;
            }
        }

        /// <summary>
        /// (EN)
        /// For image detection AI models, you will need to provide files for training, using this method, you can convert byte[] into a Image, save this in your defined directory & start training your model
        /// (ES)
        /// Para los modelos de detección de imágenes en IA, tienes que proveer archivos de imagen para el entramiento, usando este método, puedes convertir desde byte[] a una Imagen, guarda está en tu directorio definido y empieza a entrenar tu modelo        /// </summary>
        /// <param name="byteArrayIn">Image file as array byte</param>
        public static void ByteArrayToImage(byte[] byteArrayIn)
        {
            try
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream(byteArrayIn);
                System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
                returnImage.Save("your directory will be here", System.Drawing.Imaging.ImageFormat.Png);
            }
            catch (System.Exception exc)
            {
                throw exc;
            }
        }
    }
}
