/* UPDATE 3.4.0.0*/

SET SEARCH_PATH = "COMMON";

UPDATE "Variable" SET "VALUE" = '3.7.0.0' WHERE "NAME" = 'DB_VERSION';

SET SEARCH_PATH = "0001";

ALTER TABLE "MovimientoBanco" DROP CONSTRAINT "MovimientoBanco_CODIGO_key";
ALTER TABLE "MovimientoBanco" DROP CONSTRAINT "MovimientoBanco_SERIAL_key";


/* UPDATE 3.5.0.0*/

SET SEARCH_PATH = "COMMON";

SET SEARCH_PATH = "0001";

ALTER TABLE "MovimientoBanco" ADD COLUMN "FECHA" timestamp without time zone;
ALTER TABLE "MovimientoBanco" ADD COLUMN "ID_OPERACION" varchar(255);
ALTER TABLE "MovimientoBanco" ADD COLUMN "IMPORTE" decimal(10,2);



/* UPDATE 3.6.0.0*/

SET SEARCH_PATH = "COMMON";

INSERT INTO "COMMON"."SecureItem" ("NAME") VALUES ('Informes');

SET SEARCH_PATH = "0001";

CREATE TABLE "Registro" 
( 
	"OID" bigint NOT NULL,
	"TIPO_REGISTRO" int8,
	"SERIAL" int8 DEFAULT 0 NOT NULL,
	"CODIGO" varchar(255),
	"ESTADO" int8 DEFAULT 1,
	"NOMBRE" varchar(255),
	"FECHA" timestamp without time zone,
	"OBSERVACIONES" text,
	CONSTRAINT "PK_Registro" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "Registro" OWNER TO moladmin;
GRANT ALL ON TABLE "Registro" TO moladmin;
GRANT ALL ON TABLE "Registro" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "LineaRegistro" 
( 
	"OID" bigint NOT NULL,
	"OID_REGISTRO" bigserial NOT NULL,
	"OID_ENTIDAD" bigserial NOT NULL,
	"TIPO_ENTIDAD" int8,
	"SERIAL" int8 DEFAULT 0 NOT NULL,
	"CODIGO" varchar(255),
	"ESTADO" int8 DEFAULT 1,
	"FECHA" timestamp without time zone,
	"DESCRIPCION" text,
	"OBSERVACIONES" text,
	CONSTRAINT "PK_LineaRegistro" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "LineaRegistro" OWNER TO moladmin;
GRANT ALL ON TABLE "LineaRegistro" TO moladmin;
GRANT ALL ON TABLE "LineaRegistro" TO GROUP "MOLEQULE_ADMINISTRATOR";

ALTER TABLE "LineaRegistro" ADD CONSTRAINT "FK_LineaRegistro_Registro" FOREIGN KEY ("OID_REGISTRO") REFERENCES "Registro" ("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE "LineaCaja" ADD COLUMN "ESTADO" bigint DEFAULT 1;

UPDATE "LineaCaja" SET "ESTADO" = 1 WHERE "OID_CIERRE" != 0;
UPDATE "LineaCaja" SET "ESTADO" = 8 WHERE "OID_CIERRE" = 0;


/* UPDATE 3.7.0.0*/

SET SEARCH_PATH = "COMMON";


SET SEARCH_PATH = "0001";

ALTER TABLE "Registro" ADD COLUMN "OID_USUARIO" bigint;
ALTER TABLE "LineaRegistro" ADD COLUMN "ID_EXPORTACION" varchar(255);
