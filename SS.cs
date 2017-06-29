using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecureGameGuard
{
    public partial class SS : Form
    {
        public SS():base()
        {
            InitializeComponent();
        }

        int mintAncho = 100;
        ArrayList alstBotones = new ArrayList();
        string mstrRetorno;

        ///<summary> Agrega un titulo al formulario </summary>
        ///<param name="Cadena">El titulo a agregar</param>
        public void AgregarTitulo(string Cadena)
        {
            ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            //Autor: angell
            //Fecha de Creación: 16/12/2004
            //Modificaciones:
            ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            //                DESCRIPCION DE LAS VARIABLES LOCALES
            //    (agregar nombre de variables y su descripción)
            ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            this.Text = Cadena;
        }

        ///<summary> Agrega un boton al formulario </summary>
        ///<param name="Cadena">El titulo del boton</param>
        public void AgregarBoton(string Cadena)
        {
            ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            //Autor: angell
            //Fecha de Creación: 16/12/2004
            //Modificaciones:
            ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            //                DESCRIPCION DE LAS VARIABLES LOCALES
            //    (agregar nombre de variables y su descripción)
            ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            System.Windows.Forms.Button cmdBoton = new System.Windows.Forms.Button();

            cmdBoton.Text = Cadena;
            cmdBoton.Height = 30; cmdBoton.Width = mintAncho;
            alstBotones.Add(cmdBoton);
        }

        ///<summary> Agrega un mensaje al Formulario </summary>
        ///<param name="cadena">El texto del mensaje</param>
        public void AgregarMensaje(string cadena)
        {
            ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            //Autor: angell
            //Fecha de Creación: 16/12/2004
            //Modificaciones:
            ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            //                DESCRIPCION DE LAS VARIABLES LOCALES
            //    (agregar nombre de variables y su descripción)
            ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            lblMensaje.Text = cadena;
        }

        ///<summary> Diseña el MessageBox </summary>
        ///<returns> Devuelve el campo TEXT del botón presionado</returns>
        public string Mostrar()
        {
            ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            //Autor: angell
            //Fecha de Creación: 16/12/2004
            //Modificaciones:
            ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            //                DESCRIPCION DE LAS VARIABLES LOCALES
            //   cmdBoton        : un objeto boton temporal
            //   intContador     : la cantidad de botones del formulario
            //   intLargo        : la suma del largo de todos los botones mas sus espacios
            //   intI            : contador para el FOR-NEXT
            ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            System.Windows.Forms.Button cmdBoton;
            int intContador = alstBotones.Count;
            int intLargo = intContador * (mintAncho + 10);
            int intI;

            //seteamos el largo del formulario + 50 unidades
            this.Width = intLargo + 50;
            //seteamos el largo de la etiqueta del formulario
            this.lblMensaje.Width = intLargo;
            //centramos la etiqueta haciendola comensar en la posicion 25 (pues se agrego 50, 25 de cada lado al formulario)
            lblMensaje.Left = 25;

            //para cada boton del arraylist, iteramos y lo agregamos al formulario
            //asignándole el evento EVENTOCLICK que cargara en la variable
            //de retorno el contenido del campo TEXT del botón
            for (intI = 0; intI < intContador; intI++)
            {
                cmdBoton = ((Button)alstBotones[intI]);
                //situamos la posicion del boton en base a su orden
                cmdBoton.Location = new System.Drawing.Point((mintAncho + 10) * intI + 25, 60);

                //agregamos el controlador del evento click al boton
                cmdBoton.Click += new /* TODO: Comprobar el tipo de delegado */ EventHandler(EventoClick);

                //seteamos al formulario como padre del control.
                this.Controls.Add(cmdBoton);
            }

            //centramos en la pantalla el formulario
            this.CenterToScreen();
            //lo mostramos y esperamos hasta que se haya presionado un boton
            //evento que cerrará el formulario
            this.ShowDialog();

            //retornamos el valor de la variable de retorno
            return mstrRetorno;
        }

        ///<sumary>El evento que controla el click de los botones </sumary>
        private void EventoClick(System.Object Sender, EventArgs e)
        {
            mstrRetorno = ((Button)Sender).Text;
            this.Close();
        }



    }
}
