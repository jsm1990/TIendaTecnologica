CREATE DATABASE TIENDA_COMPRAS
GO

USE TIENDA_COMPRAS
GO 

--DROP TABLE USUARIOS
--GO

--DROP TABLE DETALLE_VENTA
--GO 

--DROP TABLE PRODUCTOS
--GO 

--DROP TABLE CATEGORIAS 
--GO 

--DROP TABLE VENTA
--GO 

--DROP TABLE CONTACTO
--GO 
--========================================================================================================
-- REALIZADO POR : MARÍA LAURA ALFARO ESPINOZA
-- DESCRIPCIÓN   : TABLA QUE CONTIENE LOS USUARIOS DEL SISTEMA
--========================================================================================================
CREATE TABLE USUARIOS 
(
    USU_ID			  INTEGER         IDENTITY(1,1)    NOT NULL,        
    USU_NOMBRE        VARCHAR(60)     DEFAULT('')	   NOT NULL,
	USU_CORREO        VARCHAR(30)     DEFAULT('')	   NOT NULL,
	USU_USUARIO       VARCHAR(30)     DEFAULT('')      NOT NULL, 
	USU_CONTRASEÑA    VARCHAR(30)     DEFAULT('')      NOT NULL,  

	--LLAVE PRIMARIA 
    CONSTRAINT PK_USUARIOS PRIMARY KEY CLUSTERED (USU_ID)      
)
GO

--========================================================================================================
-- REALIZADO POR : MARÍA LAURA ALFARO ESPINOZA
-- DESCRIPCIÓN   : TABLA QUE CONTIENE LAS CATEGORÍAS DE LOS PRODUCTOS 
--========================================================================================================
CREATE TABLE CATEGORIAS
(
    CAT_ID				  CHAR(4)         DEFAULT('')       NOT NULL,        
    CAT_DESCRICION        VARCHAR(40)     DEFAULT('')	    NOT NULL, 

	--LLAVE PRIMARIA 
    CONSTRAINT PK_CATEGORIAS PRIMARY KEY CLUSTERED (CAT_ID)      
)
GO

--========================================================================================================
-- REALIZADO POR : MARÍA LAURA ALFARO ESPINOZA
-- DESCRIPCIÓN   : TABLA QUE CONTIENE LOS PRODUCTOS A COMPRAR 
--========================================================================================================
CREATE TABLE PRODUCTOS
(
    PRO_ID				  CHAR(4)         DEFAULT('')       NOT NULL, 
	CAT_ID			      CHAR(4)         DEFAULT('')	    NOT NULL,       
    PRO_DESCRICION        VARCHAR(100)    DEFAULT('')	    NOT NULL, 
    PRO_PRECIO			  DECIMAL(18,2)	  DEFAULT(0)	    NOT NULL,  
    PRO_CANTIDAD		  SMALLINT	      DEFAULT(0)	    NOT NULL,  
    PRO_IMAGEN            VARCHAR(40)     DEFAULT('')       NOT NULL,

	--LLAVE PRIMARIA 
    CONSTRAINT PK_PRODUCTOS PRIMARY KEY CLUSTERED (PRO_ID)      
)
GO

ALTER TABLE PRODUCTOS ADD CONSTRAINT FK_PRO_CAT
    FOREIGN KEY(CAT_ID)
    REFERENCES CATEGORIAS(CAT_ID)
GO

--========================================================================================================
-- REALIZADO POR : MARÍA LAURA ALFARO ESPINOZA
-- DESCRIPCIÓN   : TABLA QUE CONTIENE LAS VENTAS DE LOS PRODUCTOS 
--========================================================================================================
CREATE TABLE VENTA
(
    VEN_ID          CHAR(6)          DEFAULT('')       NOT NULL, 
	VEN_FECHA       VARCHAR(50)      DEFAULT('')       NOT NULL, 
	VEN_SUBTOTAL    DECIMAL(13,2)    DEFAULT(0)        NOT NULL, 
	VEN_IMPUESTO    DECIMAL(13,2)    DEFAULT(0)        NOT NULL, 
	VEN_TOTAL       DECIMAL(13,2)    DEFAULT(0)        NOT NULL, 
	VEN_CLIENTE     VARCHAR(60)      DEFAULT('')       NOT NULL                         

	--LLAVE PRIMARIA 
    CONSTRAINT PK_VENTA PRIMARY KEY CLUSTERED (VEN_ID)      
)
GO

--========================================================================================================
-- REALIZADO POR : MARÍA LAURA ALFARO ESPINOZA
-- DESCRIPCIÓN   : TABLA QUE CONTIENE EL DETALLE DE LA VENTA DE LOS PRODUCTOS 
--========================================================================================================
CREATE TABLE DETALLE_VENTA
(
    DET_ID				  CHAR(10)          DEFAULT('')       NOT NULL,        
    PRO_ID				  CHAR(4)           DEFAULT('')       NOT NULL, 
    VEN_ID                CHAR(6)           DEFAULT('')       NOT NULL,
	DET_CANTIDAD          SMALLINT          DEFAULT(0)        NOT NULL, 
	DET_PRECIO            DECIMAL(13,2)     DEFAULT(0)        NOT NULL, 
	DET_SUBTOTAL          DECIMAL(13,2)     DEFAULT(0)        NOT NULL           

	--LLAVE PRIMARIA 
    CONSTRAINT PK_DETALLE_VENTA PRIMARY KEY CLUSTERED (DET_ID)      
)
GO

