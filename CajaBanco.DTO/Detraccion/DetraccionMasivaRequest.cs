using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.DTO.Detraccion
{
    public class DetraccionMasivaRequest
    {
        public string ban01Empresa { get; set; }
        public string ban01Anio { get; set; }
        public string ban01mes { get; set; }    
        public string ban01Descripcion { get; set; }
        public string ban01Fecha { get; set; }
        public string ban01Estado { get; set; }
        public string ban01Usuario { get; set; }
        public string ban01Pc { get; set; }
        public string ban01FechaRegistro { get; set; }
        public string ban01MedioPago { get; set; }
        public string detraccionLote { get; set; }
        public string ban01motivopagoCod { get; set; }

        public string numerooperacion { get;set; }
        public string enlacePago { get; set; }
        public string nombreArchivo { get;set; }
        public byte[] contenidoArchivo { get; set;}
        public string flagOperacion { get; set; }
           

        
        /*
         @Ban01Empresa varchar(2),                    
@Ban01Anio varchar(4),                      
@Ban01Mes varchar(2),                      
@Ban01Descripcion varchar(400),                      
@Ban01Fecha varchar(10),    -- se asignara la fecha desde el web frontend del metodo actualiza comprobante                
@Ban01Estado varchar(2),
@Ban01Usuario varchar(15),                      
@Ban01Pc varchar(20),                      
@Ban01FechaRegistro varchar(10),                 
@Ban01MedioPago     char(2),        
@DetraccionLote  varchar(5),    
@Ban01motivopagoCod char(2), -- el 03 es pagoi detraccion Masivo  
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
