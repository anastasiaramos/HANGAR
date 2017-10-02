using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using moleQule.Library.Application;
using moleQule.Library;
using moleQule.Library.Invoice;
using moleQule.Library.Store;
using moleQule.Library.Common;
using moleQule.Face.Invoice;

using moleQule.Face.Store;

namespace moleQule.Face.Application
{
    public partial class SettingsForm : moleQule.Face.SettingsBaseForm
    {
        #region Attributes & Properties

        public new const string ID = "SettingsForm";
        public new static Type Type { get { return typeof(SettingsForm); } }
        
        SerieInfo _serie_venta;
        SerieInfo _serie_compra;
        TipoGastoInfo _nominas;
        TipoGastoInfo _seguros;
        TipoGastoInfo _irpf;
        CashInfo _caja_tickets;

        #endregion

        #region Business Methods

        public void SetBarsVisibility()
        {
            try
            {
                Principal.SetInstructionBarView(Bars_CLB.GetItemCheckState(0) == CheckState.Checked);
                Principal.SetInvoiceBarView(Bars_CLB.GetItemCheckState(1) == CheckState.Checked);
                Principal.SetQualityBarView(Bars_CLB.GetItemCheckState(2) == CheckState.Checked);
                //Principal.SetShowAutopilot(Bars_CLB.GetItemCheckState(3) == CheckState.Checked);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                System.Windows.Forms.Application.ProductName,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
        }

        public void ShowBarsVisibility()
        {
            if (Bars_CLB == null) return;
                
            Bars_CLB.SetItemChecked(0, Principal.GetInstructionBarView());
            Bars_CLB.SetItemChecked(1, Principal.GetInvoiceBarView());
            Bars_CLB.SetItemChecked(2, Principal.GetQualityBarView());
            //Bars_CLB.SetItemChecked(3, Principal.GetShowAutopilot());
        }

        protected override void LoadSettings()
        {
            //APPLICATION SETTINGS 
            LANHost_TB.Text = Principal.GetLANServer();
            WANHost_TB.Text = Principal.GetWANServer();

            // GENERAL SETTINGS
            try { FiltrarAno_CkB.Checked = Library.Common.ModulePrincipal.GetUseActiveYear(); }
            catch { }
            try { AnoActivo_DTP.Value = Library.Common.ModulePrincipal.GetActiveYear(); }
            catch { }

            //NOTIFICACIONES
            try { ShowNofity_CkB.Checked = SettingsMng.Instance.GetShowAutopilot(); }
            catch { }

            try { NotifyFacturasE_CkB.Checked = Library.Invoice.ModulePrincipal.GetNotifyFacturasEmitidas(); }
            catch { }
            try { NotifyFacturasR_CkB.Checked = Library.Store.ModulePrincipal.GetNotifyFacturasRecibidas(); }
            catch { }
            try { NotifyCobros_CkB.Checked = Library.Invoice.ModulePrincipal.GetNotifyCobros(); }
            catch { }
            try { NotifyPagos_CkB.Checked = Library.Store.ModulePrincipal.GetNotifyPagos(); }
            catch { }
            try { NotifyGastos_CkB.Checked = Library.Store.ModulePrincipal.GetNotifyGastos(); }
            catch { }

            try { NotifyFacturasE_TB.Text = Library.Invoice.ModulePrincipal.GetNotifyPlazoFacturasEmitidas().ToString(); }
            catch { }
            try { NotifyFacturasR_TB.Text = Library.Store.ModulePrincipal.GetNotifyPlazoFacturasRecibidas().ToString(); }
            catch { }
            try { NotifyCobros_TB.Text = Library.Invoice.ModulePrincipal.GetNotifyPlazoCobros().ToString(); }
            catch { }
            try { NotifyPagos_TB.Text = Library.Store.ModulePrincipal.GetNotifyPlazoPagos().ToString(); }
            catch { }
            try { NotifyGastos_TB.Text = Library.Store.ModulePrincipal.GetNotifyPlazoGastos().ToString(); }
            catch { }

            // FACTURACION / CAJA
            try
            {
                _serie_venta = SerieInfo.Get(Library.Invoice.ModulePrincipal.GetDefaultSerieSetting());
                SerieVenta_TB.Text = _serie_venta.Nombre;
            }
            catch { }

            try
            {
                _serie_compra = SerieInfo.Get(Library.Store.ModulePrincipal.GetDefaultSerieSetting());
                SerieCompra_TB.Text = _serie_compra.Nombre;
            }
            catch { }

            try { LineaCaja_CkB.Checked = Library.Invoice.ModulePrincipal.GetLineaCajaLibreSetting(); }
            catch { }

            try
            {
                _caja_tickets = CashInfo.Get(Library.Invoice.ModulePrincipal.GetCajaTicketsSetting());
                CajaTickets_TB.Text = _caja_tickets.Nombre;
            }
            catch { }

            // CONTABILIDAD
            CuentaCaja_TB.Text = CashInfo.Get(1, false).CuentaContable;
            CuentaNominas_TB.Text = Library.Invoice.ModulePrincipal.GetCuentaNominasSetting();
            CuentaSegSocial_TB.Text = Library.Invoice.ModulePrincipal.GetCuentaSegurosSocialesSetting();
            CuentaHacienda_TB.Text = Library.Invoice.ModulePrincipal.GetCuentaHaciendaSetting();
            CuentaRemuneraciones_TB.Text = Library.Invoice.ModulePrincipal.GetCuentaRemuneracionesSetting();
            CuentaEfectosAPagar_TB.Text = Library.Invoice.ModulePrincipal.GetCuentaEfectosAPagarSetting();
            CuentaEfectosACobrar_TB.Text = Library.Invoice.ModulePrincipal.GetCuentaEfectosACobrarSetting();
            AsientoInicial_TB.Text = Library.Invoice.ModulePrincipal.GetLastAsientoSetting();
            Diario_TB.Text = Library.Invoice.ModulePrincipal.GetJournalSetting();
            NDigitosCuentasContables_CB.Text = Library.Common.ModulePrincipal.GetNDigitosCuentasContablesSetting().ToString();
            UseTPVCount_CkB.Checked = Library.Invoice.ModulePrincipal.GetUseTPVCountSetting();
            ContabilidadFolder_TB.Text = Library.Invoice.ModulePrincipal.GetContabilidadFolder();

            CuentaCaja_TB.Text = CashInfo.Get(1, false).CuentaContable;

            // NOMINAS
            try
            {
                _nominas = TipoGastoInfo.Get(Library.Store.ModulePrincipal.GetDefaultNominasSetting());
                Nominas_TB.Text = _nominas.Nombre;
            }
            catch { }

            try
            {
                _seguros = TipoGastoInfo.Get(Library.Store.ModulePrincipal.GetDefaultSegurosSetting());
                Seguros_TB.Text = _seguros.Nombre;
            }
            catch { }

            try
            {
                _irpf = TipoGastoInfo.Get(Library.Store.ModulePrincipal.GetDefaultIRPFSetting());
                IRPF_TB.Text = _irpf.Nombre;
            }
            catch { }

            //// BALANCE
            BalancePrintFacturasExplotacion_CkB.Checked = Library.Invoice.ModulePrincipal.GetBalancePrintFacturasExplotacion();
            BalancePrintFacturasAcreedores_CkB.Checked = Library.Invoice.ModulePrincipal.GetBalancePrintFacturasAcreeedores();
            BalancePrintOtrosGastos_CkB.Checked = Library.Invoice.ModulePrincipal.GetBalancePrintOtrosGastos();
            BalancePrintGastosNominas_CkB.Checked = Library.Invoice.ModulePrincipal.GetBalancePrintGastosNominas();
            BalancePrintEfectosPtesVto_CkB.Checked = Library.Invoice.ModulePrincipal.GetBalancePrintEfectosPendientesVto();
            BalancePrintPagosEstimados_CkB.Checked = Library.Invoice.ModulePrincipal.GetBalancePrintPagosEstimados();

            BalancePrintFacturasEmitidas_CkB.Checked = Library.Invoice.ModulePrincipal.GetBalancePrintFacturasEmitidas();
            BalancePrintExistencias_CkB.Checked = Library.Invoice.ModulePrincipal.GetBalancePrintExistencias();
            BalancePrintEfectosNegociados_CkB.Checked = Library.Invoice.ModulePrincipal.GetBalancePrintEfectosNegociados();
            BalancePrintEfectosPendientes_CkB.Checked = Library.Invoice.ModulePrincipal.GetBalancePrintEfectosPendientes();
            BalancePrintAyudasPendientes_CkB.Checked = Library.Invoice.ModulePrincipal.GetBalancePrintAyudasPendientes();
            BalancePrintAyudasCobradas_CkB.Checked = Library.Invoice.ModulePrincipal.GetBalancePrintAyudasCobradas();
            BalancePrintBancos_CkB.Checked = Library.Invoice.ModulePrincipal.GetBalancePrintBancos();

            //Settings de Auditoría 

            try { NotifyAuditorias_CkB.Checked = Library.Quality.ModulePrincipal.GetNotifyAuditorias(); }
            catch { }

            try { NotifyAuditorias_TB.Text = Library.Quality.ModulePrincipal.GetNotifyPlazoAuditorias().ToString(); }
            catch { }

            try { PM_DiscrepanciasN1_TB.Text = Library.Quality.ModulePrincipal.GetPlazoMaximoDiscrepanciasN1Setting().ToString(); }
            catch { }
            try { PM_DiscrepanciasN2_TB.Text = Library.Quality.ModulePrincipal.GetPlazoMaximoDiscrepanciasN2Setting().ToString(); }
            catch { }
            try { PM_DiscrepanciasN3_TB.Text = Library.Quality.ModulePrincipal.GetPlazoMaximoDiscrepanciasN3Setting().ToString(); }
            catch { }
            try { PM_GeneracionInforme_TB.Text = Library.Quality.ModulePrincipal.GetPlazoMaximoGeneracionInformeSetting().ToString(); }
            catch { }
            try { PM_NotificacionDiscrepancias_TB.Text = Library.Quality.ModulePrincipal.GetPlazoMaximoNotificacionDiscrepanciasSetting().ToString(); }
            catch { }
            try { PM_NotificacionFinAuditoria_TB.Text = Library.Quality.ModulePrincipal.GetPlazoMaximoNotificacionFinAuditoriaSetting().ToString(); }
            catch { }
            try { PM_RespuestaAmpliacion_TB.Text = Library.Quality.ModulePrincipal.GetPlazoMaximoRespuestaAmpliacionSetting().ToString(); }
            catch { }
            try { PorcentajeMaximoAmpliacion_TB.Text = Library.Quality.ModulePrincipal.GetPlazoMaximoAmpliacionSetting().ToString(); }
            catch { }
            try { AvisoDiscrepanciasAbiertas_TB.Text = Library.Quality.ModulePrincipal.GetAvisoDiscrepanciasAbiertasSetting().ToString(); }
            catch { }

            //Exámenes

            try { PM_FaltasModulo_TB.Text = Library.Instruction.ModulePrincipal.GetPorcentajeMaximoFaltasModuloSetting().ToString(); }
            catch { }
            try { Pm_ExamenAprobado_TB.Text = Library.Instruction.ModulePrincipal.GetPorcentajeMinimoExamenAprobadoSetting().ToString(); }
            catch { }
            try { PM_FaltasModulo_CB.Checked = Convert.ToBoolean(Library.Instruction.ModulePrincipal.GetCriterioPorcentajeMaximoFaltasModuloSetting()); }
            catch { }
            try { Pm_NotaExamen_CB.Checked = Convert.ToBoolean(Library.Instruction.ModulePrincipal.GetCriterioPorcentajeMinimoExamenAprobadoSetting()); }
            catch { }


            moleQule.Library.HComboBoxSourceList lista_horas_ini = new moleQule.Library.HComboBoxSourceList();

            lista_horas_ini.Add(new ComboBoxSource(1, "9:00"));
            lista_horas_ini.Add(new ComboBoxSource(2, "10:00"));
            lista_horas_ini.Add(new ComboBoxSource(3, "11:00"));
            lista_horas_ini.Add(new ComboBoxSource(4, "12:00"));
            lista_horas_ini.Add(new ComboBoxSource(5, "13:00"));
            lista_horas_ini.Add(new ComboBoxSource(6, "14:00"));
            lista_horas_ini.Add(new ComboBoxSource(7, "15:00"));
            lista_horas_ini.Add(new ComboBoxSource(8, "16:00"));
            lista_horas_ini.Add(new ComboBoxSource(9, "17:00"));
            lista_horas_ini.Add(new ComboBoxSource(10, "18:00"));
            lista_horas_ini.Add(new ComboBoxSource(11, "19:00"));
            lista_horas_ini.Add(new ComboBoxSource(12, "20:00"));
            lista_horas_ini.Add(new ComboBoxSource(13, "21:00"));

            moleQule.Library.HComboBoxSourceList lista_horas_fin = new moleQule.Library.HComboBoxSourceList();

            lista_horas_fin.Add(new ComboBoxSource(1, "9:59"));
            lista_horas_fin.Add(new ComboBoxSource(2, "10:59"));
            lista_horas_fin.Add(new ComboBoxSource(3, "11:59"));
            lista_horas_fin.Add(new ComboBoxSource(4, "12:59"));
            lista_horas_fin.Add(new ComboBoxSource(5, "13:59"));
            lista_horas_fin.Add(new ComboBoxSource(6, "14:59"));
            lista_horas_fin.Add(new ComboBoxSource(7, "15:59"));
            lista_horas_fin.Add(new ComboBoxSource(8, "16:59"));
            lista_horas_fin.Add(new ComboBoxSource(9, "17:59"));
            lista_horas_fin.Add(new ComboBoxSource(10, "18:59"));
            lista_horas_fin.Add(new ComboBoxSource(11, "19:59"));
            lista_horas_fin.Add(new ComboBoxSource(12, "20:59"));
            lista_horas_fin.Add(new ComboBoxSource(13, "21:59"));

            Datos_HorasMI.DataSource = lista_horas_ini;
            Datos_HorasMF.DataSource = lista_horas_fin;
            Datos_HorasT1I.DataSource = lista_horas_ini;
            Datos_HorasT1F.DataSource = lista_horas_fin;
            Datos_HorasT2I.DataSource = lista_horas_ini;
            Datos_HorasT2F.DataSource = lista_horas_fin;

            try { InicioManana_CB.SelectedValue = Convert.ToInt64(Library.Instruction.ModulePrincipal.GetHoraInicioDisponibilidadMananaSetting()); }
            catch { }
            try { FinManana_CB.SelectedValue = Convert.ToInt64(Library.Instruction.ModulePrincipal.GetHoraFinDisponibilidadMananaSetting()); }
            catch { }
            try { InicioTarde1_CB.SelectedValue = Convert.ToInt64(Library.Instruction.ModulePrincipal.GetHoraInicioDisponibilidadTarde1Setting()); }
            catch { }
            try { FinTarde1_CB.SelectedValue = Convert.ToInt64(Library.Instruction.ModulePrincipal.GetHoraFinDisponibilidadTarde1Setting()); }
            catch { }
            try { InicioTarde2_CB.SelectedValue = Convert.ToInt64(Library.Instruction.ModulePrincipal.GetHoraInicioDisponibilidadTarde2Setting()); }
            catch { }
            try { FinTarde2_CB.SelectedValue = Convert.ToInt64(Library.Instruction.ModulePrincipal.GetHoraFinDisponibilidadTarde2Setting()); }
            catch { }

            try { InstructoresAutorizados_CB.Checked = Convert.ToBoolean(Library.Instruction.ModulePrincipal.GetMostrarInstructoresAutorizadosSetting()); }
            catch { }

            try { ImpresionEmpresaDefault_CB.Checked = Convert.ToBoolean(Library.Instruction.ModulePrincipal.GetImpresionEmpresaDefaultBoolSetting()); }
            catch { }

            try { 
                CompanyInfo empresa = CompanyInfo.Get(Convert.ToInt64(Library.Instruction.ModulePrincipal.GetImpresionEmpresaDefaultOidSetting()),false);
                ImpresionEmpresaDefault_TB.Text = empresa.Name;
            }
            catch { }


            base.LoadSettings();
        }

        protected override void SaveSettings()
        {
            //APPLICATION SETTINGS 
            Principal.SetLANServer(LANHost_TB.Text);
            Principal.SetWANServer(WANHost_TB.Text);

            // GENERAL
            Library.Common.ModulePrincipal.SetActiveYear(AnoActivo_DTP.Value);
            Library.Common.ModulePrincipal.SetUseActiveYear(FiltrarAno_CkB.Checked);

            //NOTIFICACIONES
            SettingsMng.Instance.SetShowAutopilot(ShowNofity_CkB.Checked);

            Library.Store.ModulePrincipal.SetNotifyFacturasRecibidas(NotifyFacturasR_CkB.Checked);
            Library.Invoice.ModulePrincipal.SetNotifyFacturasEmitidas(NotifyFacturasE_CkB.Checked);
            Library.Invoice.ModulePrincipal.SetNotifyCobros(NotifyCobros_CkB.Checked);
            Library.Store.ModulePrincipal.SetNotifyPagos(NotifyPagos_CkB.Checked);
            Library.Store.ModulePrincipal.SetNotifyGastos(NotifyGastos_CkB.Checked);

            try { Library.Store.ModulePrincipal.SetNotifyPlazoFacturasRecibidas(Convert.ToInt32(NotifyFacturasR_TB.Text)); }
            catch { }
            try { Library.Invoice.ModulePrincipal.SetNotifyPlazoFacturasEmitidas(Convert.ToInt32(NotifyFacturasE_TB.Text)); }
            catch { }
            try { Library.Invoice.ModulePrincipal.SetNotifyPlazoCobros(Convert.ToInt32(NotifyCobros_TB.Text)); }
            catch { }
            try { Library.Store.ModulePrincipal.SetNotifyPlazoPagos(Convert.ToInt32(NotifyPagos_TB.Text)); }
            catch { }
            try { Library.Store.ModulePrincipal.SetNotifyPlazoGastos(Convert.ToInt32(NotifyGastos_TB.Text)); }
            catch { }

            // FACTURACION / CAJA
            Library.Invoice.ModulePrincipal.SetDefaultSerieSetting((_serie_venta != null) ? _serie_venta.Oid : 0);
            Library.Store.ModulePrincipal.SetDefaultSerieSetting((_serie_compra != null) ? _serie_compra.Oid : 0);
            Library.Invoice.ModulePrincipal.SetLineaCajaLibreSetting(LineaCaja_CkB.Checked);
            Library.Invoice.ModulePrincipal.SetCajaTicketsSetting((_caja_tickets != null) ? _caja_tickets.Oid : 0);

            // CONTABILIDAD
            Library.Common.ModulePrincipal.SetNDigitosCuentasContablesSetting(Convert.ToInt64(NDigitosCuentasContables_CB.Text));
            Library.Invoice.ModulePrincipal.SetCuentaNominasSetting(CuentaNominas_TB.Text);
            Library.Invoice.ModulePrincipal.SetCuentaSegurosSocialesSetting(CuentaSegSocial_TB.Text);
            Library.Invoice.ModulePrincipal.SetCuentaHaciendaSetting(CuentaHacienda_TB.Text);
            Library.Invoice.ModulePrincipal.SetCuentaRemuneracionesSetting(CuentaRemuneraciones_TB.Text);
            Library.Invoice.ModulePrincipal.SetCuentaEfectosACobrarSetting(CuentaEfectosACobrar_TB.Text);
            Library.Invoice.ModulePrincipal.SetCuentaEfectosAPagarSetting(CuentaEfectosAPagar_TB.Text);
            try { Library.Invoice.ModulePrincipal.SetLastAsientoSetting(Convert.ToInt64(AsientoInicial_TB.Text)); }
            catch { }
            try { Library.Invoice.ModulePrincipal.SetJournalSetting(Convert.ToInt64(Diario_TB.Text)); }
            catch { }
            Library.Invoice.ModulePrincipal.SetUseTPVCountSetting(UseTPVCount_CkB.Checked);
            Library.Invoice.ModulePrincipal.SetContabilidadFolder(ContabilidadFolder_TB.Text);

            SetCuentaCaja();

            // NOMINAS
            Library.Store.ModulePrincipal.SetDefaultNominasSetting((_nominas != null) ? _nominas.Oid : 0);
            Library.Store.ModulePrincipal.SetDefaultSegurosSetting((_seguros != null) ? _seguros.Oid : 0);
            Library.Store.ModulePrincipal.SetDefaultIRPFSetting((_irpf != null) ? _irpf.Oid : 0);

            // BALANCE
            Library.Invoice.ModulePrincipal.SetBalancePrintFacturasExplotacion(BalancePrintFacturasExplotacion_CkB.Checked);
            Library.Invoice.ModulePrincipal.SetBalancePrintFacturasAcreeedores(BalancePrintFacturasAcreedores_CkB.Checked);
            Library.Invoice.ModulePrincipal.SetBalancePrintOtrosGastos(BalancePrintOtrosGastos_CkB.Checked);
            Library.Invoice.ModulePrincipal.SetBalancePrintGastosNominas(BalancePrintGastosNominas_CkB.Checked);
            Library.Invoice.ModulePrincipal.SetBalancePrintEfectosPendientesVto(BalancePrintEfectosPtesVto_CkB.Checked);
            Library.Invoice.ModulePrincipal.SetBalancePrintPagosEstimados(BalancePrintPagosEstimados_CkB.Checked);

            Library.Invoice.ModulePrincipal.SetBalancePrintFacturasEmitidas(BalancePrintFacturasEmitidas_CkB.Checked);
            Library.Invoice.ModulePrincipal.SetBalancePrintExistencias(BalancePrintExistencias_CkB.Checked);
            Library.Invoice.ModulePrincipal.SetBalancePrintEfectosNegociados(BalancePrintEfectosNegociados_CkB.Checked);
            Library.Invoice.ModulePrincipal.SetBalancePrintEfectosPendientes(BalancePrintEfectosPendientes_CkB.Checked);
            Library.Invoice.ModulePrincipal.SetBalancePrintAyudasPendientes(BalancePrintAyudasPendientes_CkB.Checked);
            Library.Invoice.ModulePrincipal.SetBalancePrintAyudasCobradas(BalancePrintAyudasCobradas_CkB.Checked);
            Library.Invoice.ModulePrincipal.SetBalancePrintBancos(BalancePrintBancos_CkB.Checked);
            
            //Settings de Auditoría

            Library.Quality.ModulePrincipal.SetNotifyAuditorias(NotifyAuditorias_CkB.Checked);

            try { Library.Quality.ModulePrincipal.SetNotifyPlazoAuditorias(Convert.ToInt32(NotifyAuditorias_TB.Text)); }
            catch { }

            try { Library.Quality.ModulePrincipal.SetAvisoDiscrepanciasAbiertasSetting(Convert.ToInt64(AvisoDiscrepanciasAbiertas_TB.Text)); }
            catch { }

            try { Library.Quality.ModulePrincipal.SetPazoMaximoRespuestaAmpliacionSetting(Convert.ToInt64(PM_RespuestaAmpliacion_TB.Text)); }
            catch { }

            try { Library.Quality.ModulePrincipal.SetPlazoMaximoAmpliacionSetting(Convert.ToInt64(PorcentajeMaximoAmpliacion_TB.Text)); }
            catch { }

            try { Library.Quality.ModulePrincipal.SetPlazoMaximoDiscrepanciasN1Setting(Convert.ToInt64(PM_DiscrepanciasN1_TB.Text)); }
            catch { }

            try { Library.Quality.ModulePrincipal.SetPlazoMaximoDiscrepanciasN2Setting(Convert.ToInt64(PM_DiscrepanciasN2_TB.Text)); }
            catch { }

            try { Library.Quality.ModulePrincipal.SetPlazoMaximoDiscrepanciasN3Setting(Convert.ToInt64(PM_DiscrepanciasN3_TB.Text)); }
            catch { }            

            try { Library.Quality.ModulePrincipal.SetPlazoMaximoGeneracionInformeSetting(Convert.ToInt64(PM_GeneracionInforme_TB.Text)); }
            catch { }

            try { Library.Quality.ModulePrincipal.SetPlazoMaximoNotificacionDiscrepanciasSetting(Convert.ToInt64(PM_NotificacionDiscrepancias_TB.Text)); }
            catch { }

            try { Library.Quality.ModulePrincipal.SetPlazoMaximoNotificacionFinAuditoriaSetting(Convert.ToInt64(PM_NotificacionFinAuditoria_TB.Text)); }
            catch { }

            //Exámenes

            try { Library.Instruction.ModulePrincipal.SetPorcentajeMaximoFaltasModuloSetting(Convert.ToInt64(PM_FaltasModulo_TB.Text)); }
            catch { }
            try { Library.Instruction.ModulePrincipal.SetPorcentajeMinimoExamenAprobadoSetting(Convert.ToInt64(Pm_ExamenAprobado_TB.Text)); }
            catch { }
            try { Library.Instruction.ModulePrincipal.SetCriterioPorcentajeMaximoFaltasModuloSetting(PM_FaltasModulo_CB.Checked); }
            catch { }
            try { Library.Instruction.ModulePrincipal.SetCriterioPorcentajeMinimoExamenAprobadoSetting(Pm_NotaExamen_CB.Checked); }
            catch { }

            //Cuadros de disponibilidad

            try 
            { 
                Library.Instruction.ModulePrincipal.SetHoraInicioDisponibilidadMananaSetting((long)InicioManana_CB.SelectedValue); 
            }
            catch { }
            try 
            {
                if ((long)FinManana_CB.SelectedValue < (long)InicioManana_CB.SelectedValue)
                    FinManana_CB.SelectedValue = InicioManana_CB.SelectedValue;
                Library.Instruction.ModulePrincipal.SetHoraFinDisponibilidadMananaSetting((long)FinManana_CB.SelectedValue); 
            }
            catch { }
            try 
            {
                Library.Instruction.ModulePrincipal.SetHoraInicioDisponibilidadTarde1Setting((long)InicioTarde1_CB.SelectedValue); 
            }
            catch { }
            try
            {
                if ((long)FinTarde1_CB.SelectedValue < (long)InicioTarde1_CB.SelectedValue)
                    FinTarde1_CB.SelectedValue = InicioTarde1_CB.SelectedValue;
                Library.Instruction.ModulePrincipal.SetHoraFinDisponibilidadTarde1Setting((long)FinTarde1_CB.SelectedValue); 
            }
            catch { }

            try
            {
                Library.Instruction.ModulePrincipal.SetHoraInicioDisponibilidadTarde2Setting((long)InicioTarde2_CB.SelectedValue); 
            }
            catch { }
            try
            {
                if ((long)FinTarde2_CB.SelectedValue < (long)InicioTarde2_CB.SelectedValue)
                    FinTarde2_CB.SelectedValue = InicioTarde2_CB.SelectedValue;
                Library.Instruction.ModulePrincipal.SetHoraFinDisponibilidadTarde2Setting((long)FinTarde2_CB.SelectedValue);
            }
            catch { }

            try { Library.Instruction.ModulePrincipal.SetMostrarInstructoresAutorizadosSetting(Convert.ToBoolean(InstructoresAutorizados_CB.Checked)); }
            catch { }

            try { Library.Instruction.ModulePrincipal.SetImpresionEmpresaDefaultBoolSetting(Convert.ToBoolean(ImpresionEmpresaDefault_CB.Checked)); }
            catch { }
            //try { Library.Instruction.ModulePrincipal.SetImpresionEmpresaDefaultOidSetting((long)ImpresionEmpresaDefaultOid_CB.SelectedValue);}
            //catch { }

            Properties.Settings.Default.Save();
            base.SaveSettings();
        }

        protected void SetCuentaCaja()
        {
            Cash caja = Cash.Get(1, false);
            caja.CuentaContable = CuentaCaja_TB.Text;
            caja.Save();
            caja.CloseSession();
        }
                
        #endregion

        #region Factory Methods

        public SettingsForm()
            : base()
        {
            InitializeComponent();
            RefreshMainData();
        }

        public void SetCuentasMask()
        {
            string mask = Library.Invoice.ModuleController.GetCuentasMask();
            SetCuentasMask(mask);
        }
        public void SetCuentasMask(string mask)
        {
            CuentaCaja_TB.Mask = mask;
            CuentaNominas_TB.Mask = mask;
            CuentaSegSocial_TB.Mask = mask;
            CuentaHacienda_TB.Mask = mask;
            CuentaRemuneraciones_TB.Mask = mask;
            CuentaEfectosAPagar_TB.Mask = mask;
            CuentaEfectosACobrar_TB.Mask = mask;
        }

        #endregion

        #region Style & Source

        /// <summary>
        /// Obtiene los datos de origen de los combobox
        /// </summary>
        protected override void RefreshMainData()
        {
            base.RefreshMainData();

            PgMng.Grow();
            ShowBarsVisibility();

            PgMng.Grow();
            
        }

        #endregion

        //#region Actions

        //protected override void SubmitAction()
        //{
        //    SetBarsVisibility();
        //    SetContabilidadSettings();

        //    Library.Common.ModulePrincipal.SaveSettings();
        //    Library.Invoice.ModulePrincipal.SaveSettings();
        //    Library.Store.ModulePrincipal.SaveSettings();
        //    Library.Quality.ModulePrincipal.SaveSettings();

        //    base.SubmitAction();
        //    _action_result = DialogResult.OK;
        //}

        //#endregion

        //#region Buttons

        //private void SerieVenta_BT_Click(object sender, EventArgs e)
        //{
        //    SerieList series = SerieList.GetList(false, ETipoSerie.Venta);
        //    SerieSelectForm form = new SerieSelectForm(this, series);

        //    if (form.ShowDialog() == DialogResult.OK)
        //    {
        //        _serie_venta = form.Selected as SerieInfo;
        //        SerieVenta_TB.Text = _serie_venta.Nombre;
        //    }

        //}

        //private void SerieCompra_BT_Click(object sender, EventArgs e)
        //{
        //    SerieList series = SerieList.GetList(false, ETipoSerie.Compra);
        //    SerieSelectForm form = new SerieSelectForm(this, series);

        //    if (form.ShowDialog() == DialogResult.OK)
        //    {
        //        _serie_compra = form.Selected as SerieInfo;
        //        SerieCompra_TB.Text = _serie_compra.Nombre;
        //    }

        //}

        //private void Examinar_BT_Click(object sender, EventArgs e)
        //{
        //    Browser.ShowDialog();
        //    RutaSalida_TB.Text = Browser.SelectedPath;
        //}

        //#endregion

        //#region Events

        //private void FiltrarAno_CkB_CheckedChanged(object sender, EventArgs e)
        //{
        //    AnoActivo_DTP.Enabled = FiltrarAno_CkB.Checked;
        //}

        //#endregion

        #region Actions

        protected override void SubmitAction()
        {
            SetBarsVisibility();

            Principal.SaveSettings();
            Library.Common.ModulePrincipal.SaveSettings();
            Library.Invoice.ModulePrincipal.SaveSettings();
            Library.Store.ModulePrincipal.SaveSettings();
            Library.Instruction.ModulePrincipal.SaveSettings();
            Library.Quality.ModulePrincipal.SaveSettings();

            base.SubmitAction();
        }

        #endregion

        #region Buttons
        
        private void SerieVenta_BT_Click(object sender, EventArgs e)
        {
            SerieList list = SerieList.GetList(false, ETipoSerie.Venta);
            SerieSelectForm form = new SerieSelectForm(this);

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                _serie_venta = form.Selected as SerieInfo;
                SerieVenta_TB.Text = _serie_venta.Nombre;
            }
        }

