use premium_web
--go
--select create_date, name from sys.procedures order by create_date desc


--select type, create_date, modify_date , name from sys.objects where type= 'U' order by modify_date desc
go
Create procedure Spu_Ban_Trae_Prepagos  
@anio int,  
@mes int  
as  
Begin  
select Ban01Numero as 'Id Nro',convert(varchar(10),Ban01Fecha,103) as 'Fecha Pago',              
     P.Ban01Descripcion as 'Descripcion',E.Ban01Descripcion as 'Estado',E.Ban01Codigo as 'Codigo'              
     from Ban01PresupuestoPago P left join Ban01Estado E on P.Ban01Empresa=e.Ban01Empresa              
     and P.Ban01Estado=e.Ban01Codigo              
     where E.Ban01Codigo in(04,05)              
     and YEAR(Ban01Fecha)=@anio and MONTH(Ban01Fecha)=@Mes              
     order by 1 desc     
End  
Go
CREATE proc Spu_Seg_Trae_AutenticacionUsuario    
@NombreUsuario varchar(20),                            
@ClaveUsuario varchar(20) ,                  
@codigoEmpresa varchar(2)                
as                            
begin                             
Select * from Segusuario  usu     
where usu.Codigo = @NombreUsuario     
And usu.ClaveUsuario = @ClaveUsuario      
And usu.CodigoEmpresa = @codigoEmpresa      
end      
go
CREATE procedure Spu_Ban_Upd_Bancos    
@Ban01Empresa varchar(2),    
@Ban01IdBanco varchar(3),    
@Ban01Descripcion varchar(400),    
@Ban01Prefijo varchar(10) ,  
@mensaje varchar(200) output,  
@flag int output   
as    
Begin    
 Begin transaction    
    
    
  --insert into Ban01Banco(Ban01Empresa,Ban01IdBanco,Ban01Descripcion,Ban01Prefijo)          
  --   values (@Ban01Empresa,@Ban01IdBanco,@Ban01Descripcion,@Ban01Prefijo)        
  update Ban01Banco set Ban01Descripcion=@Ban01Descripcion ,Ban01Prefijo=@Ban01Prefijo         
    where Ban01Empresa=@Ban01Empresa and Ban01IdBanco=@Ban01IdBanco        
    
 if @@Error <> 0     
 Begin    
  set @mensaje = 'Error al actualizar'  
  Goto ManejaError    
 End    
    
 set @mensaje = 'Actualizacion exitosa'  
 set @flag = 1  
 Commit transaction    
 return 1    
    
 ManejaError:   
 set @flag = -1   
 Rollback transaction    
    
 return -1    
End    
go

CREATE procedure Spu_Ban_Ins_Bancos    
@Ban01Empresa varchar(2),    
@Ban01IdBanco varchar(3),    
@Ban01Descripcion varchar(400),    
@Ban01Prefijo varchar(10),  
@mensaje varchar(200) output,  
@flag int output  
as    
Begin    
 Begin transaction    
 declare @numero int    
 declare @Ban01NumBanco varchar(2)    
 select @numero =MAX(RIGHT(Ban01IdBanco,2))+1 from Ban01Banco     
   if @numero is null          
  begin          
    set @Ban01NumBanco='01'          
  end          
      else          
  begin          
   set @Ban01NumBanco= replicate('0',2-len(@numero))+ ltrim(STR(@numero))          
  end      
    
    
  insert into Ban01Banco(Ban01Empresa,Ban01IdBanco,Ban01Descripcion,Ban01Prefijo)          
     values (@Ban01Empresa,@Ban01NumBanco,@Ban01Descripcion,@Ban01Prefijo)        
    
 if @@Error <> 0     
 Begin    
 set @mensaje = 'Error al insertar'  
  Goto ManejaError    
 End    
    
 set @mensaje = 'inseracion exitosa'  
 set @flag = 1   
 Commit transaction    
 return 1    
    
 ManejaError:    
 set @flag = -1  
 Rollback transaction    
    
 return -1    
End    
go

