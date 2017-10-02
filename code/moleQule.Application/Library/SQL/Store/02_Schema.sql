-- STORE MODULE SCHEMA TABLES

DROP TABLE IF EXISTS "AlbaranProveedor" CASCADE;
CREATE TABLE "AlbaranProveedor" 
( 
	"OID" bigserial NOT NULL,
	"OID_SERIE" bigint,
    "OID_ACREEDOR" bigint,
    "TIPO_ACREEDOR" bigint,
    "SERIAL" bigint DEFAULT 0 NOT NULL,
    "CODIGO" character varying(255),
    "ANO" bigint,
    "FECHA" timestamp without time zone,
    "FECHA_REGISTRO" timestamp without time zone,
    "FORMA_PAGO" bigint DEFAULT 1,
    "DIAS_PAGO" bigint DEFAULT 0,
    "MEDIO_PAGO" bigint DEFAULT 1,
    "PREVISION_PAGO" date,
    "P_IRPF" numeric(10,2),
    "P_DESCUENTO" numeric(10,2),
    "DESCUENTO" numeric(10,2) DEFAULT 0,
    "BASE_IMPONIBLE" numeric(10,2),
    "IGIC" numeric(10,2),
    "TOTAL" numeric(10,2),
    "CUENTA_BANCARIA" character varying(255),
    "NOTA" boolean,
    "OBSERVACIONES" text,
    "CONTADO" boolean DEFAULT false NOT NULL,
    "RECTIFICATIVO" boolean DEFAULT false,
    "ESTADO" bigint DEFAULT 1,
    "OID_ALMACEN" bigint DEFAULT 0,
    "OID_EXPEDIENTE" bigint DEFAULT 0,
    "OID_USUARIO" bigint DEFAULT 0,
    "EXPEDIENTE" character varying(255),
	CONSTRAINT "PK_AlbaranProveedor" PRIMARY KEY ("OID")	
) WITHOUT OIDS;

