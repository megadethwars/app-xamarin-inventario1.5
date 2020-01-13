using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;

namespace Inventario2
{
    public class ControllerHistorialCompleto
    {
        public ControllerHistorialCompleto() { 
        
        }

        //bisquedas dependiando de resultado

        public   async Task<List<Movimientos>> Search(ModelHistorialCompleto modelhistorial)
        {
            try
            {
                List<Movimientos> lista = await MovementCase2(modelhistorial);
                return lista;
            }
            catch
            {
                return null;
            }
            
        }




        /// 
        /// 
        /// 
        private async Task<List<Movimientos>> MovementCase1(ModelHistorialCompleto modelhistorial)
        {

            // searching only by date
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.fecha == modelhistorial.fecha.ToString()).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase2(ModelHistorialCompleto modelhistorial)
        {

            // searching only by model 
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.modelo == modelhistorial.modelo).ToListAsync();
            
            return table;
        }

        private async Task<List<Movimientos>> MovementCase3(ModelHistorialCompleto modelhistorial)
        {

            // searching only by model and date
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.modelo == modelhistorial.modelo).
                Where(u => u.fecha == modelhistorial.fecha.ToString()).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase4(ModelHistorialCompleto modelhistorial)
        {

            // searching only by product
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.producto == modelhistorial.producto).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase5(ModelHistorialCompleto modelhistorial)
        {

            // searching only by product and date
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.producto == modelhistorial.producto).
                Where(u => u.fecha == modelhistorial.fecha.ToString()).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase6(ModelHistorialCompleto modelhistorial)
        {

            // searching only by product and model
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.producto == modelhistorial.producto).
                Where(u => u.modelo == modelhistorial.modelo).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase7(ModelHistorialCompleto modelhistorial)
        {

            // searching only by model and date, product
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.producto == modelhistorial.producto).
                Where(u => u.modelo == modelhistorial.modelo).Where(u => u.fecha == modelhistorial.fecha.ToString()).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase8(ModelHistorialCompleto modelhistorial)
        {

            // searching only by product
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.movimiento == modelhistorial.movimiento).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase9(ModelHistorialCompleto modelhistorial)
        {

            // searching only by model and date
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.movimiento == modelhistorial.movimiento).
                Where(u => u.fecha == modelhistorial.fecha.ToString()).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase10(ModelHistorialCompleto modelhistorial)
        {

            // searching only by movimiento and modelo
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.movimiento == modelhistorial.movimiento).
                Where(u => u.modelo == modelhistorial.modelo).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase11(ModelHistorialCompleto modelhistorial)
        {

            // searching only by movimiento and date, modelo
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.movimiento == modelhistorial.movimiento).
                Where(u => u.modelo == modelhistorial.modelo).Where(u => u.fecha == modelhistorial.fecha.ToString()).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase12(ModelHistorialCompleto modelhistorial)
        {

            // searching only by movimiento and producto
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.movimiento == modelhistorial.movimiento).
                Where(u => u.producto == modelhistorial.producto).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase13(ModelHistorialCompleto modelhistorial)
        {

            // searching only by movimiendo, producto y fecha
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.movimiento == modelhistorial.movimiento).
                Where(u => u.producto == modelhistorial.producto).Where(u => u.fecha == modelhistorial.fecha.ToString()).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase14(ModelHistorialCompleto modelhistorial)
        {

            // searching only by movimiendo, producto y modelo
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.movimiento == modelhistorial.movimiento).
                Where(u => u.producto == modelhistorial.producto).Where(u => u.modelo == modelhistorial.modelo).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase15(ModelHistorialCompleto modelhistorial)
        {
           
            // searching only by movimiendo, producto  modelo date
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.movimiento == modelhistorial.movimiento).
                Where(u => u.producto == modelhistorial.producto).Where(u => u.modelo == modelhistorial.modelo).
                Where(u => u.fecha == modelhistorial.fecha.ToString()).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase16(ModelHistorialCompleto modelhistorial)
        {

            // searching only idproduct
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.IdProducto == modelhistorial.IdProducto).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase17(ModelHistorialCompleto modelhistorial)
        {

            // searching only by idproduct and date
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.IdProducto == modelhistorial.IdProducto).
            Where(u => u.fecha == modelhistorial.fecha.ToString()).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase18(ModelHistorialCompleto modelhistorial)
        {

            
            // searching only by idproduct and model
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.IdProducto == modelhistorial.IdProducto).
            Where(u => u.modelo == modelhistorial.modelo).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase19(ModelHistorialCompleto modelhistorial)
        {

            // searching only by idproduct  model, date
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.IdProducto == modelhistorial.IdProducto).
            Where(u => u.modelo == modelhistorial.modelo).Where(u => u.fecha == modelhistorial.fecha.ToString()).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase20(ModelHistorialCompleto modelhistorial)
        {

            // searching only by idproduct  and product
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.IdProducto == modelhistorial.IdProducto).
            Where(u => u.producto == modelhistorial.producto).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase21(ModelHistorialCompleto modelhistorial)
        {

            // searching only by idproduct  and product and date
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.IdProducto == modelhistorial.IdProducto).
            Where(u => u.producto == modelhistorial.producto).Where(u => u.fecha == modelhistorial.fecha.ToString()).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase22(ModelHistorialCompleto modelhistorial)
        {

            // searching only by idproduct  and product and model
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.IdProducto == modelhistorial.IdProducto).
            Where(u => u.producto == modelhistorial.producto).Where(u => u.modelo == modelhistorial.modelo).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase23(ModelHistorialCompleto modelhistorial)
        {

            // searching only by idproduct  and product and model and date
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.IdProducto == modelhistorial.IdProducto).
            Where(u => u.producto == modelhistorial.producto).Where(u => u.modelo == modelhistorial.modelo).
            Where(u => u.fecha == modelhistorial.fecha.ToString()).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase24(ModelHistorialCompleto modelhistorial)
        {

            // searching only by idproduct  and movement
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.IdProducto == modelhistorial.IdProducto).
            Where(u => u.movimiento == modelhistorial.movimiento).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase25(ModelHistorialCompleto modelhistorial)
        {

            // searching only by idproduct  and movement and date
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.IdProducto == modelhistorial.IdProducto).
            Where(u => u.movimiento == modelhistorial.movimiento).Where(u => u.fecha == modelhistorial.fecha.ToString()).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase26(ModelHistorialCompleto modelhistorial)
        {

            // searching only by idproduct  and movement and model
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.IdProducto == modelhistorial.IdProducto).
            Where(u => u.movimiento == modelhistorial.movimiento).Where(u => u.modelo == modelhistorial.modelo).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase27(ModelHistorialCompleto modelhistorial)
        {

            // searching only by idproduct  and movement model and date
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.IdProducto == modelhistorial.IdProducto).
            Where(u => u.movimiento == modelhistorial.movimiento).Where(u => u.modelo == modelhistorial.modelo).
            Where(u => u.fecha == modelhistorial.fecha.ToString()).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase28(ModelHistorialCompleto modelhistorial)
        {

            // searching only by idproduct  and movement   product and model
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.IdProducto == modelhistorial.IdProducto).
            Where(u => u.movimiento == modelhistorial.movimiento).Where(u => u.producto == modelhistorial.producto).
            Where(u => u.modelo == modelhistorial.modelo).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase29(ModelHistorialCompleto modelhistorial)
        {

            // searching only by idproduct  and movement and  product 
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.IdProducto == modelhistorial.IdProducto).
            Where(u => u.movimiento == modelhistorial.movimiento).Where(u => u.producto == modelhistorial.producto).ToListAsync();

