using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Hangar.Face;
using Hangar.Library;

using Hipatia.Face;
using Hipatia.Library;

using moleQule.Library;

namespace Hangar.Face.Hipatia
{
    public partial class SelectAgenteInputForm1 : SelectAgenteInputBaseForm
    {
        #region Business Methods

        public new const string ID = "SelectAgenteInputForm";
        public new static Type Type { get { return typeof(SelectAgenteInputForm1); } }

        protected override long GetOid()
        {
            switch (_tipo)
            {
                case "Cliente":
                    if (Datos_Agentes.Current == null) return -1;
                    return ((ClienteInfo)Datos_Agentes.Current).Oid;
                case "Alumno":
                    if (Datos_Agentes.Current == null) return -1;
                    return ((AlumnoInfo)Datos_Agentes.Current).Oid;
                case "Empleado":
                    if (Datos_Agentes.Current == null) return -1;
                    return ((InstructorInfo)Datos_Agentes.Current).Oid;
                //case "Factura":
                //    if (Datos_Agentes.Current == null) return -1;
                //    return ((FacturaInfo)Datos_Agentes.Current).Oid;
                case "Auditoria":
                    if (Datos_Agentes.Current == null) return -1;
                    return ((AuditoriaInfo)Datos_Agentes.Current).Oid;
                case "Proveedor":
                    if (Datos_Agentes.Current == null) return -1;
                    return ((ProveedorInfo)Datos_Agentes.Current).Oid;
                case "Promocion":
                    if (Datos_Agentes.Current == null) return -1;
                    return ((PromocionInfo)Datos_Agentes.Current).Oid;
                case "Curso":
                    if (Datos_Agentes.Current == null) return -1;
                    return ((CursoInfo)Datos_Agentes.Current).Oid;
                case "Modulo":
                    if (Datos_Agentes.Current == null) return -1;
                    return ((ModuloInfo)Datos_Agentes.Current).Oid;
                default:
                    return -1;

            }
        }

        #endregion

        #region Factory Methods

        public SelectAgenteInputForm1() 
            : base()
        {
            InitializeComponent();
        }

        #endregion

        #region Style & Source

        protected override void SelectEntities(EntidadInfo entidad)
        {
            _tipo = entidad.Tipo;
            _entity_type_oid = entidad.Oid;
            switch (_tipo)
            {
                case "Cliente":
                    {
                        ClienteList clientes = ClienteList.GetList(false);
                        List<ClienteInfo> lista = new List<ClienteInfo>();

                        foreach (ClienteInfo obj in clientes)
                        {
                            if (entidad.Agentes.GetItemByProperty("Oid", obj.Oid) == null)
                                lista.Add(obj);
                        }
                        Datos_Agentes.DataSource = lista;
                    }
                    break;
                case "Alumno":
                    {
                        AlumnoList alumnos = AlumnoList.GetList(false); ;
                        List<AlumnoInfo> lista = new List<AlumnoInfo>();

                        foreach (AlumnoInfo obj in alumnos)
                        {
                            if (entidad.Agentes.GetItemByProperty("Oid", obj.Oid) == null)
                                lista.Add(obj);
                        }

                        Datos_Agentes.DataSource = lista;
                    }
                    break;
                case "Empleado":
                    {
                        InstructorList empleados = InstructorList.GetList(false);
                        List<InstructorInfo> lista = new List<InstructorInfo>();

                        foreach (InstructorInfo obj in empleados)
                        {
                            if (entidad.Agentes.GetItemByProperty("Oid", obj.Oid) == null)
                                lista.Add(obj);
                        }

                        Datos_Agentes.DataSource = lista;
                    }
                    break;
                //case "Factura":
                //    {
                //        FacturaList facturas = FacturaList.GetList(false);
                //        List<FacturaInfo> lista = new List<FacturaInfo>();

                //        foreach (FacturaInfo obj in facturas)
                //        {
                //            if (!entidad.Agentes.ContainsAgent(obj.Oid))
                //                lista.Add(obj);
                //        }

                //        Datos_Agentes.DataSource = lista;
                //    }
                //    break;
                case "Auditoria":
                    {
                        AuditoriaList auditorias = AuditoriaList.GetList();
                        List<AuditoriaInfo> lista = new List<AuditoriaInfo>();

                        foreach (AuditoriaInfo obj in auditorias)
                        {
                            if (entidad.Agentes.GetItemByProperty("Oid", obj.Oid) == null)
                                lista.Add(obj);
                        }

                        Datos_Agentes.DataSource = lista;
                    }
                    break;
                case "Proveedor":
                    {
                        ProveedorList proveedores = ProveedorList.GetList(false);
                        List<ProveedorInfo> lista = new List<ProveedorInfo>();

                        foreach (ProveedorInfo obj in proveedores)
                        {
                            if (entidad.Agentes.GetItemByProperty("Oid", obj.Oid) == null)
                                lista.Add(obj);
                        }

                        Datos_Agentes.DataSource = lista;
                    }
                    break;
                case "Promocion":
                    {
                        PromocionList promociones = PromocionList.GetList(false);
                        List<PromocionInfo> lista = new List<PromocionInfo>();

                        foreach (PromocionInfo obj in promociones)
                        {
                            if (entidad.Agentes.GetItemByProperty("Oid", obj.Oid) == null)
                                lista.Add(obj);
                        }

                        Datos_Agentes.DataSource = lista;
                    }
                    break;
                case "Curso":
                    {
                        CursoList cursos = CursoList.GetList(false);
                        List<CursoInfo> lista = new List<CursoInfo>();

                        foreach (CursoInfo obj in cursos)
                        {
                            if (entidad.Agentes.GetItemByProperty("Oid", obj.Oid) == null)
                                lista.Add(obj);
                        }

                        Datos_Agentes.DataSource = lista;
                    }
                    break;
                case "Modulo":
                    {
                        ModuloList modulos = ModuloList.GetList(false);
                        List<ModuloInfo> lista = new List<ModuloInfo>();

                        foreach (ModuloInfo obj in modulos)
                        {
                            if (entidad.Agentes.GetItemByProperty("Oid", obj.Oid) == null)
                                lista.Add(obj);
                        }

                        Datos_Agentes.DataSource = lista;
                    }
                    break;
                //default:
                //    _tipo = "";
                //    throw new iQException("No se ha encontrado el tipo de entidad " + entidad.Tipo);

            }
            Format();
        }

        public override void ShowFields()
        {
            switch (_tipo)
            {
                case "Expediente":
                    Tabla.Columns["Nombre"].Visible = false;
                    break;
                
                default:
                    Tabla.Columns["Nombre"].Visible = true;
                    break;
            }
        }
        
        #endregion

    }
}