CREATE  procedure Spu_Ban_Del_Bancos      
@Ban01Empresa varchar(2),      
@Ban01IdBanco varchar(3),  
@mensaje varchar(200) output,  
@flag int output  
as      
Begin      
 Begin transaction      
      
      
  --insert into Ban01Banco(Ban01Empresa,Ban01IdBanco,Ban01Descripcion,Ban01Prefijo)            
  --   values (@Ban01Empresa,@Ban01IdBanco,@Ban01Descripcion,@Ban01Prefijo)          
  delete from Ban01Banco             
    where Ban01Empresa=@Ban01Empresa and Ban01IdBanco=@Ban01IdBanco      
      
 if @@Error <> 0       
 Begin      
  set @mensaje = 'Error al eliminar'  
  Goto ManejaError     
    
 End      
   
 set @mensaje = 'Eliminacion Exitosa'    
 set @flag = 1  
 Commit transaction      
 return 1      
      
 ManejaError:      
 set @flag = -1  
 Rollback transaction      
      
 return -1      
End    
go
create procedure Spu_Ban_Ins_CuentaBancaria    
@Ban01Empresa varchar(2),    
@Ban01IdBanco varchar(3),    
@Ban01IdCuenta varchar(20),    
@Ban01IdNro varchar(5),    
@Ban01Moneda varchar(5),    
@Ban01Descripcion varchar(400),    
@Ban01CuentaContable varchar(15),    
@Ban01Itf varchar(10),    
@Ban01Prefijo varchar(10),    
@Ban01CtaDet varchar(10)    
as    
begin    
Begin transaction    
--sp_help Ban01CuentaBancaria    
    
        
    declare @numero as int    
    declare @Ban01NumBanco as varchar(2)    
   select @numero =MAX(RIGHT(Ban01IdNro,2))+1 from Ban01CuentaBancaria          
    if @numero is null          
     begin          
      set @Ban01NumBanco='01'          
     end          
    else          
     begin          
     set @Ban01NumBanco= replicate('0',2-len(@numero))+ ltrim(STR(@numero))          
     end          
  --sp_help Ban01CuentaBancaria    
    insert into Ban01CuentaBancaria(Ban01Empresa,    
Ban01IdBanco,    
Ban01IdCuenta,    
Ban01IdNro,    
Ban01Moneda,    
Ban01Descripcion,    
Ban01CuentaContable,    
Ban01Itf,    
Ban01Prefijo,    
Ban01CtaDet)          
     values (@Ban01Empresa,    
@Ban01IdBanco,    
@Ban01IdCuenta,    
@Ban01NumBanco,    
@Ban01Moneda,    
@Ban01Descripcion,    
@Ban01CuentaContable,    
@Ban01Itf,    
@Ban01Prefijo,    
@Ban01CtaDet)        
    
 if @@Error <> 0     
 Begin    
  Goto ManejaError    
 End    
    
 Commit transaction    
 return 1    
    
 ManejaError:    
 Rollback transaction    
    
 return -1    
End    
go
create procedure Spu_Ban_Upd_CuentaBancaria    
@Ban01Empresa varchar(2),    
@Ban01IdBanco varchar(3),    
@Ban01IdCuenta varchar(20),    
@Ban01IdNro varchar(5),    
@Ban01Moneda varchar(5),    
@Ban01Descripcion varchar(400),    
@Ban01CuentaContable varchar(15),    
@Ban01Itf varchar(10),    
@Ban01Prefijo varchar(10),    
@Ban01CtaDet varchar(10)    
as    
begin    
Begin transaction    
--sp_help Ban01CuentaBancaria    
    
        
       
   update Ban01CuentaBancaria set Ban01IdCuenta=@Ban01IdCuenta,Ban01Moneda=@Ban01Moneda,          
     Ban01Descripcion=@Ban01Descripcion,Ban01CuentaContable=@Ban01CuentaContable, Ban01Itf=@Ban01Itf,          
     Ban01Prefijo=@Ban01Prefijo , Ban01CtaDet=@Ban01CtaDet        
    where Ban01Empresa=@Ban01Empresa and Ban01IdNro=@Ban01IdNro     
 -- and Ban01IdBanco = @Ban01IdBanco     
 --select * from Ban01CuentaBancaria where Ban01Empresa = '01' and     
 if @@Error <> 0     
 Begin    
  Goto ManejaError    
 End    
    
 Commit transaction    
 return 1    
    
 ManejaError:    
 Rollback transaction    
    
 return -1    
