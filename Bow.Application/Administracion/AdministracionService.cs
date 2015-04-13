using Abp.Localization;
using Abp.UI;
using AutoMapper;
using Bow.Administracion.DTOs.InputModels;
using Bow.Administracion.DTOs.OutputModels;
using Bow.Administracion.Entidades;
using Bow.Administracion.Repositorios;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bow.Administracion
{
    public class AdministracionService : IAdministracionService
    {
        #region Repositorios
        private IPreguntaFrecuenteRepositorio _preguntaFrecuenteRepositorio;
        private IMensajeRepositorio _mensajeRepositorio;
        private IUsuarioRepositorio _usuarioRepositorio;
        private IPuntajeRepositorio _puntajeRepositorio;
        private IPreguntaRepositorio _preguntaRepositorio;
        private IRespuestaRepositorio _respuestaRepositorio;
        private ITipoRepositorio _tipoRepositorio;

        #endregion

        //Inyección de Dependencia en el Servicio
        public AdministracionService(
            IPreguntaFrecuenteRepositorio preguntaFrecuenteRepositorio,
            IMensajeRepositorio mensajeRepositorio,
            IUsuarioRepositorio usuarioRepositorio,
            IPuntajeRepositorio puntajeRepositorio,
            IPreguntaRepositorio preguntaRepositorio,
            IRespuestaRepositorio respuestaRepositorio,
            ITipoRepositorio tipoRepositorio)
        {
            _preguntaFrecuenteRepositorio = preguntaFrecuenteRepositorio;
            _mensajeRepositorio = mensajeRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
            _puntajeRepositorio = puntajeRepositorio;
            _preguntaRepositorio = preguntaRepositorio;
            _respuestaRepositorio = respuestaRepositorio;
            _tipoRepositorio = tipoRepositorio;
        }

        /*********************************************************************************************
         ***********************************  Preguntas Frecuentes  **********************************
         *********************************************************************************************/

        public GetPreguntaFrecuenteOutput GetPreguntaFrecuente(GetPreguntaFrecuenteInput faqInput)
        {
            return Mapper.Map<GetPreguntaFrecuenteOutput>(_preguntaFrecuenteRepositorio.Get(faqInput.Id));
        }

        public GetAllPreguntasFrecuentesOutput GetAllPreguntasFrecuentes()
        {
            var listaFAQs = _preguntaFrecuenteRepositorio.GetAllList().OrderBy(p => p.Pregunta);
            return new GetAllPreguntasFrecuentesOutput { PreguntasFrecuentes = Mapper.Map<List<PreguntaFrecuenteOutput>>(listaFAQs) };
        }

        public GetAllPreguntasFrecuentesActivasOutput GetAllPreguntasFrecuentesActivas()
        {
            var listaFAQs = _preguntaFrecuenteRepositorio.GetAll().Where(p => p.EstadoActiva).OrderBy(p => p.Pregunta);
            return new GetAllPreguntasFrecuentesActivasOutput { PreguntasFrecuentes = Mapper.Map<List<PreguntaFrecuenteOutput>>(listaFAQs) };
        }

        public void SavePreguntaFrecuente(SavePreguntaFrecuenteInput nuevaFaq)
        {
            PreguntaFrecuente existeFAQ = _preguntaFrecuenteRepositorio.FirstOrDefault(p => p.Pregunta.ToLower() == nuevaFaq.Pregunta.ToLower());

            if (existeFAQ == null)
            {
                _preguntaFrecuenteRepositorio.Insert(Mapper.Map<PreguntaFrecuente>(nuevaFaq));
            }
            else
            {
                var mensajeError = LocalizationHelper.GetString("Bow", "zonificacion_pais_validarNombrePais");
                throw new UserFriendlyException(mensajeError);
            }
        }

        public void DeletePreguntaFrecuente(DeletePreguntaFrecuenteInput faqEliminar)
        {

            _preguntaFrecuenteRepositorio.Delete(faqEliminar.Id);
        }

        public void UpdatePreguntaFrecuente(UpdatePreguntaFrecuenteInput faqUpdate)
        {
            PreguntaFrecuente existeFAQ = _preguntaFrecuenteRepositorio.FirstOrDefault(p => p.Pregunta.ToLower() == faqUpdate.Pregunta.ToLower() && p.Id != faqUpdate.Id);

            if (existeFAQ == null)
            {
                _preguntaFrecuenteRepositorio.Update(Mapper.Map<PreguntaFrecuente>(faqUpdate));
            }
            else
            {
                var mensajeError = LocalizationHelper.GetString("Bow", "zonificacion_pais_validarNombrePais");
                throw new UserFriendlyException(mensajeError);
            }
        }

        /*********************************************************************************************
         *****************************************  Mensajes  ****************************************
         *********************************************************************************************/

        public void EnviarMensaje(EnviarMensajeInput mensaje)
        {
            _mensajeRepositorio.Insert(Mapper.Map<Mensaje>(mensaje));
        }

        public GetMensajeOutput GetMensaje(GetMensajeInput mensaje)
        {
            Mensaje mensajeRespuesta = _mensajeRepositorio.Get(mensaje.Id);
            if (mensaje.ReceptorId == mensajeRespuesta.UsuarioReceptorId)
            {
                mensajeRespuesta.FueLeido = true;
                _mensajeRepositorio.Update(mensajeRespuesta);
            }
            return Mapper.Map<GetMensajeOutput>(mensajeRespuesta);
        }

        public GetAllMensajesByEmisorOutput GetAllMensajesByEmisor(GetAllMensajesByEmisorInput mensajeEmisor)
        {
            return new GetAllMensajesByEmisorOutput { Mensajes = Mapper.Map<List<MensajeOutput>>(_mensajeRepositorio.GetAllMensajesByEmisor(mensajeEmisor.EmisorId)) };
        }

        public GetAllMensajesByReceptorOutput GetAllMensajesByReceptor(GetAllMensajesByReceptorInput mensajeEmisor)
        {
            return new GetAllMensajesByReceptorOutput { Mensajes = Mapper.Map<List<MensajeOutput>>(_mensajeRepositorio.GetAllMensajesByReceptor(mensajeEmisor.ReceptorId)) };
        }

        public void DeleteMensaje(DeleteMensajeInput mensajeEliminar)
        {

            _mensajeRepositorio.Delete(mensajeEliminar.Id);
        }

        public GetMensajesSinLeerByUsuarioOutput GetMensajesSinLeerByUsuario(GetMensajesSinLeerByUsuarioInput usuario)
        {
            return new GetMensajesSinLeerByUsuarioOutput { MensajesSinLeer = _mensajeRepositorio.GetAll().Where(m => m.UsuarioReceptorId == usuario.Id && m.FueLeido == false).Count() };
        }

        /*********************************************************************************************
         ******************************************  Usuario  ****************************************
         *********************************************************************************************/

        public GetUsuarioByCODAOutput GetUsuarioByCODA(GetUsuarioByCODAInput usuario)
        {
            return Mapper.Map<GetUsuarioByCODAOutput>(_usuarioRepositorio.GetAll().Where(u => u.Coda == usuario.Coda).FirstOrDefault());
        }

        public GetPuntajeUsuarioOutput GetPuntajeUsuario(GetPuntajeUsuarioInput usuario)
        {
            return new GetPuntajeUsuarioOutput { PuntajeTotal = _puntajeRepositorio.GetAll().Where(p => p.UsuarioId == usuario.Id).Sum(p => p.PuntajeValor) };
        }

        public void SaveUsuario(SaveUsuarioInput usuario)
        {
            _usuarioRepositorio.Insert(Mapper.Map<Usuario>(usuario));
        }

        public GetHistorialPuntajesUsuarioOutput GetHistorialPuntajesUsuario(GetHistorialPuntajesUsuarioInput usuario)
        {
            return new GetHistorialPuntajesUsuarioOutput { Puntajes = Mapper.Map<List<PuntajeUsuarioOutput>>(_puntajeRepositorio.GetAllHistorialPuntajesByUsuario(usuario.UsuarioId)) };
        }

        /*********************************************************************************************
         ****************************************  Preguntas  ****************************************
         *********************************************************************************************/

        public GetPreguntaOutput GetPregunta(GetPreguntaInput preguntaInput)
        {
            return Mapper.Map<GetPreguntaOutput>(_preguntaRepositorio.Get(preguntaInput.Id));
        }

        public GetAllPreguntasByDimensionOutput GetAllPreguntasByDimension(GetAllPreguntasByDimensionInput dimension)
        {
            var listaPreguntas = _preguntaRepositorio.GetAllList().Where(p => p.DimensionId == dimension.DimensionId).OrderBy(p => p.Texto);
            return new GetAllPreguntasByDimensionOutput { Preguntas = Mapper.Map<List<PreguntasByDimensionOutput>>(listaPreguntas) };
        }

        public void SavePregunta(SavePreguntaInput nuevaPregunta)
        {
            Pregunta existePregunta = _preguntaRepositorio.FirstOrDefault(p => p.Texto.ToLower() == nuevaPregunta.Texto.ToLower());

            if (existePregunta == null)
            {
                _preguntaRepositorio.Insert(Mapper.Map<Pregunta>(nuevaPregunta));
            }
            else
            {
                var mensajeError = LocalizationHelper.GetString("Bow", "zonificacion_pais_validarNombrePais");
                throw new UserFriendlyException(mensajeError);
            }
        }

        public void DeletePregunta(DeletePreguntaInput preguntaEliminar)
        {

            _preguntaRepositorio.Delete(preguntaEliminar.Id);
        }

        public void UpdatePregunta(UpdatePreguntaInput preguntaUpdate)
        {
            Pregunta existePregunta = _preguntaRepositorio.FirstOrDefault(p => p.Texto.ToLower() == preguntaUpdate.Texto.ToLower() && p.Id != preguntaUpdate.Id);

            if (existePregunta == null)
            {
                _preguntaRepositorio.Update(Mapper.Map<Pregunta>(preguntaUpdate));
            }
            else
            {
                var mensajeError = LocalizationHelper.GetString("Bow", "zonificacion_pais_validarNombrePais");
                throw new UserFriendlyException(mensajeError);
            }
        }

        public GetPreguntaAleatoriaByDimensionAndJuegoOutput GetPreguntaAleatoriaByDimensionAndJuego(GetPreguntaAleatoriaByDimensionAndJuegoInput dimensionAndJuego)
        {
            List<Pregunta> preguntas = _preguntaRepositorio.GetAll().Where(p => p.DimensionId == dimensionAndJuego.DimensionId && p.JuegoId == dimensionAndJuego.JuegoId).ToList();
            var rand = new Random();
            return Mapper.Map<GetPreguntaAleatoriaByDimensionAndJuegoOutput>(preguntas[rand.Next(preguntas.Count())]);
        }

        /*********************************************************************************************
         ****************************************  Respuestas  ***************************************
         *********************************************************************************************/

        public GetRespuestaOutput GetRespuesta(GetRespuestaInput respuestaInput)
        {
            return Mapper.Map<GetRespuestaOutput>(_respuestaRepositorio.Get(respuestaInput.Id));
        }

        public GetAllRespuestasByPreguntaOutput GetAllRespuestasByPregunta(GetAllRespuestasByPreguntaInput pregunta)
        {
            var listaRespuestas = _respuestaRepositorio.GetAllList().Where(p => p.PreguntaId == pregunta.PreguntaId).OrderBy(p => p.Texto);
            return new GetAllRespuestasByPreguntaOutput { Respuestas = Mapper.Map<List<RespuestasByPreguntaOutput>>(listaRespuestas) };
        }

        public void SaveRespuesta(SaveRespuestaInput nuevaRespuesta)
        {
            Respuesta existeRespuesta = _respuestaRepositorio.FirstOrDefault(p => p.Texto.ToLower() == nuevaRespuesta.Texto.ToLower());

            if (existeRespuesta == null)
            {
                _respuestaRepositorio.Insert(Mapper.Map<Respuesta>(nuevaRespuesta));
            }
            else
            {
                var mensajeError = LocalizationHelper.GetString("Bow", "zonificacion_pais_validarNombrePais");
                throw new UserFriendlyException(mensajeError);
            }
        }

        public void DeleteRespuesta(DeleteRespuestaInput respuestaEliminar)
        {

            _respuestaRepositorio.Delete(respuestaEliminar.Id);
        }

        public void UpdateRespuesta(UpdateRespuestaInput respuestaUpdate)
        {
            Respuesta existeRespuesta = _respuestaRepositorio.FirstOrDefault(p => p.Texto.ToLower() == respuestaUpdate.Texto.ToLower() && p.Id != respuestaUpdate.Id);

            if (existeRespuesta == null)
            {
                _respuestaRepositorio.Update(Mapper.Map<Respuesta>(respuestaUpdate));
            }
            else
            {
                var mensajeError = LocalizationHelper.GetString("Bow", "zonificacion_pais_validarNombrePais");
                throw new UserFriendlyException(mensajeError);
            }
        }

        /*********************************************************************************************
         ***************************************  Tipos Usuario  *************************************
         *********************************************************************************************/

        public GetTipoPPROutput GetTipoPPR()
        {
            return Mapper.Map<GetTipoPPROutput>(_tipoRepositorio.GetAll().Where(t => t.Nombre == BowConsts.TIPO_USUARIO_PPR).FirstOrDefault());
        }

        public GetTipoProfesionalReintegradorOutput GetTipoProfesionalReintegrador()
        {
            return Mapper.Map<GetTipoProfesionalReintegradorOutput>(_tipoRepositorio.GetAll().Where(t => t.Nombre == BowConsts.TIPO_USUARIO_PROFESIONAL).FirstOrDefault());
        }

        /*********************************************************************************************
         *************************************  Puntajes Usuario  ************************************
         *********************************************************************************************/

        public void SavePuntaje(SavePuntajeInput puntaje)
        {
            var p = _puntajeRepositorio.Insert(Mapper.Map<Puntaje>(puntaje));
        }

    }
}
