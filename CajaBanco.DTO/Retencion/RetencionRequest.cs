using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Retencion
{
    public class RetencionRequest
    {
        public string ban01empresa { get; set; }

        public string ban01anio { get; set; }
        public string ban01mes { get; set; }
        public string ban01descripcion { get; set; }
        public string ban01fecha { get; set; }
        public string ban01estado { get; set; }
        public string ban01usuario { get; set; }
        public string ban01pc { get; set; }
        public string ban01fecharegistro { get; set; }
        public string ban01mediopago { get; set; }

        public string ban01motivopagocod { get; set; }
        
        //datoa de año + mes 
        public string retencionMensualNro { get; set; }

        //datos para la confirmacion de pago
        public string numerooperacion { get; set; }
        public string enlacepago { get; set; }
        public string nombrearchivo { get; set; }
        public byte[] contenidoarchivo { get; set; }
        public string flagoperacion { get; set; }
        /*        
            -- Agregar los campos del pago           
            --@fechapago VARCHAR(10),      -- formulario web  frontend parametro del metod actualiza comprobante      
            @numerooperacion VARCHAR(10),      --formulario web frontend del metod actualiza comprobante   
   
            @enlacepago VARCHAR(MAX),      --formulario web  frontend del metod actualiza comprobante      
            @nombreArchivo VARCHAR(MAX),      -- formulario web frontend del metod actualiza comprobante      
            @contenidoArchivo VARBINARY(MAX),      --formulario web frotend del metod actualiza comprobante      
            @flagOperacion CHAR(1),      --formulario web frontend del metodo actualiza comprobante      
         */
    }
}
