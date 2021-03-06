/* UPDATE 3.11.0.0*/

SET SEARCH_PATH = "COMMON";

UPDATE "Variable" SET "VALUE" = '3.11.0.0' WHERE "NAME" = 'DB_VERSION';

ALTER TABLE "Proveedor" ADD COLUMN "TIPO" bigint DEFAULT 1;
UPDATE "Proveedor" SET "TIPO" = 1;

ALTER TABLE "Despachante" ADD COLUMN "TIPO" bigint DEFAULT 5;
UPDATE "Despachante" SET "TIPO" = 5;

ALTER TABLE "Naviera" ADD COLUMN "TIPO" bigint DEFAULT 2;
UPDATE "Naviera" SET "TIPO" = 2;

ALTER TABLE "Transportista" ADD COLUMN "TIPO" bigint DEFAULT 3;
UPDATE "Transportista" SET "TIPO" = 3 WHERE "TIPO_TRANSPORTISTA" = 0 OR "TIPO_TRANSPORTISTA" = 1;
UPDATE "Transportista" SET "TIPO" = 4 WHERE "TIPO_TRANSPORTISTA" = 2;

SET SEARCH_PATH = "0001";

ALTER TABLE "Empleado" ADD COLUMN "TIPO" bigint DEFAULT 6;
UPDATE "Empleado" SET "TIPO" = 6;
