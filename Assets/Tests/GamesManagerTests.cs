using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;
using System.Collections;
using static System.Net.Mime.MediaTypeNames;
using System;

public class GamesManagerTests
{
    public IEnumerator TestStageNumberDisplay()
    {
        // Assuming there's a MainData class that holds the current stage number
        MainData.cur_Stage = 5; // Example stage number

        var gameObject = new GameObject();
        var gamesManager = gameObject.AddComponent<GamesManager>();
        var textGameObject = new GameObject("StageNumberText", typeof(Text));
        gamesManager.txt_StageNum = textGameObject.GetComponent<Text>();

        // Normally, the Update method would set this text, but we call ShowUI directly for testing
        gamesManager.ShowUI();

        // Check if the UI text matches the current stage
        Assert.AreEqual("5", gamesManager.txt_StageNum.text, "Stage number displayed does not match expected value.");

        // Cleanup
        Object.Destroy(gameObject);
        Object.Destroy(textGameObject);

        yield return null;
    }
}
