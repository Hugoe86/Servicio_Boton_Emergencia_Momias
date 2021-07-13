using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Net.Mail;
using Telerik.WinControls.Themes;
using DigitalIO;
using Utilerias;
using System.Threading;
using System.IO;
using Telerik.WinControls.UI;

namespace Notificaciones_Boton_.Formularios
{
    public partial class Frm_Notificaciones_Pulso : Telerik.WinControls.UI.RadForm
    {

        #region Variables
        MccDaq.MccBoard DaqBoard = new MccDaq.MccBoard(0);
        Relevador Rele;
        int NumPorts, NumBits, FirstBit;
        int PortType, ProgAbility;
        MccDaq.DigitalPortType PortNum;
        DigitalIO.clsDigitalIO DioProps = new DigitalIO.clsDigitalIO();
        DateTime tiempo_deteccion_inicio = DateTime.MinValue;//    variable para saber la hora en que fue detectada
        DateTime tiempo_deteccion_fin = DateTime.MinValue;//    variable para saber la hora en que fue detectada
        DateTime tiempo_email_enviado = DateTime.MinValue;//    variable para saber la hora en que fue detectada
        DateTime tiempo_email_proximo = DateTime.MinValue;//    variable para saber la hora en que fue detectada
        Int32 tiempo_segundos_espera_entre_detecciones = 600;//   variable para saber cuanto tiempo tiene que esperar para volver a detectar y enviar correo
        int Puerto_Entrada = 0;
        public String ruta_archivo = "";//  variable para la ruta
        public string cuenta = "";
        public string contraseña = "";
        public string enviar_ = "";
        public Int32 puerto_ = 0;
        public Int32 tiempo_ = 0;
        public string asunto_ = "";
        public string cuerpo_ = "";
        public string SmtpClient_ = "";
        Int32 cont_grafica = 0;
        Int32 limite_grafica = 10;
        Int32 limite_enviar_correos = 5;
        Int32 limite_reactivar = 5;
        Int32 limite_escaner = 15;
        Boolean bandera_activado = false;
        Boolean bandera_pulso_detectado = false;
        Boolean bandera_email = false;
        Boolean bandera_escaneo = false;
        Int32 cont_inactivando = 0;
        Int32 cont_activando = 0;
        Int32 cont_escaneando = 0;

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public Frm_Notificaciones_Pulso()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_Notificaciones_Pulso_Load(object sender, EventArgs e)
        {
            try
            {
                //  se cargan los parámetros
                ruta_archivo = "C:/Parametros_Servicio/parametros.txt";
                lectura_archivo(ruta_archivo);

                PortType = clsDigitalIO.PORTIN;
                NumPorts = DioProps.FindPortsOfType(DaqBoard, PortType, out ProgAbility, out PortNum, out NumBits, out FirstBit);

                Rele = new Relevador();
                Rele.Activar_Relevador();


                tiempo_deteccion_inicio = DateTime.Now;
                tiempo_deteccion_fin = tiempo_deteccion_inicio.AddSeconds(15);

                Bar_Escaneo.StartWaiting();

                Tmr_Escaneando.Start();
            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public void lectura_archivo(string ruta_archivo)
        {
            try
            {



                string[] lineas = System.IO.File.ReadAllLines(@"" + ruta_archivo);




                foreach (string linea in lineas)
                {
                    if (linea.Contains("cuenta"))
                    {
                        string[] valores_ = linea.Split(':');

                        cuenta = valores_[1];

                    }
                    else if (linea.Contains("contraseña"))
                    {
                        string[] valores_ = linea.Split(':');

                        contraseña = valores_[1];

                    }
                    else if (linea.Contains("enviar"))
                    {
                        string[] valores_ = linea.Split(':');

                        enviar_ = valores_[1];

                    }
                    else if (linea.Contains("puerto_entrada"))
                    {
                        string[] valores_ = linea.Split(':');
                        string puerto_auxiliar = "";

                        puerto_auxiliar = valores_[1];
                        puerto_ = Convert.ToInt32(puerto_auxiliar);


                    }
                    else if (linea.Contains("tiempo_espera"))
                    {
                        string[] valores_ = linea.Split(':');
                        string tiempo_auxiliar = "";

                        tiempo_auxiliar = valores_[1];
                        tiempo_ = Convert.ToInt32(tiempo_auxiliar);


                    }
                    else if (linea.Contains("asunto"))
                    {
                        string[] valores_ = linea.Split(':');

                        asunto_ = valores_[1];


                    }
                    else if (linea.Contains("SmtpClient"))
                    {
                        string[] valores_ = linea.Split(':');

                        SmtpClient_ = valores_[1];


                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tmr_Inactivando_Tick(object sender, EventArgs e)
        {
            try
            {
                
                cont_inactivando--;

                //  se arroja el resultado
                this.Invoke((MethodInvoker)delegate
                {
                    //Lbl_Inactivo_Timer.Text = cont_inactivando.ToString();
                    Bar_Enviar_Correo.StartWaiting();
                });

                //  validamos el limite de tiempo esperado
                if (cont_inactivando == 0)
                {

                    //  se enviara correo
                    Enviar_Correo();

                    //  se arroja el resultado
                    this.Invoke((MethodInvoker)delegate
                    {
                        Tbl_Pnl_Derecho_Superior.Visible = false;
                    });

                    Tmr_Inactivando.Stop();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Texto"></param>
        private void Mostrar_Mensaje_RadAlert(RadDesktopAlert Control, String Titulo, String Texto)
        {
            try
            {

                //  se arroja el resultado
                this.Invoke((MethodInvoker)delegate
                {
                    Control.CaptionText = "advertencia";
                    Control.ContentText = Texto;
                    Control.Show();
                });


             

            }
            catch (Exception e)
            {
                throw e;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tmr_Escaneando_Tick(object sender, EventArgs e)
        {
            try
            {


                if (tiempo_deteccion_inicio != DateTime.MinValue)
                {
                    //  validamos la hora
                    if (DateTime.Now >= tiempo_deteccion_inicio && DateTime.Now <= tiempo_deteccion_fin)
                    {
                        //  validamos la bandera de escaneo
                        if (bandera_escaneo == false)
                        {
                            Tmr_Pulso.Start();
                            bandera_escaneo = true;


                            cont_escaneando = limite_escaner;

                            //  se arroja el resultado
                            this.Invoke((MethodInvoker)delegate
                            {
                                Tbl_Pnl_Central_Superior.Visible = true;

                                Bar_Escaneo.StartWaiting();
                            });
                        }
                    }
                    //se inactiva el timer
                    else if(DateTime.Now > tiempo_deteccion_fin)
                    {
                        //  validamos la bandera del escaneo
                        if (bandera_escaneo == true)
                        {
                            tiempo_deteccion_inicio = DateTime.Now.AddSeconds(30);
                            tiempo_deteccion_fin = tiempo_deteccion_inicio.AddSeconds(15);
                            bandera_escaneo = false;

                            Tmr_Pulso.Stop();

                            //  se arroja el resultado
                            this.Invoke((MethodInvoker)delegate
                            {
                                
                                Tbl_Pnl_Central_Superior.Visible = false;
                                Bar_Escaneo.StopWaiting();
                            });
                        }

                    }
                }
                else
                {
                    tiempo_deteccion_inicio = DateTime.MinValue;
                }



            }
            catch (Exception)
            {

                throw;
            }
        }

       



        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Tmr_Pulso_Tick(object sender, EventArgs e)
        {
            short DataValue = 0;
            

            try
            {

                MccDaq.ErrorInfo ULStat = DaqBoard.DIn(PortNum, out DataValue);

                int resul = DataValue & (1 << Puerto_Entrada);// estructura & (valore esperado << puerto)


                //  validamos el pulso
                if (resul != 0)
                {
                  

                    if (cont_grafica >= 0 && cont_grafica < limite_grafica)
                    {
                        cont_grafica++;
                    }

                    //  se arroja el resultado
                    this.Invoke((MethodInvoker)delegate
                    {
                        Rgau_Grafica_Pulso.Value = cont_grafica;
                    });

                    //  validamos que sea el limite
                    if (cont_grafica == limite_grafica)
                    {
                        //  validamos la fecha
                        if (tiempo_email_proximo == DateTime.MinValue)
                        {
                            tiempo_email_proximo = DateTime.Now;
                        }

                        //  validamos la bandera
                        if (bandera_email == false)
                        {


                            //  validamos la hora
                            if (DateTime.Now >= tiempo_email_proximo)
                            {
                                bandera_pulso_detectado = true;
                                bandera_email = true;



                                cont_inactivando = limite_enviar_correos;

                                //  se arroja el resultado
                                this.Invoke((MethodInvoker)delegate
                                {
                                    Bar_Enviar_Correo.StartWaiting();
                                });

                                //  se arroja el resultado
                                this.Invoke((MethodInvoker)delegate
                                {
                                    Tbl_Pnl_Derecho_Superior.Visible = true;
                                });

                                Tmr_Inactivando.Start();
                            }
                        }


                    }
                }
                else
                {
                    if (cont_grafica > 0)
                    {
                        cont_grafica--;
                    }


                    //  se arroja el resultado
                    this.Invoke((MethodInvoker)delegate
                    {
                        Rgau_Grafica_Pulso.Value = cont_grafica;
                    });


                    //  validamos que no tenga pulso
                    if(cont_grafica == 0)
                    {
                        //  validamos la bandera
                        if (bandera_pulso_detectado == true)
                        {

                            if (bandera_activado == false)
                            {
                                //  se activara el timer de activación
                                bandera_activado = true;
                                bandera_pulso_detectado = false;

                                cont_activando = limite_enviar_correos;

                                //  se arroja el resultado
                                this.Invoke((MethodInvoker)delegate
                                {
                                    //Lbl_Activacion_Timer.Text = cont_activando.ToString();
                                    Bar_Activacion.StartWaiting();
                                });

                                //  se arroja el resultado
                                this.Invoke((MethodInvoker)delegate
                                {
                                    Tbl_Pnl_Izquierdo_Superior.Visible = true;
                                });



                                Tmr_Activando.Start();

                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public void Enviar_Correo()
        {
            SmtpClient correo_server = new SmtpClient(SmtpClient_);
            var mail = new MailMessage();

            try
            {

                //  validamos la variable
                if (tiempo_email_proximo != DateTime.MinValue)
                {
                    //  validamos la hora
                    if (DateTime.Now >= tiempo_email_proximo)
                    {
                        mail.From = new MailAddress(cuenta);
                        mail.To.Add(enviar_);
                        mail.Subject = asunto_;
                        mail.IsBodyHtml = true;

                        string htmlBody;


                        htmlBody = "<table>";

                        htmlBody += "   <tr>";
                        htmlBody += "       <td>";
                        htmlBody += "           <img src =''/>";
                        htmlBody += "       </td>";
                        htmlBody += "       <td>";
                        htmlBody += "       </td>";
                        htmlBody += "   </tr>";

                        htmlBody += "   <tr>";
                        htmlBody += "       <td align='left' >";
                        htmlBody += "           <h3>Notificación</h3>";
                        htmlBody += "       </td>";
                        htmlBody += "   </tr>";




                        htmlBody += "    <tr>";
                        htmlBody += "        <td>";
                        htmlBody += "            <b>Mensaje:</b>";
                        htmlBody += "        </td>";
                        htmlBody += "        <td style='background - color: yellow;'>";
                        htmlBody += "            Se acciono el botón de emergencia " + DateTime.Now.ToString();
                        htmlBody += "        </td>";
                        htmlBody += "    </tr>";

                        htmlBody += "</table>";


                        mail.Body = htmlBody;

                        //  configuración de la cuenta de correo
                        correo_server.Port = 587;
                        correo_server.UseDefaultCredentials = false;
                        correo_server.Credentials = new System.Net.NetworkCredential(cuenta, contraseña);
                        correo_server.EnableSsl = true;
                        correo_server.Send(mail);

                        tiempo_email_enviado = DateTime.Now;
                        tiempo_email_proximo = tiempo_email_enviado.AddSeconds(tiempo_segundos_espera_entre_detecciones);

                        bandera_email = false;
                        Mostrar_Mensaje_RadAlert(RadAlert_Email, "Email", "Se esta enviando email al administrador");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tmr_Activando_Tick(object sender, EventArgs e)
        {
            try
            {
                cont_activando--;

                //  se arroja el resultado
                this.Invoke((MethodInvoker)delegate
                {
                    //Lbl_Activacion_Timer.Text = cont_activando.ToString();
                    Bar_Activacion.StartWaiting();
                });

                //  validamos el limite de tiempo esperado
                if (cont_activando == 0)
                {

                    
                    //  se arroja el resultado
                    this.Invoke((MethodInvoker)delegate
                    {
                        Tbl_Pnl_Izquierdo_Superior.Visible = false;
                    });

                    tiempo_email_enviado = DateTime.MinValue;
                    tiempo_email_proximo = DateTime.MinValue;

                    bandera_activado = false;

                    Tmr_Inactivando.Stop();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


       


    }
}
