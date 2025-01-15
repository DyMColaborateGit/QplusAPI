using App.Infraestructure.Connect.Configuration.TblDoc;
using App.Infraestructure.Connect.Entities;
using App.Infraestructure.Connect.Entities.Scp;
using App.Infraestructure.Connect.Entities.T;
using App.Infraestructure.Connect.Entities.TblAud;
using App.Infraestructure.Connect.Entities.TblCom;
using App.Infraestructure.Connect.Entities.TblDoc;
using App.Infraestructure.Connect.Entities.TblInd;
using App.Infraestructure.Connect.Entities.TblMast;
using App.Infraestructure.Connect.Entities.Tipo;
using App.Models.Models;
using App.Models.Models.Scp;
using App.Models.Models.T;
using App.Models.Models.TblAud;
using App.Models.Models.TblCom;
using App.Models.Models.TblDoc;
using App.Models.Models.TblInd;
using App.Models.Models.TblMast;
using App.Models.Models.Tipo;
using AutoMapper;

namespace App.Infraestructure.Profiles;

public class MappingProfiles: Profile
{
    public MappingProfiles() 
    {
        CreateMap<scp_CargosEntities, SCP_CargosModels>().ReverseMap();
        CreateMap<scp_CargosProcesosEntities, SCP_CargosProcesosModels>().ReverseMap();
        CreateMap<scp_UsuariosEntities, SCP_UsuarioModels>().ReverseMap();
        CreateMap<scp_RolesEntities, SCP_RolesModels>().ReverseMap();
        CreateMap<scp_UsuariosRolesEntities, SCP_UsuariosRolesModels>().ReverseMap(); 
        CreateMap<scp_FuncionariosEntities, SCP_FuncionariosModels>().ReverseMap();
        CreateMap<scp_FuncionariosEntities, JOINSCP_FuncionariosModels>().ReverseMap();
        CreateMap<tbl_mast_OficinasEntities, TBL_mast_OficinasModels>().ReverseMap();
        CreateMap<tbl_mast_ZonasEntities, TBL_mast_ZonasModels>().ReverseMap();
        CreateMap<scp_EmpresasEntities, SCP_EmpresasModels>().ReverseMap();
        CreateMap<scp_ProcesosEntities, SCP_ProcesosModels>().ReverseMap();
        CreateMap<scp_EmpresasTitulosEntities, SCP_EmpresasTitulosModels>().ReverseMap();
        CreateMap<scp_ParametrosEmpresasEntities, SCP_ParametrosEmpresasModels>().ReverseMap();

        CreateMap<tbl_com_EncabezadoEvaEntities, Tbl_com_EncabezadoEvaModels>().ReverseMap();
        CreateMap<tbl_com_ProgEvaluacionEntities, Tbl_com_ProgEvaluacionModels>().ReverseMap();
        CreateMap<tbl_com_ProgramacionMasivaEvaluacionesEntities, Tbl_com_ProgramacionMasivaEvaluacionesModels>().ReverseMap();
        CreateMap<tbl_com_NormasEntities, Tbl_com_NormasModels>().ReverseMap();
        CreateMap<tbl_com_NormasEntities, JOINTbl_com_NormasModels>().ReverseMap();
        CreateMap<tbl_com_ResultadosEvaluacionEntities, Tbl_com_ResultadosEvaluacionModels>().ReverseMap();
        CreateMap<tbl_com_ResultadosEntities, Tbl_com_ResultadosModels>().ReverseMap();
        CreateMap<tbl_com_ProgEvaluacionEntities, ResponseTbl_com_ProgEvaluacionModels>().ReverseMap();
        CreateMap<tbl_com_EscalaEvaluacionEntities, Tbl_com_EscalaEvaluacionModels>().ReverseMap();
        CreateMap<tbl_com_TxtFormEvaluacionEntities, Tbl_com_TxtFormEvaluacionModels>().ReverseMap();
        CreateMap<tbl_com_AspectosValoracionEntities, Tbl_com_AspectosValoracionModels>().ReverseMap();
        CreateMap<tbl_com_ResultadoEvaluacionADAEntities, TBL_com_ResultadoEvaluacionADAModels>().ReverseMap();
        CreateMap<tbl_com_ParametrosDesempenoEntities, TBL_com_ParametrosDesempenoModels>().ReverseMap();
        CreateMap<tbl_com_ResultcomTecnicasEntities, TBL_com_ResultcomTecnicasModels>().ReverseMap();
        CreateMap<tbl_com_ConsolidadoDesempenoEntities, TBL_com_ConsolidadoDesempenoModels>().ReverseMap();
        CreateMap<tbl_com_NivelesCompetenciasEntities, TBL_com_NivelesCompetenciasModels>().ReverseMap();
        CreateMap<tbl_com_DialogodeDesarrolloEntities, TBL_com_DialogodeDesarrolloModels>().ReverseMap();
        CreateMap<tbl_com_RelGestoresDialogoDesarrolloEntities, TBL_com_RelGestoresDialogoDesarrolloModels>().ReverseMap();
        CreateMap<tbl_com_NivelesdeDesempenoEntities, TBL_com_NivelesdeDesempenoModels>().ReverseMap();
        CreateMap<tbl_com_NivelesCargoCompEntities, JOINTBL_com_NivelesCargoCompModels>().ReverseMap();
        CreateMap<tbl_com_NivelesCargoCompEntities, TBL_com_NivelesCargoCompModels>().ReverseMap();
        CreateMap<tbl_com_TiposActividadEntities, TBL_com_TiposActividadModels>().ReverseMap();
        CreateMap<tbl_com_ActividadesPIDEntities, TBL_com_ActividadesPIDModels>().ReverseMap();
        CreateMap<tbl_com_ActividadesCompetenciasEntities, TBL_com_ActividadesCompetenciasModels>().ReverseMap();
        CreateMap<tbl_com_ActividadesIndicadoresEntities, TBL_com_ActividadesIndicadoresModels>().ReverseMap();
        CreateMap<tbl_com_EncuestaEntities, TBL_com_EncuestaModels>().ReverseMap();
        CreateMap<tbl_com_EncuestaPreguntaEntities, TBL_com_EncuestaPreguntaModels>().ReverseMap();
        CreateMap<tbl_com_EncuestaPreguntaEntities, JOIN_tbl_com_EncuestaPreguntaModels>().ReverseMap();
        CreateMap<tbl_com_PreguntasEntities, TBL_com_PreguntasModels>().ReverseMap();
        CreateMap<tbl_com_MatrizdeTalentosEntities, TBL_com_MatrizdeTalentosModels>().ReverseMap();
        CreateMap<tbl_com_MatrizdeTalentosEntities, ResponseTBL_com_MatrizdeTalentosModels>().ReverseMap();
        CreateMap<tbl_com_NivelesDesempenoPpalEntities, TBL_com_NivelesDesempenoPpalModels>().ReverseMap();

        CreateMap<tbl_ind_PesosxTipoIndxNivelCompEntities, Tbl_ind_PesosxTipoIndxNivelCompModels>().ReverseMap();
        CreateMap<tbl_ind_MastIndicadoresEntities, Tbl_ind_MastIndicadoresModels>().ReverseMap();
        CreateMap<tbl_ind_ObjetivosCalidadEntities, Tbl_ind_ObjetivosCalidadModels>().ReverseMap();
        CreateMap<tbl_ind_TiposIndicadoresEstrategicosEntities, TBL_ind_TiposIndicadoresEstrategicosModels>().ReverseMap();
        CreateMap<tbl_ind_RelIndiEstrategicosFuncionariosEntities, TBL_ind_RelIndiEstrategicosFuncionariosModels>().ReverseMap();
        CreateMap<tbl_ind_PesosxTipoIndEstxTipoNivelEstEntities, TBL_ind_PesosxTipoIndEstxTipoNivelEstModels>().ReverseMap();
        CreateMap<tbl_ind_TotalIndEstCorporativosEntities, TBL_ind_TotalIndEstCorporativosModels>().ReverseMap();
        CreateMap<tbl_Ind_ResulDirectorGerentesEntities, TBL_Ind_ResulDirectorGerentesModels>().ReverseMap();
        CreateMap<tbl_ind_TotalIndEstCorporativosEntities, GeneralTBL_ind_TotalIndEstCorporativosModels>().ReverseMap();
        CreateMap<TBL_ind_TotalIndEstCorporativosModels, GeneralTBL_ind_TotalIndEstCorporativosModels>().ReverseMap();
        CreateMap<tbl_ind_ResultIndiCoporpEntities, TBL_ind_ResultIndiCoporpModels>().ReverseMap();
        CreateMap<tbl_ind_ResultIndiCoporpEntities, JOINTBL_ind_ResultIndiCoporpModels>().ReverseMap();

        CreateMap<tbl_aud_EvaAuditoresEntities, TBL_aud_EvaAuditoresModels>().ReverseMap();
        CreateMap<tbl_aud_EvaPreguntasEntities, TBL_aud_EvaPreguntasModels>().ReverseMap();
        CreateMap<auditoriasEntities, AuditoriasModels>().ReverseMap();

        CreateMap<tbl_doc_DocumentosEntities, TBL_doc_DocumentosModels>().ReverseMap();
        CreateMap<tbl_doc_DocumentosEntities, ResponseTBL_doc_DocumentosModels>().ReverseMap();

        CreateMap<areasEntities, AreasModels>().ReverseMap();

        CreateMap<productosEntities, ProductosModels>().ReverseMap();

        CreateMap<tbl_mast_SistemasGestionEntities, TBL_mast_SistemasGestionModels>().ReverseMap();

        CreateMap<tipos_DocumentoEntities, tipos_documentoModels>().ReverseMap();

        CreateMap<historial_cambiosEntities, Historial_cambiosModels>().ReverseMap();

        CreateMap<control_distribucionEntities, Control_distribucionModels>().ReverseMap();

        CreateMap<tbl_com_EncabezadoEvaEntities, ResponseEncabezadoEvaModels>().ReverseMap();
        CreateMap<tbl_com_ResultadosEvaluacionEntities, ResponseJoinTbl_com_ResultadosEvaluacionModels>().ReverseMap();
        CreateMap<tbl_com_ResultadosEvaluacionEntities, ResponseTbl_com_ResultadosEvaluacionModels>().ReverseMap();
        CreateMap<tbl_com_ResultadosEvaIndicadoresEntities, Tbl_com_ResultadosEvaIndicadoresModels>().ReverseMap();
        CreateMap<tbl_com_ResultadosEvaIndicadoresEntities, JOINTbl_com_ResultadosEvaIndicadoresModels>().ReverseMap();
        CreateMap<scp_UsuariosRolesEntities, ResponseSCP_UsuariosRolesModels>().ReverseMap();
        CreateMap<tbl_aud_EvaAuditoresEntities, ResponseTBL_aud_EvaAuditoresModels>().ReverseMap();
        CreateMap<auditoriasEntities, ResponseAuditoriasModels>().ReverseMap();

    }
}
