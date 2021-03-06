-- INVOICE MODULE SCHEMA DATA SCRIPT

-- USERS PRIVILEGES

INSERT INTO "Privilege" ("OID_USER", "OID_ITEM", "READ", "CREATE", "MODIFY", "DELETE") 
	SELECT u."OID", i."OID", FALSE, FALSE, FALSE, FALSE 
	FROM "COMMON"."User" AS u, "COMMON"."SecureItem" AS i
	WHERE (u."OID", i."OID") NOT IN (SELECT "OID_USER", "OID_ITEM" FROM "Privilege");

-- INSERTS

INSERT INTO "Setting" ("NAME", "VALUE") VALUES ('LAST_ENTRY', '1');
INSERT INTO "Setting" ("NAME", "VALUE") VALUES ('JOURNAL', '1');
INSERT INTO "Setting" ("NAME", "VALUE") VALUES ('USE_TPV_COUNT', 'TRUE');
INSERT INTO "Setting" ("NAME", "VALUE") VALUES ('DEFAULT_SERIE_VENTA', '1');
INSERT INTO "Setting" ("NAME", "VALUE") VALUES ('CUENTA_NOMINAS', '');
INSERT INTO "Setting" ("NAME", "VALUE") VALUES ('CUENTA_SEGUROS_SOCIALES', '');
INSERT INTO "Setting" ("NAME", "VALUE") VALUES ('CUENTA_HACIENDA_PUBLICA', '');
INSERT INTO "Setting" ("NAME", "VALUE") VALUES ('CUENTA_REMUNERACIONES', '');
INSERT INTO "Setting" ("NAME", "VALUE") VALUES ('CUENTA_EFECTOS_A_PAGAR', '');
INSERT INTO "Setting" ("NAME", "VALUE") VALUES ('CUENTA_EFECTOS_A_COBRAR', '');
INSERT INTO "Setting" ("NAME", "VALUE") VALUES ('CUENTA_SUBVENCIONES', '');
INSERT INTO "Setting" ("NAME", "VALUE") VALUES ('LINEA_CAJA_LIBRE', 'TRUE');
INSERT INTO "Setting" ("NAME", "VALUE") VALUES ('CAJA_TICKETS', '2');
INSERT INTO "Setting" ("NAME", "VALUE") VALUES ('DEFAULT_TIPO_FACTURACION', '1');
INSERT INTO "Setting" ("NAME", "VALUE") VALUES ('DEFAULT_TIPO_DESCUENTO', '2');
INSERT INTO "Setting" ("NAME", "VALUE") VALUES ('CONTROL_STOCK_NEGATIVO', 'TRUE');
INSERT INTO "Setting" ("NAME", "VALUE") VALUES ('N_DIGITOS_N_FACTURA', '5');
INSERT INTO "Setting" ("NAME", "VALUE") VALUES ('N_DECIMALES_PRECIOS', '5');
INSERT INTO "Setting" ("NAME" , "VALUE") VALUES ('ENVIAR_FACTURAS_PENDIENTES', 'FALSE');
INSERT INTO "Setting" ("NAME" , "VALUE") VALUES ('FECHA_ULTIMO_ENVIO_FACTURAS_PENDIENTES', '01/01/2012');
INSERT INTO "Setting" ("NAME" , "VALUE") VALUES ('HORA_ENVIO_FACTURAS_PENDIENTES', '01/01/2012 00:00');
INSERT INTO "Setting" ("NAME" , "VALUE") VALUES ('PERIODICIDAD_ENVIO_FACTURAS_PENDIENTES', '7');
INSERT INTO "Setting" ("NAME" , "VALUE") VALUES ('PLAZO_ENVIO_FACTURAS_PENDIENTES', '15');
INSERT INTO "Setting" ("NAME" , "VALUE") VALUES ('IMPUESTOS_IMPORTACION', '0');
INSERT INTO "Setting" ("NAME" , "VALUE") VALUES ('TIPO_INTERES_GASTOS_DEMORA', '0');

INSERT INTO "Caja"("OID", "CODIGO", "NOMBRE", "OBSERVACIONES") VALUES (1, '1', 'PRINCIPAL', '');
INSERT INTO "Caja"("OID", "CODIGO", "NOMBRE", "OBSERVACIONES") VALUES (2, '2', 'TICKETS', '');

ALTER SEQUENCE "Caja_OID_seq" RESTART WITH 2;

--UPDATE "0001"."Cliente" SET "CUENTA_CONTABLE" = '43000' || btrim(to_char("NUMERO_CLIENTE", '00000')); 
--UPDATE "0001"."Cliente" SET "CUENTA_CONTABLE" = '4300000000' WHERE "NUMERO_CLIENTE" = 1100; 