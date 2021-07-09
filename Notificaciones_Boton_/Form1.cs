using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using Telerik.WinControls;
using Telerik.WinControls.Themes;
using DigitalIO;
using Utilerias;
using System.Threading;

namespace Notificaciones_Boton_
{
    public partial class Form1 : Form
    {
        MccDaq.MccBoard DaqBoard = new MccDaq.MccBoard(0);
        Relevador Rele;
        int NumPorts, NumBits, FirstBit;
        int PortType, ProgAbility;
        MccDaq.DigitalPortType PortNum;
        DigitalIO.clsDigitalIO DioProps = new DigitalIO.clsDigitalIO();
        DateTime tiempo_deteccion_inicio = DateTime.MinValue;//    variable para saber la hora en que fue detectada
        Int32 tiempo_segundos_espera_entre_detecciones = 60;//   variable para saber cuanto tiempo tiene que esperar para volver a detectar y enviar correo
        int Puerto_Entrada = 0;

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                PortType = clsDigitalIO.PORTIN;
                NumPorts = DioProps.FindPortsOfType(DaqBoard, PortType, out ProgAbility, out PortNum, out NumBits, out FirstBit);

                Rele = new Relevador();
                Rele.Activar_Relevador();
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
        private void Btn_Enviar_Correo_Click(object sender, EventArgs e)
        {

            try
            {
                MessageBoxButtons mensaje = MessageBoxButtons.OK;
                RadMessageIcon icon = RadMessageIcon.Info;
                RightToLeft rtl = RightToLeft.No;


                Enviar_Correo();
            


                DialogResult ds;
                Telerik.WinControls.RadMessageBox.Instance.MinimumSize = new System.Drawing.Size(100, 100);

                ds = Telerik.WinControls.RadMessageBox.Show(this, "Se envió el correo", "Notificación", mensaje, icon, MessageBoxDefaultButton.Button1, rtl);
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
            SmtpClient correo_server = new SmtpClient("smtp.live.com");
            var mail = new MailMessage();
            try
            {
                mail.From = new MailAddress(Txt_Cuenta.Text);
                mail.To.Add(Txt_Enviar_Cuenta.Text);
                mail.Subject = "Notificación botón de seguridad";
                mail.IsBodyHtml = true;

                string htmlBody;
                htmlBody = "Pruebas: " + DateTime.Now.ToString();
                mail.Body = htmlBody;

                //  configuración de la cuenta de correo
                correo_server.Port = 587;
                correo_server.UseDefaultCredentials = false;
                correo_server.Credentials = new System.Net.NetworkCredential(Txt_Cuenta.Text, Txt_Contraseña.Text);
                correo_server.EnableSsl = true;
                correo_server.Send(mail);

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
        private void Btn_Enviar_Pulso_Click(object sender, EventArgs e)
        {
            int puerto = 0;
            int tiempo_pulso = 0;

            try
            {
                puerto = Convert.ToInt32(Txt_Puerto_Pulso.Text);
                tiempo_pulso = Convert.ToInt32(Txt_Tiempo_Relevador.Text);


                Pulso(puerto, tiempo_pulso);
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
        private void Btn_Iniciar_Terminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Btn_Iniciar_Terminar.Text.Contains("Iniciar"))
                {
                    Btn_Iniciar_Terminar.Text = "Terminar";

                    Timer_Pulso.Start();

                }
                else
                {
                    Btn_Iniciar_Terminar.Text = "Iniciar";
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
        private void Timer_Pulso_Tick(object sender, EventArgs e)
        {
            short DataValue = 0;
            try
            {

                MccDaq.ErrorInfo ULStat = DaqBoard.DIn(PortNum, out DataValue);

                int resul = DataValue & (1 << Puerto_Entrada);// estructura & (valore esperado << puerto)

                //  validamos el pulso
                if (resul != 0)
                {
                    //  se arroja el resultado
                    this.Invoke((MethodInvoker)delegate
                    {
                        Txt_Resultado_Pulso.Text = "1";
                    });

                    //  validamos la variable, que no sea el valor menor de la fecha
                    if (tiempo_deteccion_inicio != DateTime.MinValue)
                    {

                        DateTime tiempo_deteccion_fin = tiempo_deteccion_inicio.AddSeconds(tiempo_segundos_espera_entre_detecciones);

                        //  se compara la fecha y hora contra la actual, si supera el valor de espera se vuelve a notificar
                        if (tiempo_deteccion_fin <= DateTime.Now)
                        {
                            //  se asigna la hora
                            tiempo_deteccion_inicio = DateTime.Now;



                            //  se arroja el resultado
                            this.Invoke((MethodInvoker)delegate
                            {
                                Txt_Resultado_Fecha_Inicio.Text = tiempo_deteccion_inicio.ToString();
                            });


                            DateTime tiempo_deteccion_fin_ = tiempo_deteccion_inicio.AddSeconds(tiempo_segundos_espera_entre_detecciones);

                            //  se arroja el resultado
                            this.Invoke((MethodInvoker)delegate
                            {
                                Txt_Resultado_Fecha_Fin.Text = tiempo_deteccion_fin_.ToString();
                            });

                            Enviar_Correo();
                        }
                    }
                    //  cuando es la primera vez
                    else
                    {
                        //  se asigna la hora
                        tiempo_deteccion_inicio = DateTime.Now;

                        //  se arroja el resultado
                        this.Invoke((MethodInvoker)delegate
                        {
                            Txt_Resultado_Fecha_Inicio.Text = tiempo_deteccion_inicio.ToString();
                        });


                        DateTime tiempo_deteccion_fin = tiempo_deteccion_inicio.AddSeconds(tiempo_segundos_espera_entre_detecciones);

                        //  se arroja el resultado
                        this.Invoke((MethodInvoker)delegate
                        {
                            Txt_Resultado_Fecha_Fin.Text = tiempo_deteccion_fin.ToString();
                        });


                        Enviar_Correo();




                    }

                }
                //  se configura la variable con el valor mas chico
                else
                {
                    //  se arroja el resultado
                    this.Invoke((MethodInvoker)delegate
                    {
                        Txt_Resultado_Pulso.Text = "0";
                    });

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
        /// <param name="Puerto"></param>
        private void Pulso(int Puerto, int tiempo)
        {
            Monitor.Enter(Rele);

            try
            {
                Rele.Activar_Relevador(MccDaq.DigitalLogicState.High, Puerto);
                Thread.Sleep(tiempo);
                Rele.Activar_Relevador(MccDaq.DigitalLogicState.Low, Puerto);
            }
            finally
            {
                Monitor.Exit(Rele);
            }
        }

    }
}
