﻿SET search_path TO "COMMON";
-- HIPATIA MODULE COMMON DATA SCRIPT

-- INSERTS

INSERT INTO "Variable" ("NAME", "VALUE") VALUES ('HIPATIA_DB_VERSION', '4.1.1.2');

INSERT INTO "HPDocumentType" ("OID", "VALOR", "USER_CREATED") VALUES (1, 'IMAGEN', FALSE);
INSERT INTO "HPDocumentType" ("OID", "VALOR", "USER_CREATED") VALUES (2, 'AUDIO', FALSE);
INSERT INTO "HPDocumentType" ("OID", "VALOR", "USER_CREATED") VALUES (3, 'VIDEO', FALSE);
INSERT INTO "HPDocumentType" ("OID", "VALOR", "USER_CREATED") VALUES (5, 'DOCUMENTO DE TEXTO', TRUE);
INSERT INTO "HPDocumentType" ("OID", "VALOR", "USER_CREATED") VALUES (4, 'PDF', TRUE);

-- SECURE ITEMS INSERTS

INSERT INTO "SecureItem" ("NAME", "TIPO", "DESCRIPTOR") VALUES ('Documentos', '101', 'DOCUMENTO');

-- ITEM MAP INSERTS

-- DOCUMENT		-> VARIABLE
--				-> EMPRESA

INSERT INTO "COMMON"."ItemMap" ("OID_ITEM","PRIVILEGE","OID_ASSOCIATE_ITEM","ASSOCIATE_PRIVILEGE")  
	SELECT SI."OID", '1', ASI."OID", '1' 
	FROM "COMMON"."SecureItem" AS SI
	INNER JOIN "COMMON"."SecureItem" AS ASI ON SI."DESCRIPTOR" = 'DOCUMENTO' AND ASI."DESCRIPTOR" = 'VARIABLE';

INSERT INTO "COMMON"."ItemMap" ("OID_ITEM","PRIVILEGE","OID_ASSOCIATE_ITEM","ASSOCIATE_PRIVILEGE")  
	SELECT SI."OID", '2', ASI."OID", '1' 
	FROM "COMMON"."SecureItem" AS SI
	INNER JOIN "COMMON"."SecureItem" AS ASI ON SI."DESCRIPTOR" = 'DOCUMENTO' AND ASI."DESCRIPTOR" = 'VARIABLE';

INSERT INTO "COMMON"."ItemMap" ("OID_ITEM","PRIVILEGE","OID_ASSOCIATE_ITEM","ASSOCIATE_PRIVILEGE")  
	SELECT SI."OID", '3', ASI."OID", '1' 
	FROM "COMMON"."SecureItem" AS SI
	INNER JOIN "COMMON"."SecureItem" AS ASI ON SI."DESCRIPTOR" = 'DOCUMENTO' AND ASI."DESCRIPTOR" = 'VARIABLE';

INSERT INTO "COMMON"."ItemMap" ("OID_ITEM","PRIVILEGE","OID_ASSOCIATE_ITEM","ASSOCIATE_PRIVILEGE")  
	SELECT SI."OID", '4', ASI."OID", '1' 
	FROM "COMMON"."SecureItem" AS SI
	INNER JOIN "COMMON"."SecureItem" AS ASI ON SI."DESCRIPTOR" = 'DOCUMENTO' AND ASI."DESCRIPTOR" = 'VARIABLE';

INSERT INTO "COMMON"."ItemMap" ("OID_ITEM","PRIVILEGE","OID_ASSOCIATE_ITEM","ASSOCIATE_PRIVILEGE")  
	SELECT SI."OID", '1', ASI."OID", '1' 
	FROM "COMMON"."SecureItem" AS SI
	INNER JOIN "COMMON"."SecureItem" AS ASI ON SI."DESCRIPTOR" = 'DOCUMENTO' AND ASI."DESCRIPTOR" = 'EMPRESA';

INSERT INTO "COMMON"."ItemMap" ("OID_ITEM","PRIVILEGE","OID_ASSOCIATE_ITEM","ASSOCIATE_PRIVILEGE")  
	SELECT SI."OID", '2', ASI."OID", '1' 
	FROM "COMMON"."SecureItem" AS SI
	INNER JOIN "COMMON"."SecureItem" AS ASI ON SI."DESCRIPTOR" = 'DOCUMENTO' AND ASI."DESCRIPTOR" = 'EMPRESA'	;

INSERT INTO "COMMON"."ItemMap" ("OID_ITEM","PRIVILEGE","OID_ASSOCIATE_ITEM","ASSOCIATE_PRIVILEGE")  
	SELECT SI."OID", '3', ASI."OID", '1' 
	FROM "COMMON"."SecureItem" AS SI
	INNER JOIN "COMMON"."SecureItem" AS ASI ON SI."DESCRIPTOR" = 'DOCUMENTO' AND ASI."DESCRIPTOR" = 'EMPRESA'	;

INSERT INTO "COMMON"."ItemMap" ("OID_ITEM","PRIVILEGE","OID_ASSOCIATE_ITEM","ASSOCIATE_PRIVILEGE")  
	SELECT SI."OID", '4', ASI."OID", '1' 
	FROM "COMMON"."SecureItem" AS SI
	INNER JOIN "COMMON"."SecureItem" AS ASI ON SI."DESCRIPTOR" = 'DOCUMENTO' AND ASI."DESCRIPTOR" = 'EMPRESA'	;