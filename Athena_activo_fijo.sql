/**/
/*USO DE LA BASE DE DATOS*/
use activo_fijo
select *from  asignaciones 
select*from  personas p 
select *from activos_fijos 

/*Crear nuevo activo fijo.*/
insert  into activos_fijos (codigo, tipo_activo_id, descripcion) values ("MAC0001", 4, "Macbookair 15 chip M3")
/*Consultar la información de un activo fijo por su código de activo.*/
/*Opcion 1*/
select * from activos_fijos where codigo = 'MAC0001' and tipo_activo_id =4
/*Opcion 2*/
select 
activos_fijos.id_activo_fijo, 
activos_fijos.codigo,
tipo_activo.id_tipo_activo,
activos_fijos.descripcion 
from activos_fijos
inner join tipo_activo 
on activos_fijos.tipo_activo_id =tipo_activo.id_tipo_activo 
/*Consultar información general de las asignaciones de los activos concernientes con
Persona, Area de trabajo y activos.*/

SELECT
    personas.nombres  AS nombre_persona,
    areas_trabajo.nombre  AS nombre_area_trabajo,
    activos_fijos.codigo  AS codigo_activo
FROM
    personas
INNER JOIN
    areas_trabajo ON personas.areas_trabajo_id  = areas_trabajo.id_areas_trabajo 
INNER JOIN
    activos_fijos ON personas.id_persona = activos_fijos.id_activo_fijo;
   /*Asignar un activo.*/
     /*Crear la persona paa el activo.*/
   insert into personas (nombres, n_carnet,areas_trabajo_id) values("Gardenia","GU0001",3)
     /*creando el activo.*/
   insert into asignaciones (persona_id, activos_fijos_id)values (12, 30)
/*Eliminar una asignacion de activo.*/
    DELETE FROM asignaciones WHERE activos_fijos_id IN (SELECT id_activo_fijo FROM activos_fijos WHERE codigo = 'MAC0001' AND tipo_activo_id = 4);
DELETE FROM activos_fijos WHERE codigo = 'MAC0001' AND tipo_activo_id = 4;

