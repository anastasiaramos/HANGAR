/* UPDATE 0.8.2.0*/

SET SEARCH_PATH = "COMMON";

--ALTER TABLE "Serie" ADD COLUMN "VENTA" boolean NOT NULL DEFAULT FALSE;

--ALTER TABLE "Despachante" ADD COLUMN "ID" varchar(50);
--ALTER TABLE "Proveedor" RENAME COLUMN "VAT_NUMBER" TO "ID";
--ALTER TABLE "Naviera" ADD COLUMN "ID" varchar(50);
--ALTER TABLE "Transportista" ADD COLUMN "ID" varchar(50);

--ALTER TABLE "Despachante" ADD COLUMN "TIPO_ID" int8 NOT NULL DEFAULT 0;
--ALTER TABLE "Proveedor" ADD COLUMN "TIPO_ID" int8 NOT NULL DEFAULT 0;
--ALTER TABLE "Naviera" ADD COLUMN "TIPO_ID" int8 NOT NULL DEFAULT 0;
--ALTER TABLE "Transportista" ADD COLUMN "TIPO_ID" int8 NOT NULL DEFAULT 0;

SET SEARCH_PATH = "0001";

CREATE TABLE "0001"."Alumno_Convocatoria"
(
  "OID" bigserial NOT NULL,
  "OID_CONVOCATORIA" bigint NOT NULL,
  "OID_ALUMNO" bigint NOT NULL,
  "OID_CLIENTE" bigint,
  CONSTRAINT "ALUMNO_CONVOCATORIA_PK" PRIMARY KEY ("OID"),
  CONSTRAINT fk_alumno_convocatoria_curso FOREIGN KEY ("OID_CONVOCATORIA")
      REFERENCES "0001"."Convocatoria_Curso" ("OID") MATCH SIMPLE
      ON UPDATE CASCADE ON DELETE RESTRICT
)WITHOUT OIDS;

ALTER TABLE "0001"."Alumno_Convocatoria" OWNER TO hangar_admin;
GRANT ALL ON TABLE "0001"."Alumno_Convocatoria" TO hangar_admin;
GRANT ALL ON TABLE "0001"."Alumno_Convocatoria" TO "HANGAR_ADMINISTRADOR";

