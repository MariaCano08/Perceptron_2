
using System;

namespace Perceptron
{

	public class Entry
	{
		
		int X; //Coordenada en el picturebox
		int Y; //Coordenada en el picturebox
		float x_f; //X1 
		float y_f; //X2
		bool class_; //Salida deseada 
		
		public Entry(){
			
		}
		
		public Entry(int X, int Y, bool class_){
			this.X = X;
			this.Y = Y;
			this.class_ = class_;
		}
		
		public int getX(){
			return X;
		}
		
		public void setX(int X){
			this.X = X;
		}
		
		public int getY(){
			return Y;
		}
		
		public void setY(int Y){
			this.Y = Y;
		}
		
		public float getX_f(){
			return x_f;
		}
		
		public void setX_f(float x_f){
			this.x_f = x_f;
		}
		
		public float getY_f(){
			return y_f;
		}
		
		public void setY_f(float y_f){
			this.y_f = y_f;
		}
		
		public bool getClass(){
			return class_;
		}
		
		public void setClass(bool class_){
			this.class_ = class_;
		}
	}
}
