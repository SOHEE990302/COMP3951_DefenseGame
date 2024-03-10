using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NewBehaviourScript : MonoBehaviour
{
    //1. If you click on the screen where the character is
    // recognize the character. 
    // pc : If you click the mouse on the screen
    // Mobile: When you touch the screen

    // 정보를 화면에 표시
    public Text info1;
    int Input_state;


    // Start is called before the first frame update
    void Start()
    {
        Input_state = 0;
        info1.text = "none";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)==true) //0 <- left / 1,2 <- middle, right
        {
            Input_state = 1;
            // Recognize 3D objects when pressed
            //How do you perceive -> ray tracing
            Ray screenray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit other;
            if (Physics.Raycast(screenray, out other, 20f) == true)
            {
                //You need to check what is the correct object
                print("There's a guy who got hit" + other.transform.name);
                if (other.transform.tag == "Enemy")
                {
                    Destroy(other.transform.gameObject);
                }
            }
            else
            {
                print("No one has been hit");

            }
        }
        if (Input.GetMouseButtonUp(0)==true)
        {
            Input_state = 2;
        }
        ShowInputState(Input_state);
    }
    void ShowInputState(int state)
    {
        if(state == 1)
        {
            info1.text = "눌렀따";
        }
        if(state == 2)
        {
            info1.text = "떼어졌음";
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