/*CREATE TABLE "Albaran_FacturaProveedor" 
( 
	"OID" bigserial NOT NULL,
	"OID_ALBARAN" int8 NOT NULL,
	"OID_FACTURA" int8 NOT NULL,
	"FECHA_ASIGNACION" date
) WITHOUT OIDS;

ALTER TABLE "Albaran_FacturaProveedor" ADD CONSTRAINT "PK_Albaran_FacturaProveedor" PRIMARY KEY ("OID");
ALTER TABLE "Albaran_FacturaProveedor" ADD CONSTRAINT "UQ_Albaran_FacturaProveedor_OID_ALBARAN" UNIQUE("OID_ALBARAN", "OID_FACTURA");
ALTER TABLE "Albaran_FacturaProveedor" OWNER TO hangar_admin;
GRANT ALL ON TABLE "Albaran_FacturaProveedor" TO hangar_admin;
GRANT ALL ON TABLE "Albaran_FacturaProveedor" TO GROUP "HANGAR_ADMINISTRADOR";

DROP TABLE IF EXISTS "AlbaranProveedor" CASCADE;
CREATE TABLE "AlbaranProveedor" ( 
	"OID" bigserial NOT NULL,
	"OID_SERIE" int8,
	"OID_ACREEDOR" int8,
	"TIPO_ACREEDOR" int8,
	"SERIAL" int8 DEFAULT 0 NOT NULL UNIQUE,
	"CODIGO" varchar(255),
	"ANO" int8,
	"FECHA" date,
	"FECHA_REGISTRO" date,
	"FORMA_PAGO" bigint DEFAULT 1,
	"DIAS_PAGO" bigint DEFAULT 0,
	"MEDIO_PAGO" bigint DEFAULT 1,
	"PREVISION_PAGO" date,
	"P_IRPF" numeric(10,2),
	"P_DESCUENTO" decimal(10,2),
	"DESCUENTO" decimal(10,2) default 0,
	"BASE_IMPONIBLE" decimal(10,2),
	"IGIC" decimal(10,2),
	"TOTAL" decimal(10,2),
	"CUENTA_BANCARIA" varchar(255),
	"NOTA" boolean,
	"OBSERVACIONES" text,
	"CONTADO" boolean NOT NULL DEFAULT false,
	"RECTIFICATIVO" boolean DEFAULT false	
) WITHOUT OIDS;

ALTER TABLE "AlbaranProveedor" ADD CONSTRAINT PK_AlbaranProveedor PRIMARY KEY ("OID");
ALTER TABLE "AlbaranProveedor" OWNER TO hangar_admin;
GRANT ALL ON TABLE "AlbaranProveedor" TO hangar_admin;
GRANT ALL ON TABLE "AlbaranProveedor" TO GROUP "HANGAR_ADMINISTRADOR";

DROP TABLE IF EXISTS "ConceptoAlbaranProveedor";
CREATE TABLE "ConceptoAlbaranProveedor" ( 
	"OID" bigserial NOT NULL,
	"OID_ALBARAN" int8,
	"OID_PRODUCTO_EXPEDIENTE" int8,
	"OID_EXPEDIENTE" int8,
	"OID_PRODUCTO" int8,
	"OID_KIT" bigint NOT NULL DEFAULT 0,
	"CODIGO_EXPEDIENTE" varchar(255),
	"CONCEPTO" varchar(255),
	"FACTURACION_BULTO" boolean,
	"CANTIDAD" decimal(10,2),
	"CANTIDAD_BULTOS" numeric(10,4),
	"P_IGIC" decimal(10,2),
	"P_DESCUENTO" decimal(10,2),
	"TOTAL" decimal(10,2),
	"PRECIO" decimal(10,5),
	"SUBTOTAL" decimal(10,2),
	"GASTOS" decimal(10,5)	
) WITHOUT OIDS;

ALTER TABLE "ConceptoAlbaranProveedor" ADD CONSTRAINT PK_ConceptoAlbaranProveedor PRIMARY KEY ("OID");
ALTER TABLE "ConceptoAlbaranProveedor" OWNER TO hangar_admin;
GRANT ALL ON TABLE "ConceptoAlbaranProveedor" TO hangar_admin;
GRANT ALL ON TABLE "ConceptoAlbaranProveedor" TO GROUP "HANGAR_ADMINISTRADOR";

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

DROP TABLE IF EXISTS "FacturaProveedor" CASCADE;
CREATE TABLE "FacturaProveedor" 
( 
	"OID" bigserial NOT NULL,
	"OID_SERIE" int8,
	"OID_ACREEDOR" int8,
	"TIPO_ACREEDOR" int8,
	"SERIAL" int8 DEFAULT 0 NOT NULL UNIQUE,
	"CODIGO" varchar(255),
	"N_FACTURA" varchar(255),
    "VAT_NUMBER" character varying(255),
    "ACREEDOR" character varying(255),
    "DIRECCION" character varying(255),
    "CODIGO_POSTAL" character varying(255),
    "PROVINCIA" character varying(255),
    "MUNICIPIO" character varying(255),	
	"ANO" int8,
	"FECHA" date,
	"FECHA_REGISTRO" date,
	"FORMA_PAGO" bigint DEFAULT 1,
	"DIAS_PAGO" bigint DEFAULT 0,
	"MEDIO_PAGO" bigint DEFAULT 1,
	"PREVISION_PAGO" date,
	"BASE_IMPONIBLE" decimal(10,2),
	"P_IGIC" decimal(10,2),
	"P_DESCUENTO" decimal(10,2),
	"DESCUENTO" decimal(10,2) default 0,
	"TOTAL" decimal(10,2),
	"NOTA" boolean,
	"OBSERVACIONES" text,
	"CUENTA_BANCARIA" varchar(255)
) WITHOUT OIDS;

DROP TABLE IF EXISTS "CobroREA";
CREATE TABLE "0001"."CobroREA"
(
  "OID" bigserial,
  "OID_COBRO" bigint NOT NULL,
  "OID_EXPEDIENTE" bigint NOT NULL,
  "CANTIDAD" numeric(10,2),
  CONSTRAINT "PK_CobroREA" PRIMARY KEY ("OID")
)
WITHOUT OIDS;

ALTER TABLE "0001"."CobroREA" OWNER TO hangar_admin;
GRANT ALL ON TABLE "0001"."CobroREA" TO hangar_admin;
GRANT ALL ON TABLE "0001"."CobroREA" TO GROUP "HANGAR_ADMINISTRADOR";

ALTER TABLE "FacturaProveedor" ADD CONSTRAINT "PK_FacturaProveedor" PRIMARY KEY ("OID");
ALTER TABLE "FacturaProveedor" OWNER TO hangar_admin;
GRANT ALL ON TABLE "FacturaProveedor" TO hangar_admin;
GRANT ALL ON TABLE "FacturaProveedor" TO GROUP "HANGAR_ADMINISTRADOR";

ALTER TABLE "AlbaranProveedor" ADD CONSTRAINT "FK_AlbaranProveedor_Serie" FOREIGN KEY ("OID_SERIE") REFERENCES "COMMON"."Serie" ("OID")ON UPDATE CASCADE ON DELETE RESTRICT ;
ALTER TABLE "Albaran_FacturaProveedor" ADD CONSTRAINT "FK_Albaran_FacturaProveedor_AlbaranProveedor" FOREIGN KEY ("OID_ALBARAN") REFERENCES "AlbaranProveedor" ("OID") ON UPDATE CASCADE ON DELETE RESTRICT;
ALTER TABLE "Albaran_FacturaProveedor" ADD CONSTRAINT "FK_Albaran_FacturaProveedor_FacturaProveedor" FOREIGN KEY ("OID_FACTURA") REFERENCES "FacturaProveedor" ("OID") ON UPDATE CASCADE ON DELETE CASCADE;
ALTER TABLE "ConceptoAlbaranProveedor" ADD CONSTRAINT "FK_ConceptoAlbaranProveedor_AlbaranProveedor" FOREIGN KEY ("OID_ALBARAN") REFERENCES "AlbaranProveedor" ("OID")ON UPDATE CASCADE ON DELETE CASCADE ;
ALTER TABLE "ConceptoFacturaProveedor" ADD CONSTRAINT "FK_ConceptoFacturaP_FacturaP" FOREIGN KEY ("OID_FACTURA") REFERENCES "FacturaProveedor" ("OID")ON UPDATE CASCADE ON DELETE CASCADE ;
ALTER TABLE "ConceptoFacturaProveedor" ADD CONSTRAINT "FK_ConceptoFacturaP_ConceptoAlbaranP" FOREIGN KEY ("OID_CONCEPTO_ALBARAN") REFERENCES "ConceptoAlbaranProveedor" ("OID")ON UPDATE CASCADE ON DELETE RESTRICT;*/

