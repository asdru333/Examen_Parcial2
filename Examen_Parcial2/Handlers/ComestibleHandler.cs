using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System;
using Examen_Parcial2.Models;

namespace Examen_Parcial2.Handlers
{
    public class ComestibleHandler: BaseDatosHandler
    {
        ArchivosHandler manejadorDeImagen = new ArchivosHandler();
        public List<PizzaModel> obtenerPizzas()
        {
            string consulta = "SELECT * FROM Comestible C JOIN Pizza P ON C.nombrePK = P.nombreFK;";
            List<PizzaModel> pizzas = new List<PizzaModel>();
            DataTable tabla = leerBaseDeDatos(consulta);
            foreach (DataRow columna in tabla.Rows)
            {
                pizzas.Add(
                    new PizzaModel
                    {
                        nombre = Convert.ToString(columna["nombrePK"]),
                        precio = Convert.ToDouble(columna["precio"]),
                        salsa = Convert.ToString(columna["salsa"])
                    });
            }
            return pizzas;
        }

        public bool agregarPizza(PizzaModel pizza)
        {
            string ConsultaComestible = "INSERT INTO Comestible ( nombrePK, precio, fotoArchivo, fotoTipo ) "
                + "VALUES ( @nombre, @precio, @fotoArchivo, @fotoTipo );";

            string ConsultaPizza = "INSERT INTO Pizza (nombreFK, salsa ) "
                + "VALUES (@nombrePizza @salsa );";

            Dictionary<string, object> valoresParametrosComestible = new Dictionary<string, object> {
                {"@nombre", pizza.nombre },
                {"@precio", pizza.precio },
                {"@fotoTipo", pizza.fotoArchivo.ContentType }
            };
            valoresParametrosComestible.Add("@fotoArchivo", manejadorDeImagen.ConvertirArchivoABytes(pizza.fotoArchivo));

            Dictionary<string, object> valoresParametrosPizza = new Dictionary<string, object> {
                {"@nombrePizza", pizza.nombre },
                {"@salsa", pizza.salsa }
            };

            return (insertarEnBaseDatos(ConsultaComestible, valoresParametrosComestible) && insertarEnBaseDatos(ConsultaPizza, valoresParametrosPizza));
        }

        public bool agregarIngredientes(string pizza, string ingrediente)
        {
            string consulta = "INSERT INTO PizzaIngrediente VALUES (@pizza, @ingrediente)";

            Dictionary<string, object> valoresParametros = new Dictionary<string, object> {
                {"@pizza", pizza },
                {"@ingrediente", ingrediente }
            };
            return (insertarEnBaseDatos(consulta, valoresParametros));
        }

        public List<BebidaModel> obtenerBebidas()
        {
            string consulta = "SELECT * FROM Comestible C JOIN Bebida B ON C.nombrePK = B.nombreFK;";
            List<BebidaModel> bebidas = new List<BebidaModel>();
            DataTable tabla = leerBaseDeDatos(consulta);
            foreach (DataRow columna in tabla.Rows)
            {
                bebidas.Add(
                    new BebidaModel
                    {
                        nombre = Convert.ToString(columna["nombrePK"]),
                        precio = Convert.ToDouble(columna["precio"]),
                        categoriaBebida = Convert.ToString(columna["categoriaBebida"]),
                        litros = Convert.ToDouble(columna["litros"])
                    });
            }
            return bebidas;
        }

        public bool agregarBebida(BebidaModel bebida)
        {
            string consultaComestible = "INSERT INTO Comestible ( nombrePK, precio, fotoArchivo, fotoTipo ) "
                + "VALUES ( @nombre, @precio, @fotoArchivo, @fotoTipo );";

            string consultaBebida = "INSERT INTO Bebida ( nombreFK, categoriaBebida, litros ) "
                + "VALUES (@nombreBebida, @categoriaBebida, @litros );";

            Dictionary<string, object> valoresParametrosComestible = new Dictionary<string, object> {
                {"@nombre", bebida.nombre },
                {"@precio", bebida.precio },
                {"@fotoTipo", bebida.fotoArchivo.ContentType },
            };
            valoresParametrosComestible.Add("@fotoArchivo", manejadorDeImagen.ConvertirArchivoABytes(bebida.fotoArchivo));

            Dictionary<string, object> valoresParametrosBebida = new Dictionary<string, object> {
                {"nombreBebida", bebida.nombre },
                {"@categoriaBebida", bebida.categoriaBebida },
                {"@litros", bebida.litros }
            };
            return (insertarEnBaseDatos(consultaComestible, valoresParametrosComestible) && insertarEnBaseDatos(consultaBebida, valoresParametrosBebida));
        }

        public List<AcompananteModel> obtenerAcompanantes()
        {
            string consulta = "SELECT * FROM Comestible C JOIN Acompanante A ON C.nombrePK = A.nombreFK;";
            List<AcompananteModel> acompanantes = new List<AcompananteModel>();
            DataTable tabla = leerBaseDeDatos(consulta);
            foreach (DataRow columna in tabla.Rows)
            {
                acompanantes.Add(
                    new AcompananteModel
                    {
                        nombre = Convert.ToString(columna["nombrePK"]),
                        precio = Convert.ToDouble(columna["precio"]),
                        unidades = Convert.ToInt32(columna["unidades"])
                    });
            }
            return acompanantes;
        }

        public bool agregarAcompanante(AcompananteModel acompanante)
        {
            string consultaComestible = "INSERT INTO Comestible ( nombrePK, precio, fotoArchivo, fotoTipo ) "
                + "VALUES ( @nombre, @precio, @fotoArchivo, @fotoTipo );";

            string consultaAcompanante = "INSERT INTO Acompanante ( nombreFK, unidades ) "
                + "VALUES ( @nombreAcompanante, @unidades );";

            Dictionary<string, object> valoresParametrosComestible = new Dictionary<string, object> {
                {"@nombre", acompanante.nombre },
                {"@precio", acompanante.precio },
                {"@fotoTipo", acompanante.fotoArchivo.ContentType },
            };
            valoresParametrosComestible.Add("@fotoArchivo", manejadorDeImagen.ConvertirArchivoABytes(acompanante.fotoArchivo));

            Dictionary<string, object> valoresParametrosAcompanante = new Dictionary<string, object> {
                {"@nombreAcompanante", acompanante.nombre },
                {"@unidades", acompanante.unidades },
            };
            return (insertarEnBaseDatos(consultaComestible, valoresParametrosComestible) && insertarEnBaseDatos(consultaAcompanante, valoresParametrosAcompanante));
        }

        public Tuple<byte[], string> ObtenerFoto(string nombre)
        {
            string columnaContenido = "fotoArchivo";
            string columnaTipo = "fotoTipo";
            string consulta = "SELECT " + columnaContenido + ", " + columnaTipo + " FROM Comestible WHERE nombrePK = @nombre";
            KeyValuePair<string, object> parametro = new KeyValuePair<string, object>("@nombre", nombre);
            return obtenerArchivo(consulta, parametro, columnaContenido, columnaTipo);
        }
    }
}

