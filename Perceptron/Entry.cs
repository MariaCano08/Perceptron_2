
using System;

namespace Perceptron
{

	public class Entry
	{
		
		int X; //Coordenada en el picturebox
		int Y; //Coordenada en el picturebox
		float x1; //X1 
		float x2; //X2
		bool class_; //Salida deseada True == 1, False == 0
		
		public Entry(){
			
		}
		
		public Entry(int X, int Y, bool class_){
			this.X = X;
			this.Y = Y;
			x1 = calculateScale(true,X);
			x2 = calculateScale(false,Y);
			this.class_ = class_;
		}
		
		public Entry(int X, int Y){
			this.X = X;
			this.Y = Y;
			x1 = calculateScale(true,X);
			x2 = calculateScale(false,Y);
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
		
		public float getX1(){
			return x1;
		}
		
		public void setX1(float x1){
			this.x1 = x1;
		}
		
		public float getX2(){
			return x2;
		}
		
		public void setX2(float x2){
			this.x2 = x2;
		}
		
		public bool getClass(){
			return class_;
		}
		
		public void setClass(bool class_){
			this.class_ = class_;
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
	}
}
