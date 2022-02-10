/*
 * Created by SharpDevelop.
 * User: mfern
 * Date: 2/2/2022
 * Time: 8:25 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Perceptron
{
	/// <summary>
	/// Description of window.
	/// </summary>
	public partial class Window : Form
	{
		Brush b = new SolidBrush(Color.Purple);
		Bitmap bmp;
		Graphics gf;
		
		List<Entry> entryList;
		float lr;
		int mEp;
		Random rand;
		List<float> v_w;
		
		public Window()
		{
			InitializeComponent();
			entryList = new List<Entry>();
			lr = 0;
			mEp = 0;
			rand = new Random();
			v_w = new List<float>();
		}
		
		void PictureBox1MouseClick(object sender, MouseEventArgs e)//escala de 30 centro 300,300
		{	
			//MessageBox.Show(e.X.ToString()+", "+e.Y.ToString());
			
			if(e.Button == MouseButtons.Left){ //If is LEFT - CLASS 1
				//gf.FillEllipse(b, new RectangleF(e.X,e.Y, 15, 15));
				entryList.Add(new Entry(e.X,e.Y,true));
			}
			else{ //If is RIGHT - CLASS 0
				//gf.FillEllipse(new SolidBrush(Color.GreenYellow), new RectangleF(e.X,e.Y, 15, 15));
				entryList.Add(new Entry(e.X,e.Y,false));
				
			}
			drawClasses();
		}
		
		void drawClasses(){
			
			bmp = new Bitmap (pictureBox1.Width,pictureBox1.Height);
			gf= Graphics.FromImage(bmp);
			gf.Clear(Color.Transparent);
			
			
			for(int i = 0; i < entryList.Count; i++){
				Entry aux = entryList[i];
				if(aux.getClass()){ //If is LEFT - CLASS 1
					gf.FillEllipse(b, new RectangleF(aux.getX(),aux.getY(), 15, 15));
				}
				else{ //If is RIGHT - CLASS 0
					gf.FillEllipse(new SolidBrush(Color.GreenYellow), new RectangleF(aux.getX(),aux.getY(), 15, 15));
					
				}
				
			}
			//Pen p = new Pen(Color.Red);
			//gf.DrawLine(p, 10, 80, 300, 300);
			
			//pictureBox1.Image = bmp;
			pictureBox1.BackgroundImage = bmp;
			//pictureBox1.Refresh();
		}
		
		void PictureBox1Paint(object sender, PaintEventArgs e)
		{
			Pen pen_ = new Pen(Color.Black,2);
			
			SolidBrush sb = new SolidBrush(Color.Black);
			Font f = new Font("Times new roman", 12);
			int x_c=pictureBox1.Width/2;
			int y_c=pictureBox1.Height/2;
			double count=-1;
			double inc=0.10;
			e.Graphics.TranslateTransform(x_c,y_c);
			//e.Graphics.ScaleTransform(-1,1);
			
			
			e.Graphics.DrawLine(pen_,x_c*-1,0,x_c*2,0);
			e.Graphics.DrawLine(pen_,0,y_c,0,y_c*-1);
			
			for(int i=-x_c;i<x_c;i+=30){
				e.Graphics.DrawLine(pen_,5,i,-5,i);
				e.Graphics.DrawLine(pen_,i,5,i,-5);
				if(i!=0){
					
					e.Graphics.DrawString(""+(float)count,f,sb,i-8,5); //X
					e.Graphics.DrawString(""+(float)count*-1,f,sb,5,i-8);// Y
					
				}
				count=count+inc;
				
			}
		}
		
		void ButtonInicializeWClick(object sender, EventArgs e)
		{
			if(entryList.Count == 0){
				MessageBox.Show("Por favor primero ingresa los puntos a evaluar");
			}
			else{
				//inicializar pesos W random
				for(int i = 0; i < 2; i++){
					v_w.Add((float) rand.Next(0,5)); //aun no guarda W0
				}
				MessageBox.Show("Vector inicializado");
			}
			
		}
		
		
		
		void ButtonInitClick(object sender, EventArgs e)
		{
			if(textBoxLearningR.Text == "" || textBoxEpochM.Text == ""){
				MessageBox.Show("Por favor revisa que hayas llenado los campos correctamente");
			}
			else if(v_w.Count == 0){
				MessageBox.Show("Por favor primero inicializa el vector de pesos");
			}
			else{
				lr = float.Parse(textBoxLearningR.Text);
				mEp = Int32.Parse(textBoxEpochM.Text);
				
				//MessageBox.Show("Inicia el perceptron"+" lr= "+lr+" epm= "+mEp);
				Perceptron p= new Perceptron(lr,mEp, gf, bmp, pictureBox1);
				p.inicialize(entryList);
			}
			
		}
		void ButtonEvaluatePairsClick(object sender, EventArgs e)
		{
			//Se evaluaran todos los pares de puntos ordenados 
		}
		


	}
}
