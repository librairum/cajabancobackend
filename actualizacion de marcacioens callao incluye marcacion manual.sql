use InterfazBiotime
go

CREATE procedure [dbo].[Spu_Int_Trae_Marcadores]                    
as          
Begin          
  
select       
   marcadorProveedor.id as MarcadorProveedorCod,       
   marcadorProveedor.alias as MarcadorProveedorDesc,       
   marcadorProveedor.ip_address as MarcadorProveedorIp ,       
   marcadorProveedor.real_ip,    
   marcadorProveedor.sn    
  ,isnull(marcadorInterfaz.MarcadorClienteCod,'') as MarcadorClienteCod    
  , isnull(marcadorInterfaz.MarcadorDesc,'') as MarcadorDesc    
  ,isnull(marcadorInterfaz.MarcadorEstado,'') as MarcadorEstado    
  , (case                 
  when marcadorInterfaz.MarcadorEstado  = 'A' then 'Activo'                 
  when marcadorInterfaz.MarcadorEstado  = 'I' then 'Inactivo'                
  else   '' end) as MarcadorEstadoDesc                  
            
  from zkbiotime.dbo.iclock_terminal marcadorProveedor      
        
              
 left join dbo.MarcadoresEquivalencias marcadorInterfaz                    
on marcadorProveedor.id = convert(int, marcadorInterfaz.marcadorproveedorcod)    
  
union all   
select 200 as  MarcadorProveedorCod,  'RELOJ MANUAL' as MarcadorProveedorDesc,  
'' as MarcadorProveedorIp, '' as real_ip ,'RM00000000001' as sn,  
'' as MarcadorClienteCod, '' as MarcadorDesc, '' as  MarcadorEstado,  
'' as MarcadorEstadoDesc  
  
  
End      

  --use zkbiotime
  --crear vista en zkbiotime
  --sp_helptext VerMarcacionesManuales
  CREATE View VerMarcacionesManuales    
  as          
  select  'RELOJ MANUAL' as NombreMarcador,          
   'RM00000000001' as CodigoMarcador,           
   punch_time as FechaHoraMarcacion,          
   emp.emp_code as CodigoEmpleado,           
  isnull((emp.first_name + ' '+  emp.last_name),'') as NombreEmpleado,          
   dbo.ObtenerFecha(punch_time) as FechaFormateada,               
   dbo.ObtenerHora(punch_time) as TiempoFormateado    
   --apply_reason    
  from zkbiotime.dbo.att_manuallog marcaciones     
  Inner join zkbiotime.dbo.workflow_workflowinstance MarcacionAprobacion     
  on workflowinstance_ptr_id = id    
    
  inner join  zkbiotime.dbo.personnel_employee emp            
  on MarcacionAprobacion.employee_id = emp.id 

  --inner join zkbiotime.dbo.iclock_terminal reloj      
  --on reloj.id = marcaciones.terminal_id      

  --actualizar el procedimeinto de traer marcaciones
  --exec [Spu_Int_Traer_AsistenciaGeneral] '20250501', '20250525', ''
  --sp_helptext [Spu_Int_Traer_AsistenciaGeneral]
CREATE Procedure [dbo].[Spu_Int_Traer_AsistenciaGeneral]                
( @fechainicio varchar(10), @fechafin varchar(10)         
 ,@marcadores varchar(max)        
)                          
as                          
 begin                          
--20241201                
--20241230                
    --marcadores        
         
 declare @tblMarcadores as table( idMarcador varchar(max) )        
 insert into @tblMarcadores        
 select value from dbo.SplitString(@marcadores,'|')        
 --select * from @tblMarcadores        
 if isnull(@marcadores,'') <>''        
 Begin        
  -- cargar por fecha inicio y fecha fin                      
  select NombreMarcador, CodigoMarcador, FechaHoraMarcacion, CodigoEmpleado, NombreEmpleado,                 
  FechaFormateada,     
  TiempoFormateado    ,      
   FechaFormateada  +  ' '+  dbo.FormatTime12Hour(TiempoFormateado) as TiempoFormateadoSicape      
  --ClaveIndiceEvtAsistencia , NombreEvtAsistencia,                 
  --Anio, Mes                      
  from zkbiotime.dbo.VerMarcacionesAsistencia                              
  inner join @tblMarcadores m         
  on m.idMarcador = zkbiotime.dbo.VerMarcacionesAsistencia.CodigoMarcador        
  where FechaHoraMarcacion >= Convert(datetime, @fechainicio + ' 00:00', 121)                           
  and   FechaHoraMarcacion <=  Convert(datetime, @fechafin + ' 23:59',121)        
  --and CodigoEmpleado='05300977'          
    
  union all     
    
  select NombreMarcador,     
  CodigoMarcador,     
  FechaHoraMarcacion,     
  CodigoEmpleado,     
  NombreEmpleado,      
  FechaFormateada,     
  TiempoFormateado,    
  FechaFormateada  +  ' '+  dbo.FormatTime12Hour(TiempoFormateado) as TiempoFormateadoSicape     
      
 from zkbiotime.dbo.VerMarcacionesManuales  
 INNER JOIN @tblMarcadores m  
 on m.idMarcador = zkbiotime.dbo.VerMarcacionesManuales.CodigoMarcador  
    where FechaHoraMarcacion >= Convert(datetime, @fechainicio + ' 00:00', 121)                       
    and   FechaHoraMarcacion <=  Convert(datetime, @fechafin + ' 23:59',121)            
     
    order  by FechaHoraMarcacion desc             
         
           
 End        
 else        
 Begin        
  -- cargar por fecha inicio y fecha fin                      
  select NombreMarcador, CodigoMarcador, FechaHoraMarcacion, CodigoEmpleado, NombreEmpleado,                 
  FechaFormateada, TiempoFormateado  ,      
  FechaFormateada  +  ' '+      
  dbo.FormatTime12Hour(TiempoFormateado) as TiempoFormateadoSicape      
  --ClaveIndiceEvtAsistencia , NombreEvtAsistencia,                 
  --Anio, Mes                      
  from zkbiotime.dbo.VerMarcacionesAsistencia                              
  --inner join @tblMarcadores m         
  --on m.idMarcador = zkbiotime.dbo.VerMarcacionesAsistencia.CodigoMarcador        
  where FechaHoraMarcacion >= Convert(datetime, @fechainicio + ' 00:00', 121)                           
  and   FechaHoraMarcacion <=  Convert(datetime, @fechafin + ' 23:59',121)          
    
  union all     
 select NombreMarcador,     
 CodigoMarcador,     
 FechaHoraMarcacion,     
 CodigoEmpleado,     
 NombreEmpleado,      
 FechaFormateada,     
 TiempoFormateado,    
 FechaFormateada  +  ' '+  dbo.FormatTime12Hour(TiempoFormateado) as TiempoFormateadoSicape     
 from zkbiotime.dbo.VerMarcacionesManuales                          
 where FechaHoraMarcacion >= Convert(datetime, @fechainicio + ' 00:00', 121)                      
 and   FechaHoraMarcacion <=  Convert(datetime, @fechafin + ' 23:59',121)          
  order  by FechaHoraMarcacion desc           
 end        
         
                 
                      
                           
 end 