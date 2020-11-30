using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculator : MonoBehaviour
{
    public float result;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void clickButton(int buttonValue)
    {
        Debug.Log(message: $" button press test: {buttonValue}"); //used to test button press in console
    }

}
