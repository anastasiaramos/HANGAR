-- INVOICE MODULE DETAIL SCHEMA SCRIPT
-- Requires STORE MODULE

CREATE TABLE "Albaran" 
( 
	"OID" bigserial NOT NULL,
	"OID_SERIE" bigint,
    "OID_CLIENTE" bigint,
    "OID_TRANSPORTISTA" bigint,
    "SERIAL" bigint DEFAULT 0 NOT NULL,
    "CODIGO" character varying(255),
    "ANO" bigint,
    "FECHA" timestamp without time zone,
    "FORMA_PAGO" bigint DEFAULT 1,
    "DIAS_PAGO" bigint DEFAULT 0,
    "MEDIO_PAGO" bigint DEFAULT 1,
    "PREVISION_PAGO" date,
    "BASE_IMPONIBLE" numeric(10,2),
    "P_IGIC" numeric(10,2),
    "P_DESCUENTO" numeric(10,2),
    "DESCUENTO" numeric(10,2) DEFAULT 0,
    "TOTAL" numeric(10,2),
    "CUENTA_BANCARIA" character varying(255),
    "NOTA" boolean,
    "OBSERVACIONES" text,
    "CONTADO" boolean DEFAULT false NOT NULL,
    "RECTIFICATIVO" boolean DEFAULT false,
    "OID_USUARIO" bigint DEFAULT 0,
    "OID_ALMACEN" bigint DEFAULT 0,
    "OID_EXPEDIENTE" bigint DEFAULT 0,
	"ESTADO" bigint DEFAULT 1,
	CONSTRAINT "PK_Albaran" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "Albaran" OWNER TO moladmin;
GRANT ALL ON TABLE "Albaran" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "Albaran_Factura" 
( 
	"OID" bigserial NOT NULL,
	"OID_ALBARAN" bigint NOT NULL,
    "OID_FACTURA" bigint NOT NULL,
    "FECHA_ASIGNACION" date,
	CONSTRAINT "PK_Albaran_Factura" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "Albaran_Factura" OWNER TO moladmin;
GRANT ALL ON TABLE "Albaran_Factura" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "Albaran_Ticket" 
( 
	"OID" bigserial NOT NULL,
	"OID_ALBARAN" bigint NOT NULL,
    "OID_TICKET" bigint NOT NULL,
    "FECHA_ASIGNACION" timestamp without time zone,
	CONSTRAINT "PK_Albaran_Ticket" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "Albaran_Ticket" OWNER TO moladmin;
GRANT ALL ON TABLE "Albaran_Ticket" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE IF EXISTS "Alumno_Cliente" CASCADE;
CREATE TABLE "Alumno_Cliente" 
( 
	"OID" bigserial  NOT NULL,
	"OID_ALUMNO" bigint NOT NULL,
    "OID_CLIENTE" bigint NOT NULL,
	CONSTRAINT PK_Alumno_Cliente PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "Alumno_Cliente" OWNER TO moladmin;
GRANT ALL ON TABLE "Alumno_Cliente" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE IF EXISTS "Caja" CASCADE;
CREATE TABLE "Caja" 
( 
	"OID" bigserial NOT NULL,
	"CODIGO" character varying(255),
    "NOMBRE" character varying(255),
    "OBSERVACIONES" text,
    "CUENTA_CONTABLE" text,
	CONSTRAINT PK_Caja PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "Caja" OWNER TO moladmin;
GRANT ALL ON TABLE "Caja" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "CierreCaja" 
( 
	"OID" bigserial NOT NULL,
	"OID_CAJA" bigint NOT NULL,
    "SERIAL" bigint DEFAULT 0 NOT NULL,
    "CODIGO" character varying(255),
    "DEBE" numeric(10,2) DEFAULT 0,
    "HABER" numeric(10,2) DEFAULT 0,
    "FECHA" timestamp without time zone,
    "OBSERVACIONES" text,
    "OID_USUARIO" bigint DEFAULT 5,
	CONSTRAINT "PK_CierreCaja" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "CierreCaja" OWNER TO moladmin;
GRANT ALL ON TABLE "CierreCaja" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE IF EXISTS "Cliente" CASCADE;
CREATE TABLE "Cliente" 
( 
	"OID" bigserial NOT NULL,
	"OID_EXT" int8 DEFAULT 0,
	"SERIAL" bigint DEFAULT 0 NOT NULL,
    "ESTADO" bigint DEFAULT 10,
    "TIPO_ID" bigint,
    "VAT_NUMBER" character varying(255),
    "NOMBRE" character varying(255),
    "NOMBRE_COMERCIAL" character varying(255),
    "TITULAR" character varying(255),
    "DIRECCION" character varying(255),
    "POBLACION" character varying(255),
    "CODIGO_POSTAL" character varying(255),
    "PROVINCIA" character varying(255),
	"PAIS" character varying(255),
    "TELEFONOS" character varying(255),
    "FAX" character varying(255),
    "MOVIL" character varying(255),
    "MUNICIPIO" character varying(255),
	"COUNTRY" character varying(255),
    "EMAIL" character varying(255),
	"BIRTH_DATE" timestamp without time zone,
    "OBSERVACIONES" text,
    "HISTORIA" text,
    "LIMITE_CREDITO" numeric(10,2),
    "CONTACTO" character varying(255),
    "MEDIO_PAGO" bigint DEFAULT 1,
    "FORMA_PAGO" bigint,
    "DIAS_PAGO" bigint,
    "CODIGO_EXPLOTACION" character varying(255),
    "CUENTA_BANCARIA" character varying(255),
    "OID_CUENTA_BANCARIA_ASOCIADA" bigint DEFAULT 0,
    "DESCUENTO" numeric(10,2) DEFAULT 0,
    "PRECIO_TRANSPORTE" numeric(10,2),
    "OID_TRANSPORTE" bigint DEFAULT 0 NOT NULL,
    "CUENTA_CONTABLE" text,
    "OID_IMPUESTO" bigint,
    "TIPO_INTERES" numeric(10,2) DEFAULT 0,
    "P_DESCUENTO_PTO_PAGO" numeric(10,2) DEFAULT 0,
    "CODIGO" character varying(255),
    "PRIORIDAD_PRECIO" bigint DEFAULT 3,
    "ENVIAR_FACTURA_PENDIENTE" boolean DEFAULT false,
	CONSTRAINT "Cliente_PK" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "Cliente" OWNER TO moladmin;
GRANT ALL ON TABLE "Cliente" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE IF EXISTS "Cobro" CASCADE;
CREATE TABLE "Cobro" 
( 
	"OID" bigserial NOT NULL,
	"OID_CLIENTE" bigint,
    "ID_COBRO" bigint,
    "TIPO_COBRO" integer DEFAULT 0 NOT NULL,
    "FECHA" timestamp without time zone,
    "IMPORTE" numeric(10,2),
    "MEDIO_PAGO" bigint DEFAULT 1,
    "VENCIMIENTO" date,
    "COBRADO" boolean,
    "OBSERVACIONES" text,
    "OID_CUENTA_BANCARIA" bigint DEFAULT 0,
    "SERIAL" bigint DEFAULT 0 NOT NULL,
    "CODIGO" character varying(255),
    "OID_TPV" bigint,
    "ESTADO" bigint DEFAULT 1,
    "ID_MOV_CONTABLE" character varying(255),
    "GASTOS_BANCARIOS" numeric(10,2) DEFAULT 0,
    "OID_USUARIO" integer DEFAULT 0,
	CONSTRAINT "PK_Cobro" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "Cobro" OWNER TO moladmin;
GRANT ALL ON TABLE "Cobro" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "Cobro_Factura" 
( 
	"OID" bigserial NOT NULL,
	"OID_COBRO" bigint NOT NULL,
    "OID_FACTURA" bigint NOT NULL,
    "CANTIDAD" numeric(10,2),
    "FECHA_ASIGNACION" date,
	CONSTRAINT "PK_Cobro_Factura" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "Cobro_Factura" OWNER TO moladmin;
GRANT ALL ON TABLE "Cobro_Factura" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE IF EXISTS "CobroREA";
CREATE TABLE "CobroREA"
(
	"OID" bigserial,
	"OID_COBRO" bigint NOT NULL,
    "OID_EXPEDIENTE" bigint NOT NULL,
    "CANTIDAD" numeric(10,2),
    "OID_EXPEDIENTE_REA" bigint,
	CONSTRAINT "PK_CobroREA" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "CobroREA" OWNER TO moladmin;
GRANT ALL ON TABLE "CobroREA" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "ConceptoAlbaran" 
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
    "CODIGO_PRODUCTO_CLIENTE" character varying(255),
	CONSTRAINT "PK_ConceptoAlbaran" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "ConceptoAlbaran" OWNER TO moladmin;
GRANT ALL ON TABLE "ConceptoAlbaran" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "ConceptoFactura" 
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
    "GASTOS" numeric(10,5),
    "OID_IMPUESTO" bigint,
    "OID_ALMACEN" bigint DEFAULT 0,
    "CODIGO_PRODUCTO_CLIENTE" character varying(255),
	CONSTRAINT "PK_ConceptoFactura" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "ConceptoFactura" OWNER TO moladmin;
GRANT ALL ON TABLE "ConceptoFactura" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "ConceptoProforma" 
( 
	"OID" bigserial NOT NULL,
	"OID_PROFORMA" bigint,
    "OID_PRODUCTO_EXPEDIENTE" bigint DEFAULT 0 NOT NULL,
    "OID_EXPEDIENTE" bigint DEFAULT 0 NOT NULL,
    "OID_PRODUCTO" bigint,
    "CODIGO_EXPEDIENTE" character varying(255),
    "CONCEPTO" character varying(255),
    "FACTURACION_BULTO" boolean DEFAULT false NOT NULL,
    "CANTIDAD" numeric(10,2),
    "CANTIDAD_BULTOS" numeric(10,4),
    "P_IMPUESTOS" numeric(10,2),
    "P_DESCUENTO" numeric(10,2),
    "TOTAL" numeric(10,2),
    "PRECIO" numeric(10,5),
    "SUBTOTAL" numeric(10,2),
    "OID_IMPUESTO" bigint DEFAULT 0,
	CONSTRAINT "PK_ConceptoProforma" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "ConceptoProforma" OWNER TO moladmin;
GRANT ALL ON TABLE "ConceptoProforma" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "ConceptoTicket" 
( 
	"OID" bigserial NOT NULL,
	"OID_TICKET" bigint,
    "OID_PRODUCTO_EXPEDIENTE" bigint,
    "OID_EXPEDIENTE" bigint,
    "OID_PRODUCTO" bigint,
    "OID_KIT" bigint DEFAULT 0 NOT NULL,
    "OID_CONCEPTO_ALBARAN" bigint,
    "OID_IMPUESTO" bigint,
    "CODIGO_EXPEDIENTE" character varying(255),
    "CONCEPTO" character varying(255),
    "FACTURACION_BULTO" boolean,
    "CANTIDAD" numeric(10,2),
    "CANTIDAD_BULTOS" numeric(10,4),
    "P_IMPUESTOS" numeric(10,2),
    "P_DESCUENTO" numeric(10,2),
    "TOTAL" numeric(10,2),
    "PRECIO" numeric(10,5),
    "SUBTOTAL" numeric(10,2),
    "GASTOS" numeric(10,5),
	CONSTRAINT "PK_ConceptoTicket" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "ConceptoTicket" OWNER TO moladmin;
GRANT ALL ON TABLE "ConceptoTicket" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "Curso_Cliente" 
( 
	"OID" bigserial NOT NULL,
	"OID_CURSO" bigint NOT NULL,
    "OID_CLIENTE" bigint NOT NULL,
	CONSTRAINT "PK_Curso_Cliente" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "Curso_Cliente" OWNER TO moladmin;
GRANT ALL ON TABLE "Curso_Cliente" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE IF EXISTS "Factura" CASCADE;
CREATE TABLE "Factura" 
( 
	"OID" bigserial NOT NULL,
	"OID_SERIE" bigint,
    "OID_CLIENTE" bigint,
    "OID_TRANSPORTISTA" bigint,
    "SERIAL" bigint DEFAULT 0 NOT NULL,
    "CODIGO" character varying(255),
    "VAT_NUMBER" character varying(255),
    "CLIENTE" character varying(255),
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
    "BASE_IMPONIBLE" numeric(10,2),
    "P_IGIC" numeric(10,2),
    "P_DESCUENTO" numeric(10,2),
    "DESCUENTO" numeric(10,2) DEFAULT 0,
    "TOTAL" numeric(10,2),
    "CUENTA_BANCARIA" character varying(255),
    "NOTA" boolean,
    "OBSERVACIONES" text,
    "ALBARAN" boolean,
    "RECTIFICATIVA" boolean,
    "ESTADO" bigint DEFAULT 1,
    "P_IRPF" numeric(10,2),
    "ALBARANES" text,
    "ID_MOV_CONTABLE" character varying(255),
    "ESTADO_COBRO" bigint DEFAULT 0,
    "OID_USUARIO" bigint DEFAULT 0,
	CONSTRAINT "PK_Factura" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "Factura" OWNER TO moladmin;
GRANT ALL ON TABLE "Factura" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE  IF EXISTS "LineaCaja" CASCADE;
CREATE TABLE "LineaCaja" ( 
	"OID" bigserial  NOT NULL,
	"OID_CAJA" bigint NOT NULL,
    "OID_CIERRE" bigint DEFAULT 0,
    "SERIAL" bigint,
    "CODIGO" character varying(255),
    "N_FACTURA" character varying(255),
    "FECHA" timestamp without time zone,
    "CONCEPTO" character varying(255),
    "OID_COBRO" bigint,
    "OID_PAGO" bigint,
    "N_CLIENTE" bigint,
    "N_PROVEEDOR" character varying(255),
    "DEBE" numeric(10,2),
    "HABER" numeric(10,2),
    "OBSERVACIONES" text,
    "OID_CUENTA_BANCARIA" bigint DEFAULT 0,
    "ESTADO" bigint DEFAULT 1,
    "TIPO" bigint DEFAULT 5,
	CONSTRAINT "PK_LineaCaja" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "LineaCaja" OWNER TO moladmin;
GRANT ALL ON TABLE "LineaCaja" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE  IF EXISTS "LineaPedido" CASCADE;
CREATE TABLE "LineaPedido" 
( 
	"OID" bigserial  NOT NULL,
	"OID_PEDIDO" bigint NOT NULL,
    "OID_PRODUCTO" bigint NOT NULL,
    "ESTADO" bigint,
    "CONCEPTO" character varying(255),
    "CANTIDAD" numeric(10,2) DEFAULT 0 NOT NULL,
    "CANTIDAD_BULTOS" numeric(10,4),
    "PRECIO" numeric(10,5),
    "TOTAL" numeric(10,2),
    "OBSERVACIONES" text,
    "OID_PARTIDA" bigint DEFAULT 0,
    "OID_EXPEDIENTE" bigint DEFAULT 0,
    "OID_KIT" bigint DEFAULT 0,
    "FACTURACION_BULTOS" boolean DEFAULT false,
    "P_IMPUESTOS" numeric(10,2) DEFAULT 0,
    "P_DESCUENTO" numeric(10,2) DEFAULT 0,
    "GASTOS" numeric(10,2) DEFAULT 0,
    "SUBTOTAL" numeric(10,2) DEFAULT 0,
    "OID_ALMACEN" bigint DEFAULT 0,
    "OID_IMPUESTO" bigint DEFAULT 0,
	CONSTRAINT "PK_LineaPedido" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "LineaPedido" OWNER TO moladmin;
GRANT ALL ON TABLE "LineaPedido" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE IF EXISTS "MovimientoBanco" CASCADE;
CREATE TABLE "MovimientoBanco" ( 
	"OID" bigserial  NOT NULL,
	"OID_OPERACION" bigint NOT NULL,
    "TIPO_OPERACION" bigint DEFAULT 0,
    "SERIAL" bigint,
    "CODIGO" character varying(255),
    "OID_USUARIO" bigint,
    "AUDITADO" boolean DEFAULT false,
    "OBSERVACIONES" text,
    "ESTADO" bigint DEFAULT 1,
    "FECHA_OPERACION" timestamp without time zone,
    "ID_OPERACION" character varying(255),
    "IMPORTE" numeric(10,2),
    "TIPO_CUENTA" bigint DEFAULT 1,
    "OID_CUENTA" bigint DEFAULT 0,
    "FECHA_CREACION" timestamp without time zone,
    "FECHA" timestamp without time zone,
    "TIPO_MOVIMIENTO" bigint DEFAULT 1,
	CONSTRAINT "PK_MovimientoBanco" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "MovimientoBanco" OWNER TO moladmin;
GRANT ALL ON TABLE "MovimientoBanco" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE  IF EXISTS "Pedido" CASCADE;
CREATE TABLE "Pedido" 
( 
	"OID" bigserial  NOT NULL,
	"OID_USUARIO" bigint DEFAULT 0,
    "OID_CLIENTE" bigint DEFAULT 0,
    "OID_PRODUCTO" bigint DEFAULT 0,
    "SERIAL" bigint NOT NULL,
    "CODIGO" character varying(255) NOT NULL,
    "FECHA" timestamp without time zone,
    "TOTAL" numeric(10,2),
    "ESTADO" bigint,
    "OBSERVACIONES" text,
    "OID_SERIE" bigint DEFAULT 0,
    "BASE_IMPONIBLE" numeric(10,2),
    "IMPUESTOS" numeric(10,2),
    "P_DESCUENTO" numeric(10,2),
    "DESCUENTO" numeric(10,2) DEFAULT 0,
    "OID_ALMACEN" bigint DEFAULT 0,
    "OID_EXPEDIENTE" bigint DEFAULT 0,
	CONSTRAINT "PK_Pedido" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "Pedido" OWNER TO moladmin;
GRANT ALL ON TABLE "Pedido" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "Prestamo" 
( 
	"OID" bigserial NOT NULL,
	"OID_CUENTA" bigint DEFAULT 0,
    "FECHA_FIRMA" timestamp without time zone,
    "FECHA_INGRESO" timestamp without time zone,
    "FECHA_VENCIMIENTO" timestamp without time zone,
    "NOMBRE" character varying(255),
    "IMPORTE" numeric(10,2),
    "OBSERVACIONES" text,
    "SERIAL" bigint DEFAULT 0 NOT NULL,
    "CODIGO" character varying(255),
    "OID_PAGO" bigint DEFAULT 0,
	"N_CUOTAS" bigint DEFAULT 1,
	"INICIO_PAGO" date,
	"PERIODO_PAGO" bigint DEFAULT 1,
	"IMPORTE_CUOTA" numeric(10,2),
	CONSTRAINT "PK_Prestamo" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "Prestamo" OWNER TO moladmin;
GRANT ALL ON TABLE "Prestamo" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "Producto_Cliente" 
( 
	"OID" bigserial NOT NULL,
	"OID_PRODUCTO" bigint,
    "OID_CLIENTE" bigint,
    "PRECIO" numeric(10,5),
    "FACTURACION_BULTO" boolean,
    "P_DESCUENTO" numeric(10,2) DEFAULT 0,
    "TIPO_DESCUENTO" bigint DEFAULT 1,
    "PRECIO_COMPRA" numeric(10,2) DEFAULT 0,
    "FACTURAR" boolean DEFAULT false,
    "FECHA_VALIDEZ" timestamp without time zone,
	CONSTRAINT "PK_Producto_Cliente" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "Producto_Cliente" OWNER TO moladmin;
GRANT ALL ON TABLE "Producto_Cliente" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "Proforma" 
( 
	"OID" bigserial NOT NULL,
	"OID_SERIE" bigint,
    "OID_CLIENTE" bigint,
    "SERIAL" bigint DEFAULT 0 NOT NULL,
    "CODIGO" character varying(255),
    "FECHA" date,
    "SUBTOTAL" numeric(10,2),
    "P_DESCUENTO" numeric(10,2),
    "IMPUESTOS" numeric(10,2),
    "TOTAL" numeric(10,2),
    "NOTA" boolean,
    "OBSERVACIONES" text,
    "P_IRPF" numeric(10,2),
    "OID_USUARIO" integer DEFAULT 0,
	CONSTRAINT "PK_Proforma" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "Proforma" OWNER TO moladmin;
GRANT ALL ON TABLE "Proforma" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE IF EXISTS "ReciboAlumno" CASCADE;
CREATE TABLE "ReciboAlumno" 
( 
	"OID" bigserial NOT NULL,
	"OID_ALUMNO" bigint NOT NULL,
    "FECHA" timestamp without time zone,
    "TOTAL" real,
    "FORMA_PAGO" character varying(255),
    "DOCUMENTO_ASOCIADO" bigint,
    "OBSERVACIONES" text,
	CONSTRAINT "PK_ReciboAlumno" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "ReciboAlumno" OWNER TO moladmin;
GRANT ALL ON TABLE "ReciboAlumno" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "Ticket" 
( 
	"OID" bigserial NOT NULL,
	"OID_SERIE" bigint,
    "OID_TPV" bigint,
    "SERIAL" bigint DEFAULT 0 NOT NULL,
    "CODIGO" character varying(255),
    "ESTADO" bigint DEFAULT 1,
    "TIPO" bigint DEFAULT 1,
    "FECHA" timestamp without time zone,
    "BASE_IMPONIBLE" numeric(10,2),
    "IMPUESTOS" numeric(10,2),
    "DESCUENTO" numeric(10,2),
    "TOTAL" numeric(10,2),
    "FORMA_PAGO" bigint DEFAULT 1,
    "DIAS_PAGO" bigint DEFAULT 0,
    "MEDIO_PAGO" bigint DEFAULT 1,
    "PREVISION_PAGO" timestamp without time zone,
    "OBSERVACIONES" text,
    "ALBARANES" text,
    "OID_USUARIO" integer DEFAULT 0,
	CONSTRAINT "PK_Ticket" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "Ticket" OWNER TO moladmin;
GRANT ALL ON TABLE "Ticket" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE IF EXISTS "TipoInteres" CASCADE;
CREATE TABLE "TipoInteres" 
( 
	"OID" bigserial  NOT NULL,
	"OID_PRESTAMO" bigint NOT NULL,
	"TIPO_INTERES" numeric(10,2) NOT NULL,
	"FECHA_INICIO" date,
	"FECHA_FIN" date,
	"IMPORTE_CUOTA" numeric(10,2),
	CONSTRAINT PK_TipoInteres PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "TipoInteres" OWNER TO moladmin;
GRANT ALL ON TABLE "TipoInteres" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE IF EXISTS "IVTransaction" CASCADE;
CREATE TABLE "IVTransaction" 
( 
	"OID" bigserial NOT NULL,
	"OID_ENTITY" int8 NOT NULL,
	"ENTITY_TYPE" int8 NOT NULL,
	"SERIAL" int8 DEFAULT 0 NOT NULL,
	"CODE" character varying(255),
	"TYPE" int8 DEFAULT 1,
	"STATUS" int8 DEFAULT 1,
	"CREATED" timestamp without time zone,
	"RESOLVED" timestamp without time zone,	
	"TRANSACTIONID" character varying(255),
	"AUTH_CODE" character varying(255),
	"PAN_MASK" character varying(255),
	"AMOUNT" numeric(10,2),
	"CURRENCY" int8 NOT NULL DEFAULT 1,
	"GATEWAY" int8 NOT NULL DEFAULT 1,
	"DESCRIPTION" text,
    CONSTRAINT "IVTransaction_PK" PRIMARY KEY ("OID")
)WITHOUT OIDS;

ALTER TABLE "IVTransaction" OWNER TO moladmin;
GRANT ALL ON TABLE "IVTransaction" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE IF EXISTS "Traspaso" CASCADE;
CREATE TABLE "Traspaso" ( 
	"OID" bigserial  NOT NULL,
	"OID_CUENTA_ORIGEN" bigint NOT NULL,
    "OID_CUENTA_DESTINO" bigint NOT NULL,
    "OID_USUARIO" bigint,
    "SERIAL" bigint,
    "CODIGO" character varying(255),
    "ESTADO" bigint,
    "FECHA" timestamp without time zone,
    "OBSERVACIONES" text,
    "IMPORTE" numeric(10,2),
    "TIPO" bigint DEFAULT 7,
    "GASTOS_BANCARIOS" numeric(10,2) DEFAULT 0,
    "FECHA_RECEPCION" timestamp without time zone,
	CONSTRAINT "PK_Traspaso" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "Traspaso" OWNER TO moladmin;
GRANT ALL ON TABLE "Traspaso" TO GROUP "MOLEQULE_ADMINISTRATOR";

-- FOREIGN KEYS
	
ALTER TABLE ONLY "Albaran"
    ADD CONSTRAINT "Albaran_SERIAL_key" UNIQUE ("SERIAL");

ALTER TABLE ONLY "Cliente"
    ADD CONSTRAINT "Cliente_SERIAL_key" UNIQUE ("SERIAL");

ALTER TABLE ONLY "Factura"
    ADD CONSTRAINT "Factura_SERIAL_key" UNIQUE ("SERIAL");

ALTER TABLE ONLY "Prestamo"
    ADD CONSTRAINT "Prestamo_SERIAL_key" UNIQUE ("SERIAL");

ALTER TABLE ONLY "Ticket"
    ADD CONSTRAINT "Ticket_SERIAL_key" UNIQUE ("SERIAL");

ALTER TABLE ONLY "Albaran_Factura"
    ADD CONSTRAINT "UQ_Albaran_Factura_OID_ALBARAN" UNIQUE ("OID_ALBARAN", "OID_FACTURA");

ALTER TABLE ONLY "Albaran_Ticket"
    ADD CONSTRAINT "UQ_Albaran_Ticket_OID_ALBARAN" UNIQUE ("OID_ALBARAN", "OID_TICKET");


ALTER TABLE ONLY "Albaran"
    ADD CONSTRAINT "FK_Albaran_Cliente" FOREIGN KEY ("OID_CLIENTE") REFERENCES "Cliente"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "Albaran_Factura"
    ADD CONSTRAINT "FK_Albaran_Factura_Albaran" FOREIGN KEY ("OID_ALBARAN") REFERENCES "Albaran"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "Albaran_Factura"
    ADD CONSTRAINT "FK_Albaran_Factura_Factura" FOREIGN KEY ("OID_FACTURA") REFERENCES "Factura"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "Albaran"
    ADD CONSTRAINT "FK_Albaran_Serie" FOREIGN KEY ("OID_SERIE") REFERENCES "Serie"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "Albaran_Ticket"
    ADD CONSTRAINT "FK_Albaran_Ticket_Ticket" FOREIGN KEY ("OID_TICKET") REFERENCES "Ticket"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "CierreCaja"
    ADD CONSTRAINT "FK_CierreCaja_Caja" FOREIGN KEY ("OID_CAJA") REFERENCES "Caja"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "CobroREA"
    ADD CONSTRAINT "FK_CobroREA_Cobro" FOREIGN KEY ("OID_COBRO") REFERENCES "Cobro"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "CobroREA"
    ADD CONSTRAINT "FK_CobroREA_Expediente" FOREIGN KEY ("OID_EXPEDIENTE") REFERENCES "Expediente"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "Cobro_Factura"
    ADD CONSTRAINT "FK_Cobro_Factura_Cobro" FOREIGN KEY ("OID_COBRO") REFERENCES "Cobro"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "Cobro_Factura"
    ADD CONSTRAINT "FK_Cobro_Factura_Factura" FOREIGN KEY ("OID_FACTURA") REFERENCES "Factura"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "ConceptoAlbaran"
    ADD CONSTRAINT "FK_ConceptoAlbaran_Albaran" FOREIGN KEY ("OID_ALBARAN") REFERENCES "Albaran"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "ConceptoFactura"
    ADD CONSTRAINT "FK_ConceptoFactura_ConceptoAlbaran" FOREIGN KEY ("OID_CONCEPTO_ALBARAN") REFERENCES "ConceptoAlbaran"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "ConceptoFactura"
    ADD CONSTRAINT "FK_ConceptoFactura_Factura" FOREIGN KEY ("OID_FACTURA") REFERENCES "Factura"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "ConceptoProforma"
    ADD CONSTRAINT "FK_ConceptoProforma_Proforma" FOREIGN KEY ("OID_PROFORMA") REFERENCES "Proforma"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "Factura"
    ADD CONSTRAINT "FK_Factura_Cliente" FOREIGN KEY ("OID_CLIENTE") REFERENCES "Cliente"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "LineaCaja"
    ADD CONSTRAINT "FK_LineaCaja_Caja" FOREIGN KEY ("OID_CAJA") REFERENCES "Caja"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "LineaPedido"
    ADD CONSTRAINT "FK_LineaPedido_Pedido" FOREIGN KEY ("OID_PEDIDO") REFERENCES "Pedido"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "Pedido"
    ADD CONSTRAINT "FK_Pedido_Cliente" FOREIGN KEY ("OID_CLIENTE") REFERENCES "Cliente"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "Producto_Cliente"
    ADD CONSTRAINT "FK_Producto_Cliente_Cliente" FOREIGN KEY ("OID_CLIENTE") REFERENCES "Cliente"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "Producto_Cliente"
    ADD CONSTRAINT "FK_Producto_Cliente_Producto" FOREIGN KEY ("OID_PRODUCTO") REFERENCES "Producto"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "Proforma"
    ADD CONSTRAINT "FK_Proforma_Cliente" FOREIGN KEY ("OID_CLIENTE") REFERENCES "Cliente"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "Proforma"
    ADD CONSTRAINT "FK_Proforma_Serie" FOREIGN KEY ("OID_SERIE") REFERENCES "Serie"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "Traspaso"
    ADD CONSTRAINT "Traspaso_OID_CUENTA_DESTINO_fkey" FOREIGN KEY ("OID_CUENTA_DESTINO") REFERENCES "CuentaBancaria"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "Traspaso"
    ADD CONSTRAINT "Traspaso_OID_CUENTA_ORIGEN_fkey" FOREIGN KEY ("OID_CUENTA_ORIGEN") REFERENCES "CuentaBancaria"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "Traspaso"
    ADD CONSTRAINT "Traspaso_OID_USUARIO_fkey" FOREIGN KEY ("OID_USUARIO") REFERENCES "COMMON"."User"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;