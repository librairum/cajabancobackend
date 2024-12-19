--USE [LionsVentas]
GO

/****** Object:  StoredProcedure [dbo].[Spu_Seg_Trae_menuxperfil]    Script Date: 19/12/2024 15:33:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure  [dbo].[Spu_Seg_Trae_menuxperfil]    
@codigoPerfil int ,          
@cCodModulo char(2)                 
as                  
begin                  
select (m.nivel1 + m.nivel2 + m.nivel3) as CodigoFormulario,                   
 m.Etiqueta ,m.comando,f.nombre as nombreFormulario,                  
 m.nombreIcono, f.descripcion as DescripcionFormulario,   
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
GO


