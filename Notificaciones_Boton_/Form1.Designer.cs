
namespace Notificaciones_Boton_
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Lbl_Cuenta = new Telerik.WinControls.UI.RadLabel();
            this.Lbl_Contraseña = new Telerik.WinControls.UI.RadLabel();
            this.Txt_Cuenta = new Telerik.WinControls.UI.RadTextBoxControl();
            this.Txt_Contraseña = new Telerik.WinControls.UI.RadTextBoxControl();
            this.Btn_Enviar_Correo = new Telerik.WinControls.UI.RadButton();
            this.telerikMetroBlueTheme1 = new Telerik.WinControls.Themes.TelerikMetroBlueTheme();
            this.Lbl_Enviar_A = new Telerik.WinControls.UI.RadLabel();
            this.visualStudio2012DarkTheme1 = new Telerik.WinControls.Themes.VisualStudio2012DarkTheme();
            this.desertTheme1 = new Telerik.WinControls.Themes.DesertTheme();
            this.Txt_Enviar_Cuenta = new Telerik.WinControls.UI.RadTextBoxControl();
            this.Btn_Iniciar_Terminar = new Telerik.WinControls.UI.RadButton();
            this.Timer_Pulso = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Lbl_Cuenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lbl_Contraseña)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Cuenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Contraseña)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Enviar_Correo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lbl_Enviar_A)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Enviar_Cuenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Iniciar_Terminar)).BeginInit();
            this.SuspendLayout();
            // 
            // Lbl_Cuenta
            // 
            this.Lbl_Cuenta.Location = new System.Drawing.Point(46, 48);
            this.Lbl_Cuenta.Name = "Lbl_Cuenta";
            this.Lbl_Cuenta.Size = new System.Drawing.Size(43, 16);
            this.Lbl_Cuenta.TabIndex = 0;
            this.Lbl_Cuenta.Text = "Cuenta";
            this.Lbl_Cuenta.ThemeName = "TelerikMetroBlue";
            // 
            // Lbl_Contraseña
            // 
            this.Lbl_Contraseña.Location = new System.Drawing.Point(46, 73);
            this.Lbl_Contraseña.Name = "Lbl_Contraseña";
            this.Lbl_Contraseña.Size = new System.Drawing.Size(65, 16);
            this.Lbl_Contraseña.TabIndex = 1;
            this.Lbl_Contraseña.Text = "Contraseña";
            this.Lbl_Contraseña.ThemeName = "TelerikMetroBlue";
            // 
            // Txt_Cuenta
            // 
            this.Txt_Cuenta.Location = new System.Drawing.Point(134, 45);
            this.Txt_Cuenta.Name = "Txt_Cuenta";
            this.Txt_Cuenta.Size = new System.Drawing.Size(260, 20);
            this.Txt_Cuenta.TabIndex = 2;
            this.Txt_Cuenta.Text = "ventas_momias@hotmail.com";
            this.Txt_Cuenta.ThemeName = "TelerikMetroBlue";
            // 
            // Txt_Contraseña
            // 
            this.Txt_Contraseña.Location = new System.Drawing.Point(134, 73);
            this.Txt_Contraseña.Name = "Txt_Contraseña";
            this.Txt_Contraseña.Size = new System.Drawing.Size(260, 20);
            this.Txt_Contraseña.TabIndex = 3;
            this.Txt_Contraseña.Text = "P@ssw0rd2021";
            this.Txt_Contraseña.ThemeName = "TelerikMetroBlue";
            // 
            // Btn_Enviar_Correo
            // 
            this.Btn_Enviar_Correo.Location = new System.Drawing.Point(411, 45);
            this.Btn_Enviar_Correo.Name = "Btn_Enviar_Correo";
            this.Btn_Enviar_Correo.Size = new System.Drawing.Size(141, 87);
            this.Btn_Enviar_Correo.TabIndex = 4;
            this.Btn_Enviar_Correo.Text = "Enviar Correo";
            this.Btn_Enviar_Correo.ThemeName = "Desert";
            this.Btn_Enviar_Correo.Click += new System.EventHandler(this.Btn_Enviar_Correo_Click);
            // 
            // Lbl_Enviar_A
            // 
            this.Lbl_Enviar_A.Location = new System.Drawing.Point(46, 116);
            this.Lbl_Enviar_A.Name = "Lbl_Enviar_A";
            this.Lbl_Enviar_A.Size = new System.Drawing.Size(51, 16);
            this.Lbl_Enviar_A.TabIndex = 5;
            this.Lbl_Enviar_A.Text = "Enviar a:";
            this.Lbl_Enviar_A.ThemeName = "TelerikMetroBlue";
            // 
            // Txt_Enviar_Cuenta
            // 
            this.Txt_Enviar_Cuenta.Location = new System.Drawing.Point(134, 112);
            this.Txt_Enviar_Cuenta.Name = "Txt_Enviar_Cuenta";
            this.Txt_Enviar_Cuenta.Size = new System.Drawing.Size(260, 20);
            this.Txt_Enviar_Cuenta.TabIndex = 6;
            this.Txt_Enviar_Cuenta.Text = "enrique.ramirez@contel.com.mx";
            this.Txt_Enviar_Cuenta.ThemeName = "TelerikMetroBlue";
            // 
            // Btn_Iniciar_Terminar
            // 
            this.Btn_Iniciar_Terminar.Location = new System.Drawing.Point(46, 191);
            this.Btn_Iniciar_Terminar.Name = "Btn_Iniciar_Terminar";
            this.Btn_Iniciar_Terminar.Size = new System.Drawing.Size(145, 53);
            this.Btn_Iniciar_Terminar.TabIndex = 7;
            this.Btn_Iniciar_Terminar.Text = "Iniciar";
            this.Btn_Iniciar_Terminar.Click += new System.EventHandler(this.Btn_Iniciar_Terminar_Click);
            // 
            // Timer_Pulso
            // 
            this.Timer_Pulso.Interval = 500;
            this.Timer_Pulso.Tick += new System.EventHandler(this.Timer_Pulso_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Btn_Iniciar_Terminar);
            this.Controls.Add(this.Txt_Enviar_Cuenta);
            this.Controls.Add(this.Lbl_Enviar_A);
            this.Controls.Add(this.Btn_Enviar_Correo);
            this.Controls.Add(this.Txt_Contraseña);
            this.Controls.Add(this.Txt_Cuenta);
            this.Controls.Add(this.Lbl_Contraseña);
            this.Controls.Add(this.Lbl_Cuenta);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Lbl_Cuenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lbl_Contraseña)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Cuenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Contraseña)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Enviar_Correo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lbl_Enviar_A)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Enviar_Cuenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Iniciar_Terminar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel Lbl_Cuenta;
        private Telerik.WinControls.UI.RadLabel Lbl_Contraseña;
        private Telerik.WinControls.UI.RadTextBoxControl Txt_Cuenta;
        private Telerik.WinControls.UI.RadTextBoxControl Txt_Contraseña;
        private Telerik.WinControls.UI.RadButton Btn_Enviar_Correo;
        private Telerik.WinControls.Themes.TelerikMetroBlueTheme telerikMetroBlueTheme1;
        private Telerik.WinControls.UI.RadLabel Lbl_Enviar_A;
        private Telerik.WinControls.Themes.VisualStudio2012DarkTheme visualStudio2012DarkTheme1;
        private Telerik.WinControls.Themes.DesertTheme desertTheme1;
        private Telerik.WinControls.UI.RadTextBoxControl Txt_Enviar_Cuenta;
        private Telerik.WinControls.UI.RadButton Btn_Iniciar_Terminar;
        private System.Windows.Forms.Timer Timer_Pulso;
    }
}

