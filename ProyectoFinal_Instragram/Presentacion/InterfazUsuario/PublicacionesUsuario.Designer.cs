
namespace ProyectoFinal_Instragram.Presentacion.InterfazUsuario
{
    partial class PublicacionesUsuario
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnSubir = new System.Windows.Forms.Button();
            this.btnExaminar = new System.Windows.Forms.Button();
            this.imgPresentacion = new System.Windows.Forms.PictureBox();
            this.txtComentario = new System.Windows.Forms.TextBox();
            this.txtPublicaciones = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgPresentacion)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(334, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "publicaciones";
            // 
            // btnSubir
            // 
            this.btnSubir.Location = new System.Drawing.Point(393, 308);
            this.btnSubir.Name = "btnSubir";
            this.btnSubir.Size = new System.Drawing.Size(144, 44);
            this.btnSubir.TabIndex = 1;
            this.btnSubir.Text = "Subir publicacion";
            this.btnSubir.UseVisualStyleBackColor = true;
            this.btnSubir.Click += new System.EventHandler(this.btnSubir_Click);
            // 
            // btnExaminar
            // 
            this.btnExaminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExaminar.Location = new System.Drawing.Point(95, 278);
            this.btnExaminar.Name = "btnExaminar";
            this.btnExaminar.Size = new System.Drawing.Size(100, 29);
            this.btnExaminar.TabIndex = 16;
            this.btnExaminar.Text = "Examinar Foto";
            this.btnExaminar.UseVisualStyleBackColor = true;
            this.btnExaminar.Click += new System.EventHandler(this.btnExaminar_Click);
            // 
            // imgPresentacion
            // 
            this.imgPresentacion.Location = new System.Drawing.Point(45, 83);
            this.imgPresentacion.Name = "imgPresentacion";
            this.imgPresentacion.Size = new System.Drawing.Size(208, 189);
            this.imgPresentacion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgPresentacion.TabIndex = 15;
            this.imgPresentacion.TabStop = false;
            // 
            // txtComentario
            // 
            this.txtComentario.Location = new System.Drawing.Point(334, 105);
            this.txtComentario.Multiline = true;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(267, 167);
            this.txtComentario.TabIndex = 17;
            // 
            // txtPublicaciones
            // 
            this.txtPublicaciones.Location = new System.Drawing.Point(95, 54);
            this.txtPublicaciones.Name = "txtPublicaciones";
            this.txtPublicaciones.Size = new System.Drawing.Size(100, 23);
            this.txtPublicaciones.TabIndex = 18;
            // 
            // PublicacionesUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtPublicaciones);
            this.Controls.Add(this.txtComentario);
            this.Controls.Add(this.btnExaminar);
            this.Controls.Add(this.imgPresentacion);
            this.Controls.Add(this.btnSubir);
            this.Controls.Add(this.label1);
            this.Name = "PublicacionesUsuario";
            this.Text = "PublicacionesUsuario";
            ((System.ComponentModel.ISupportInitialize)(this.imgPresentacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSubir;
        private System.Windows.Forms.Button btnExaminar;
        private System.Windows.Forms.PictureBox imgPresentacion;
        private System.Windows.Forms.TextBox txtComentario;
        private System.Windows.Forms.TextBox txtPublicaciones;
    }
}