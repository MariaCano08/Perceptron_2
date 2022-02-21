/*
 * Created by SharpDevelop.
 * User: mfern
 * Date: 2/8/2022
 * Time: 1:52 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Perceptron;

namespace Perceptron
{
	/// <summary>
	/// Description of Perceptron.
	/// </summary>
	public class Perceptron
	{
		double theta;
		int limitEpoch;// va cambiar dependiendo del usuario
    	Random random = new Random();
    	List<Entry> entryList= new List<Entry>();
    	List<double[]> x= new List<double[]>();//entradas
		List<int> y= new List<int>();//salidas deseadas
		Graphics gr;
		Bitmap bmp;
		Bitmap bmp2;
		PictureBox pb1;
		List<float> v_wf;
		
		
		public Perceptron(double theta, int epoch, Graphics gr, Bitmap bmp, PictureBox pb1)//v_x,v_y, theta 
		{
			this.theta=theta;
			this.limitEpoch=epoch;
			//this.gr = gr;
			this.bmp = bmp;
			this.pb1 = pb1;
			bmp2 = new Bitmap (pb1.Width,pb1.Height);
			this.gr= Graphics.FromImage(bmp2);
			//this.gr.Clear(Color.Transparent);
			
			//Pen p = new Pen(Color.Red);
			//gr.DrawLine(p, 10, 80, 300, 300);
		}
		List<float> change_values(List<float> v_w, double theta, double err, double[] x)
		{
			double nw=0;
			List<float> n_v_w= new List<float>();
			n_v_w.Add(v_w[0]);
			for(int i=1;i<v_w.Count;i++){
				nw=v_w[i]+theta*err*x[i-1];
				n_v_w.Add((float)nw);
				
				
			}
			
			
			return n_v_w;
		}
		
		
		
		public void inicialize(List<Entry> el, List<float> vw){
			
			
			//List<float> v_w=inicialize_w(3);// donde la entrada es dependiente al tamaño de x
			bool done=false;
			int epoch=0;
			double have=0,err;
			dataFill(el);
//			double[] obj=new double[]{1.0,1.0};
//			x.Add(obj);
//			y.Add(1);
			List<float> v_w=vw;// donde la entrada es dependiente al tamaño de x
			
			
			while(done == false && 	epoch<limitEpoch ){//revisa tu condicion tochoii
				done= true;
				for(int i=0;i<x.Count;i++){
					have=pw(x[i],v_w);//obtenida
					err=y[i]-have;
					if((int)err!=0){
						done=false;
						//done=true;
						drawLine(v_w,theta,x[i]);
						v_w=change_values(v_w,theta,err,x[i]);
						//drawline(v_w)
					}
					
				}
				epoch++;
			}
			
			List<double> y_obt = new List<double>(); //Vector de clases obtenidas
			for(int i=0;i<x.Count;i++){
					have=pw(x[i],v_w);//obtenida
					y_obt.Add(have);
			}
			v_wf = v_w;
			
			if(epoch == limitEpoch){
				MessageBox.Show("El algoritmo no convergió");
				           
			}else{
				MessageBox.Show("Terminó el entrenamiento con "+epoch+" epocas");
			}
		}
		void drawLine(List<float> v_w, double theta, double[] x){
			double m=-(v_w[1]/v_w[2]);// REVISAR CALCULO DE LINEA W
			double b= theta/v_w[2];
			double y_ = m * x[0] + b;
			double y_1 = m * x[1] + b;
			
			Pen p = new Pen(Color.Red,10);
			
			//gr.DrawLine(p, 10, 80, 300, 300);}
			gr.Clear(Color.Transparent);
			gr.DrawLine(p, calculateScaleInv(true,x[0]), calculateScaleInv(false,y_), 
			            calculateScaleInv(true,x[1]), calculateScaleInv(false,y_1));
			
			pb1.Image = bmp2;
			pb1.Refresh();
		}
		
		public int calculateScaleInv(bool axis, double pos){
			float value;
			if(axis){ // True - X
				value = ((float)pos + 1) *300;
			}
			else{// False - Y
				value = (((float)pos * -1) +1) *300;
			}
			
			return (int)value;
			
		}
		
		
		bool activation_funtion(float u){
			if(u>=0){
				return true;
			}
			return false;
		}
		
		
		double pw(double []x, List<float> w){
			double pw=0;
			for (int i=0; i< x.Length;i++){
				double xi = x[i];
				float wi = w[i+1];
				pw+=xi*wi;
			}
			
			if(pw >= 0){
				return 1;
			}
			return 0;
		}

		List<float> inicialize_w(int l)
		{
			List<float>v_w= new List<float>();
			for(int i=0;i<l;i++){
				v_w.Add((float)random.Next(1, 5));
			}
			return v_w;
		}
		
		void dataFill(List<Entry> el){
			Entry aux;
			for(int i= 0; i < el.Count; i++){
				aux = el[i];
				x.Add(new double[]{(double)aux.getX1(), (double)aux.getX2()}); //Creo que aqui le agrego -1
				y.Add(aux.getClass() ? 1 : 0);
			}
		}
		
		float calculateScale(bool axis, int pos){
			float value;
			if(axis){ // True - X
				value = ((float)pos / 300) -1;
			}
			else{// False - Y
				value = (((float)pos / 300) -1)* -1;
			}
			
			return value;
			
		}
		
		public void evaluate(){
			List<Entry> pairList = new List<Entry>();
			
			for(int y = 0; y<600; y+=30){
				for( int x = 0; x <600; x+=30){
					double []x_v = {calculateScale(true,x),calculateScale(false,y)};
					double class_ = pw(x_v,v_wf);
					if(class_ == 1){
						pairList.Add(new Entry(x,y,true));
					}
					else{
						pairList.Add(new Entry(x,y,false));
					}
					
				}
			}

			drawClasses(pairList);
			
			
		}
		
		void drawClasses(List<Entry> le){
			Brush b = new SolidBrush(Color.Purple);
			gr.Clear(Color.Transparent);
			for(int i = 0; i < le.Count; i++){
				Entry aux = le[i];
				if(aux.getClass()){ //If is LEFT - CLASS 1
					gr.FillEllipse(b, new RectangleF(aux.getX()-20,aux.getY()-20, 15, 15));
				}
				else{ //If is RIGHT - CLASS 0
					gr.FillEllipse(new SolidBrush(Color.GreenYellow), new RectangleF(aux.getX()-20,aux.getY()-20, 15, 15));
					
				}
				
			}
			//double [] x_ = x[0];
			
			//double m=-(v_wf[1]/v_wf[2]);// REVISAR CALCULO DE LINEA W
			//double b_= theta/v_wf[2];
			//double y_ = m * x_[0] + b_;
			//double y_1 = m * x_[1] + b_;
			
			//Pen p = new Pen(Color.Red,10);
			//gr.DrawLine(p, calculateScaleInv(true,x_[0]), calculateScaleInv(false,y_), 
			//            calculateScaleInv(true,x_[1]), calculateScaleInv(false,y_1));
			pb1.Image = bmp2;
			pb1.Refresh();
			
		}
	}
}
