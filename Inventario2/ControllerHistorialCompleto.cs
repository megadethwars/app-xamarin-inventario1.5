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

            // searching only by model
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.fecha == modelhistorial.fecha.ToString()).ToListAsync();

            return table;
        }

        private async Task<List<Movimientos>> MovementCase2(ModelHistorialCompleto modelhistorial)
        {

            // searching only by model
            var table = await App.MobileService.GetTable<Movimientos>().Where(u => u.modelo == modelhistorial.modelo ).ToListAsync();
            
            return table;
        }




    }
}
