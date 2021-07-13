
namespace Notificaciones_Boton_.Formularios
{
    partial class Frm_Notificaciones_Pulso
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Tbl_Pnl_Principal = new System.Windows.Forms.TableLayoutPanel();
            this.Rgau_Grafica_Pulso = new Telerik.WinControls.UI.Gauges.RadRadialGauge();
            this.radialGaugeArc1 = new Telerik.WinControls.UI.Gauges.RadialGaugeArc();
            this.radialGaugeArc2 = new Telerik.WinControls.UI.Gauges.RadialGaugeArc();
            this.radialGaugeNeedle1 = new Telerik.WinControls.UI.Gauges.RadialGaugeNeedle();
            this.Tbl_Pnl_Izquierdo_Superior = new System.Windows.Forms.TableLayoutPanel();
            this.Lbl_Activacion = new Telerik.WinControls.UI.RadLabel();
            this.Tbl_Pnl_Derecho_Superior = new System.Windows.Forms.TableLayoutPanel();
            this.Lbl_Inactivo = new Telerik.WinControls.UI.RadLabel();
            this.Tbl_Pnl_Central_Superior = new System.Windows.Forms.TableLayoutPanel();
            this.Lbl_Escaner = new Telerik.WinControls.UI.RadLabel();
            this.visualStudio2012DarkTheme1 = new Telerik.WinControls.Themes.VisualStudio2012DarkTheme();
            this.Tmr_Pulso = new System.Windows.Forms.Timer(this.components);
            this.RadAlert_Email = new Telerik.WinControls.UI.RadDesktopAlert(this.components);
            this.Tmr_Inactivando = new System.Windows.Forms.Timer(this.components);
            this.Tmr_Activando = new System.Windows.Forms.Timer(this.components);
            this.Tmr_Escaneando = new System.Windows.Forms.Timer(this.components);
            this.Bar_Escaneo = new Telerik.WinControls.UI.RadWaitingBar();
            this.Bar_Enviar_Correo = new Telerik.WinControls.UI.RadWaitingBar();
            this.Bar_Activacion = new Telerik.WinControls.UI.RadWaitingBar();
            this.Tbl_Pnl_Principal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Rgau_Grafica_Pulso)).BeginInit();
            this.Tbl_Pnl_Izquierdo_Superior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Lbl_Activacion)).BeginInit();
            this.Tbl_Pnl_Derecho_Superior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Lbl_Inactivo)).BeginInit();
            this.Tbl_Pnl_Central_Superior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Lbl_Escaner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bar_Escaneo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bar_Enviar_Correo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bar_Activacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // Tbl_Pnl_Principal
            // 
            this.Tbl_Pnl_Principal.ColumnCount = 3;
            this.Tbl_Pnl_Principal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.Tbl_Pnl_Principal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.Tbl_Pnl_Principal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.Tbl_Pnl_Principal.Controls.Add(this.Rgau_Grafica_Pulso, 1, 1);
            this.Tbl_Pnl_Principal.Controls.Add(this.Tbl_Pnl_Izquierdo_Superior, 0, 0);
            this.Tbl_Pnl_Principal.Controls.Add(this.Tbl_Pnl_Derecho_Superior, 2, 0);
            this.Tbl_Pnl_Principal.Controls.Add(this.Tbl_Pnl_Central_Superior, 1, 0);
            this.Tbl_Pnl_Principal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tbl_Pnl_Principal.Location = new System.Drawing.Point(0, 0);
            this.Tbl_Pnl_Principal.Name = "Tbl_Pnl_Principal";
            this.Tbl_Pnl_Principal.RowCount = 2;
            this.Tbl_Pnl_Principal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Tbl_Pnl_Principal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Tbl_Pnl_Principal.Size = new System.Drawing.Size(489, 318);
            this.Tbl_Pnl_Principal.TabIndex = 0;
            // 
            // Rgau_Grafica_Pulso
            // 
            this.Rgau_Grafica_Pulso.BackColor = System.Drawing.Color.White;
            this.Rgau_Grafica_Pulso.CausesValidation = false;
            this.Rgau_Grafica_Pulso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Rgau_Grafica_Pulso.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radialGaugeArc1,
            this.radialGaugeArc2,
            this.radialGaugeNeedle1});
            this.Rgau_Grafica_Pulso.Location = new System.Drawing.Point(165, 162);
            this.Rgau_Grafica_Pulso.Name = "Rgau_Grafica_Pulso";
            this.Rgau_Grafica_Pulso.RangeEnd = 10D;
            this.Rgau_Grafica_Pulso.Size = new System.Drawing.Size(157, 153);
            this.Rgau_Grafica_Pulso.StartAngle = 180D;
            this.Rgau_Grafica_Pulso.SweepAngle = 180D;
            this.Rgau_Grafica_Pulso.TabIndex = 7;
            this.Rgau_Grafica_Pulso.Text = "radRadialGauge1";
            this.Rgau_Grafica_Pulso.Value = 0F;
            // 
            // radialGaugeArc1
            // 
            this.radialGaugeArc1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(190)))), ((int)(((byte)(79)))));
            this.radialGaugeArc1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(191)))), ((int)(((byte)(80)))));
            this.radialGaugeArc1.BindEndRange = true;
            this.radialGaugeArc1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.radialGaugeArc1.Name = "radialGaugeArc1";
            this.radialGaugeArc1.RangeEnd = 0D;
            this.radialGaugeArc1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.radialGaugeArc1.Width = 40D;
            // 
            // radialGaugeArc2
            // 
            this.radialGaugeArc2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.radialGaugeArc2.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(194)))), ((int)(((byte)(194)))));
            this.radialGaugeArc2.BindStartRange = true;
            this.radialGaugeArc2.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.radialGaugeArc2.Name = "radialGaugeArc2";
            this.radialGaugeArc2.RangeEnd = 100D;
            this.radialGaugeArc2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.radialGaugeArc2.Width = 40D;
            // 
            // radialGaugeNeedle1
            // 
            this.radialGaugeNeedle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.radialGaugeNeedle1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.radialGaugeNeedle1.BackLenghtPercentage = 0D;
            this.radialGaugeNeedle1.BindValue = true;
            this.radialGaugeNeedle1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.radialGaugeNeedle1.InnerPointRadiusPercentage = 0D;
            this.radialGaugeNeedle1.LenghtPercentage = 94D;
            this.radialGaugeNeedle1.Name = "radialGaugeNeedle1";
            this.radialGaugeNeedle1.PointRadiusPercentage = 7D;
            this.radialGaugeNeedle1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.radialGaugeNeedle1.Thickness = 8D;
            this.radialGaugeNeedle1.Value = 0F;
            // 
            // Tbl_Pnl_Izquierdo_Superior
            // 
            this.Tbl_Pnl_Izquierdo_Superior.ColumnCount = 1;
            this.Tbl_Pnl_Izquierdo_Superior.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Tbl_Pnl_Izquierdo_Superior.Controls.Add(this.Lbl_Activacion, 0, 0);
            this.Tbl_Pnl_Izquierdo_Superior.Controls.Add(this.Bar_Activacion, 0, 1);
            this.Tbl_Pnl_Izquierdo_Superior.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tbl_Pnl_Izquierdo_Superior.Location = new System.Drawing.Point(3, 3);
            this.Tbl_Pnl_Izquierdo_Superior.Name = "Tbl_Pnl_Izquierdo_Superior";
            this.Tbl_Pnl_Izquierdo_Superior.RowCount = 3;
            this.Tbl_Pnl_Izquierdo_Superior.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.Tbl_Pnl_Izquierdo_Superior.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.Tbl_Pnl_Izquierdo_Superior.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.Tbl_Pnl_Izquierdo_Superior.Size = new System.Drawing.Size(156, 153);
            this.Tbl_Pnl_Izquierdo_Superior.TabIndex = 8;
            this.Tbl_Pnl_Izquierdo_Superior.Visible = false;
            // 
            // Lbl_Activacion
            // 
            this.Lbl_Activacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Lbl_Activacion.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Activacion.Location = new System.Drawing.Point(3, 3);
            this.Lbl_Activacion.Name = "Lbl_Activacion";
            this.Lbl_Activacion.Size = new System.Drawing.Size(95, 30);
            this.Lbl_Activacion.TabIndex = 0;
            this.Lbl_Activacion.Text = "Activando";
            this.Lbl_Activacion.ThemeName = "VisualStudio2012Dark";
            // 
            // Tbl_Pnl_Derecho_Superior
            // 
            this.Tbl_Pnl_Derecho_Superior.ColumnCount = 1;
            this.Tbl_Pnl_Derecho_Superior.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Tbl_Pnl_Derecho_Superior.Controls.Add(this.Lbl_Inactivo, 0, 0);
            this.Tbl_Pnl_Derecho_Superior.Controls.Add(this.Bar_Enviar_Correo, 0, 1);
            this.Tbl_Pnl_Derecho_Superior.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tbl_Pnl_Derecho_Superior.Location = new System.Drawing.Point(328, 3);
            this.Tbl_Pnl_Derecho_Superior.Name = "Tbl_Pnl_Derecho_Superior";
            this.Tbl_Pnl_Derecho_Superior.RowCount = 3;
            this.Tbl_Pnl_Derecho_Superior.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.Tbl_Pnl_Derecho_Superior.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.Tbl_Pnl_Derecho_Superior.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.Tbl_Pnl_Derecho_Superior.Size = new System.Drawing.Size(158, 153);
            this.Tbl_Pnl_Derecho_Superior.TabIndex = 9;
            this.Tbl_Pnl_Derecho_Superior.Visible = false;
            // 
            // Lbl_Inactivo
            // 
            this.Lbl_Inactivo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Lbl_Inactivo.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Inactivo.Location = new System.Drawing.Point(3, 3);
            this.Lbl_Inactivo.Name = "Lbl_Inactivo";
            this.Lbl_Inactivo.Size = new System.Drawing.Size(153, 30);
            this.Lbl_Inactivo.TabIndex = 1;
            this.Lbl_Inactivo.Text = "Enviando email...";
            this.Lbl_Inactivo.ThemeName = "VisualStudio2012Dark";
            // 
            // Tbl_Pnl_Central_Superior
            // 
            this.Tbl_Pnl_Central_Superior.ColumnCount = 1;
            this.Tbl_Pnl_Central_Superior.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Tbl_Pnl_Central_Superior.Controls.Add(this.Lbl_Escaner, 0, 0);
            this.Tbl_Pnl_Central_Superior.Controls.Add(this.Bar_Escaneo, 0, 1);
            this.Tbl_Pnl_Central_Superior.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tbl_Pnl_Central_Superior.Location = new System.Drawing.Point(165, 3);
            this.Tbl_Pnl_Central_Superior.Name = "Tbl_Pnl_Central_Superior";
            this.Tbl_Pnl_Central_Superior.RowCount = 3;
            this.Tbl_Pnl_Central_Superior.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.Tbl_Pnl_Central_Superior.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.Tbl_Pnl_Central_Superior.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.Tbl_Pnl_Central_Superior.Size = new System.Drawing.Size(157, 153);
            this.Tbl_Pnl_Central_Superior.TabIndex = 10;
            // 
            // Lbl_Escaner
            // 
            this.Lbl_Escaner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Lbl_Escaner.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Escaner.Location = new System.Drawing.Point(3, 3);
            this.Lbl_Escaner.Name = "Lbl_Escaner";
            this.Lbl_Escaner.Size = new System.Drawing.Size(111, 30);
            this.Lbl_Escaner.TabIndex = 1;
            this.Lbl_Escaner.Text = "Escaneando";
            this.Lbl_Escaner.ThemeName = "VisualStudio2012Dark";
            // 
            // Tmr_Pulso
            // 
            this.Tmr_Pulso.Interval = 500;
            this.Tmr_Pulso.Tick += new System.EventHandler(this.Tmr_Pulso_Tick);
            // 
            // RadAlert_Email
            // 
            this.RadAlert_Email.AutoCloseDelay = 5;
            this.RadAlert_Email.CanMove = false;
            this.RadAlert_Email.CaptionText = "Error Escaner A";
            this.RadAlert_Email.FixedSize = new System.Drawing.Size(200, 200);
            this.RadAlert_Email.Opacity = 0.7F;
            this.RadAlert_Email.ThemeName = "VisualStudio2012Dark";
            // 
            // Tmr_Inactivando
            // 
            this.Tmr_Inactivando.Interval = 1000;
            this.Tmr_Inactivando.Tick += new System.EventHandler(this.Tmr_Inactivando_Tick);
            // 
            // Tmr_Activando
            // 
            this.Tmr_Activando.Interval = 1000;
            this.Tmr_Activando.Tick += new System.EventHandler(this.Tmr_Activando_Tick);
            // 
            // Tmr_Escaneando
            // 
            this.Tmr_Escaneando.Interval = 1000;
            this.Tmr_Escaneando.Tick += new System.EventHandler(this.Tmr_Escaneando_Tick);
            // 
            // Bar_Escaneo
            // 
            this.Bar_Escaneo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Bar_Escaneo.Location = new System.Drawing.Point(3, 53);
            this.Bar_Escaneo.Name = "Bar_Escaneo";
            this.Bar_Escaneo.Size = new System.Drawing.Size(151, 44);
            this.Bar_Escaneo.TabIndex = 2;
            this.Bar_Escaneo.Text = "radWaitingBar1";
            this.Bar_Escaneo.ThemeName = "VisualStudio2012Dark";
            // 
            // Bar_Enviar_Correo
            // 
            this.Bar_Enviar_Correo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Bar_Enviar_Correo.Location = new System.Drawing.Point(3, 53);
            this.Bar_Enviar_Correo.Name = "Bar_Enviar_Correo";
            this.Bar_Enviar_Correo.Size = new System.Drawing.Size(152, 44);
            this.Bar_Enviar_Correo.TabIndex = 2;
            this.Bar_Enviar_Correo.Text = "radWaitingBar1";
            // 
            // Bar_Activacion
            // 
            this.Bar_Activacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Bar_Activacion.Location = new System.Drawing.Point(3, 53);
            this.Bar_Activacion.Name = "Bar_Activacion";
            this.Bar_Activacion.Size = new System.Drawing.Size(150, 44);
            this.Bar_Activacion.TabIndex = 1;
            this.Bar_Activacion.Text = "radWaitingBar1";
            // 
            // Frm_Notificaciones_Pulso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 318);
            this.Controls.Add(this.Tbl_Pnl_Principal);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Notificaciones_Pulso";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Notificador de boton de emergencia";
            this.ThemeName = "VisualStudio2012Dark";
            this.Load += new System.EventHandler(this.Frm_Notificaciones_Pulso_Load);
            this.Tbl_Pnl_Principal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Rgau_Grafica_Pulso)).EndInit();
            this.Tbl_Pnl_Izquierdo_Superior.ResumeLayout(false);
            this.Tbl_Pnl_Izquierdo_Superior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Lbl_Activacion)).EndInit();
            this.Tbl_Pnl_Derecho_Superior.ResumeLayout(false);
            this.Tbl_Pnl_Derecho_Superior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Lbl_Inactivo)).EndInit();
            this.Tbl_Pnl_Central_Superior.ResumeLayout(false);
            this.Tbl_Pnl_Central_Superior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Lbl_Escaner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bar_Escaneo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bar_Enviar_Correo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bar_Activacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel Tbl_Pnl_Principal;
        private Telerik.WinControls.Themes.VisualStudio2012DarkTheme visualStudio2012DarkTheme1;
        private Telerik.WinControls.UI.Gauges.RadRadialGauge Rgau_Grafica_Pulso;
        private Telerik.WinControls.UI.Gauges.RadialGaugeArc radialGaugeArc1;
        private Telerik.WinControls.UI.Gauges.RadialGaugeArc radialGaugeArc2;
        private Telerik.WinControls.UI.Gauges.RadialGaugeNeedle radialGaugeNeedle1;
        private System.Windows.Forms.TableLayoutPanel Tbl_Pnl_Izquierdo_Superior;
        private Telerik.WinControls.UI.RadLabel Lbl_Activacion;
        private System.Windows.Forms.TableLayoutPanel Tbl_Pnl_Derecho_Superior;
        private Telerik.WinControls.UI.RadLabel Lbl_Inactivo;
        private System.Windows.Forms.Timer Tmr_Pulso;
        private Telerik.WinControls.UI.RadDesktopAlert RadAlert_Email;
        private System.Windows.Forms.Timer Tmr_Inactivando;
        private System.Windows.Forms.Timer Tmr_Activando;
        private System.Windows.Forms.TableLayoutPanel Tbl_Pnl_Central_Superior;
        private Telerik.WinControls.UI.RadLabel Lbl_Escaner;
        private System.Windows.Forms.Timer Tmr_Escaneando;
        private Telerik.WinControls.UI.RadWaitingBar Bar_Escaneo;
        private Telerik.WinControls.UI.RadWaitingBar Bar_Enviar_Correo;
        private Telerik.WinControls.UI.RadWaitingBar Bar_Activacion;
    }
}