using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace UMBRA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Import("C:\\Users\\USER\\Desktop\\pornhub.com-db.csv");
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
                    //separate row values for accesing individual values.
                    //separa los valores de la fila para acceder a los valores individuales.
                    string[] csvArray = inputLine.Split(new char[] { '|' });

                    //extract labels & add them to custom class (2 columns have label values)
                    //extrae las etiquetas y agregalas a la clase personalizada (hay 2 columnas que contienen etiquetas)
                    var _labels = new List<Custom_Classes.Label>();
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

                    var _images = new List<Custom_Classes.Image>();
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
                        (ES).- El Set esta completo, en este nivel contiene: titulo (extraido del archivo csv), URL de las imagenes (extraido del archivo csv) y etiquetas (extraido del archivo csv)
                     */
                }

            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        /// <summary>
        /// (EN)
        /// Once image URL site is saved at your database, next step is download image file, use this method for sending site URL image, this will return Image as byte[], using Image class you can manage this
        /// (ES)
        /// Una vez que la URL del sitio esta guardada, el siguiente paso es descargar el archivo de imagen, usa este metodo para enviar la URL del archivo, este te regresarael archivo de imagen como byte[], usando la clase Image puedes manejarlo
        /// </summary>
        /// <param name="_url">WebSite URL</param>
        /// <returns>Image as array byte</returns>
        private static byte[] DownloadImage(string _url)
        {
            try
            {
                using (var webClient = new WebClient())
                {
                    var _imageFromWebSite = webClient.DownloadData(new Uri(_url));
                    return _imageFromWebSite;
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        /// <summary>
        /// For image detection AI models, you will need to provide files for training, using this method, you can convert byte[] into a Image, save this in your defined directory & start training your model
        /// 
        /// Para los modelos de detección en IA, tienes que proveer archivos de imagen para el entramiento, usando este metodo, puedes convertir desde byte[] a una Imagen, guarda esta en tu directorio definido y empieza a entrenar tu modelo
        /// </summary>
        /// <param name="byteArrayIn">Image file as array byte</param>
        public static void ByteArrayToImage(byte[] byteArrayIn)
        {
            try
            {
                MemoryStream ms = new MemoryStream(byteArrayIn);
                Image returnImage = Image.FromStream(ms);
                returnImage.Save("your directory will be here", System.Drawing.Imaging.ImageFormat.Png);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}
