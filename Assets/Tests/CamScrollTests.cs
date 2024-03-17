using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;
using System;

public class CamScrollTests
{
    private GameObject cameraGameObject;
    private Camera myCamera;
    private CamScroll camScroll;

    // Setup before each test
    public void Setup()
    {
        cameraGameObject = new GameObject("TestCamera");
        myCamera = cameraGameObject.AddComponent<Camera>();
        camScroll = cameraGameObject.AddComponent<CamScroll>();
        camScroll.mycam = myCamera;
    }

    // Teardown after each test
    public void Teardown()
    {
        Object.Destroy(cameraGameObject);
    }

    // Test if the camera moves right when directed
    public IEnumerator CameraMovesRight()
    {
        // Save the initial position
        var initialPosition = myCamera.transform.position;

        // Move to the right
        camScroll.Btn_Scroll_R();
        yield return null; // Wait for one frame
        camScroll.Update();

        // Assert that the camera has moved to the right
        Assert.IsTrue(myCamera.transform.position.x > initialPosition.x, "Camera did not move to the right.");
    }

    // Test if the camera stays within set boundaries
    public IEnumerator CameraStaysWithinBoundaries()
    {
        // Attempt to move beyond the boundary
        camScroll.dir_x = 1; // Move right
        for (int i = 0; i < 100; i++)
        {
            camScroll.Update();
            yield return null;
        }

        // Assert that the camera's position is within the boundaries
        Assert.IsTrue(myCamera.transform.position.x <= 30, "Camera moved beyond the right boundary.");
        Assert.IsTrue(myCamera.transform.position.x >= -30, "Camera moved beyond the left boundary.");
    }
}
