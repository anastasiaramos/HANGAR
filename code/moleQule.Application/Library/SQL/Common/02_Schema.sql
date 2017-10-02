-- COMMON MODULE SCHEMA SCRIPT

CREATE TABLE "Ayuda" 
( 
	"OID" bigserial NOT NULL,
	"SERIAL" bigint DEFAULT 0 NOT NULL,
    "CODIGO" character varying(255),
    "ESTADO" bigint DEFAULT 10,
    "NOMBRE" character varying(255),
    "CUENTA_CONTABLE" character varying(255),
    "OBSERVACIONES" text,
	CONSTRAINT "PK_Ayuda" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "Ayuda" OWNER TO moladmin;
GRANT ALL ON TABLE "Ayuda" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "AyudaPeriodo" 
( 
	"OID" bigserial NOT NULL,
	"OID_AYUDA" bigint NOT NULL,
    "ESTADO" bigint DEFAULT 10,
    "TIPO_DESCUENTO" bigint DEFAULT 2,
    "PORCENTAJE" numeric(10,2) DEFAULT 0,
    "CANTIDAD" numeric(10,5) DEFAULT 0,
    "FECHA_INI" timestamp without time zone,
    "FECHA_FIN" timestamp without time zone,
    "OBSERVACIONES" text,
	CONSTRAINT "PK_AyudaPeriodo" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "AyudaPeriodo" OWNER TO moladmin;
GRANT ALL ON TABLE "AyudaPeriodo" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "CuentaBancaria" 
( 
	"OID" bigserial NOT NULL,
	"VALOR" character varying(255),
    "OBSERVACIONES" text,
    "CUENTA_CONTABLE" text,
    "CUENTA_CONTABLE_GASTOS" text,
    "SALDO_INICIAL" numeric(10,2) DEFAULT 0,
    "ESTADO" bigint DEFAULT 10,
    "OID_ASOCIADA" bigint DEFAULT 0,
    "TIPO" bigint DEFAULT 1,
    "ENTIDAD" character varying(255),
    "FECHA_FIRMA" timestamp without time zone,
    "DURACION_POLIZA" timestamp without time zone,
    "COMISION" numeric(10,2),
    "TIPO_INTERES" numeric(10,2),
	"PAGO_GASTOS_INICIO" boolean DEFAULT FALSE,
	"DIAS_CREDITO" bigint,
	CONSTRAINT "PK_CuentaBancaria" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "CuentaBancaria" OWNER TO moladmin;
GRANT ALL ON TABLE "CuentaBancaria" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "Impuesto" 
( 
	"OID" bigserial NOT NULL,
	"NOMBRE" character varying(255),
    "PORCENTAJE" numeric(10,2) DEFAULT 0,
    "CUENTA_CONTABLE_REPERCUTIDO" character varying(255),
    "CUENTA_CONTABLE_SOPORTADO" character varying(255),
    "OBSERVACIONES" text,
	CONSTRAINT "PK_Impuesto" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "Impuesto" OWNER TO moladmin;
GRANT ALL ON TABLE "Impuesto" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "LineaRegistro" 
( 
	"OID" bigserial NOT NULL,
	"OID_REGISTRO" bigint NOT NULL,
    "OID_ENTIDAD" bigint NOT NULL,
    "TIPO_ENTIDAD" bigint,
    "SERIAL" bigint DEFAULT 0 NOT NULL,
    "CODIGO" character varying(255),
    "ESTADO" bigint DEFAULT 1,
    "FECHA" timestamp without time zone,
    "DESCRIPCION" text,
    "OBSERVACIONES" text,
    "ID_EXPORTACION" character varying(255),
	CONSTRAINT "PK_LineaRegistro" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "LineaRegistro" OWNER TO moladmin;
GRANT ALL ON TABLE "LineaRegistro" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "Registro" 
( 
	"OID" bigserial NOT NULL,
	"TIPO_REGISTRO" bigint,
    "SERIAL" bigint DEFAULT 0 NOT NULL,
    "CODIGO" character varying(255),
    "ESTADO" bigint DEFAULT 1,
    "NOMBRE" character varying(255),
    "FECHA" timestamp without time zone,
    "OBSERVACIONES" text,
    "OID_USUARIO" bigint,
	CONSTRAINT "PK_Registro" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "Registro" OWNER TO moladmin;
GRANT ALL ON TABLE "Registro" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE IF EXISTS "Pesaje" CASCADE;
CREATE TABLE "Pesaje" 
( 
	"OID" bigserial NOT NULL,
	"SERIAL" bigint,
    "CODIGO" character varying(255),
    "ESTADO" bigint DEFAULT 1,
    "FECHA" timestamp without time zone,
    "DESCRIPCION" text,
    "BRUTO" numeric(10,2),
    "NETO" numeric(10,2),
    "TARA" numeric(10,2),
    "OBSERVACIONES" text,	
	CONSTRAINT "PK_Pesaje" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "Pesaje" OWNER TO moladmin;
GRANT ALL ON TABLE "Pesaje" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "TarjetaCredito" 
( 
	"OID" bigserial NOT NULL,
	"OID_CUENTA_BANCARIA" bigint NOT NULL,
    "NOMBRE" character varying(255),
    "NUMERACION" character varying(255),
    "CUENTA_CONTABLE" character varying(255),
    "OBSERVACIONES" text,
    "TIPO" bigint DEFAULT 1,
    "FORMA_PAGO" bigint DEFAULT 3,
    "DIAS_PAGO" bigint DEFAULT 1,
    "DIA_EXTRACTO" bigint DEFAULT 3,
	CONSTRAINT "PK_TarjetaCredito" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "TarjetaCredito" OWNER TO moladmin;
GRANT ALL ON TABLE "TarjetaCredito" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "TPV" 
( 
	"OID" bigserial NOT NULL,
	"OID_CUENTA_BANCARIA" bigint NOT NULL,
    "NOMBRE" character varying(255),
    "CUENTA_CONTABLE" character varying(255),
    "OBSERVACIONES" text,
    "P_COMISION" numeric(10,2) DEFAULT 0,
	CONSTRAINT "PK_TPV" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "TPV" OWNER TO moladmin;
GRANT ALL ON TABLE "TPV" TO GROUP "MOLEQULE_ADMINISTRATOR";


ALTER TABLE ONLY "CuentaBancaria"
    ADD CONSTRAINT "CUENTA_BANCARIA_VALOR_key" UNIQUE ("VALOR");

ALTER TABLE ONLY "Impuesto"
    ADD CONSTRAINT "Impuesto_NOMBRE_key" UNIQUE ("NOMBRE");

ALTER TABLE ONLY "TPV"
    ADD CONSTRAINT "TPV_NOMBRE_key" UNIQUE ("NOMBRE");

ALTER TABLE ONLY "TarjetaCredito"
    ADD CONSTRAINT "TarjetaCredito_NOMBRE_key" UNIQUE ("NOMBRE");

ALTER TABLE ONLY "TarjetaCredito"
    ADD CONSTRAINT "TarjetaCredito_NUMERACION_key" UNIQUE ("NUMERACION");

ALTER TABLE ONLY "AyudaPeriodo"
    ADD CONSTRAINT "FK_AyudaPeriodo_Ayuda" FOREIGN KEY ("OID_AYUDA") REFERENCES "Ayuda"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "LineaRegistro"
    ADD CONSTRAINT "FK_LineaRegistro_Registro" FOREIGN KEY ("OID_REGISTRO") REFERENCES "Registro"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "TPV"
    ADD CONSTRAINT "FK_TPV_CuentaBancaria" FOREIGN KEY ("OID_CUENTA_BANCARIA") REFERENCES "CuentaBancaria"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "TarjetaCredito"
    ADD CONSTRAINT "FK_TarjetaCredito_CuentaBancaria" FOREIGN KEY ("OID_CUENTA_BANCARIA") REFERENCES "CuentaBancaria"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;
