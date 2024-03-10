using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Zombie enum 
public enum ActionType { init, idle, walk, run, contact, //On respond walk/run towards the target, when reach the target change the contact status
    attack, drain, cooltime //attack and drain and cooltime
} 

public class ZombieControl : MonoBehaviour
{

    ActionType myact;

    //status change based on time
    float action_time;
    GameObject Find_obj; // Find a subject
    Base_Control obj_logic; // Associate the source with the corresponding variable

    // Start is called before the first frame update
    void Start()
    {
        action_time = 0;
        myact = ActionType.init;
        Find_obj = GameObject.Find("Player_Base"); //Find objects in hyrachy by name
        obj_logic = Find_obj.GetComponent<Base_Control>(); // Connect the source code connected through the object to the variable I created -> print("Find_obj" + Find_obj.tag);
        print("Find_obj" + Find_obj.tag);
    }

    // Update is called once per frame
    void Update()
    {
/*        print("Status: " +  myact);*/
        Enemy_Action();
    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player_Base")
        {
            myact = ActionType.contact;
            Vector3 curpos = this.transform.position;
            this.transform.position = new Vector3(curpos.x-0.1f, curpos.y, curpos.z);
        }
    }

    void Enemy_Action()
    {
        switch (myact)
        {
            case ActionType.init:
                myact = ActionType.idle; 
                break;
            case ActionType.idle: //zombie idle for 1 second
                action_time += Time.deltaTime;
                if(action_time >=0.81f) //idle 1.5 sec
                {
                    action_time = 0;
                    myact = ActionType.walk;
                }
                break; 
            case ActionType.walk: //zombie walk
                this.transform.Translate(Vector3.forward * Time.deltaTime * 1.8f);
                action_time += Time.deltaTime;
                if (action_time >= 3.5f) //walk 3.5 sec
                {
                    action_time = 0;
                    myact = ActionType.run;
                }
                break;
            case ActionType.run: //zombie run
                this.transform.Translate(Vector3.forward * Time.deltaTime * 5f);
                break;
            case ActionType.contact: //zombie contacts target
                myact = ActionType.cooltime;
                break;
            case ActionType.attack: //Attack Attack Motion
                action_time += Time.deltaTime;
                if(action_time >= 1.5f)
                {
                    action_time = 0;
                    myact = ActionType.drain;
                }
                break;
            case ActionType.drain: //reducing the energy of the main character base
                //Reduce the base's life
                obj_logic.Damaged(2.5f);
                // Find the subject of the main character base. - Connection



                myact = ActionType.cooltime;
                break;
            case ActionType.cooltime:
                action_time += Time.deltaTime;

                if (action_time >= 1.7f) //more than 1 second
                {
                    action_time = 0;
                    myact = ActionType.attack;
                }
                    break;
        }

    }
}
