using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calculator : MonoBehaviour {

	public Text result;
	public Text clearText;


	double firstNumber;     //stores first number entered, important for division and subtraction etc
	string currentOperator = "";
	bool isNewNumber = true;    //true or false to see when next number is entered

	public void onNumberPressed(string pressed){    //event handler for button press
		if (isNewNumber) {
			this.result.text = pressed;
			isNewNumber = false;
		} else {
			if (this.result.text.Contains (".")) {
				this.result.text += pressed;
			} else {
				double number;
				int pressedNumber;
				if (double.TryParse (this.result.text, out number) && int.TryParse (pressed, out pressedNumber)) { //parsing first and second number from strings
					double newNumber = (number * 10) + pressedNumber;           //* 10 is so when you type a number over 9 it displays properly, inputting 6,5 displays as 65 etc
					this.result.text = newNumber.ToString ();                           //convert result back to string to display 
				}
			}
		}


		clearText.text = "C";

	}


	public void onDotPressed(){   //event handler for . pressed 
		if (isNewNumber) {
			this.result.text = "0.";    //if . is the first thing pressed, add a 0. infront of the next number
		} else {
			if (!this.result.text.Contains (".")) {   //if . isnt the first button pressed 
				this.result.text += ".";
			}
		}

		clearText.text = "C";
	}


	public void onPercentagePressed(){      //event handler for the % function
		double number;
		if (double.TryParse (this.result.text, out number)) {   //parse number from text to double 
			double newNumber = number/100;      //divide number parsed by 100 to show it as a percentage
			this.result.text = newNumber.ToString ();   //convert back to string
		}
	}


	public void onTogglePressed(){      //event handler for +/- button
		double number;
		if (double.TryParse (this.result.text, out number)) {
			double newNumber = -1*number;       //multiplies the number by -1 to convert it to negative
			this.result.text = newNumber.ToString ();   //converst from double back to string
		}

	}


	public void onOperatorPressed(string pressed){      //event handler to hold the values of the new number + the first number when one of the operator buttons are pressed e.g multiply divide

		double number;
		if (double.TryParse (this.result.text, out number)) {
			firstNumber = number;
			currentOperator = pressed;
			isNewNumber = true;
		}

	}

	public void onEqualsPressed(){   //event handler for the equals operator

		if (currentOperator == "") {   //if no button pressed do nothing 
			return;
		}

		double number;
		if (double.TryParse (this.result.text, out number)) {    //parse text to double
			double newNumber = 0;       //variable initialized as 0 to store result 
			switch (currentOperator) {

			case "divide":                              //cases depending on which operator is pressed, the sum is performed depending on which one and then set as the result text below
				newNumber = firstNumber / number;
				break;

			case "multiply":
				newNumber = firstNumber * number;
				break;

			case "minus":
				newNumber = firstNumber - number;
				break;

			case "plus":
				newNumber = firstNumber + number;
				break;

			}

			this.result.text = newNumber.ToString ();   //sets result to text field 
			isNewNumber = true;
			clearText.text = "AC";

		}

	}

	public void onClearPressed(){  //event handler for clear button
		this.result.text = "0";     //set result field to 0 which is default on iOS
		isNewNumber = true;

		if (clearText.text == "AC") {   //if clear button = AC (All Clear), clear all numbers including the first number and also the current operator 
			firstNumber = 0;            //set first number to default 0 
			currentOperator = "";       //reset operator
		} else {
			clearText.text = "AC";      //if clear button = C, once pressed set it to AC 
		}
	}



}
