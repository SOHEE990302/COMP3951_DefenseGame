using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MarketManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        print("Current Stage" + MainData.curstage);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NextSence()
    {
        
    }
    public void GoNextStage() //move to next stage
    {
        MainData.curstage += 1;

        SceneManager.LoadScene("2_Game_Scene");
    }
}
