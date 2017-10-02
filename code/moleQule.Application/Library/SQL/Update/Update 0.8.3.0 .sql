/* UPDATE 0.8.3.0*/

SET SEARCH_PATH = "COMMON";

/*ALTER TABLE "Despachante" ADD COLUMN "ALIAS" character varying(255);
ALTER TABLE "Naviera" ADD COLUMN "ALIAS" character varying(255);
ALTER TABLE "Proveedor" ADD COLUMN "ALIAS" character varying(255);
ALTER TABLE "Transportista" ADD COLUMN "ALIAS" character varying(255);*/

/*ALTER TABLE "Despachante" ALTER COLUMN "FORMA_PAGO" SET DEFAULT 1;
ALTER TABLE "Naviera" ALTER COLUMN "FORMA_PAGO" SET DEFAULT 1;
ALTER TABLE "Proveedor" ALTER COLUMN "FORMA_PAGO" SET DEFAULT 1;
ALTER TABLE "Transportista" ALTER COLUMN "FORMA_PAGO" SET DEFAULT 1;*/

SET SEARCH_PATH = "0001";

/*DROP TABLE IF EXISTS "FacturaProveedor" CASCADE;
CREATE TABLE "FacturaProveedor" 
( 
	"OID" bigserial NOT NULL,
	"OID_SERIE" int8,
	"OID_ACREEDOR" int8,
	"TIPO_ACREEDOR" int8,
	"SERIAL" int8 DEFAULT 0 NOT NULL UNIQUE,
	"CODIGO" character varying(50),
	"N_FACTURA" character varying(50),
    "VAT_NUMBER" character varying(255),
    "EMISOR" character varying(255),
    "DIRECCION" character varying(255),
    "CODIGO_POSTAL" character varying(255),
    "PROVINCIA" character varying(255),
    "MUNICIPIO" character varying(255),	
	"ANO" int8,
	"FECHA" date,
	"FORMA_PAGO" bigint DEFAULT 1,
	"DIAS_PAGO" bigint DEFAULT 0,
	"MEDIO_PAGO" bigint DEFAULT 1,
	"PREVISION_PAGO" date,
	"BASE_IMPONIBLE" decimal(10,2) DEFAULT 0,
	"P_IRPF" decimal(10,2) DEFAULT 0,
	"P_IGIC" decimal(10,2) DEFAULT 0,
	"P_DESCUENTO" decimal(10,2) DEFAULT 0,
	"DESCUENTO" decimal(10,2) DEFAULT 0,
	"TOTAL" decimal(10,2) DEFAULT 0,
	"CUENTA_BANCARIA" varchar(255),
	"NOTA" boolean,
	"OBSERVACIONES" text,
	"ALBARAN" boolean,
	"RECTIFICATIVA" boolean
) WITHOUT OIDS;

ALTER TABLE "FacturaProveedor" ADD CONSTRAINT "PK_FacturaProveedor" PRIMARY KEY ("OID");
ALTER TABLE "FacturaProveedor" OWNER TO hangar_admin;
GRANT ALL ON TABLE "FacturaProveedor" TO hangar_admin;
GRANT ALL ON TABLE "FacturaProveedor" TO GROUP "HANGAR_ADMINISTRADOR";

DROP TABLE IF EXISTS "ConceptoFacturaProveedor";
CREATE TABLE "ConceptoFacturaProveedor" 
( 
	"OID" bigserial NOT NULL,
	"OID_FACTURA" int8,
	"OID_PRODUCTO_EXPEDIENTE" int8,
	"OID_EXPEDIENTE" int8,
	"OID_PRODUCTO" int8,
	"OID_KIT" int8 NOT NULL DEFAULT 0,
	"OID_CONCEPTO_ALBARAN" int8,
	"CODIGO_EXPEDIENTE" varchar(255),
	"CONCEPTO" varchar(255),
	"FACTURACION_BULTO" boolean,
	"CANTIDAD" decimal(10,2),
	"CANTIDAD_BULTOS" numeric(10,4),
	"P_IGIC" decimal(10,2),
	"P_DESCUENTO" decimal(10,2),
	"TOTAL" decimal(10,2),
	"PRECIO" decimal(10,5),
	"SUBTOTAL" decimal(10,2)
) WITHOUT OIDS;

ALTER TABLE "ConceptoFacturaProveedor" ADD CONSTRAINT "PK_ConceptoFacturaProveedor" PRIMARY KEY ("OID");
ALTER TABLE "ConceptoFacturaProveedor" OWNER TO hangar_admin;
GRANT ALL ON TABLE "ConceptoFacturaProveedor" TO hangar_admin;
GRANT ALL ON TABLE "ConceptoFacturaProveedor" TO GROUP "HANGAR_ADMINISTRADOR";

ALTER TABLE "ConceptoFacturaProveedor" ADD CONSTRAINT "FK_ConceptoFacturaP_FacturaP" FOREIGN KEY ("OID_FACTURA") REFERENCES "FacturaProveedor" ("OID")ON UPDATE CASCADE ON DELETE CASCADE ;
ALTER TABLE "ConceptoFacturaProveedor" ADD CONSTRAINT "FK_ConceptoFacturaP_ConceptoAlbaranP" FOREIGN KEY ("OID_CONCEPTO_ALBARAN") REFERENCES "ConceptoAlbaranProveedor" ("OID")ON UPDATE CASCADE ON DELETE RESTRICT;*/

--ALTER TABLE "Cobro" ADD COLUMN "MEDIO_PAGO" bigint DEFAULT 1;
--ALTER TABLE "Pago" ADD COLUMN "MEDIO_PAGO" bigint DEFAULT 1;
--ALTER TABLE "Cobro" DROP COLUMN "TIPO";
--ALTER TABLE "Pago" DROP COLUMN "TIPO";

--ALTER TABLE "Empleado" RENAME COLUMN "NOMBRE" TO "NOMBRE_PROPIO";
--ALTER TABLE "Empleado" ADD COLUMN "NOMBRE" varchar(255);
UPDATE "Empleado" SET "NOMBRE" = "NOMBRE_PROPIO" ||' ' || "APELLIDOS";

--ALTER TABLE "Alumno_Convocatoria" ADD COLUMN "FECHA" date;

/*ALTER TABLE "Alumno" ADD COLUMN "FECHA_NACIMIENTO" date;
ALTER TABLE "Alumno" ADD COLUMN "REQUISITOS" bool DEFAULT TRUE;
ALTER TABLE "Alumno" ADD COLUMN "PRUEBA_ACCESO" bool DEFAULT TRUE;
ALTER TABLE "Alumno" ADD COLUMN "LUGAR_TRABAJO" varchar(255);
ALTER TABLE "Alumno" ADD COLUMN "LUGAR_ESTUDIO" varchar(255);
ALTER TABLE "Alumno" ADD COLUMN "FORMACION" varchar(255);
ALTER TABLE "Alumno" ADD COLUMN "IDIOMAS" varchar(255);*/
