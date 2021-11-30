using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System;
using Examen_Parcial2.Models;

namespace Examen_Parcial2.Handlers
{
    public class ComboHandler: BaseDatosHandler
    {
        ArchivosHandler manejadorDeImagen = new ArchivosHandler();

        public List<ComboModel> obtenerCombos()
        {
            string consulta = "SELECT * FROM Comestible C JOIN Combo Co ON C.nombrePK = Co.nombreFK;";
            List<ComboModel> combo = new List<ComboModel>();
            DataTable tabla = leerBaseDeDatos(consulta);
            foreach (DataRow columna in tabla.Rows)
            {
                combo.Add(
                    new ComboModel
                    {
                        nombre = Convert.ToString(columna["nombrePK"]),
                        precio = Convert.ToDouble(columna["precio"]),
                        pizza = Convert.ToString(columna["pizzaFK"]),
                        bebida = Convert.ToString(columna["bebidaFK"]),
                        acompanante = Convert.ToString(columna["acompananteFK"])
                    } );
            }
            return combo;
        }

     
        public bool agregarCombo(ComboModel combo)
        {
            string ConsultaComestible = "INSERT INTO Comestible ( nombrePK, precio, fotoArchivo, fotoTipo ) "
                + "VALUES ( @nombre, @precio, @fotoArchivo, @fotoTipo );";

            string ConsultaCombo = "INSERT INTO Pizza (nombreFK, pizzaFK, bebidaFK, acompananteFK ) "
                + "VALUES (@nombrePizza, @pizzaFK, @bebidaFK, @acompananteFK );";

            Dictionary<string, object> valoresParametrosComestible = new Dictionary<string, object> {
                {"@nombre", combo.nombre },
                {"@precio", combo.precio },
                {"@fotoTipo", combo.fotoArchivo.ContentType }
            };
            valoresParametrosComestible.Add("@fotoArchivo", manejadorDeImagen.ConvertirArchivoABytes(combo.fotoArchivo));

            Dictionary<string, object> valoresParametrosCombo = new Dictionary<string, object> {
                {"@nombrePizza", combo.nombre },
                {"@pizza", combo.pizza },
                {"@bebida", combo.bebida },
                {"@acompanante", combo.acompanante }
            };

            return (insertarEnBaseDatos(ConsultaComestible, valoresParametrosComestible) && insertarEnBaseDatos(ConsultaCombo, valoresParametrosCombo));
        }

        public Tuple<byte[], string> obtenerFoto(string nombre)
        {
            string columnaContenido = "fotoArchivo";
            string columnaTipo = "fotoTipo";
            string consulta = "SELECT " + columnaContenido + ", " + columnaTipo + " FROM Comestible WHERE nombrePK = @nombre";
            KeyValuePair<string, object> parametro = new KeyValuePair<string, object>("@nombre", nombre);
            return obtenerArchivo(consulta, parametro, columnaContenido, columnaTipo);
        }
    }
}

