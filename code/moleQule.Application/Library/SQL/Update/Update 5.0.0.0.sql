﻿/* UPDATE 5.0.0.0*/

SET SEARCH_PATH = "COMMON";

UPDATE "Variable" SET "VALUE" = '5.0.0.0' WHERE "NAME" = 'DB_VERSION';


SET search_path TO "0001";

ALTER TABLE "CuentaBancaria" ADD COLUMN "ENTIDAD" varchar(255);
ALTER TABLE "Gasto" ADD COLUMN "OID_TIPO" int8 DEFAULT 0;