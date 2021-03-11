using Microsoft.EntityFrameworkCore;
using SegundoParcial_AP.DAL;
using SegundoParcial_AP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SegundoParcial_AP.BLL
{
    public class VentasBLL
    {
        public static Ventas Buscar (int id)
        {
            Ventas ventas = new Ventas();
            Contexto contexto = new Contexto();

            try
            {
                ventas = contexto.Ventas.Find(id);
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return ventas;

        }

        public static List<Ventas> GetList(Expression<Func<Ventas, bool>> venta)
        {
            List<Ventas> Lista = new List<Ventas>();
            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.Ventas.Where(venta).ToList();

            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                contexto.Dispose();
            }
            return Lista;

        }

        public static async Task<List<CobrosDetalle>> GetVentasPendiente(int clienteId)
        {
            var pendiente = new List<CobrosDetalle>();
            Contexto contexto = new Contexto();

            var ventas = await contexto.Ventas
                .Where(V => V.ClienteId == clienteId && V.Balance > 0)
                .AsNoTracking()
                .ToListAsync();

            foreach(var item in ventas)
            {
                pendiente.Add(new CobrosDetalle
                {
                    VentaId = item.VentaId,
                    Venta = item,
                    Cobrado = 0

                });
            }

            return pendiente;
        }

        public static async Task<List<CobrosDetalle>> GetVentasCobradas(int clienteId)
        {
            var pendiente = new List<CobrosDetalle>();
            Contexto contexto = new Contexto();

            var ventas = await contexto.Ventas
                .Where(V => V.ClienteId == clienteId && V.Balance > 0)
                .AsNoTracking()
                .ToListAsync();

            foreach (var item in ventas)
            {
                pendiente.Add(new CobrosDetalle
                {
                    VentaId = item.VentaId,
                    Venta = item,
                    Cobrado = 0

                });
            }

            return pendiente;
        }



    }
}
