CREATE DATABASE store;

USE store;

CREATE TABLE productos(
idproducto INT PRIMARY KEY AUTO_INCREMENT,
nombre VARCHAR(255),
descripcion VARCHAR(255),
precio DECIMAL(9,2),
create_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
update_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP);

DELIMITER //
DROP PROCEDURE if EXISTS p_errorHandler;
CREATE PROCEDURE p_errorHandler

(
	IN _errorHandler INT 
)
BEGIN 

	DECLARE errorMensaje VARCHAR(255);
	
	case _errorHandler
	when 1062 then 
		SET errorMensaje = 'Error: Registro duplicado';
	
	when 1292 then 
		SET errorMensaje = 'Error: Tipo de dato incorrecto';
	
	when 1054 then 
		SET errorMensaje = 'Error: La columna no existe';
	ELSE 
		SET errorMensaje = 'Error: Desconocido';
	END case;
	SELECT errorMensaje AS ERROR;

END //
DELIMITER ;

DELIMITER //
DROP PROCEDURE IF EXISTS p_InsertarProductos;
CREATE PROCEDURE p_InsertarProductos
(
    IN _nombre VARCHAR(255),
    IN _descripcion VARCHAR(255),
    IN _precio DECIMAL(9,2)
)
BEGIN
    DECLARE exit handler FOR 1062 CALL p_errorHandler(1062);
    DECLARE exit handler FOR 1054 CALL p_errorHandler(1054);
    DECLARE exit handler FOR 1292 CALL p_errorHandler(1292);
    
    INSERT INTO productos (nombre, descripcion, precio)
    VALUES (_nombre, _descripcion, _precio);
END //
DELIMITER ;


DELIMITER //
DROP PROCEDURE IF EXISTS p_ModificarProductos;
CREATE PROCEDURE p_ModificarProductos
(
    IN _idproducto INT,
    IN _nombre VARCHAR(255),
    IN _descripcion VARCHAR(255),
    IN _precio DECIMAL(9,2)
)
BEGIN
    DECLARE exit handler FOR 1062 CALL p_errorHandler(1062);
    DECLARE exit handler FOR 1054 CALL p_errorHandler(1054);
    DECLARE exit handler FOR 1292 CALL p_errorHandler(1292);
    
    UPDATE productos
    SET nombre = _nombre, descripcion = _descripcion, precio = _precio
    WHERE idproducto = _idproducto;
END //
DELIMITER ;

DELIMITER //
DROP PROCEDURE IF EXISTS p_EliminarProductos;
CREATE PROCEDURE p_EliminarProductos
(
    IN _idproducto INT
)
BEGIN
    DECLARE exit handler FOR 1062 CALL p_errorHandler(1062);
    DECLARE exit handler FOR 1054 CALL p_errorHandler(1054);
    DECLARE exit handler FOR 1292 CALL p_errorHandler(1292);
    
    DELETE FROM productos
    WHERE idproducto = _idproducto;
END //
DELIMITER ;

SELECT * FROM productos;