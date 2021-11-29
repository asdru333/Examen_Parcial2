﻿using System.IO;
using System.Web;

namespace Examen_Parcial2.Handlers
{
    public class ArchivosHandler
    {
        public byte[] ConvertirArchivoABytes(HttpPostedFileBase archivo)
        {
            byte[] bytes;
            BinaryReader lector = new BinaryReader(archivo.InputStream); //
            bytes = lector.ReadBytes(archivo.ContentLength);
            return bytes;
        }
    }
}