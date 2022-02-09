/*
 * Created by SharpDevelop.
 * User: mfern
 * Date: 2/2/2022
 * Time: 8:25 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Perceptron
{
	partial class Window
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.TextBox textBoxLearningR;
		private System.Windows.Forms.TextBox textBoxEpochM;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button buttonInicializeW;
		private System.Windows.Forms.Button buttonInit;
		private System.Windows.Forms.Button buttonEvaluatePairs;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.textBoxLearningR = new System.Windows.Forms.TextBox();
			this.textBoxEpochM = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.buttonInicializeW = new System.Windows.Forms.Button();
			this.buttonInit = new System.Windows.Forms.Button();
			this.buttonEvaluatePairs = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDark;
			this.pictureBox1.InitialImage = null;
			this.pictureBox1.Location = new System.Drawing.Point(12, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(600, 600);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox1Paint);
			this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBox1MouseClick);
			// 
			// textBoxLearningR
			// 
			this.textBoxLearningR.Location = new System.Drawing.Point(743, 66);
			this.textBoxLearningR.Name = "textBoxLearningR";
			this.textBoxLearningR.Size = new System.Drawing.Size(100, 20);
			this.textBoxLearningR.TabIndex = 1;
			// 
			// textBoxEpochM
			// 
			this.textBoxEpochM.Location = new System.Drawing.Point(743, 106);
			this.textBoxEpochM.Name = "textBoxEpochM";
			this.textBoxEpochM.Size = new System.Drawing.Size(100, 20);
			this.textBoxEpochM.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(636, 64);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(101, 23);
			this.label1.TabIndex = 3;
			this.label1.Text = "Learning rate:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(620, 99);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(117, 33);
			this.label2.TabIndex = 4;
			this.label2.Text = "Epocas maximas:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// buttonInicializeW
			// 
			this.buttonInicializeW.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonInicializeW.Location = new System.Drawing.Point(743, 156);
			this.buttonInicializeW.Name = "buttonInicializeW";
			this.buttonInicializeW.Size = new System.Drawing.Size(100, 27);
			this.buttonInicializeW.TabIndex = 5;
			this.buttonInicializeW.Text = "Inicializar W";
			this.buttonInicializeW.UseVisualStyleBackColor = true;
			this.buttonInicializeW.Click += new System.EventHandler(this.ButtonInicializeWClick);
			// 
			// buttonInit
			// 
			this.buttonInit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonInit.Location = new System.Drawing.Point(743, 208);
			this.buttonInit.Name = "buttonInit";
			this.buttonInit.Size = new System.Drawing.Size(100, 27);
			this.buttonInit.TabIndex = 6;
			this.buttonInit.Text = "Iniciar ";
			this.buttonInit.UseVisualStyleBackColor = true;
			this.buttonInit.Click += new System.EventHandler(this.ButtonInitClick);
			// 
			// buttonEvaluatePairs
			// 
			this.buttonEvaluatePairs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonEvaluatePairs.Location = new System.Drawing.Point(743, 263);
			this.buttonEvaluatePairs.Name = "buttonEvaluatePairs";
			this.buttonEvaluatePairs.Size = new System.Drawing.Size(100, 27);
			this.buttonEvaluatePairs.TabIndex = 7;
			this.buttonEvaluatePairs.Text = "Evaluar";
			this.buttonEvaluatePairs.UseVisualStyleBackColor = true;
			this.buttonEvaluatePairs.Click += new System.EventHandler(this.ButtonEvaluatePairsClick);
			// 
			// Window
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(884, 733);
			this.Controls.Add(this.buttonEvaluatePairs);
			this.Controls.Add(this.buttonInit);
			this.Controls.Add(this.buttonInicializeW);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBoxEpochM);
			this.Controls.Add(this.textBoxLearningR);
			this.Controls.Add(this.pictureBox1);
			this.Name = "Window";
			this.Text = "window";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
