using App.Infraestructure.Connect.Entities;
using App.Infraestructure.Connect.Entities.Scp;
using App.Infraestructure.Connect.Entities.Share;
using App.Infraestructure.Connect.Entities.T;
using App.Infraestructure.Connect.Entities.TblAud;
using App.Infraestructure.Connect.Entities.TblCom;
using App.Infraestructure.Connect.Entities.TblDoc;
using App.Infraestructure.Connect.Entities.TblInd;
using App.Infraestructure.Connect.Entities.TblMast;
using App.Infraestructure.Connect.Entities.Tipo;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace App.Infraestructure.Connect;

public class ConnectContext : DbContext
{
    public ConnectContext(DbContextOptions Options) : base(Options){}

    #region HELPERS
    public DbSet<Exception_LogEntities> Exception_Log { get; set; }
    #endregion

    #region SCP
    public DbSet<scp_UsuariosEntities> SCP_Usuario { get; set; }
    public DbSet<scp_ClientesEntities> SCP_Clientes { get; set; }
    public DbSet<scp_CargosEntities> SCP_Cargos { get; set; }
    public DbSet<scp_CargosProcesosEntities> SCP_CargosProcesos { get; set; }
    public DbSet<scp_EmpresasEntities> SCP_Empresas { get; set; }
    public DbSet<scp_FuncionariosEntities> SCP_Funcionarios { get; set; }
    public DbSet<scp_RolesEntities> SCP_Roles { get; set; }
    public DbSet<scp_UsuariosRolesEntities> SCP_UsuariosRoles { get; set; }
    public DbSet<scp_ProcesosEntities> SCP_Procesos { get; set; }
    public DbSet<scp_EmpresasTitulosEntities> SCP_EmpresasTitulos { get; set; }
    public DbSet<scp_ParametrosEmpresasEntities> SCP_ParametrosEmpresas { get; set; }
    #endregion

    #region TBL-MAST
    public DbSet<tbl_mast_OficinasEntities> TBL_mast_Oficinas { get; set; }
    public DbSet<tbl_mast_ZonasEntities> TBL_mast_Zonas { get; set; }
    public DbSet<tbl_mast_SistemasGestionEntities> TBL_mast_SistemasGestion { get; set; }
    #endregion

    #region TBL-AUD
    public DbSet<auditoriasEntities> Auditorias { get; set; }
    public DbSet<tbl_aud_EvaAuditoresEntities> TBL_aud_EvaAuditores { get; set; }
    public DbSet<tbl_aud_EvaPreguntasEntities> TBL_aud_EvaPreguntas { get; set; }
    public DbSet<tbl_aud_preguntasEntities> TBL_aud_preguntas { get; set; }
    #endregion

