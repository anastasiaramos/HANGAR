using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;

using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Library.Instruction;

namespace moleQule.Library.Application
{
    public class Scripts
    {
        /// <summary>
        /// Cambia el nombre de las imágenes de las preguntas
        /// Sustitye el Oid viejo por el nuevo Oid formateado
        /// </summary>
        /// <param name="preguntas"></param>
        public static void RenombrarImagenesPreguntas(PreguntaList preguntas)
        {
            string root = Images.GetRootPath();
            foreach (PreguntaInfo item in preguntas)
            {
                string nombre = item.Oid.ToString("00000") + ".jpg";
                if (item.OidOld != 0 && !File.Exists(root + ".\\Recursos\\Fotos\\JPEG\\" + nombre))
                {
                    string ruta = ".\\Recursos\\Fotos\\JPEG\\" + item.OidOld.ToString() + ".jpg";
                    if (File.Exists(root + ruta))
                    {
                        Bitmap imagen = new Bitmap(root + ruta);
                        Images.Save(root + ruta, AppController.FOTOS_PREGUNTAS_PATH, nombre, imagen.Width, imagen.Height);
                        //Images.DeleteImage(root + ruta);
                        //if (imagen.RawFormat.Guid.Equals(System.Drawing.Imaging.ImageFormat.Jpeg.Guid))
                        //    nombre += ".jpg";
                        //if (imagen.RawFormat.Guid.Equals(System.Drawing.Imaging.ImageFormat.Bmp.Guid))
                        //    nombre += ".bmp"; 
                        imagen.Dispose();
                        if (item.Imagen != nombre) 
                            item.FormatImagen(nombre);
                    }
                    //else
                    //    item.FormatImagen(string.Empty);
                }
            }
        }

        /// <summary>
        /// Cambia el nombre de las imágenes de las preguntas de examen
        /// Sustitye el Oid de la pregunta a la que hacen referencia por el nuevo Oid formateado
        /// </summary>
        /// <param name="preguntas"></param>
        public static void RenombrarImagenesPreguntasExamen()
        {
            PreguntaExamenList preguntas_examen = PreguntaExamenList.GetList(false);
            string root = Images.GetRootPath();

            foreach (PreguntaExamenInfo pregunta in preguntas_examen)
            {
                string oid_examen = pregunta.OidExamen.ToString("00000");
                string nombre = pregunta.Oid.ToString("000000") + ".jpg";

                if (pregunta.OidPreguntaOld != 0 && !File.Exists(root + AppController.FOTOS_PREGUNTAS_EXAMEN_PATH + oid_examen + "\\" + nombre))
                {
                    string ruta = AppController.FOTOS_PREGUNTAS_EXAMEN_PATH + oid_examen + "\\" + pregunta.OidPreguntaOld.ToString() + ".jpg";
                    if (File.Exists(root + ruta))
                    {
                        Bitmap imagen = new Bitmap(root + ruta);
                        Images.Save(root + ruta, AppController.FOTOS_PREGUNTAS_EXAMEN_PATH + oid_examen + "\\", nombre, imagen.Width);
                        imagen.Dispose();
                        Images.DeleteImage(root + ruta);
                        Images.DeleteImage(root + ruta.Substring(0, ruta.Length - 3) + "bmp");
                        pregunta.FormatImagen(nombre);
                    }
                    else
                        pregunta.FormatImagen(string.Empty);
                }
            }
        }

        public static void SetPreguntasReservadas()
        {
            ExamenList examenes = ExamenList.GetList(false);

            Pregunta.InitializeReservadas();

            foreach (ExamenInfo item in examenes)
            {
                //si no se ha emitido hay que marcar como reservadas sus preguntas
                if (item.FechaEmision.Date.Equals(DateTime.MaxValue.Date)
                    || item.FechaEmision.Date.Equals(DateTime.MinValue.Date)
                    || item.FechaEmision.Year.Equals(1970))
                {
                    //se obtienen los oids de las preguntas incluidas en el examen
                    string preguntas = item.MemoPreguntas;

                    while (preguntas != string.Empty)
                    {
                        int indice = preguntas.IndexOf(";");
                        string oid = preguntas.Substring(0, indice);
                        preguntas = preguntas.Substring(indice + 1);
                        long oid_pregunta = Convert.ToInt32(oid);

                        Pregunta.FormatReservada(oid_pregunta);
                    }
                }
            }
        }

        public static void FormatFechaDisponibilidad()
        {
            PreguntaExamenList preguntasexamen = PreguntaExamenList.GetList(false);
            PreguntaList preguntas = PreguntaList.GetList(false);
            ExamenList examenes = ExamenList.GetList(false);

            foreach (PreguntaInfo item in preguntas)
            {
                DateTime fecha_disponibilidad = DateTime.MaxValue;

                foreach (PreguntaExamenInfo pexamen in preguntasexamen)
                {
                    //la pregunta se encuentra en un examen emitido
                    if (item.Oid == pexamen.OidPregunta)
                    {
                        ExamenInfo examen = examenes.GetItem(pexamen.OidExamen);

                        DateTime fecha = examen.FechaExamen.AddMonths(6);

                        if (fecha_disponibilidad.Equals(DateTime.MaxValue)
                            || ( !fecha_disponibilidad.Equals(DateTime.MaxValue) &&
                            fecha.Date > fecha_disponibilidad.Date))
                            fecha_disponibilidad = fecha;
                    }
                }

                if (fecha_disponibilidad.Date.Equals(DateTime.MaxValue.Date))
                    fecha_disponibilidad = item.FechaAlta;

                if (!item.FechaDisponibilidad.Date.Equals(fecha_disponibilidad.Date))
                    Pregunta.FormatDisponibilidad(item.Oid, fecha_disponibilidad);
            }
        }

    }
}
