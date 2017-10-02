-- COMMON MODULE COMMON SCHEMA SCRIPT

CREATE TABLE "CARGO"
(
  "OID" bigserial NOT NULL,
  "VALOR" character varying(255) NOT NULL,
  CONSTRAINT "CARGO_PK" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "CARGO" OWNER TO moladmin;
GRANT ALL ON TABLE "CARGO" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "ContactoEmpresa"
(
	"OID" bigserial NOT NULL UNIQUE,
	"OID_EMPRESA" bigint NOT NULL,
    "CARGO" character varying(255),
    "NOMBRE" character varying(255),
    "DNI" character varying(255),
    "DIRECCION" character varying(255),
    "COD_POSTAL" character varying(255),
    "MUNICIPIO" character varying(255),
    "PROVINCIA" character varying(255),
    "TELEFONOS" character varying(255),
	CONSTRAINT "CONTACTOEMPRESA_PK" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "ContactoEmpresa" OWNER TO moladmin;
GRANT ALL ON TABLE "ContactoEmpresa" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE IF EXISTS "Country" CASCADE;
CREATE TABLE "Country" 
( 
	"OID" bigserial NOT NULL,
	"LOCALE" character varying(255) UNIQUE,
    CONSTRAINT "Country_PK" PRIMARY KEY ("OID")
)

ALTER TABLE "Country" OWNER TO moladmin;
GRANT ALL ON TABLE "Country" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "Empresa"
(
	"OID" bigserial NOT NULL UNIQUE,
	"SERIAL" bigint NOT NULL,
    "CODIGO" character varying(255) NOT NULL,
    "NOMBRE" character varying(255),
    "ID" character varying(255),
    "TIPO_ID" bigint NOT NULL,
    "CTA_COTIZACION" character varying(255),
    "DIRECCION" character varying(255),
    "MUNICIPIO" character varying(255),
    "COD_POSTAL" character varying(255),
    "PROVINCIA" character varying(255),
    "TELEFONOS" character varying(255),
    "FAX" character varying(255),
    "URL" character varying(255),
    "EMAIL" character varying(255),
    "RESPONSABLE" character varying(255),
    "LOGO" character varying(255),
    "CUENTA_BANCARIA" character varying(255),
    "P_IRPF" numeric(10,2),
	CONSTRAINT "EMPRESA_PK" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "Empresa" OWNER TO moladmin;
GRANT ALL ON TABLE "Empresa" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "IDIOMA"
(
	"OID" bigserial NOT NULL,
	"VALOR" character varying(255) NOT NULL,
	CONSTRAINT "IDIOMA_PK" PRIMARY KEY ("OID")
)WITHOUT OIDS;

ALTER TABLE "IDIOMA" OWNER TO moladmin;
GRANT ALL ON TABLE "IDIOMA" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "MUNICIPIO"
(
	"OID" bigserial NOT NULL,
	"VALOR" character varying(255) NOT NULL,
    "PROVINCIA" character varying(255),
    "COD_POSTAL" character varying(255),
    "LOCALIDAD" character varying(255),
    "PAIS" character varying(255),
	CONSTRAINT "MUNICIPIO_PK" PRIMARY KEY ("OID")
)WITHOUT OIDS;

ALTER TABLE "MUNICIPIO" OWNER TO moladmin;
GRANT ALL ON TABLE "MUNICIPIO" TO GROUP "MOLEQULE_ADMINISTRATOR";

-- FOREIGN KEYS

ALTER TABLE ONLY "SchemaUser"
    ADD CONSTRAINT "SchemaUser_OID_SCHEMA_fkey" FOREIGN KEY ("OID_SCHEMA") REFERENCES "Empresa"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "CARGO"
    ADD CONSTRAINT "CARGO_VALOR_key" UNIQUE ("VALOR");

ALTER TABLE ONLY "Empresa"
    ADD CONSTRAINT "Empresa_CODIGO_key" UNIQUE ("CODIGO");

ALTER TABLE ONLY "Empresa"
    ADD CONSTRAINT "Empresa_SERIAL_key" UNIQUE ("SERIAL");
	
ALTER TABLE ONLY "IDIOMA"
    ADD CONSTRAINT "IDIOMA_VALOR_key" UNIQUE ("VALOR");
	
ALTER TABLE ONLY "ContactoEmpresa"
    ADD CONSTRAINT "ContactoEmpresa_CARGO_fkey" FOREIGN KEY ("CARGO") REFERENCES "CARGO"("VALOR") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "ContactoEmpresa"
    ADD CONSTRAINT "ContactoEmpresa_OID_EMPRESA_fkey" FOREIGN KEY ("OID_EMPRESA") REFERENCES "Empresa"("OID") ON UPDATE CASCADE ON DELETE CASCADE;