End    
go
create procedure Spu_Ban_Del_CuentaBancaria    
@Ban01Empresa varchar(2),     
--@Ban01IdCuenta varchar(20),     
--@Ban01IdBanco varchar(5),    
@Ban01IdNro varchar(5)    
as    
Begin    
    
Begin transaction    
    
Delete from Ban01CuentaBancaria    
where Ban01Empresa = @Ban01Empresa    
and Ban01IdNro = @Ban01IdNro    
if @@error <> 0     
begin    
 Goto ManejaError    
end    
Commit transaction    
return 1    
ManejaError:    
 Rollback transaction    
    
 return -1    
end  
go
Create procedure Spu_Ban_Trae_CuentaBancaria  
@Ban01Empresa varchar(2),  
@Ban01IdBanco varchar(3)  
as  
Begin  
select CB.Ban01IdCuenta as 'Id Cuenta',B.Ban01Descripcion as 'Banco', --B.Ban01IdBanco+' '+                
    (case CB.Ban01Moneda when 'S' then 'Soles' else 'Dolares' end) 'Moneda',                
    CB.Ban01Descripcion as 'Cuenta Bancaria',CB.Ban01IdNro as 'ID',                
    isnull(cb.Ban01CuentaContable,'') as 'Cta Contable',CB.Ban01Itf as 'Cta ITF',CB.Ban01Prefijo as 'Pref' ,Ban01CtaDet as 'Cta Gastos'               
  from Ban01CuentaBancaria CB inner join Ban01Banco B on B.Ban01IdBanco=CB.Ban01IdBanco                
  where CB.Ban01Empresa=@Ban01Empresa  and B.Ban01IdBanco=@Ban01IdBanco      
  
End
go
CREATE procedure Spu_Ban_Trae_Bancos  
  
@Ban01Empresa varchar(2),  
@Ban01Descripcion varchar(400)  
as  
Begin  
 select Ban01IdBanco as 'ID',   
  Ban01Descripcion as 'Bancos',  
  Ban01IdBanco+' '+Ban01Descripcion as 'NBancos' ,  
  isnull(Ban01Prefijo,'') as 'Alias',  
  Ban01Empresa, Ban01IdBanco, Ban01Descripcion, Ban01Prefijo  
  from Ban01Banco                
  where Ban01Empresa=@Ban01Empresa and Ban01IdBanco not like '00'   
  and Ban01Descripcion like '%'+ (@Ban01Descripcion)+'%'  
end
go
CREATE procedure  [dbo].[Spu_Seg_Trae_menuxperfil]      
@codigoPerfil int ,            
@cCodModulo char(2)                   
as                    
begin                    
select (m.nivel1 + m.nivel2 + m.nivel3) as CodigoFormulario,                     
 m.Etiqueta ,m.comando,isnull(f.nombre,'') as nombreFormulario,                    
 m.nombreIcono, isnull(f.descripcion,'') as DescripcionFormulario,     
 p.codigo as  CodigoPerfil,    
 p.nombre as NomPerfil    
 from segmenu m           
 -- menu x perfil          
 Left join segmenuxperfil  mp            
 on  m.codigo = mp.codigoMenu       
 and  m.codmodulo = mp.codmodulo       
 -- Perfil          
 left join segperfil p           
 on mp.codigoperfil =  p.codigo           
 -- Formulario          
 left join segformulario f                     
 on  m.codigoFormulario = f.codigo       
     and  m.codmodulo = f.codmodulo      
           
 --          
 where mp.codigoperfil =  @codigoPerfil           
 and mp.codmodulo = @cCodModulo              
 order by CodigoFormulario asc                
end    









--Spu_Ban01_Insert_BancosNumeros
