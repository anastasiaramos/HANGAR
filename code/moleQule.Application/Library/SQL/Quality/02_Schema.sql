-- QUALITY DETAIL SCHEMA SCRIPT

DROP TABLE IF EXISTS "AccionCorrectora" CASCADE;
CREATE TABLE "AccionCorrectora"
(
	"OID" bigserial NOT NULL,
	"OID_INFORME_CORRECTOR" bigint NOT NULL,
    "OID_DISCREPANCIA" bigint NOT NULL,
    "TEXTO" character varying,
    "NUMERO" bigint NOT NULL,
    "CODIGO" character varying(255) NOT NULL,
    "SERIAL" bigint NOT NULL,
	CONSTRAINT "AccionCorrectora_PK" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "AccionCorrectora" OWNER TO moladmin;
GRANT ALL ON TABLE "AccionCorrectora" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE IF EXISTS "ActaComite" CASCADE;
CREATE TABLE "ActaComite"
(
	"OID" bigserial NOT NULL,
	"CODIGO" character varying(255),
    "SERIAL" bigint NOT NULL,
    "TITULO" character varying(255),
    "REVISION" bigint NOT NULL,
    "MOTIVO" character varying,
    "FECHA" date,
	CONSTRAINT "ActaComite_PK" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "ActaComite" OWNER TO moladmin;
GRANT ALL ON TABLE "ActaComite" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE IF EXISTS "Ampliacion" CASCADE;
CREATE TABLE "Ampliacion"
(
	"OID" bigserial NOT NULL,
	"OID_INFORME_AMPLIACION" bigint NOT NULL,
    "OID_DISCREPANCIA" bigint NOT NULL,
    "FECHA_DEBIDA" date NOT NULL,
    "FECHA_CIERRE" date,
    "OBSERVACIONES" character varying(255),
    "CODIGO" character varying(255) NOT NULL,
    "SERIAL" bigint NOT NULL,
	CONSTRAINT "Ampliacion_PK" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "Ampliacion" OWNER TO moladmin;
GRANT ALL ON TABLE "Ampliacion" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE IF EXISTS "Area" CASCADE;
CREATE TABLE "Area"
(
	"OID" bigserial NOT NULL,
	"NOMBRE" character varying(255) NOT NULL,
    "CODIGO" character varying(255) NOT NULL,
    "SERIAL" bigint NOT NULL,
    "OBSERVACIONES" character varying(255),
	CONSTRAINT "Area_PK" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "Area" OWNER TO moladmin;
GRANT ALL ON TABLE "Area" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE IF EXISTS "Auditoria" CASCADE;
CREATE TABLE "Auditoria"
(
	"OID" bigserial NOT NULL,
	"OID_AUDITOR" bigint NOT NULL,
    "OID_TIPO_AUDITORIA" bigint NOT NULL,
    "CODIGO" character varying(255) NOT NULL,
    "SERIAL" bigint NOT NULL,
    "FECHA_INICIO" date NOT NULL,
    "FECHA_FIN" date NOT NULL,
    "REFERENCIA" character varying(255),
    "OBSERVACIONES" character varying(255),
    "OID_PLAN" bigint DEFAULT 5 NOT NULL,
    "ESTADO" bigint DEFAULT 1 NOT NULL,
    "OID_RESPONSABLE" bigint NOT NULL,
    "OID_USUARIO_AUDITOR" bigint DEFAULT 1 NOT NULL,
    "OID_USUARIO_RESPONSABLE" bigint DEFAULT 1 NOT NULL,
    "OID_DEPARTAMENTO_AUDITOR" bigint,
    "OID_DEPARTAMENTO_RESPONSABLE" bigint,
    "OID_PLAN_TIPO" bigint NOT NULL,
    "FECHA_COMUNICACION" date,
	CONSTRAINT "Auditoria_PK" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "Auditoria" OWNER TO moladmin;
GRANT ALL ON TABLE "Auditoria" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE IF EXISTS "Auditoria_Area" CASCADE;
CREATE TABLE "Auditoria_Area"
(
	"OID" bigserial NOT NULL,
	"OID_AUDITORIA" bigint NOT NULL,
    "OID_AREA" bigint NOT NULL,
	CONSTRAINT "Auditoria_Area_PK" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "Auditoria_Area" OWNER TO moladmin;
GRANT ALL ON TABLE "Auditoria_Area" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE IF EXISTS "ClaseAuditoria" CASCADE;
CREATE TABLE "ClaseAuditoria"
(
	"OID" bigserial NOT NULL,
	"CODIGO" character varying(255) NOT NULL,
    "SERIAL" bigint NOT NULL,
    "NUMERO" bigint,
    "TIPO" character varying(255),
    "NOMBRE" character varying(255) NOT NULL,
    "OBSERVACIONES" text,
	CONSTRAINT "ClaseAuditoria_PK" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "ClaseAuditoria" OWNER TO moladmin;
GRANT ALL ON TABLE "ClaseAuditoria" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE IF EXISTS "Criterio" CASCADE;
CREATE TABLE "Criterio"
(
	"OID" bigserial NOT NULL,
	"OID_TIPO_AUDITORIA" bigint NOT NULL,
    "NOMBRE" character varying NOT NULL,
    "NUMERO" bigint NOT NULL,
	CONSTRAINT "Criterio_PK" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "Criterio" OWNER TO moladmin;
GRANT ALL ON TABLE "Criterio" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE IF EXISTS "Cuestion" CASCADE;
CREATE TABLE "Cuestion"
(
	"OID" bigserial NOT NULL,
	"OID_TIPO_AUDITORIA" bigint NOT NULL,
    "NUMERO" bigint NOT NULL,
    "TEXTO" character varying(255) NOT NULL,
    "NOTA" character varying(255),
    "REFERENCIAS" character varying(255),
	CONSTRAINT "Cuestion_PK" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "Cuestion" OWNER TO moladmin;
GRANT ALL ON TABLE "Cuestion" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE IF EXISTS "CuestionAuditoria" CASCADE;
CREATE TABLE "CuestionAuditoria"
(
	"OID" bigserial NOT NULL,
	"OID_AUDITORIA" bigint NOT NULL,
    "OID_CUESTION" bigint NOT NULL,
    "NUMERO" bigint NOT NULL,
    "ACEPTADO" boolean,
    "OBSERVACIONES" character varying,
	CONSTRAINT "CuestionAuditoria_PK" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "CuestionAuditoria" OWNER TO moladmin;
GRANT ALL ON TABLE "CuestionAuditoria" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE IF EXISTS "Departamento" CASCADE;
CREATE TABLE "Departamento"
(
	"OID" bigserial NOT NULL,
	"CODIGO" character varying(255),
    "SERIAL" bigint NOT NULL,
    "NOMBRE" character varying(255),
    "TELEFONOS" character varying(255),
    "FAX" character varying(255),
    "EMAIL" character varying(255),
	CONSTRAINT "Departamento_PK" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "Departamento" OWNER TO moladmin;
GRANT ALL ON TABLE "Departamento" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE IF EXISTS "Discrepancia" CASCADE;
CREATE TABLE "Discrepancia"
(
	"OID" bigserial NOT NULL,
	"OID_INFORME" bigint NOT NULL,
    "NUMERO" bigint NOT NULL,
    "TEXTO" character varying(255),
    "NIVEL" bigint NOT NULL,
    "FECHA_DEBIDA" date NOT NULL,
    "OBSERVACIONES" character varying(255),
    "FECHA_CIERRE" date,
    "CODIGO" character varying(255) NOT NULL,
    "SERIAL" bigint NOT NULL,
    "OID_CUESTION" bigint NOT NULL,
    "DISCREPANCIA" boolean DEFAULT true,
    "FECHA_AMPLIACION" date NOT NULL,
	CONSTRAINT "Discrepancia_PK" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "Discrepancia" OWNER TO moladmin;
GRANT ALL ON TABLE "Discrepancia" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE IF EXISTS "HistoriaAuditoria" CASCADE;
CREATE TABLE "HistoriaAuditoria"
(
	"OID" bigserial NOT NULL,
	"OID_AUDITORIA" bigint NOT NULL,
    "OID_EMPLEADO" bigint NOT NULL,
    "ESTADO" bigint NOT NULL,
    "OBSERVACIONES" character varying,
    "FECHA" date,
    "HORA" time without time zone,
	CONSTRAINT "HistoriaAuditoria_PK" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "HistoriaAuditoria" OWNER TO moladmin;
GRANT ALL ON TABLE "HistoriaAuditoria" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE IF EXISTS "Incidencia" CASCADE;
CREATE TABLE "Incidencia"
(
	"OID" bigserial NOT NULL,
	"OID_AGENTE" bigint NOT NULL,
    "TIPO_AGENTE" character varying(255),
    "CODIGO" character varying(255) NOT NULL,
    "SERIAL" bigint NOT NULL,
    "FECHA" timestamp without time zone,
    "TEXTO" text,
    "OBSERVACIONES" text,
	CONSTRAINT "Incidencia_PK" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "Incidencia" OWNER TO moladmin;
GRANT ALL ON TABLE "Incidencia" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE IF EXISTS "InformeAmpliacion" CASCADE;
CREATE TABLE "InformeAmpliacion"
(
	"OID" bigserial NOT NULL,
	"OID_INFORME_DISCREPANCIA" bigint NOT NULL,
    "FECHA" date NOT NULL,
    "OBSERVACIONES" character varying,
    "CODIGO" character varying(255) NOT NULL,
    "SERIAL" bigint NOT NULL,
    "NOTIFICADO" boolean DEFAULT false,
    "TITULO" character varying,
    "FECHA_CREACION" timestamp without time zone,
    "VALORADO" boolean DEFAULT false,
    "FECHA_COMUNICACION" date,
    "NUMERO" character varying NOT NULL,
	CONSTRAINT "InformeAmpliacion_PK" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "InformeAmpliacion" OWNER TO moladmin;
GRANT ALL ON TABLE "InformeAmpliacion" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE IF EXISTS "InformeCorrector" CASCADE;
CREATE TABLE "InformeCorrector"
(
	"OID" bigserial NOT NULL,
	"OID_INFORME_DISCREPANCIA" bigint NOT NULL,
    "FECHA" date NOT NULL,
    "OBSERVACIONES" character varying,
    "CODIGO" character varying(255) NOT NULL,
    "SERIAL" bigint NOT NULL,
    "NOTIFICADO" boolean DEFAULT false,
    "TITULO" character varying,
    "FECHA_CREACION" timestamp without time zone,
    "FECHA_COMUNICACION" date,
    "NUMERO" character varying NOT NULL,
	CONSTRAINT "InformeCorrector_PK" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "InformeCorrector" OWNER TO moladmin;
GRANT ALL ON TABLE "InformeCorrector" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE IF EXISTS "InformeDiscrepancia" CASCADE;
CREATE TABLE "InformeDiscrepancia"
(
	"OID" bigserial NOT NULL,
	"OID_AUDITORIA" bigint NOT NULL,
    "FECHA" date NOT NULL,
    "OBSERVACIONES" character varying,
    "CODIGO" character varying(255) NOT NULL,
    "SERIAL" bigint NOT NULL,
    "NOTIFICADO" boolean DEFAULT false,
    "TITULO" character varying,
    "FECHA_CREACION" timestamp without time zone,
    "FECHA_COMUNICACION" date,
    "NUMERO" character varying NOT NULL,
	CONSTRAINT "InformeDiscrepancia_PK" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "InformeDiscrepancia" OWNER TO moladmin;
GRANT ALL ON TABLE "InformeDiscrepancia" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE IF EXISTS "NotificacionInterna" CASCADE;
CREATE TABLE "NotificacionInterna"
(
	"OID" bigserial NOT NULL,
	"OID_ASOCIADO" bigint NOT NULL,
    "TIPO_ASOCIADO" bigint NOT NULL,
    "CODIGO" character varying(255) NOT NULL,
    "SERIAL" bigint NOT NULL,
    "NUMERO" bigint NOT NULL,
    "COMENTARIOS" character varying,
    "ASUNTO" character varying NOT NULL,
    "FECHA" date NOT NULL,
    "ATENCION" character varying(255),
    "COPIA" character varying(255),
	CONSTRAINT "NotificacionInterna_PK" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "NotificacionInterna" OWNER TO moladmin;
GRANT ALL ON TABLE "NotificacionInterna" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE IF EXISTS "PlanAnual" CASCADE;
CREATE TABLE "PlanAnual"
(
	"OID" bigserial NOT NULL,
	"CODIGO" character varying(255) NOT NULL,
    "SERIAL" bigint NOT NULL,
    "NOMBRE" character varying(255) NOT NULL,
    "OBSERVACIONES" character varying(255),
    "EDICION" character varying(255) NOT NULL,
    "REVISION" character varying(255) NOT NULL,
    "FECHA" date NOT NULL,
    "ANO" bigint,
	CONSTRAINT "PlanAnual_PK" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "PlanAnual" OWNER TO moladmin;
GRANT ALL ON TABLE "PlanAnual" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE IF EXISTS "Plan_Tipo" CASCADE;
CREATE TABLE "Plan_Tipo"
(
	"OID" bigserial NOT NULL,
	"OID_PLAN" bigint NOT NULL,
    "OID_TIPO" bigint NOT NULL,
    "ORDEN" bigint NOT NULL,
    "ENERO" boolean DEFAULT false,
    "FEBRERO" boolean DEFAULT false,
    "MARZO" boolean DEFAULT false,
    "ABRIL" boolean DEFAULT false,
    "MAYO" boolean DEFAULT false,
    "JUNIO" boolean DEFAULT false,
    "JULIO" boolean DEFAULT false,
    "AGOSTO" boolean DEFAULT false,
    "SEPTIEMBRE" boolean DEFAULT false,
    "OCTUBRE" boolean DEFAULT false,
    "NOVIEMBRE" boolean DEFAULT false,
    "DICIEMBRE" boolean DEFAULT false,
	CONSTRAINT "Plan_Tipo_PK" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "Plan_Tipo" OWNER TO moladmin;
GRANT ALL ON TABLE "Plan_Tipo" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE IF EXISTS "PuntoActa" CASCADE;
CREATE TABLE "PuntoActa"
(
	"OID" bigserial NOT NULL,
	"OID_ACTA" bigint NOT NULL,
    "CODIGO" character varying(255),
    "SERIAL" bigint NOT NULL,
    "TEXTO" character varying(255),
    "NUMERO" bigint NOT NULL,
	CONSTRAINT "PuntoActa_PK" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "PuntoActa" OWNER TO moladmin;
GRANT ALL ON TABLE "PuntoActa" TO GROUP "MOLEQULE_ADMINISTRATOR";

DROP TABLE IF EXISTS "TipoAuditoria" CASCADE;
CREATE TABLE "TipoAuditoria"
(
	"OID" bigserial NOT NULL,
	"OID_CLASE_AUDITORIA" bigint NOT NULL,
    "CODIGO" character varying(255) NOT NULL,
    "SERIAL" bigint NOT NULL,
    "NOMBRE" character varying(255) NOT NULL,
    "DOCUMENTACION" character varying(255),
    "APRECIACIONES" character varying(255),
    "NUMERO" character varying(255) NOT NULL,
    "ENERO" boolean DEFAULT false,
    "FEBRERO" boolean DEFAULT false,
    "MARZO" boolean DEFAULT false,
    "ABRIL" boolean DEFAULT false,
    "MAYO" boolean DEFAULT false,
    "JUNIO" boolean DEFAULT false,
    "JULIO" boolean DEFAULT false,
    "AGOSTO" boolean DEFAULT false,
    "SEPTIEMBRE" boolean DEFAULT false,
    "OCTUBRE" boolean DEFAULT false,
    "NOVIEMBRE" boolean DEFAULT false,
    "DICIEMBRE" boolean DEFAULT false,
    "TEXTO_INFORME" character varying,
	CONSTRAINT "TipoAuditoria_PK" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "TipoAuditoria" OWNER TO moladmin;
GRANT ALL ON TABLE "TipoAuditoria" TO GROUP "MOLEQULE_ADMINISTRATOR";

-- FOREIGN KEYS

ALTER TABLE ONLY "Area"
    ADD CONSTRAINT uq_area_codigo UNIQUE ("CODIGO");

ALTER TABLE ONLY "Area"
    ADD CONSTRAINT uq_area_serial UNIQUE ("SERIAL");

ALTER TABLE ONLY "Auditoria"
    ADD CONSTRAINT uq_auditoria_codigo UNIQUE ("CODIGO");

ALTER TABLE ONLY "Auditoria"
    ADD CONSTRAINT uq_auditoria_serial UNIQUE ("SERIAL");

ALTER TABLE ONLY "ClaseAuditoria"
    ADD CONSTRAINT uq_claseauditoria_codigo UNIQUE ("CODIGO");

ALTER TABLE ONLY "ClaseAuditoria"
    ADD CONSTRAINT uq_claseauditoria_serial UNIQUE ("SERIAL");

ALTER TABLE ONLY "Incidencia"
    ADD CONSTRAINT uq_incidencia_codigo UNIQUE ("CODIGO");

ALTER TABLE ONLY "Incidencia"
    ADD CONSTRAINT uq_incidencia_oid UNIQUE ("OID");

ALTER TABLE ONLY "Incidencia"
    ADD CONSTRAINT uq_incidencia_serial UNIQUE ("SERIAL");

ALTER TABLE ONLY "PlanAnual"
    ADD CONSTRAINT uq_plananual_codigo UNIQUE ("CODIGO");

ALTER TABLE ONLY "PlanAnual"
    ADD CONSTRAINT uq_plananual_serial UNIQUE ("SERIAL");

ALTER TABLE ONLY "TipoAuditoria"
    ADD CONSTRAINT uq_tipoauditoria_codigo UNIQUE ("CODIGO");

ALTER TABLE ONLY "TipoAuditoria"
    ADD CONSTRAINT uq_tipoauditoria_serial UNIQUE ("SERIAL");

ALTER TABLE ONLY "AccionCorrectora"
    ADD CONSTRAINT fk_accioncorrectora_discrepancia FOREIGN KEY ("OID_DISCREPANCIA") REFERENCES "Discrepancia"("OID") ON UPDATE CASCADE;

ALTER TABLE ONLY "AccionCorrectora"
    ADD CONSTRAINT fk_accioncorrectora_informecorrector FOREIGN KEY ("OID_INFORME_CORRECTOR") REFERENCES "InformeCorrector"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "Ampliacion"
    ADD CONSTRAINT fk_ampliacion_discrepancia FOREIGN KEY ("OID_DISCREPANCIA") REFERENCES "Discrepancia"("OID") ON UPDATE CASCADE;

ALTER TABLE ONLY "Ampliacion"
    ADD CONSTRAINT fk_ampliacion_informeampliacion FOREIGN KEY ("OID_INFORME_AMPLIACION") REFERENCES "InformeAmpliacion"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "Auditoria_Area"
    ADD CONSTRAINT fk_auditoria_area_area FOREIGN KEY ("OID_AREA") REFERENCES "Area"("OID") ON UPDATE CASCADE;

	ALTER TABLE ONLY "Auditoria_Area"
    ADD CONSTRAINT fk_auditoria_area_auditoria FOREIGN KEY ("OID_AUDITORIA") REFERENCES "TipoAuditoria"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "Auditoria"
    ADD CONSTRAINT fk_auditoria_empleado FOREIGN KEY ("OID_AUDITOR") REFERENCES "Empleado"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "Auditoria"
    ADD CONSTRAINT fk_auditoria_plan_tipo FOREIGN KEY ("OID_PLAN_TIPO") REFERENCES "Plan_Tipo"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "Auditoria"
    ADD CONSTRAINT fk_auditoria_plananual FOREIGN KEY ("OID_PLAN") REFERENCES "PlanAnual"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "Auditoria"
    ADD CONSTRAINT fk_auditoria_responsable FOREIGN KEY ("OID_RESPONSABLE") REFERENCES "Empleado"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "Auditoria"
    ADD CONSTRAINT fk_auditoria_tipoauditoria FOREIGN KEY ("OID_TIPO_AUDITORIA") REFERENCES "TipoAuditoria"("OID") ON UPDATE CASCADE;

ALTER TABLE ONLY "Auditoria"
    ADD CONSTRAINT fk_auditoria_user_auditor FOREIGN KEY ("OID_USUARIO_AUDITOR") REFERENCES "COMMON"."User"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "Auditoria"
    ADD CONSTRAINT fk_auditoria_user_responsable FOREIGN KEY ("OID_USUARIO_RESPONSABLE") REFERENCES "COMMON"."User"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "Criterio"
    ADD CONSTRAINT fk_criterio_tipoauditoria FOREIGN KEY ("OID_TIPO_AUDITORIA") REFERENCES "TipoAuditoria"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "Cuestion"
    ADD CONSTRAINT fk_cuestion_tipoauditoria FOREIGN KEY ("OID_TIPO_AUDITORIA") REFERENCES "TipoAuditoria"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "CuestionAuditoria"
    ADD CONSTRAINT fk_cuestionauditoria_auditoria FOREIGN KEY ("OID_AUDITORIA") REFERENCES "Auditoria"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "CuestionAuditoria"
    ADD CONSTRAINT fk_cuestionauditoria_cuestion FOREIGN KEY ("OID_CUESTION") REFERENCES "Cuestion"("OID") ON UPDATE CASCADE;

ALTER TABLE ONLY "Discrepancia"
    ADD CONSTRAINT fk_discrepancia_cuestionauditoria FOREIGN KEY ("OID_CUESTION") REFERENCES "CuestionAuditoria"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "Discrepancia"
    ADD CONSTRAINT fk_discrepancia_informediscrepancia FOREIGN KEY ("OID_INFORME") REFERENCES "InformeDiscrepancia"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "HistoriaAuditoria"
    ADD CONSTRAINT fk_historia_auditoria FOREIGN KEY ("OID_AUDITORIA") REFERENCES "Auditoria"("OID") ON UPDATE RESTRICT ON DELETE RESTRICT;

ALTER TABLE ONLY "HistoriaAuditoria"
    ADD CONSTRAINT fk_historia_empleado FOREIGN KEY ("OID_EMPLEADO") REFERENCES "Empleado"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "InformeAmpliacion"
    ADD CONSTRAINT fk_informeampliacion_informediscrepancia FOREIGN KEY ("OID_INFORME_DISCREPANCIA") REFERENCES "InformeDiscrepancia"("OID") ON UPDATE CASCADE;

ALTER TABLE ONLY "InformeCorrector"
    ADD CONSTRAINT fk_informecorrector_informediscrepancia FOREIGN KEY ("OID_INFORME_DISCREPANCIA") REFERENCES "InformeDiscrepancia"("OID") ON UPDATE CASCADE;

ALTER TABLE ONLY "InformeDiscrepancia"
    ADD CONSTRAINT fk_informediscrepancia_auditoria FOREIGN KEY ("OID_AUDITORIA") REFERENCES "Auditoria"("OID") ON UPDATE CASCADE;

ALTER TABLE ONLY "Plan_Tipo"
    ADD CONSTRAINT fk_plan_tipo_plananual FOREIGN KEY ("OID_PLAN") REFERENCES "PlanAnual"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "Plan_Tipo"
    ADD CONSTRAINT fk_plan_tipo_tipoauditoria FOREIGN KEY ("OID_TIPO") REFERENCES "TipoAuditoria"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "PuntoActa"
    ADD CONSTRAINT fk_puntoacta_actacomite FOREIGN KEY ("OID_ACTA") REFERENCES "ActaComite"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "TipoAuditoria"
    ADD CONSTRAINT fk_tipoauditoria_claseauditoria FOREIGN KEY ("OID_CLASE_AUDITORIA") REFERENCES "ClaseAuditoria"("OID") ON UPDATE CASCADE;
