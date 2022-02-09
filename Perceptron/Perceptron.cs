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

namespace Perceptron
{
	/// <summary>
	/// Description of Perceptron.
	/// </summary>
	public class Perceptron
	{
    	Random random = new Random();
		public Perceptron()//v_x,v_y, theta 
		{
			
			
		}

		List<float> change_values(List<float> v_w, double theta, double err, double[] x)
		{
			double nw=0;
			List<float> n_v_w= new List<float>();
			for(int i=1;i<v_w.Count;i++){
				nw=v_w[i]+theta*err*x[i-1];
				n_v_w.Add((float)nw);
				
				
			}
			return n_v_w;
		}

		public void inicialize(){
			
			List<double[]> x= new List<double[]>();//entradas
			List<int> y= new List<int>();//salidas deseadas
			List<float> v_w=inicialize_w(3);// donde la entrada es dependiente al tamaño de x
			double theta=0.1;
			bool done=false;
			int epoch=0;
			int limitEpoch=100;// va cambiar dependiendo del usuario
			double[] obj=new double[]{1.0,1.0};
			double have=0,err;
			x.Add(obj);
			y.Add(1);
			
			
			while(done == false && 	epoch<limitEpoch ){//revisa tu condicion tochoii
				for(int i=0;i<x.Count;i++){
					have=pw(x[i],v_w);//obtenida
					err=y[i]-have;
					if((int)err!=0){
						done=true;
						v_w=change_values(v_w,theta,err,x[i]);
					}
				}
				epoch++;
			}
			//MessageBox.Show("Never");
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
				pw+=x[i]*w[i+1];
			}
			return pw;
		}

		List<float> inicialize_w(int l)
		{
			List<float> v_w= new List<float>();
			for(int i=0;i<l;i++){
				v_w.Add((float)random.Next(0, 5));
			}
			return v_w;
		}
	}
}
