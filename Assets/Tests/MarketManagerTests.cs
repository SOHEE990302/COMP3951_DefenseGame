using UnityEngine.TestTools;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Object = UnityEngine.Object;

public class MarketManagerTests
{
    public static class MainData
    {
        public static int cur_Stage = 1;
    }

    public IEnumerator TestStageIncrement()
    {
        int initialStage = MainData.cur_Stage;

        var gameObject = new GameObject();
        var marketManager = gameObject.AddComponent<MarketManager>();
        marketManager.GoNextStage();

        Assert.AreEqual(initialStage + 1, MainData.cur_Stage, "Stage did not increment as expected.");

        Object.Destroy(gameObject);
        yield return null;
    }

    public IEnumerator TestSceneLoad()
    {
        var gameObject = new GameObject();
        var marketManager = gameObject.AddComponent<MarketManager>();

        marketManager.GoNextStage();

        yield return new WaitForSeconds(1);

        Assert.AreEqual("2_Game_Scene", SceneManager.GetActiveScene().name, "Scene did not load as expected.");

        Object.Destroy(gameObject);
    }
}