            return table;
        }


        private async Task<List<Movimientos>> MovementCase30(ModelHistorialCompleto modelhistorial)
        {

            // searching only by model and date
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.modelo == modelhistorial.modelo).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase31(ModelHistorialCompleto modelhistorial)
        {

            // searching only by model and date
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.modelo == modelhistorial.modelo).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase32(ModelHistorialCompleto modelhistorial)
        {

            // searching only by model and date
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.modelo == modelhistorial.modelo).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase33(ModelHistorialCompleto modelhistorial)
        {

            // searching only by model and date
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.modelo == modelhistorial.modelo).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase34(ModelHistorialCompleto modelhistorial)
        {

            // searching only by model and date
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.modelo == modelhistorial.modelo).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase35(ModelHistorialCompleto modelhistorial)
        {

            // searching only by model and date
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.modelo == modelhistorial.modelo).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase36(ModelHistorialCompleto modelhistorial)
        {

            // searching only by model and date
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.modelo == modelhistorial.modelo).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase37(ModelHistorialCompleto modelhistorial)
        {

            // searching only by model and date
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.modelo == modelhistorial.modelo).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase38(ModelHistorialCompleto modelhistorial)
        {

            // searching only by model and date
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.modelo == modelhistorial.modelo).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase39(ModelHistorialCompleto modelhistorial)
        {

            // searching only by model and date
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.modelo == modelhistorial.modelo).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase40(ModelHistorialCompleto modelhistorial)
        {

            // searching only by model and date
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.modelo == modelhistorial.modelo).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase41(ModelHistorialCompleto modelhistorial)
        {

            // searching only by model and date
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.modelo == modelhistorial.modelo).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase42(ModelHistorialCompleto modelhistorial)
        {

            // searching only by model and date
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.modelo == modelhistorial.modelo).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase43(ModelHistorialCompleto modelhistorial)
        {

            // searching only by model and date
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.modelo == modelhistorial.modelo).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase44(ModelHistorialCompleto modelhistorial)
        {

            // searching only by model and date
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.modelo == modelhistorial.modelo).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase45(ModelHistorialCompleto modelhistorial)
        {

            // searching only by model and date
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.modelo == modelhistorial.modelo).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase46(ModelHistorialCompleto modelhistorial)
        {

            // searching only by model and date
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.modelo == modelhistorial.modelo).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase47(ModelHistorialCompleto modelhistorial)
        {

            // searching only by model and date
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.modelo == modelhistorial.modelo).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase48(ModelHistorialCompleto modelhistorial)
        {

            // searching only by model and date
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.modelo == modelhistorial.modelo).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase49(ModelHistorialCompleto modelhistorial)
        {

            // searching only by model and date
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.modelo == modelhistorial.modelo).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase50(ModelHistorialCompleto modelhistorial)
        {

            // searching only by model and date
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.modelo == modelhistorial.modelo).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase51(ModelHistorialCompleto modelhistorial)
        {

            // searching only by model and date
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.modelo == modelhistorial.modelo).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase52(ModelHistorialCompleto modelhistorial)
        {

            // searching only by model and date
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.modelo == modelhistorial.modelo).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase53(ModelHistorialCompleto modelhistorial)
        {

            // searching only by model and date
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.modelo == modelhistorial.modelo).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase54(ModelHistorialCompleto modelhistorial)
        {

            // searching only by model and date
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.modelo == modelhistorial.modelo).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase55(ModelHistorialCompleto modelhistorial)
        {

            // searching only by model and date
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.modelo == modelhistorial.modelo).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase56(ModelHistorialCompleto modelhistorial)
        {

            // searching only by model and date
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.modelo == modelhistorial.modelo).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase57(ModelHistorialCompleto modelhistorial)
        {

            // searching only by model and date
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.modelo == modelhistorial.modelo).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase58(ModelHistorialCompleto modelhistorial)
        {

            // searching only by model and date
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.modelo == modelhistorial.modelo).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase59(ModelHistorialCompleto modelhistorial)
        {

            // searching only by model and date
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.modelo == modelhistorial.modelo).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase60(ModelHistorialCompleto modelhistorial)
        {

            // searching only by model and date
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.modelo == modelhistorial.modelo).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase61(ModelHistorialCompleto modelhistorial)
        {

            // searching only by model and date
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.modelo == modelhistorial.modelo).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase62(ModelHistorialCompleto modelhistorial)
        {

            // searching only by model and date
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.modelo == modelhistorial.modelo).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase63(ModelHistorialCompleto modelhistorial)
        {

            // searching by everithing, user,idproduct,movimiento, producto, id producto, date
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.modelo == modelhistorial.modelo).ToListAsync();

            return table;
        }

    }
}