        private void SerieCompra_BT_Click(object sender, EventArgs e)
        {
            SerieList list = SerieList.GetList(false, ETipoSerie.Compra);
            SerieSelectForm form = new SerieSelectForm(this, list);

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                _serie_compra = form.Selected as SerieInfo;
                SerieCompra_TB.Text = _serie_compra.Nombre;
            }
        }

        private void CajaTickets_BT_Click(object sender, EventArgs e)
        {
            CashList list = CashList.GetList(false);
            CashSelectForm form = new CashSelectForm(this, list);

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                _caja_tickets = form.Selected as CashInfo;
                CajaTickets_TB.Text = _caja_tickets.Nombre;
            }
        }

        private void Examinar_BT_Click(object sender, EventArgs e)
        {
            Browser.ShowDialog();
            ContabilidadFolder_TB.Text = Browser.SelectedPath;
        }


        private void Seguros_BT_Click(object sender, EventArgs e)
        {
            TipoGastoList list = TipoGastoList.GetList(false);
            TipoGastoSelectForm form = new TipoGastoSelectForm(this, list);

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                _seguros = form.Selected as TipoGastoInfo;
                Seguros_TB.Text = _seguros.Nombre;
            }
        }

        private void IRPF_BT_Click(object sender, EventArgs e)
        {
            TipoGastoList list = TipoGastoList.GetList(false);
            TipoGastoSelectForm form = new TipoGastoSelectForm(this, list);

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                _irpf = form.Selected as TipoGastoInfo;
                IRPF_TB.Text = _irpf.Nombre;
            }
        }

        private void Nominas_BT_Click(object sender, EventArgs e)
        {
            TipoGastoList list = TipoGastoList.GetList(false);
            TipoGastoSelectForm form = new TipoGastoSelectForm(this, list);

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                _nominas = form.Selected as TipoGastoInfo;
                Nominas_TB.Text = _nominas.Nombre;
            }
        }

        #endregion

        #region Events

        private void FiltrarAno_CkB_CheckedChanged(object sender, EventArgs e)
        {
            AnoActivo_DTP.Enabled = FiltrarAno_CkB.Checked;
        }

        #endregion

        private void ImprimirEmpresaDefault_BT_Click(object sender, EventArgs e)
        {
            Common.CompanySelectForm form = new Common.CompanySelectForm(this);
            System.Windows.Forms.DialogResult result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    CompanyInfo selected = form.Selected as CompanyInfo;
                    Library.Instruction.ModulePrincipal.SetImpresionEmpresaDefaultOidSetting(selected.Oid);
                    ImpresionEmpresaDefault_TB.Text = selected.Name;
                }
                catch { }
            }
        }
                
        
    }
}