CREATE TABLE CONTACTO
(
    CON_ID				  INT			Identity(1,1)   NOT NULL, 
	CON_NOMBRE			  VARCHAR(50)   DEFAULT('')	    NOT NULL,       
    CON_Email			  VARCHAR(50)   DEFAULT('')	    NOT NULL, 
    CON_MENSAJE			  VARCHAR(200)	DEFAULT('')	    NOT NULL,  
 
	--LLAVE PRIMARIA 
    CONSTRAINT PK_CONTACTO PRIMARY KEY CLUSTERED (CON_ID)      
)
GO

ALTER TABLE DETALLE_VENTA ADD CONSTRAINT FK_DET_PRO 
    FOREIGN KEY(PRO_ID)
    REFERENCES PRODUCTOS(PRO_ID)
GO

ALTER TABLE DETALLE_VENTA ADD CONSTRAINT FK_DET_VEN 
    FOREIGN KEY(VEN_ID)
    REFERENCES VENTA(VEN_ID)
GO

-- INSERTS USUARIOS  
INSERT INTO USUARIOS (USU_NOMBRE, USU_CORREO, USU_USUARIO, USU_CONTRASEÑA) VALUES('María Laura Alfaro Espinoza', 'marilau.alfaroe@gmail.com', 'marilau', '12345')

-- INSERTS CATEGORÍAS 
INSERT INTO CATEGORIAS (CAT_ID, CAT_DESCRICION) VALUES('0001', 'Computadoras')
INSERT INTO CATEGORIAS (CAT_ID, CAT_DESCRICION) VALUES('0002', 'Celulares')
INSERT INTO CATEGORIAS (CAT_ID, CAT_DESCRICION) VALUES('0003', 'Periféricos')
INSERT INTO CATEGORIAS (CAT_ID, CAT_DESCRICION) VALUES('0004', 'Componentes')
INSERT INTO CATEGORIAS (CAT_ID, CAT_DESCRICION) VALUES('0005', 'Videojuegos')
-- INSERTS PRODUCTOS 
INSERT INTO PRODUCTOS (PRO_ID, CAT_ID, PRO_DESCRICION, PRO_PRECIO, PRO_CANTIDAD, PRO_IMAGEN) 
VALUES('0001', '0001', 'HP AIO 20-C303LA Pentium J4205 - 4GB - 500GB - 19.5" - Windows 10', 525000, 30, 'hp1.jpg')

INSERT INTO PRODUCTOS (PRO_ID, CAT_ID, PRO_DESCRICION, PRO_PRECIO, PRO_CANTIDAD, PRO_IMAGEN) 
VALUES('0002', '0001', 'IGAMING SPEED - RYZEN 5 2600X - SSD 240GB - RX 590 - 8GB - 1TB', 560000, 20, 'igaming1.jpg')

INSERT INTO PRODUCTOS (PRO_ID, CAT_ID, PRO_DESCRICION, PRO_PRECIO, PRO_CANTIDAD, PRO_IMAGEN) 
VALUES('0003', '0002', 'SAMSUNG GALAXY S10+', 500000, 30, 'samsung1.jpg')

INSERT INTO PRODUCTOS (PRO_ID, CAT_ID, PRO_DESCRICION, PRO_PRECIO, PRO_CANTIDAD, PRO_IMAGEN) 
VALUES('0004', '0003', 'Cable X - TECH con Conector HDMI Macho - HDMI Macho - 1.8mts', 1800, 15, 'cablex.jpg')

INSERT INTO PRODUCTOS (PRO_ID, CAT_ID, PRO_DESCRICION, PRO_PRECIO, PRO_CANTIDAD, PRO_IMAGEN) 
VALUES('0005', '0004', 'Case In Win Chopin Negro - Mini ITX', 50000, 20, 'case1.jpg')

INSERT INTO PRODUCTOS (PRO_ID, CAT_ID, PRO_DESCRICION, PRO_PRECIO, PRO_CANTIDAD, PRO_IMAGEN) 
VALUES('0006', '0005', 'Xbox One S 1TB Console - Gears of War 4 Bundle', 240000, 20, 'xbox.jpg')

INSERT INTO PRODUCTOS (PRO_ID, CAT_ID, PRO_DESCRICION, PRO_PRECIO, PRO_CANTIDAD, PRO_IMAGEN) 
VALUES('0007', '0005', 'Nintendo Switch – Neon Red and Neon Blue Joy-Con', 180000, 20, 'nintendo.jpg')

INSERT INTO PRODUCTOS (PRO_ID, CAT_ID, PRO_DESCRICION, PRO_PRECIO, PRO_CANTIDAD, PRO_IMAGEN) 
VALUES('0008', '0005', 'PlayStation 4 Slim 1TB Console - Marvel Spider-Man Bundle', 220000, 20, 'PS4.jpg')

