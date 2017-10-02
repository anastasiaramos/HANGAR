
SET SEARCH_PATH = "COMMON";

INSERT INTO "0001"."Privilege" ("OID_USER", "OID_ITEM", "READ", "WRITE") 
SELECT u."OID", i."OID", TRUE, TRUE FROM "User" AS u, "SecureItem" AS i
WHERE (u."OID", i."OID") NOT IN (SELECT "OID_USER", "OID_ITEM" FROM "0001"."Privilege");