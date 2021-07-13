using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.IO;
using DigitalIO;
using Utilerias;
using System.Threading;
using System.Net.Mail;


namespace Sw_Boton_Emergencia
{
    public partial class Service1 : ServiceBase
    {
        /// <summary>
        /// 
        /// </summary>
        #region Variables
        public System.Timers.Timer Tmr_Intervalor;
        MccDaq.MccBoard DaqBoard = new MccDaq.MccBoard(0);
        Relevador Rele;
        int NumPorts, NumBits, FirstBit;
        int PortType, ProgAbility;
        MccDaq.DigitalPortType PortNum;
        DigitalIO.clsDigitalIO DioProps = new DigitalIO.clsDigitalIO();
        DateTime tiempo_deteccion_inicio = DateTime.MinValue;//    variable para saber la hora en que fue detectada
        Int32 tiempo_segundos_espera_entre_detecciones = 60;//   variable para saber cuanto tiempo tiene que esperar para volver a detectar y enviar correo
        int Puerto_Entrada = 0; 
        short DataValue = 0;
        public String ruta_archivo = "";//  variable para la ruta
        public string cuenta = "";
        public string contraseña = "";
        public string enviar_ = "";
        public Int32 puerto_ = 0;
        public Int32 tiempo_ = 0;
        public string asunto_ = "";
        public string cuerpo_ = "";
        public string SmtpClient_ = "";
        public Boolean _bandera_envio_correo = false;

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public Service1()
        {
            InitializeComponent();

            //  se cargan los parámetros
            ruta_archivo = "C:/Parametros_Servicio/parametros.txt";
            lectura_archivo(ruta_archivo);


            Tmr_Intervalor = new System.Timers.Timer();
            Tmr_Intervalor.Interval = 100;
            Tmr_Intervalor.Elapsed += new ElapsedEventHandler(Tmr_Intervalor_Acciones);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        protected override void OnStart(string[] args)
        {
            Tmr_Intervalor.Enabled = true;
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void OnStop()
        {
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
        private void Tmr_Intervalor_Acciones(object sender, EventArgs e)
        {
            StreamWriter SW = new StreamWriter("C:\\Parametros_Servicio\\Historial.txt", true);
            StringBuilder mensaje = new StringBuilder();
            string valor_bandera = "";

            try
            {
                MccDaq.ErrorInfo ULStat = DaqBoard.DIn(PortNum, out DataValue);
                
                int resul = DataValue & (1 << Puerto_Entrada);// estructura & (valore esperado << puerto)



                //mensaje.AppendLine("***********************************************************************************");
                mensaje.AppendLine(resul.ToString());
                //mensaje.AppendLine("***********************************************************************************");

                //  validamos el pulso
                if (resul != 0)
                {

                    //Enviar_Correo();


                    //if (_bandera_envio_correo == false)
                    //{
                    //    //  se asigna la hora
                    //    tiempo_deteccion_inicio = DateTime.Now;

                    //    _bandera_envio_correo = true;
                        
                       
                    //}




                

                    ////  validamos la variable, que no sea el valor menor de la fecha
                    //if (_bandera_envio_correo == true)
                    //{

                    //    //DateTime tiempo_deteccion_fin = tiempo_deteccion_inicio.AddSeconds(tiempo_segundos_espera_entre_detecciones);

                    //    ////  se compara la fecha y hora contra la actual, si supera el valor de espera se vuelve a notificar
                    //    //if (tiempo_deteccion_fin <= DateTime.Now)
                    //    //{
                    //    //    //  se asigna la hora
                    //    //    tiempo_deteccion_inicio = DateTime.Now;

                          
                    //    //    //Enviar_Correo();
                    //    //}
                    //}
                    ////  cuando es la primera vez
                    //else
                    //{
                    //    //  se asigna la hora
                    //    tiempo_deteccion_inicio = DateTime.Now;


                     

                    //    Enviar_Correo(mensaje);

                    //    _bandera_envio_correo = true;
                    //    SW.WriteLine(mensaje.ToString());

                    //}

                    //SW.WriteLine("tiempo_deteccion_inicio");
                    //SW.WriteLine(tiempo_deteccion_inicio.ToString("dd/MM/yyyy"));


                    //SW.WriteLine("_bandera_envio_correo");
                    //SW.WriteLine(_bandera_envio_correo.ToString());

                    //SW.WriteLine("pulso si ");
                    //SW.WriteLine("***********************************************************************************");

                }
                //  se configura la variable con el valor mas chico
                else
                {

                    //_bandera_envio_correo = false;
                    //tiempo_deteccion_inicio = DateTime.MinValue;



                    //SW.WriteLine("***********************************************************************************"); 
                    //SW.WriteLine("pulso no ");


                    //SW.WriteLine("tiempo_deteccion_inicio");
                    //SW.WriteLine(tiempo_deteccion_inicio.ToString("dd/MM/yyyy hh:mm:ss"));

                    //SW.WriteLine("Puerto:  " + Puerto_Entrada.ToString());

                    //SW.WriteLine(DateTime.Now.ToShortTimeString());
                    //SW.WriteLine("***********************************************************************************");
                }




                SW.WriteLine(mensaje.ToString());


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


    }
}