ALTER TABLE "AlbaranProveedor" OWNER TO moladmin;
GRANT ALL ON TABLE "AlbaranProveedor" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE IF EXISTS "Albaran_FacturaProveedor" CASCADE;
CREATE TABLE "Albaran_FacturaProveedor" 
( 
	"OID" bigserial NOT NULL,
	"OID_ALBARAN" bigint NOT NULL,
    "OID_FACTURA" bigint NOT NULL,
    "FECHA_ASIGNACION" date,
	CONSTRAINT "PK_Albaran_FacturaProveedor" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "Albaran_FacturaProveedor" OWNER TO moladmin;
GRANT ALL ON TABLE "Albaran_FacturaProveedor" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE IF EXISTS "Almacen" CASCADE;
CREATE TABLE "Almacen" 
( 
	"OID" bigserial  NOT NULL,
	"NOMBRE" character varying(255),
    "UBICACION" character varying(255),
    "OBSERVACIONES" text,
    "SERIAL" bigint,
    "CODIGO" character varying(255),
    "ESTADO" bigint DEFAULT 10,
	CONSTRAINT "PK_Almacen" PRIMARY KEY ("OID")
) WITHOUT OIDS;
            
ALTER TABLE "Almacen" OWNER TO moladmin;
GRANT ALL ON TABLE "Almacen" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE IF EXISTS "Cabeza" CASCADE;
CREATE TABLE "Cabeza" 
( 
	"OID" bigserial NOT NULL,
	"OID_EXPEDIENTE" bigint,
    "OID_PRODUCTO_EXPEDIENTE" bigint DEFAULT 0 NOT NULL,
    "CODIGO" character varying(255) NOT NULL,
    "IDENTIFICADOR" character varying(255),
    "RAZA" character varying(255),
    "TIPO" character varying(255),
    "SEXO" character varying(255),
    "OBSERVACIONES" text,
	CONSTRAINT "PK_Cabeza" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "Cabeza" OWNER TO moladmin;
GRANT ALL ON TABLE "Cabeza" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE IF EXISTS "ConceptoAlbaranProveedor";
CREATE TABLE "ConceptoAlbaranProveedor" 
( 
	"OID" bigserial NOT NULL,
	"OID_ALBARAN" bigint,
    "OID_PRODUCTO_EXPEDIENTE" bigint,
    "OID_EXPEDIENTE" bigint,
    "OID_PRODUCTO" bigint,
    "OID_KIT" bigint DEFAULT 0 NOT NULL,
    "CODIGO_EXPEDIENTE" character varying(255),
    "CONCEPTO" character varying(255),
    "FACTURACION_BULTO" boolean,
    "CANTIDAD" numeric(10,2),
    "CANTIDAD_BULTOS" numeric(10,4),
    "P_IGIC" numeric(10,2),
    "P_DESCUENTO" numeric(10,2),
    "TOTAL" numeric(10,2),
    "PRECIO" numeric(10,5),
    "SUBTOTAL" numeric(10,2),
    "GASTOS" numeric(10,5),
    "OID_IMPUESTO" bigint,
    "OID_LINEA_PEDIDO" bigint DEFAULT 0,
    "OID_ALMACEN" bigint DEFAULT 0,
    "CODIGO_PRODUCTO_PROVEEDOR" character varying(255),	
	CONSTRAINT "PK_ConceptoAlbaranProveedor" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "ConceptoAlbaranProveedor" OWNER TO moladmin;
GRANT ALL ON TABLE "ConceptoAlbaranProveedor" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE IF EXISTS "ConceptoFacturaProveedor";
CREATE TABLE "ConceptoFacturaProveedor" 
( 
	"OID" bigserial NOT NULL,
	"OID_FACTURA" bigint,
    "OID_PRODUCTO_EXPEDIENTE" bigint,
    "OID_EXPEDIENTE" bigint,
    "OID_PRODUCTO" bigint,
    "OID_KIT" bigint DEFAULT 0 NOT NULL,
    "OID_CONCEPTO_ALBARAN" bigint,
    "CODIGO_EXPEDIENTE" character varying(255),
    "CONCEPTO" character varying(255),
    "FACTURACION_BULTO" boolean,
    "CANTIDAD" numeric(10,2),
    "CANTIDAD_BULTOS" numeric(10,4),
    "P_IGIC" numeric(10,2),
    "P_DESCUENTO" numeric(10,2),
    "TOTAL" numeric(10,2),
    "PRECIO" numeric(10,5),
    "SUBTOTAL" numeric(10,2),
    "OID_IMPUESTO" bigint,
    "CODIGO_PRODUCTO_PROVEEDOR" character varying(255),
	CONSTRAINT "PK_ConceptoFacturaProveedor" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "ConceptoFacturaProveedor" OWNER TO moladmin;
GRANT ALL ON TABLE "ConceptoFacturaProveedor" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE IF EXISTS "Despachante" CASCADE;
CREATE TABLE "Despachante" 
( 
	"OID" bigserial NOT NULL,
	"CODIGO" character varying(255) NOT NULL,
    "SERIAL" bigint DEFAULT 0 NOT NULL,
    "ID" character varying(50),
    "TIPO_ID" bigint DEFAULT 0 NOT NULL,
    "NOMBRE" character varying(255),
    "ALIAS" character varying(255),
    "MEDIO_PAGO" bigint DEFAULT 1,
    "FORMA_PAGO" bigint DEFAULT 1,
    "DIAS_PAGO" bigint,
    "CUENTA_BANCARIA" character varying(255),
    "CUENTA_ASOCIADA" character varying(255),
    "CONTACTO" character varying(255),
    "EMAIL" character varying(255),
    "DIRECCION" character varying(255),
    "LOCALIDAD" character varying(255),
    "TELEFONO" character varying(255),
    "COD_POSTAL" character varying(255),
    "PROVINCIA" character varying(255),
    "MUNICIPIO" character varying(255),
    "PAIS" character varying(255),
    "OBSERVACIONES" text,
    "OID_CUENTA_BANCARIA_ASOCIADA" bigint DEFAULT 0,
    "CUENTA_CONTABLE" text,
    "OID_IMPUESTO" bigint,
    "TIPO" bigint DEFAULT 5,
    "ESTADO" integer DEFAULT 10,	
	CONSTRAINT "PK_Despachante" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "Despachante" OWNER TO moladmin;
GRANT ALL ON TABLE "Despachante" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE IF EXISTS "Empleado";
CREATE TABLE "Empleado"
(
	"OID" bigserial NOT NULL,
	"OID_IMPUESTO" bigint,
	"TIPO" bigint DEFAULT 8,
	"CODIGO" varchar(255) NOT NULL UNIQUE,
	"SERIAL" int8 NOT NULL,
	"ESTADO" bigint DEFAULT 10,
	"NOMBRE" varchar(255),
	"NOMBRE_PROPIO" varchar(255),
	"APELLIDOS" varchar(255),
	"ALIAS" character varying(255) NOT NULL,
  	"ID" varchar(50),
	"TIPO_ID" int8 NOT NULL DEFAULT 0,
	"DIRECCION" varchar(255),
	"COD_POSTAL" varchar(255),
	"LOCALIDAD" varchar(255),
	"MUNICIPIO" varchar(255),
	"PROVINCIA" varchar(255),
	"PAIS" character varying(255),
  	"TELEFONO" varchar(255),
    "EMAIL" character varying(255),
	"FOTO" varchar(255),
	"PERFIL" int8 NOT NULL,
	"ACTIVO" bool DEFAULT true,
	"INICIO_CONTRATO" date,
	"FIN_CONTRATO" date,	
	"CUENTA_BANCARIA" character varying(255),
	"OID_CUENTA_BANCARIA_ASOCIADA" bigint DEFAULT 0,
	"CUENTA_CONTABLE" character varying(255),
	"MEDIO_PAGO" bigint DEFAULT 1,
	"FORMA_PAGO" bigint DEFAULT 1,
	"DIAS_PAGO" bigint,
	"CONTACTO" character varying(255),
	"NIVEL_ESTUDIOS" varchar(255),
	"OBSERVACIONES" text,
	"SUELDO_BRUTO" numeric(10,2) DEFAULT 0,
	"P_IRPF" numeric(10,2) DEFAULT 0,
	"CUENTA_ASOCIADA" character varying(255),	
	CONSTRAINT "EMPLEADO_PK" PRIMARY KEY ("OID")
)WITHOUT OIDS;

ALTER TABLE "Empleado" OWNER TO moladmin;
GRANT ALL ON TABLE "Empleado" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE IF EXISTS "Expediente";
CREATE TABLE "Expediente" 
( 
	"OID" bigserial NOT NULL,
	"OID_NAVIERA" bigint,
    "OID_TRANS_ORIGEN" bigint,
    "OID_TRANS_DESTINO" bigint,
    "OID_DESPACHANTE" bigint,
    "OID_FACTURA_PRO" bigint,
    "OID_FACTURA_NAV" bigint,
    "OID_FACTURA_DES" bigint,
    "OID_FACTURA_TOR" bigint,
    "OID_FACTURA_TDE" bigint,
    "TIPO_EXPEDIENTE" bigint DEFAULT 0 NOT NULL,
    "SERIAL" bigint DEFAULT 0 NOT NULL,
    "CODIGO" character varying(255),
    "PUERTO_ORIGEN" character varying(255),
    "PUERTO_DESTINO" character varying(255),
    "BUQUE" character varying(255),
    "ANO" integer DEFAULT 1,
    "FECHA_PEDIDO" date,
    "FECHA_FAC_PROVEEDOR" date,
    "FECHA_EMBARQUE" date,
    "FECHA_LLEGADA_MUELLE" date,
    "FECHA_DESPACHO_DESTINO" date,
    "FECHA_SALIDA_MUELLE" date,
    "FECHA_REGRESO_MUELLE" date,
    "OBSERVACIONES" text,
    "FLETE_NETO" numeric(10,2),
    "BAF" numeric(10,2),
    "TEUS20" boolean,
    "TEUS40" boolean,
    "T3_ORIGEN" numeric(10,2),
    "T3_DESTINO" numeric(10,2),
    "THC_ORIGEN" numeric(10,2),
    "THC_DESTINO" numeric(10,2),
    "ISPS" numeric(10,2),
    "TOTAL_IMPUESTOS" numeric(10,2),
    "G_TRANS_FAC" character varying(255),
    "G_TRANS_TOTAL" numeric(10,2),
    "N_DUA" character varying(255),
    "G_NAV_FAC" character varying(255),
    "G_NAV_TOTAL" numeric(10,2),
    "G_DESP_FAC" character varying(255),
    "G_DESP_TOTAL" numeric(10,2),
    "G_DESP_IGIC" numeric(10,2),
    "G_DESP_IGIC_SERV" numeric(10,2),
    "G_TRANS_DEST_FAC" character varying(255),
    "G_TRANS_DEST_TOTAL" numeric(10,2),
    "G_TRANS_DEST_IGIC" numeric(10,2),
    "CONTENEDOR" character varying(255),
    "OID_PROVEEDOR" bigint,
    "G_PROV_FAC" character varying(255),
    "G_PROV_TOTAL" numeric(10,2),
    "CUENTA_REA" character varying(255),
    "EXPEDIENTE_REA" character varying(255),
    "CERTIFICADO_REA" character varying(255),
    "COBRO_REA" timestamp without time zone,
    "TIPO_MERCANCIA" character varying(255),
    "NOMBRE_CLIENTE" character varying(255),
    "CODIGO_ARTICULO" character varying(255),
    "NOMBRE_TRANS_DEST" character varying(255),
    "NOMBRE_TRANS_ORIG" character varying(255),
    "AYUDAS" numeric(10,2) DEFAULT 0,
    "AYUDA" boolean DEFAULT true,
    "ESTIMAR_DESPACHANTE" boolean DEFAULT true,
    "ESTIMAR_NAVIERA" boolean DEFAULT true,
    "ESTIMAR_TORIGEN" boolean DEFAULT true,
    "ESTIMAR_TDESTINO" boolean DEFAULT true,
    "FECHA" timestamp without time zone,
	CONSTRAINT "PK_Expediente" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "Expediente" OWNER TO moladmin;
GRANT ALL ON TABLE "Expediente" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE IF EXISTS "ExpedienteREA";
CREATE TABLE "ExpedienteREA" 
( 
	"OID" bigserial NOT NULL,
	"OID_EXPEDIENTE" bigint NOT NULL,
    "SERIAL" bigint NOT NULL,
    "CODIGO" character varying(255),
    "ESTADO" bigint DEFAULT 1,
    "CODIGO_ADUANERO" character varying(255),
    "FECHA" timestamp without time zone,
    "EXPEDIENTE_REA" character varying(255),
    "CERTIFICADO_REA" character varying(255),
    "N_DUA" character varying(255),
    "COBRADO" boolean DEFAULT false,
    "OBSERVACIONES" text,
	CONSTRAINT "PK_ExpedienteREA" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "ExpedienteREA" OWNER TO moladmin;
GRANT ALL ON TABLE "ExpedienteREA" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE IF EXISTS "Familia" CASCADE;
CREATE TABLE "Familia" 
( 
	"OID" bigserial NOT NULL,
	"CODIGO" bigint NOT NULL,
    "NOMBRE" character varying(255),
    "OBSERVACIONES" text,
    "CUENTA_CONTABLE_COMPRA" text,
    "OID_IMPUESTO" bigint,
    "CUENTA_CONTABLE_VENTA" character varying(255),
    "AVISAR_BENEFICIO_MINIMO" boolean DEFAULT false,
    "P_BENEFICIO_MINIMO" numeric(10,2) DEFAULT 0,
	CONSTRAINT "PK_Familia" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "Familia" OWNER TO moladmin;
GRANT ALL ON TABLE "Familia" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE IF EXISTS "FacturaProveedor" CASCADE;
CREATE TABLE "FacturaProveedor" 
( 
	"OID" bigserial NOT NULL,
	"OID_SERIE" bigint,
    "OID_ACREEDOR" bigint,
    "TIPO_ACREEDOR" bigint,
    "SERIAL" bigint DEFAULT 0 NOT NULL,
    "CODIGO" character varying(50),
    "N_FACTURA" character varying(50),
    "VAT_NUMBER" character varying(255),
    "EMISOR" character varying(255),
    "DIRECCION" character varying(255),
    "CODIGO_POSTAL" character varying(255),
    "PROVINCIA" character varying(255),
    "MUNICIPIO" character varying(255),
    "ANO" bigint,
    "FECHA" date,
    "FORMA_PAGO" bigint DEFAULT 1,
    "DIAS_PAGO" bigint DEFAULT 0,
    "MEDIO_PAGO" bigint DEFAULT 1,
    "PREVISION_PAGO" date,
    "BASE_IMPONIBLE" numeric(10,2) DEFAULT 0,
    "P_IRPF" numeric(10,2) DEFAULT 0,
    "P_IGIC" numeric(10,2) DEFAULT 0,
    "P_DESCUENTO" numeric(10,2) DEFAULT 0,
    "DESCUENTO" numeric(10,2) DEFAULT 0,
    "TOTAL" numeric(10,2) DEFAULT 0,
    "CUENTA_BANCARIA" character varying(255),
    "NOTA" boolean,
    "OBSERVACIONES" text,
    "ALBARAN" boolean,
    "RECTIFICATIVA" boolean,
    "FECHA_REGISTRO" date,
    "ESTADO" bigint DEFAULT 1,
    "ALBARANES" text,
    "ID_MOV_CONTABLE" character varying(255),
    "OID_USUARIO" bigint DEFAULT 0,
    "OID_EXPEDIENTE" bigint DEFAULT 0,
    "EXPEDIENTE" character varying(255),
	CONSTRAINT "PK_FacturaProveedor" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "FacturaProveedor" OWNER TO moladmin;
GRANT ALL ON TABLE "FacturaProveedor" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE IF EXISTS "Gasto" CASCADE;
CREATE TABLE "Gasto" 
( 
	"OID" bigserial NOT NULL,
	"OID_EXPEDIENTE" bigint NOT NULL,
    "OID_FACTURA" bigint,
    "DESCRIPCION" text,
    "FACTURAS" character varying(255),
    "TOTAL" numeric(10,2),
    "PREVISION_PAGO" date,
    "PAGADO" boolean,
    "TIPO" bigint DEFAULT 1,
    "SERIAL" bigint,
    "CODIGO" character varying(255),
    "OID_EMPLEADO" bigint,
    "OID_REMESA_NOMINA" bigint,
    "ESTADO" bigint,
    "OBSERVACIONES" text,
    "FECHA" timestamp without time zone,
    "OID_ALBARAN" bigint DEFAULT 0,
    "OID_CONCEPTO_FACTURA" bigint DEFAULT 0,
    "OID_CONCEPTO_ALBARAN" bigint DEFAULT 0,
    "OID_TIPO" bigint DEFAULT 0,
    "OID_USUARIO" bigint DEFAULT 1,
	CONSTRAINT "PK_Gasto" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "Gasto" OWNER TO moladmin;
GRANT ALL ON TABLE "Gasto" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE IF EXISTS "InventarioAlmacen" CASCADE;
CREATE TABLE "InventarioAlmacen" 
( 
	"OID" bigserial  NOT NULL,
	"OID_ALMACEN" bigint NOT NULL,
    "NOMBRE" character varying(255),
    "FECHA" date,
    "OBSERVACIONES" text,
	CONSTRAINT "PK_InventarioAlmacen" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "InventarioAlmacen" OWNER TO moladmin;
GRANT ALL ON TABLE "InventarioAlmacen" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE  IF EXISTS "LibroGanadero" CASCADE;
CREATE TABLE "LibroGanadero" 
( 
	"OID" bigserial  NOT NULL,
	"SERIAL" bigint NOT NULL,
    "CODIGO" character varying(255) NOT NULL,
    "NOMBRE" character varying(255),
    "BALANCE" numeric(10,2),
    "ESTADO" bigint DEFAULT 10,
    "OBSERVACIONES" text,
	CONSTRAINT "PK_LibroGanadero" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "LibroGanadero" OWNER TO moladmin;
GRANT ALL ON TABLE "LibroGanadero" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE IF EXISTS "LineaAlmacen" CASCADE;
CREATE TABLE "LineaAlmacen" 
( 
	"OID" bigserial  NOT NULL,
	"OID_ALMACEN" bigint NOT NULL,
    "CONCEPTO" character varying(255),
    "FECHA" date,
    "CANTIDAD" numeric(10,2) DEFAULT 0 NOT NULL,
    "OBSERVACIONES" text,
    "REFERENCIA" character varying(255),
	CONSTRAINT "PK_LineaAlmacen" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "LineaAlmacen" OWNER TO moladmin;
GRANT ALL ON TABLE "LineaAlmacen" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE IF EXISTS "LineaFomento" CASCADE;
CREATE TABLE "LineaFomento" 
( 
	"OID" bigserial NOT NULL,
	"OID_PARTIDA" bigint NOT NULL,
    "OID_EXPEDIENTE" bigint NOT NULL,
    "OID_NAVIERA" bigint NOT NULL,
    "SERIAL" bigint,
    "CODIGO" character varying(255),
    "FECHA" timestamp without time zone,
    "DESCRIPCION" text,
    "ID_SOLICITUD" character varying(255),
    "ID_ENVIO" character varying(255),
    "CONOCIMIENTO" text,
    "FECHA_CONOCIMIENTO" date,
    "DUA" character varying(255),
    "FLETE_NETO" numeric(10,2),
    "BAF" numeric(10,2),
    "TEUS20" boolean,
    "TEUS40" boolean,
    "T3_ORIGEN" numeric(10,2),
    "T3_DESTINO" numeric(10,2),
    "THC_ORIGEN" numeric(10,2),
    "THC_DESTINO" numeric(10,2),
    "ISPS" numeric(10,2),
    "TOTAL" numeric(10,2),
    "ESTADO" bigint DEFAULT 1,
    "OBSERVACIONES" text,
    "KILOS" numeric(10,2) DEFAULT 0,	
	CONSTRAINT "PK_LineaFomento" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "LineaFomento" OWNER TO moladmin;
GRANT ALL ON TABLE "LineaFomento" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE  IF EXISTS "LineaInventario" CASCADE;
CREATE TABLE "LineaInventario" 
( 
	"OID" bigserial  NOT NULL,
	"OID_INVENTARIO" bigint NOT NULL,
    "OID_LINEAALMACEN" bigint NOT NULL,
    "CONCEPTO" character varying(255),
    "CANTIDAD" numeric(10,2) DEFAULT 0 NOT NULL,
    "OBSERVACIONES" text,
	CONSTRAINT "PK_LineaInventario" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "LineaInventario" OWNER TO moladmin;
GRANT ALL ON TABLE "LineaInventario" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE  IF EXISTS "LineaLibroGanadero" CASCADE;
CREATE TABLE "LineaLibroGanadero" 
( 
	"OID" bigserial  NOT NULL,
	"OID_LIBRO" bigint NOT NULL,
    "OID_PARTIDA" bigint NOT NULL,
    "OID_CONCEPTO" bigint NOT NULL,
    "ESTADO" bigint DEFAULT 7,
    "SERIAL" bigint NOT NULL,
    "CODIGO" character varying(255) NOT NULL,
    "CROTAL" character varying(255),
    "FECHA" timestamp without time zone,
    "SEXO" bigint DEFAULT 1,
    "EDAD" bigint DEFAULT 1,
    "RAZA" character varying(255),
    "CAUSA" character varying(255),
    "PROCEDENCIA" character varying(255),
    "BALANCE" numeric(10,2) DEFAULT 0,
    "OBSERVACIONES" text,
	CONSTRAINT "PK_LineaLibroGanadero" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "LineaLibroGanadero" OWNER TO moladmin;
GRANT ALL ON TABLE "LineaLibroGanadero" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "LineaPedidoProveedor" 
( 
	"OID" bigserial  NOT NULL,
	"OID_PEDIDO" bigint NOT NULL,
    "OID_PRODUCTO" bigint NOT NULL,
    "OID_PARTIDA" bigint DEFAULT 0,
    "OID_EXPEDIENTE" bigint DEFAULT 0,
    "OID_KIT" bigint DEFAULT 0,
    "FACTURACION_BULTOS" boolean DEFAULT false,
    "P_IMPUESTOS" numeric(10,2) DEFAULT 0,
    "P_DESCUENTO" numeric(10,2) DEFAULT 0,
    "GASTOS" numeric(10,2) DEFAULT 0,
    "ESTADO" bigint,
    "CONCEPTO" character varying(255),
    "CANTIDAD" numeric(10,2) DEFAULT 0 NOT NULL,
    "CANTIDAD_BULTOS" numeric(10,4),
    "PRECIO" numeric(10,5),
    "SUBTOTAL" numeric(10,2),
    "TOTAL" numeric(10,2),
    "OBSERVACIONES" text,
    "OID_ALMACEN" bigint DEFAULT 0,
    "OID_IMPUESTO" bigint DEFAULT 0,
    "CODIGO_PRODUCTO_PROVEEDOR" character varying(255),
	CONSTRAINT "PK_LineaPedidoProveedor" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "LineaPedidoProveedor" OWNER TO moladmin;
GRANT ALL ON TABLE "LineaPedidoProveedor" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "Maquinaria" 
( 
	"OID" bigserial NOT NULL,
	"OID_EXPEDIENTE" bigint,
    "OID_PRODUCTO_EXPEDIENTE" bigint DEFAULT 0 NOT NULL,
    "CODIGO" character varying(255),
    "IDENTIFICADOR" character varying(255),
    "DESCRIPCION" text,
    "OBSERVACIONES" text,
	CONSTRAINT "PK_Maquinaria" PRIMARY KEY ("OID") 
) WITHOUT OIDS;

ALTER TABLE "Maquinaria" OWNER TO moladmin;
GRANT ALL ON TABLE "Maquinaria" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "Naviera" 
( 
	"OID" bigserial NOT NULL,
	"SERIAL" bigint DEFAULT 0 NOT NULL,
    "CODIGO" character varying(255) NOT NULL,
    "ID" character varying(50),
    "TIPO_ID" bigint DEFAULT 0 NOT NULL,
    "NOMBRE" character varying(255),
    "ALIAS" character varying(255),
    "DIRECCION" character varying(255),
    "LOCALIDAD" character varying(255),
    "MUNICIPIO" character varying(255),
    "COD_POSTAL" character varying(255),
    "PROVINCIA" character varying(255),
    "PAIS" character varying(255),
    "TELEFONO" character varying(255),
    "CONTACTO" character varying(255),
    "EMAIL" character varying(255),
    "MEDIO_PAGO" bigint DEFAULT 1,
    "FORMA_PAGO" bigint DEFAULT 1,
    "DIAS_PAGO" bigint,
    "CUENTA_BANCARIA" character varying(255),
    "CUENTA_ASOCIADA" character varying(255),
    "OBSERVACIONES" text,
    "OID_CUENTA_BANCARIA_ASOCIADA" bigint DEFAULT 0,
    "CUENTA_CONTABLE" text,
    "OID_IMPUESTO" bigint,
    "TIPO" bigint DEFAULT 2,
    "ESTADO" integer DEFAULT 10,
	CONSTRAINT "PK_Naviera" PRIMARY KEY ("OID") 
) WITHOUT OIDS;

ALTER TABLE "Naviera" OWNER TO moladmin;
GRANT ALL ON TABLE "Naviera" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE IF EXISTS "Nomina" CASCADE;
CREATE TABLE "Nomina" 
( 
	"OID" bigserial NOT NULL,
	"OID_USUARIO" bigint DEFAULT 1,
    "OID_REMESA" bigint DEFAULT 0,
    "OID_TIPO" bigint DEFAULT 0,
    "OID_EXPEDIENTE" bigint DEFAULT 0,
    "OID_EMPLEADO" bigint,
    "SERIAL" bigint,
    "CODIGO" character varying(255),
    "ESTADO" bigint DEFAULT 1,
    "FECHA" timestamp without time zone,
    "DESCRIPCION" text,
    "BRUTO" numeric(10,2),
    "BASE_IRPF" numeric(10,2),
    "NETO" numeric(10,2),
    "P_IRPF" numeric(10,2),
    "SEGURO" numeric(10,2),
    "DESCUENTOS" numeric(10,2),
    "PREVISION_PAGO" timestamp without time zone,
    "OBSERVACIONES" text,	
	CONSTRAINT "PK_Nomina" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "Nomina" OWNER TO moladmin;
GRANT ALL ON TABLE "Nomina" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE IF EXISTS "Pago" CASCADE;
CREATE TABLE "Pago"
(
	"OID" bigserial,
	"OID_AGENTE" bigint,
    "TIPO_AGENTE" bigint NOT NULL,
    "ID_PAGO" bigint,
    "FECHA" timestamp without time zone,
    "IMPORTE" numeric(10,2) DEFAULT 0,
    "MEDIO_PAGO" bigint DEFAULT 1,
    "VENCIMIENTO" date,
    "PAGADO" boolean DEFAULT true,
    "OBSERVACIONES" text,
    "OID_CUENTA_BANCARIA" bigint DEFAULT 0,
    "SERIAL" bigint DEFAULT 0 NOT NULL,
    "CODIGO" character varying(255),
    "OID_TARJETA_CREDITO" bigint,
    "GASTOS_BANCARIOS" numeric(10,2) DEFAULT 0,
    "ESTADO" bigint DEFAULT 1,
    "ID_MOV_CONTABLE" character varying(255),
    "TIPO" bigint DEFAULT 1,
    "OID_USUARIO" integer DEFAULT 0,
	CONSTRAINT "PK_Pago" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "Pago" OWNER TO moladmin;
GRANT ALL ON TABLE "Pago" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "Pago_Operacion"
(
	"OID" bigserial,
	"OID_PAGO" bigint NOT NULL,
    "OID_OPERACION" bigint,
    "OID_EXPEDIENTE" bigint NOT NULL,
    "TIPO_AGENTE" bigint NOT NULL,
    "CANTIDAD" numeric(10,2),
    "TIPO_PAGO" bigint DEFAULT 1,
	CONSTRAINT "PK_Pago_Operacion" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "Pago_Operacion" OWNER TO moladmin;
GRANT ALL ON TABLE "Pago_Operacion" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE  IF EXISTS "Partida" CASCADE;
CREATE TABLE "Partida" 
( 
	"OID" bigserial NOT NULL,
	"OID_EXPEDIENTE" bigint,
    "OID_PRODUCTO" bigint,
    "OID_PROVEEDOR" bigint,
    "OID_KIT" bigint DEFAULT 0 NOT NULL,
    "OID_PRODUCTO_EXPEDIENTE" bigint DEFAULT 0 NOT NULL,
    "FECHA_COMPRA" timestamp without time zone,
    "TIPO_MERCANCIA" character varying(255),
    "BULTOS_INICIALES" numeric(10,2),
    "KILOS_INICIALES" numeric(10,2),
    "PRECIO_COMPRA_KILO" numeric(10,5),
    "PRECIO_VENTA_KILO" numeric(10,5),
    "PRECIO_VENTA_BULTO" numeric(10,5),
    "BENEFICIO_KILO" numeric(10,5),
    "COSTE_KILO" numeric(10,5),
    "REA_FECHA_COBRO" date,
    "REA_COBRADA" boolean,
    "AYUDA_RECIBIDA_KILO" numeric(10,5),
    "PROPORCION" numeric(10,2) DEFAULT 0 NOT NULL,
    "UBICACION" character varying(255),
    "OBSERVACIONES" text,
    "GASTO_KILO" numeric(10,5) DEFAULT 0,
    "SERIAL" bigint,
    "CODIGO" character varying(255),
    "OID_ALMACEN" bigint DEFAULT 1,
    "AYUDA" boolean DEFAULT true,
    "TIPO" bigint DEFAULT 1,
	CONSTRAINT "PK_Partida" PRIMARY KEY ("OID") 
) WITHOUT OIDS;

ALTER TABLE "Partida" OWNER TO moladmin;
GRANT ALL ON TABLE "Partida" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE  IF EXISTS "PedidoProveedor" CASCADE;
CREATE TABLE "PedidoProveedor" 
( 
	"OID" bigserial  NOT NULL,
	"OID_USUARIO" bigint DEFAULT 0,
    "OID_ACREEDOR" bigint DEFAULT 0,
    "SERIAL" bigint NOT NULL,
    "CODIGO" character varying(255) NOT NULL,
    "FECHA" timestamp without time zone,
    "ESTADO" bigint,
    "TIPO_ACREEDOR" bigint DEFAULT 1,
    "OBSERVACIONES" text,
    "OID_SERIE" bigint DEFAULT 0,
    "P_DESCUENTO" numeric(10,2),
    "DESCUENTO" numeric(10,2) DEFAULT 0,
    "BASE_IMPONIBLE" numeric(10,2),
    "IMPUESTOS" numeric(10,2),
    "TOTAL" numeric(10,2),
    "OID_EXPEDIENTE" bigint DEFAULT 0,
    "OID_ALMACEN" bigint DEFAULT 0,
	CONSTRAINT "PK_PedidoProveedor" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "PedidoProveedor" OWNER TO moladmin;
GRANT ALL ON TABLE "PedidoProveedor" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "Precio_Destino" 
( 
	"OID" bigserial NOT NULL,
	"OID_TRANSPORTISTA" bigint,
    "OID_CLIENTE" bigint,
    "NUMERO_CLIENTE" bigint,
    "CODIGO_CLIENTE" character varying(255),
    "NOMBRE_CLIENTE" character varying(255),
    "PUERTO" character varying(255),
    "PRECIO" numeric(10,2),
	CONSTRAINT "PK_Precio_Destino" PRIMARY KEY ("OID")
	
) WITHOUT OIDS;

ALTER TABLE "Precio_Destino" OWNER TO moladmin;
GRANT ALL ON TABLE "Precio_Destino" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "Precio_Origen" 
( 
	"OID" bigserial NOT NULL,
	"OID_TRANSPORTISTA" bigint,
    "OID_PROVEEDOR" bigint,
    "PROVEEDOR" character varying(255),
    "PUERTO" character varying(255),
    "PRECIO" numeric(10,2),
	CONSTRAINT "PK_Precio_Origen" PRIMARY KEY ("OID") 
) WITHOUT OIDS;

ALTER TABLE "Precio_Origen" OWNER TO moladmin;
GRANT ALL ON TABLE "Precio_Origen" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "Precio_Trayecto" ( 
	"OID" bigserial NOT NULL,
	"PUERTO_DESTINO" character varying(255),
    "PUERTO_ORIGEN" character varying(255),
    "PRECIO" numeric(10,2),
    "OID_NAVIERA" bigint,
	CONSTRAINT "PK_Precio_Trayecto" PRIMARY KEY ("OID") 
) WITHOUT OIDS;

ALTER TABLE "Precio_Trayecto" OWNER TO moladmin;
GRANT ALL ON TABLE "Precio_Trayecto" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE  IF EXISTS "Producto" CASCADE;
CREATE TABLE "Producto" 
( 
	"OID" bigserial NOT NULL,
	"OID_AYUDA" bigint,
    "OID_FAMILIA" bigint,
    "SERIAL" bigint DEFAULT 0,
    "CODIGO" character varying(255) NOT NULL,
    "BULTO" boolean,
    "NOMBRE" character varying(255),
    "DESCRIPCION" character varying(255),
    "PRECIO_COMPRA" numeric(10,5),
    "PRECIO_VENTA" numeric(10,5),
    "AYUDA_KILO" numeric(10,5),
    "CODIGO_ADUANERO" character varying(255),
    "OBSERVACIONES" text,
    "OID_IMPUESTO_COMPRA" bigint,
    "OID_IMPUESTO_VENTA" bigint,
    "CUENTA_CONTABLE_COMPRA" character varying(255),
    "CUENTA_CONTABLE_VENTA" character varying(255),
    "UNITARIO" boolean DEFAULT false,
    "ESTADO" bigint DEFAULT 10,
    "KILOS_BULTO" numeric(10,2) DEFAULT 1,
    "STOCK_MINIMO" numeric(10,2) DEFAULT 0,
    "TIPO_VENTA" bigint DEFAULT 10,
    "AVISAR_STOCK" boolean DEFAULT true,
    "BENEFICIO_CERO" boolean DEFAULT false,
    "AVISAR_BENEFICIO_MINIMO" boolean DEFAULT false,
    "P_BENEFICIO_MINIMO" numeric(10,2) DEFAULT 0,
	CONSTRAINT "PK_Producto" PRIMARY KEY ("OID") 
) WITHOUT OIDS;

ALTER TABLE "Producto" OWNER TO moladmin;
GRANT ALL ON TABLE "Producto" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE  IF EXISTS "Producto_Proveedor" CASCADE;
CREATE TABLE "Producto_Proveedor" 
( 
	"OID" bigserial NOT NULL,
	"OID_ACREEDOR" bigint,
    "OID_PRODUCTO" bigint,
    "PRECIO" numeric(10,5),
    "TIPO_ACREEDOR" bigint DEFAULT 0,
    "FACTURACION_BULTO" boolean DEFAULT false,
    "OID_IMPUESTO" bigint DEFAULT 0,
    "CODIGO_PRODUCTO_ACREEDOR" character varying(255),
    "P_DESCUENTO" numeric(10,2) DEFAULT 0,
    "TIPO_DESCUENTO" bigint DEFAULT 1,
    "AUTOMATICO" boolean DEFAULT false,
	CONSTRAINT "PK_Proveedor_Producto" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "Producto_Proveedor" OWNER TO moladmin;
GRANT ALL ON TABLE "Producto_Proveedor" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE IF EXISTS "Proveedor" CASCADE;
CREATE TABLE "Proveedor" 
( 
	"OID" bigserial NOT NULL,
	"SERIAL" bigint DEFAULT 0 NOT NULL,
    "CODIGO" character varying(255) NOT NULL,
    "ID" character varying(50),
    "TIPO_ID" bigint DEFAULT 0 NOT NULL,
    "NOMBRE" character varying(255),
    "ALIAS" character varying(255),
    "COD_POSTAL" character varying(255),
    "LOCALIDAD" character varying(255),
    "MUNICIPIO" character varying(255),
    "PROVINCIA" character varying(255),
    "TELEFONO" character varying(255),
    "PAIS" character varying(255),
    "MEDIO_PAGO" bigint DEFAULT 1,
    "FORMA_PAGO" bigint DEFAULT 1,
    "DIAS_PAGO" bigint,
    "CUENTA_BANCARIA" character varying(255),
    "CUENTA_ASOCIADA" character varying(255),
    "CONTACTO" character varying(255),
    "EMAIL" character varying(255),
    "DIRECCION" character varying(255),
    "OBSERVACIONES" text,
    "OID_CUENTA_BANCARIA_ASOCIADA" bigint DEFAULT 0,
    "CUENTA_CONTABLE" text,
    "OID_IMPUESTO" bigint,
    "TIPO" bigint DEFAULT 1,
    "ESTADO" bigint DEFAULT 10,
	CONSTRAINT "PK_Proveedor" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "Proveedor" OWNER TO moladmin;
GRANT ALL ON TABLE "Proveedor" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE IF EXISTS "Puerto_Despachante" CASCADE;
CREATE TABLE "Puerto_Despachante" 
( 
	"OID" bigserial NOT NULL,
	"OID_PUERTO" int8,
	"OID_DESPACHANTE" int8,
	CONSTRAINT "PK_Puerto_Despachante" PRIMARY KEY ("OID") 
) WITHOUT OIDS;

ALTER TABLE "Puerto_Despachante" OWNER TO moladmin;
GRANT ALL ON TABLE "Puerto_Despachante" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE IF EXISTS "RemesaNomina" CASCADE;
CREATE TABLE "RemesaNomina" 
( 
	"OID" bigserial NOT NULL,
	"SERIAL" bigint,
    "CODIGO" character varying(255),
    "FECHA" timestamp without time zone,
    "DESCRIPCION" text,
    "TOTAL" numeric(10,2),
    "IRPF" numeric(10,2),
    "SEGURO_EMPRESA" numeric(10,2),
    "SEGURO_PERSONAL" numeric(10,2) DEFAULT 0,
    "PREVISION_PAGO" timestamp without time zone,
    "ESTADO" bigint DEFAULT 1,
    "OBSERVACIONES" text,
    "BASE_IRPF" numeric(10,2) DEFAULT 0,
    "DESCUENTOS" numeric(10,2) DEFAULT 0,	
	CONSTRAINT "PK_RemesaNomina" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "RemesaNomina" OWNER TO moladmin;
GRANT ALL ON TABLE "RemesaNomina" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE IF EXISTS "Serie" CASCADE;
CREATE TABLE "Serie" 
( 
	"OID" bigserial NOT NULL,
	"NOMBRE" character varying(255),
    "IDENTIFICADOR" character varying(255),
    "TIPO_SERIE" integer DEFAULT 0,
    "CABECERA" character varying(512),
    "RESUMEN" boolean,
    "OBSERVACIONES" text,
    "OID_IMPUESTO" bigint,
    "TIPO" bigint DEFAULT 0,
	CONSTRAINT "PK_Serie" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "Serie" OWNER TO moladmin;
GRANT ALL ON TABLE "Serie" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE IF EXISTS "Serie_Familia" CASCADE;
CREATE TABLE "Serie_Familia" 
( 
	"OID" bigserial NOT NULL,
	"OID_SERIE" bigint,
    "OID_FAMILIA" bigint,
	CONSTRAINT "PK_Serie_Familia" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "Serie_Familia" OWNER TO moladmin;
GRANT ALL ON TABLE "Serie_Familia" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE IF EXISTS "Stock" CASCADE;
CREATE TABLE "Stock" 
( 
	"OID" bigserial NOT NULL,
	"OID_PRODUCTO_EXPEDIENTE" bigint,
    "OID_EXPEDIENTE" bigint,
    "OID_PRODUCTO" bigint,
    "OID_CLIENTE" bigint,
    "OID_ALBARAN" bigint DEFAULT 0,
    "OID_CONCEPTO_ALBARAN" bigint DEFAULT 0,
    "OID_STOCK" bigint DEFAULT 0 NOT NULL,
    "OID_KIT" bigint DEFAULT 0 NOT NULL,
    "CONCEPTO" character varying(255),
    "BULTOS" numeric(10,4),
    "KILOS" numeric(10,2),
    "FECHA" timestamp without time zone,
    "ENTRADA" boolean,
    "OBSERVACIONES" text,
    "TIPO" bigint DEFAULT 1,
    "INICIAL" boolean DEFAULT false,
    "OID_LINEA_PEDIDO" bigint DEFAULT 0,
    "OID_ALMACEN" bigint DEFAULT 0,
    "OID_USUARIO" integer DEFAULT 0,
	CONSTRAINT "PK_Stock" PRIMARY KEY ("OID") 
) WITHOUT OIDS;

ALTER TABLE "Stock" OWNER TO moladmin;
GRANT ALL ON TABLE "Stock" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE IF EXISTS "TipoGasto" CASCADE;
CREATE TABLE "TipoGasto" 
( 
	"OID" bigserial NOT NULL,
	"SERIAL" bigint,
    "CODIGO" character varying(255),
    "CATEGORIA" bigint,
    "NOMBRE" text,
    "MEDIO_PAGO" bigint DEFAULT 1,
    "FORMA_PAGO" bigint DEFAULT 1,
    "DIAS_PAGO" bigint,
    "OID_CUENTA_ASOCIADA" bigint DEFAULT 0,
    "CUENTA_BANCARIA" character varying(255),
    "CUENTA_CONTABLE" character varying(255),
    "OBSERVACIONES" text,	
	CONSTRAINT "PK_TipoGasto" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "TipoGasto" OWNER TO moladmin;
GRANT ALL ON TABLE "TipoGasto" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE IF EXISTS "Transportista" CASCADE;
CREATE TABLE "Transportista" 
( 
	"OID" bigserial NOT NULL,
	"SERIAL" bigint DEFAULT 0 NOT NULL,
    "CODIGO" character varying(255) NOT NULL,
    "ID" character varying(50),
    "TIPO_ID" bigint DEFAULT 0 NOT NULL,
    "NOMBRE" character varying(255),
    "ALIAS" character varying(255),
    "MEDIO_PAGO" bigint DEFAULT 1,
    "FORMA_PAGO" bigint DEFAULT 1,
    "DIAS_PAGO" bigint,
    "CUENTA_BANCARIA" character varying(255),
    "CUENTA_ASOCIADA" character varying(255),
    "CONTACTO" character varying(255),
    "EMAIL" character varying(255),
    "DIRECCION" character varying(255),
    "TELEFONO" character varying(255),
    "LOCALIDAD" character varying(255),
    "COD_POSTAL" character varying(255),
    "PROVINCIA" character varying(255),
    "MUNICIPIO" character varying(255),
    "PAIS" character varying(255),
    "OBSERVACIONES" text,
    "OID_CUENTA_BANCARIA_ASOCIADA" bigint DEFAULT 0,
    "CUENTA_CONTABLE" text,
    "OID_IMPUESTO" bigint,
    "TIPO_TRANSPORTISTA" bigint DEFAULT 0,
    "TIPO" bigint DEFAULT 3,
    "ESTADO" integer DEFAULT 10,
	CONSTRAINT "PK_Transportista" PRIMARY KEY ("OID")	
) WITHOUT OIDS;

ALTER TABLE "Transportista" OWNER TO moladmin;
GRANT ALL ON TABLE "Transportista" TO GROUP "MOLEQULE_ADMINISTRATOR";

-- UNIQUE KEYS

ALTER TABLE ONLY "Despachante"
    ADD CONSTRAINT "Despachante_CODIGO_key" UNIQUE ("CODIGO");

ALTER TABLE ONLY "Despachante"
    ADD CONSTRAINT "Despachante_SERIAL_key" UNIQUE ("SERIAL");

ALTER TABLE ONLY "Familia"
    ADD CONSTRAINT "Familia_CODIGO_key" UNIQUE ("CODIGO");

ALTER TABLE ONLY "Familia"
    ADD CONSTRAINT "Familia_NOMBRE_key" UNIQUE ("NOMBRE");

ALTER TABLE ONLY "Maquinaria"
    ADD CONSTRAINT "Maquinaria_IDENTIFICADOR_key" UNIQUE ("IDENTIFICADOR");

ALTER TABLE ONLY "Naviera"
    ADD CONSTRAINT "Naviera_CODIGO_key" UNIQUE ("CODIGO");

ALTER TABLE ONLY "Naviera"
    ADD CONSTRAINT "Naviera_SERIAL_key" UNIQUE ("SERIAL");

ALTER TABLE ONLY "Producto"
    ADD CONSTRAINT "Producto_CODIGO_key" UNIQUE ("CODIGO");

ALTER TABLE ONLY "Proveedor"
    ADD CONSTRAINT "Proveedor_CODIGO_key" UNIQUE ("CODIGO");

ALTER TABLE ONLY "Proveedor"
    ADD CONSTRAINT "Proveedor_SERIAL_key" UNIQUE ("SERIAL");

ALTER TABLE ONLY "Serie"
    ADD CONSTRAINT "Serie_IDENTIFICADOR_key" UNIQUE ("IDENTIFICADOR");

ALTER TABLE ONLY "Transportista"
    ADD CONSTRAINT "Transportista_CODIGO_key" UNIQUE ("CODIGO");

ALTER TABLE ONLY "Transportista"
    ADD CONSTRAINT "Transportista_SERIAL_key" UNIQUE ("SERIAL");

ALTER TABLE ONLY "Albaran_FacturaProveedor"
    ADD CONSTRAINT "UQ_Albaran_Factura_OID_ALBARAN_OID_FACTURA" UNIQUE ("OID_ALBARAN", "OID_FACTURA");

ALTER TABLE ONLY "Cabeza"
    ADD CONSTRAINT "Cabeza_CODIGO_key" UNIQUE ("CODIGO");
	
ALTER TABLE ONLY "ExpedienteREA"
    ADD CONSTRAINT "ExpedienteREA_CODIGO_key" UNIQUE ("CODIGO");

ALTER TABLE ONLY "Expediente"
    ADD CONSTRAINT "Expediente_CODIGO_key" UNIQUE ("CODIGO");
	
-- FOREIGN KEYS	

ALTER TABLE ONLY "AlbaranProveedor"
    ADD CONSTRAINT "FK_AlbaranProveedor_Serie" FOREIGN KEY ("OID_SERIE") REFERENCES "Serie"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "Albaran_FacturaProveedor"
    ADD CONSTRAINT "FK_Albaran_FacturaProveedor_AlbaranProveedor" FOREIGN KEY ("OID_ALBARAN") REFERENCES "AlbaranProveedor"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "Albaran_FacturaProveedor"
    ADD CONSTRAINT "FK_Albaran_FacturaProveedor_FacturaProveedor" FOREIGN KEY ("OID_FACTURA") REFERENCES "FacturaProveedor"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "Cabeza"
    ADD CONSTRAINT "FK_Cabeza_Expediente" FOREIGN KEY ("OID_EXPEDIENTE") REFERENCES "Expediente"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "Cabeza"
    ADD CONSTRAINT "FK_Cabeza_Producto_Expediente" FOREIGN KEY ("OID_PRODUCTO_EXPEDIENTE") REFERENCES "Partida"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "ConceptoAlbaranProveedor"
    ADD CONSTRAINT "FK_ConceptoAlbaranProveedor_AlbaranProveedor" FOREIGN KEY ("OID_ALBARAN") REFERENCES "AlbaranProveedor"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "ConceptoFacturaProveedor"
    ADD CONSTRAINT "FK_ConceptoFacturaP_ConceptoAlbaranP" FOREIGN KEY ("OID_CONCEPTO_ALBARAN") REFERENCES "ConceptoAlbaranProveedor"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "ConceptoFacturaProveedor"
    ADD CONSTRAINT "FK_ConceptoFacturaP_FacturaP" FOREIGN KEY ("OID_FACTURA") REFERENCES "FacturaProveedor"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "ExpedienteREA"
    ADD CONSTRAINT "FK_ExpedienteREA_Expediente" FOREIGN KEY ("OID_EXPEDIENTE") REFERENCES "Expediente"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "Partida"
    ADD CONSTRAINT "FK_Expediente_Producto_Producto" FOREIGN KEY ("OID_PRODUCTO") REFERENCES "Producto"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "LineaInventario"
    ADD CONSTRAINT fk_lineainventario_inventarioalmacen FOREIGN KEY ("OID_INVENTARIO") REFERENCES "InventarioAlmacen"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "LineaFomento"
    ADD CONSTRAINT "FK_LineaFomento_Expediente" FOREIGN KEY ("OID_EXPEDIENTE") REFERENCES "Expediente"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "LineaFomento"
    ADD CONSTRAINT "FK_LineaFomento_Partida" FOREIGN KEY ("OID_PARTIDA") REFERENCES "Partida"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "LineaLibroGanadero"
    ADD CONSTRAINT "FK_LineaLibroGanadero_LibroGanadero" FOREIGN KEY ("OID_LIBRO") REFERENCES "LibroGanadero"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "LineaPedidoProveedor"
    ADD CONSTRAINT "FK_LineaPedidoProveedor_PedidoProveedor" FOREIGN KEY ("OID_PEDIDO") REFERENCES "PedidoProveedor"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "Maquinaria"
    ADD CONSTRAINT "FK_Maquinaria_Expediente" FOREIGN KEY ("OID_EXPEDIENTE") REFERENCES "Expediente"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "Maquinaria"
    ADD CONSTRAINT "FK_Maquinaria_Producto_Expediente" FOREIGN KEY ("OID_PRODUCTO_EXPEDIENTE") REFERENCES "Partida"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "Nomina"
    ADD CONSTRAINT "FK_Nomina_Empleado" FOREIGN KEY ("OID_EMPLEADO") REFERENCES "Empleado"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "Nomina"
    ADD CONSTRAINT "FK_Nomina_RemesaNomina" FOREIGN KEY ("OID_REMESA") REFERENCES "RemesaNomina"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "Pago_Operacion"
    ADD CONSTRAINT "FK_Pago_Factura_Pago" FOREIGN KEY ("OID_PAGO") REFERENCES "Pago"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "Partida"
    ADD CONSTRAINT "FK_Partida_Almacen" FOREIGN KEY ("OID_ALMACEN") REFERENCES "Almacen"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "Precio_Destino"
    ADD CONSTRAINT "FK_Precio_Destino_Transportista" FOREIGN KEY ("OID_TRANSPORTISTA") REFERENCES "Transportista"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "Precio_Origen"
    ADD CONSTRAINT "FK_Precio_Origen_Transportista" FOREIGN KEY ("OID_TRANSPORTISTA") REFERENCES "Transportista"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "Precio_Trayecto"
    ADD CONSTRAINT "FK_Precio_Trayecto_Naviera" FOREIGN KEY ("OID_NAVIERA") REFERENCES "Naviera"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "Puerto_Despachante"
    ADD CONSTRAINT "FK_Puerto_Despachante_Despachante" FOREIGN KEY ("OID_DESPACHANTE") REFERENCES "0001"."Despachante"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "Puerto_Despachante"
    ADD CONSTRAINT "FK_Puerto_Despachante_PUERTO" FOREIGN KEY ("OID_PUERTO") REFERENCES "COMMON"."PUERTO"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "Producto_Proveedor"
    ADD CONSTRAINT "FK_Proveedor_Producto_Producto" FOREIGN KEY ("OID_PRODUCTO") REFERENCES "Producto"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "Serie_Familia"
    ADD CONSTRAINT "FK_SERIE_FAMILIA_FAMILIA" FOREIGN KEY ("OID_FAMILIA") REFERENCES "Familia"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "Serie_Familia"
    ADD CONSTRAINT "FK_SERIE_FAMILIA_SERIE" FOREIGN KEY ("OID_SERIE") REFERENCES "Serie"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "Stock"
    ADD CONSTRAINT "FK_Stock_Almacen" FOREIGN KEY ("OID_ALMACEN") REFERENCES "Almacen"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "Stock"
    ADD CONSTRAINT "FK_Stock_Producto" FOREIGN KEY ("OID_PRODUCTO") REFERENCES "Producto"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "Stock"
    ADD CONSTRAINT "FK_Stock_Producto_Expediente" FOREIGN KEY ("OID_PRODUCTO_EXPEDIENTE") REFERENCES "Partida"("OID") ON UPDATE CASCADE ON DELETE CASCADE;