ALTER TABLE "Empleado" ADD COLUMN "CONTACTO" varchar(255);
ALTER TABLE "Empleado" ADD COLUMN "PAIS" varchar(255);
ALTER TABLE "Empleado" ADD COLUMN "FORMA_PAGO" bigint DEFAULT 1;
ALTER TABLE "Empleado" ADD COLUMN "DIAS_PAGO" bigint DEFAULT 0;
ALTER TABLE "Empleado" ADD COLUMN "MEDIO_PAGO" bigint DEFAULT 1;
ALTER TABLE "Empleado" ADD COLUMN "CUENTA_BANCARIA" varchar(255);
ALTER TABLE "Empleado" ADD COLUMN "CUENTA_ASOCIADA" varchar(255);

--ALTER TABLE "CobroREA" ADD CONSTRAINT "FK_CobroREA_Cobro" FOREIGN KEY ("OID_COBRO") REFERENCES "Cobro" ("OID") ON UPDATE CASCADE ON DELETE CASCADE;
--ALTER TABLE "CobroREA" ADD CONSTRAINT "FK_CobroREA_Expediente" FOREIGN KEY ("OID_EXPEDIENTE") REFERENCES "Expediente" ("OID") ON UPDATE CASCADE ON DELETE CASCADE;

--ALTER TABLE "ConceptoFactura" RENAME COLUMN "OID_ConceptoAlbaran" TO "OID_CONCEPTO_ALBARAN";
--ALTER TABLE "Stock" RENAME COLUMN "OID_ConceptoAlbaran" TO "OID_CONCEPTO_ALBARAN";