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
		public void inicialize(){
			
			MessageBox.Show("Deberias 0");
			List<double[]> x= new List<double[]>();//entradas
			List<int> y= new List<int>();//salidas deseadas
			List<float> v_w=inicialize_w(3);// donde la entrada es dependiente al tamaño de x
			double theta=0.1;
			bool done=false;
			int epoch=0;
			int limitEpoch=100;// va cambiar dependiendo del usuario
			double[] obj=new double[]{1.0,1.0};
			double have=0;
			x.Add(obj);
			while(done == false || 	epoch<limitEpoch ){//revisa tu condicion tochoii
				for(int i=0;i<x.Count;i++){
					have=pw(x[i],v_w);//obtenida
				}
				break;
				epoch++;
			}
			MessageBox.Show("Never");
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
