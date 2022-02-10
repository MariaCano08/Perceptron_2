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
		PictureBox pb1;
		
		public Perceptron(double theta, int epoch, Graphics gr, Bitmap bmp, PictureBox pb1)//v_x,v_y, theta 
		{
			this.theta=theta;
			this.limitEpoch=epoch;
			this.gr = gr;
			this.bmp = bmp;
			this.pb1 = pb1;
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
		
		
		public void inicialize(List<Entry> el){
			
			bool done=false;
			int epoch=0;
			double have=0,err;
			dataFill(el);
//			double[] obj=new double[]{1.0,1.0};
//			x.Add(obj);
//			y.Add(1);
			List<float> v_w=inicialize_w(3);// donde la entrada es dependiente al tamaño de x
			
			
			while(done == false && 	epoch<limitEpoch ){//revisa tu condicion tochoii
				//done= true;
				for(int i=0;i<x.Count;i++){
					have=pw(x[i],v_w);//obtenida
					err=y[i]-have;
					if((int)err!=0){
						//done=false;
						done=true;
						drawLine(v_w,theta,x[i]);
						v_w=change_values(v_w,theta,err,x[i]);
						//drawline(v_w)
					}
					
				}
				epoch++;
			}
			
			List<double> y_obt = new List<double>();
			for(int i=0;i<x.Count;i++){
					have=pw(x[i],v_w);//obtenida
					y_obt.Add(have);
			}
			MessageBox.Show("Terminó el entrenamiento");
		}
		void drawLine(List<float> v_w, double theta, double[] x){
			double m=-(v_w[1]/v_w[2]);
			double b= theta/v_w[2];
			double y_ = m * x[0] + b;
			double y_1 = m * x[1] + b;
			Pen p = new Pen(Color.Red);
			gr.DrawLine(p, (int)x[0], (int)y_, (int)x[1], (int)y_1);
			
			pb1.Image = bmp;
			pb1.Refresh();
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
				float wi = w[i];
				pw+=xi*wi;
			}
			
			if(pw >= 0){
				return 1;
			}
			return 0;
		}

		List<float> inicialize_w(int l)
		{
			List<float> v_w= new List<float>();
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
		
	}
}
