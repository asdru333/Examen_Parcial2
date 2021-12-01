using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System;
using System.Web.Mvc;
using Examen_Parcial2.Models;

namespace Examen_Parcial2.Handlers
{
    public class PedidoHandler: BaseDatosHandler
    {
        public List<PedidoModel> obtenerPedidos()
        {
            string consulta = "SELECT * FROM Pedido;";
            List<PedidoModel> pedido = new List<PedidoModel>();
            DataTable tabla = leerBaseDeDatos(consulta);
            foreach (DataRow columna in tabla.Rows)
            {
                pedido.Add(
                    new PedidoModel
                    {
                        ID = Convert.ToInt32(columna["pedidoIDPK"]),
                        nombreComestible = Convert.ToString(columna["precio"]),
                        nombreCliente = Convert.ToString(columna["pizzaFK"]),
                        apellidoCliente = Convert.ToString(columna["bebidaFK"]),
                        direccion = Convert.ToString(columna["direccion"]),
                        precio = Convert.ToDouble(columna["precio"])
                    } );
            }
            return pedido;
        }
     
        public bool agregarPedido(PedidoModel pedido)
        {
            string consulta = "INSERT INTO Comestible ( nombreComestibleFK, nombreCliente, apellidoCliente, direccion, precio ) "
                + "VALUES ( @comestible, @nombreCliente, @apellidoCliente, @direccion, @precio );";

            Dictionary<string, object> valoresParametros = new Dictionary<string, object> {
                {"@comestible", pedido.nombreComestible },
                {"@nombreCliente", pedido.nombreCliente },
                {"@apellidoCliente", pedido.apellidoCliente },
                {"@direccion", pedido.direccion },
                {"@precio", pedido.precio }
            };

            return (insertarEnBaseDatos(consulta, valoresParametros));
        }
    }
}