    #region TBL-COM
    public DbSet<tbl_com_ProgramacionMasivaEvaluacionesEntities> TBL_com_ProgramacionMasivaEvaluacion { get; set; }
    public DbSet<tbl_com_EncabezadoEvaEntities> TBL_com_Encabezado { get; set; }
    public DbSet<tbl_com_ProgEvaluacionEntities> TBL_com_ProgEvaluacion { get; set; }
    public DbSet<tbl_com_NormasEntities> TBL_com_Normas { get; set; }
    public DbSet<tbl_com_ResultadosEvaluacionEntities> TBL_com_ResultadosEvaluacion { get; set; }
    public DbSet<tbl_com_ResultadosEntities> TBL_com_Resultados { get; set; }
    public DbSet<tbl_com_EscalaEvaluacionEntities> TBL_com_EscalaEvaluacion { get; set; }
    public DbSet<tbl_com_TxtFormEvaluacionEntities> TBL_com_TxtFormEvaluacion { get; set; }
    public DbSet<tbl_com_ResultadosEvaIndicadoresEntities> TBL_com_ResultadosEvaIndicadores { get; set; }
    public DbSet<tbl_com_AspectosValoracionEntities> TBL_com_AspectosValoracion { get; set; }
    public DbSet<tbl_com_ResultadoEvaluacionADAEntities> TBL_com_ResultadoEvaluacionada { get; set; }
    public DbSet<tbl_com_ParametrosDesempenoEntities> TBL_com_ParametrosDesempeno { get; set; }
    public DbSet<tbl_com_ResultcomTecnicasEntities> TBL_com_ResultcomTecnicas { get; set; }
    public DbSet<tbl_com_ConsolidadoDesempenoEntities> TBL_com_ConsolidadoDesempeno { get; set; }
    public DbSet<tbl_com_NivelesCompetenciasEntities> TBL_com_NivelesCompetencias { get; set; }
    public DbSet<tbl_com_NivelesdeDesempenoEntities> TBL_com_NivelesdeDesempeno { get; set; }
    public DbSet<tbl_com_DialogodeDesarrolloEntities> TBL_com_DialogodeDesarrollo { get; set; }
    public DbSet<tbl_com_RelGestoresDialogoDesarrolloEntities> TBL_com_RelGestoresDialogoDesarrollo { get; set; }
    public DbSet<tbl_com_NivelesCargoCompEntities> TBL_com_NivelesCargoComp { get; set; }
    public DbSet<tbl_com_TiposActividadEntities> TBL_com_TiposActividad { get; set; }
    public DbSet<tbl_com_ActividadesPIDEntities> TBL_com_ActividadesPID { get; set; }
    public DbSet<tbl_com_ActividadesCompetenciasEntities> TBL_com_ActividadesCompetencias { get; set; }
    public DbSet<tbl_com_ActividadesIndicadoresEntities> TBL_com_ActividadesIndicadores { get; set; }
    public DbSet<tbl_com_EncuestaEntities> TBL_com_Encuesta { get; set; }
    public DbSet<tbl_com_EncuestaPreguntaEntities> TBL_com_EncuestaPregunta { get; set; }
    public DbSet<tbl_com_PreguntasEntities> TBL_com_Preguntas { get; set; }
    public DbSet<tbl_com_MatrizdeTalentosEntities> TBL_com_MatrizdeTalentos { get; set; }
    public DbSet<tbl_com_NivelesDesempenoPpalEntities> TBL_Com_NivelesDesempenoPpal { get; set; }
    #endregion

    #region TBL-IND
    public DbSet<tbl_ind_PesosxTipoIndxNivelCompEntities> TBL_ind_PesosxTipoIndxNivelComp { get; set; }
    public DbSet<tbl_ind_MastIndicadoresEntities> TBL_ind_MastIndicadores { get; set; }
    public DbSet<tbl_ind_ObjetivosCalidadEntities> TBL_ind_ObjetivosCalidad { get; set; }
    public DbSet<tbl_ind_TiposIndicadoresEstrategicosEntities> TBL_ind_TiposIndicadoresEstrategicos { get; set; }
    public DbSet<tbl_ind_RelIndiEstrategicosFuncionariosEntities> TBL_ind_RelIndiEstrategicosFuncionarios { get; set; }
    public DbSet<tbl_ind_PesosxTipoIndEstxTipoNivelEstEntities> TBL_ind_PesosxTipoIndEstxTipoNivelEst { get; set; }
    public DbSet<tbl_ind_TotalIndEstCorporativosEntities> TBL_ind_TotalIndEstCorporativos { get; set; }
    public DbSet<tbl_Ind_ResulDirectorGerentesEntities> TBL_Ind_ResulDirectorGerentes { get; set; }
    public DbSet<tbl_ind_ResultIndiCoporpEntities> TBL_ind_ResultIndiCoporp { get; set; }

    #endregion

    #region TBL-DOC
    public DbSet<tbl_doc_DocumentosEntities> TBL_doc_Documentos {  get; set; }
    #endregion

    #region T
    public DbSet<areasEntities> Areas { get; set; }
    #endregion

    #region PRODUC
    public DbSet<productosEntities> Productos { get; set; }
    #endregion

    #region Tipo
    public DbSet<tipos_DocumentoEntities> Tipos_documento { get; set; } 
    #endregion
    public DbSet<historial_cambiosEntities> Historial_Cambios { get; set; }
    public DbSet<control_distribucionEntities> Control_Distribucion { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
