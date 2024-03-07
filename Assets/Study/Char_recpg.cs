using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // If you click on the screen where the character is
    // recognize the character. 
    // pc : If you click the mouse on the screen
    // Mobile: When you touch the screen

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)==true) //0 <- left / 1,2 <- 중간, 우측
        {
            print("cliked!");
            Debug.Log("cliked!");
        }
        if(Input.GetMouseButtonUp(0)==true)
        {
            print("recliked!");
            Debug.Log("recliked!");
        }
    }
}
// Class - input class with input information
// Getting various input function information Get
// Setting: Set wjdqhfmf 
// Get Input.GetKeyDown(); //Get the keyboard information
// Not available on Input.GetTouch(); //pc Mobile available
// When the mouse is connected to the mobile phone (OTG cable), the mouse pointer is generated
// When the mouse is pressed on the icon, the program connected to the icon is driven. <- touch function
// Commonly available on pc/mobic