/*
 * Creado por SharpDevelop.
 * Usuario: GNR092
 * Fecha: 06/02/2017
 * Hora: 08:04 p.m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace SecureGameGuard
{
    public enum TypeInvoke
    {
        Text,
        progressbar,
    }
    public enum MessageBoxAutoClosingIcon
    {
        /// <summary>
        ///     El cuadro de mensaje no contiene ningún símbolo.
        /// </summary>
        None = 0,
        /// <summary>
        ///    El cuadro de mensaje está compuesto por un símbolo que consiste en una X
        ///     blanca en un círculo con fondo rojo.
        /// </summary>

        Error = 16,
        /// <summary>
        /// El cuadro de mensaje está compuesto por un símbolo que consiste en una X
        ///     blanca en un círculo con fondo rojo.
        /// </summary>
        Hand = 16,
        /// <summary>
        ///  El cuadro de mensaje está compuesto por un símbolo que consiste en una X
        ///     blanca en un círculo con fondo rojo.
        /// </summary>
        Stop = 16,
        /// <summary>
        /// El cuadro de mensaje está compuesto por un símbolo que consiste en un signo
        ///    de interrogación en un círculo. Ya no se recomienda el icono de mensaje de
        ///    signo de interrogación porque no representa claramente un tipo específico
        ///    de mensaje y porque la formulación de un mensaje como una pregunta puede
        ///    aplicarse a cualquier tipo de mensaje. Además, los usuarios pueden confundir
        ///    el signo de interrogación del mensaje con la información de ayuda. Por lo
        ///    tanto, no utilice este símbolo de signo de interrogación en los cuadros de
        ///    mensaje. El sistema seguirá admitiendo su inclusión únicamente por motivos
        ///    de compatibilidad con las versiones anteriores.
        /// </summary>
        Question = 32,
        //
        // Resumen:
        //     El cuadro de mensaje está compuesto por un símbolo que consiste en un signo
        //     de exclamación en un triángulo con fondo amarillo.
        Exclamation = 48,
        /// <summary>
        /// El cuadro de mensaje está compuesto por un símbolo que consiste en un signo
        ///     de exclamación en un triángulo con fondo amarillo.
        /// </summary>
        Warning = 48,
        /// <summary>
        /// El cuadro de mensaje está compuesto por un símbolo que consiste en un letra
        ///     'i' minúscula en un círculo.
        /// </summary>
        Information = 64,
        /// <summary>
        ///  El cuadro de mensaje está compuesto por un símbolo que consiste en un letra
        ///     'i' minúscula en un círculo.
        /// </summary>
        Asterisk = 64,
    }
    public enum MessageBoxAutoClosingButtoms
    {
        OK = 0,
        OKCancel = 1,
        AbortRetryIgnore = 2,
        YesNoCancel = 3,
        YesNo = 4,
        RetryCancel = 5,
    }
}
