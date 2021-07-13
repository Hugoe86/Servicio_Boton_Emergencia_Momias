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
using System.IO;

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
        Int32 limite_grafica = 50;


        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
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
                        Txt_Cuenta.Text = cuenta;

                    }
                    else if (linea.Contains("contraseña"))
                    {
                        string[] valores_ = linea.Split(':');

                        contraseña = valores_[1];
                        Txt_Contraseña.Text = contraseña;

                    }
                    else if (linea.Contains("enviar"))
                    {
                        string[] valores_ = linea.Split(':');

                        enviar_ = valores_[1];
                        Txt_Enviar_Cuenta.Text = enviar_;

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
            SmtpClient correo_server = new SmtpClient(SmtpClient_);
            var mail = new MailMessage();

            try
            {
                mail.From = new MailAddress(cuenta);
                mail.To.Add(enviar_);
                mail.Subject = asunto_;
                mail.IsBodyHtml = true;

                string htmlBody;
                htmlBody = "Pruebas: " + DateTime.Now.ToString();
                mail.Body = htmlBody;

                //  configuración de la cuenta de correo
                correo_server.Port = 587;
                correo_server.UseDefaultCredentials = false;
                correo_server.Credentials = new System.Net.NetworkCredential(cuenta, contraseña);
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
          
            try
            {
                Pulso(puerto_, tiempo_);
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
        private void Btn_Graficar_Click(object sender, EventArgs e)
        {
            try
            {
                Tmr_Grafica.Start();
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
        private void Tmr_Grafica_Tick(object sender, EventArgs e)
        {
            short DataValue = 0;
            try
            {
                MccDaq.ErrorInfo ULStat = DaqBoard.DIn(PortNum, out DataValue);

                int resul = DataValue & (1 << Puerto_Entrada);// estructura & (valore esperado << puerto)


                //  validamos el pulso
                if (resul != 0)
                {
                    if (cont_grafica <= limite_grafica)
                    {
                        cont_grafica++;
                    }

                    //  se arroja el resultado
                    this.Invoke((MethodInvoker)delegate
                    {
                        Rgau_Grafica_Pulso.Value = cont_grafica;
                    });
                }
                else
                {
                    if (cont_grafica >= 0)
                    {
                        cont_grafica--;
                    }


                    //  se arroja el resultado
                    this.Invoke((MethodInvoker)delegate
                    {
                        Rgau_Grafica_Pulso.Value = cont_grafica;
                    });
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
            StreamWriter SW = new StreamWriter("C:\\Parametros_Servicio\\Historial.txt", true);

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


                        SW.WriteLine("***********************************************************************************");
                        SW.WriteLine(DateTime.Now.ToString("dd/MM/yyyy"));
                        SW.WriteLine("tiempo_deteccion_inicio");
                        SW.WriteLine(tiempo_deteccion_inicio.ToString("dd/MM/yyyy"));


                        SW.WriteLine("_bandera_envio_correo");
                        //SW.WriteLine(_bandera_envio_correo);

                        SW.WriteLine("pulso si ");
                        SW.WriteLine("***********************************************************************************");



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
            finally
            {
                SW.Close();
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
