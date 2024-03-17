using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;
using System;

public class ZombieControlTests
{
    public IEnumerator TestZombieStateTransition()
    {
        // Create a GameObject and add the ZombieControl component
        var zombieGameObject = new GameObject("TestZombie");
        var zombieControl = zombieGameObject.AddComponent<ZombieControl>();

        // Initially, the zombie should be in the init state
        Assert.AreEqual(ActionType.init, zombieControl.myact, "Zombie did not start in init state.");

        // Simulate time to allow state transition from init to idle
        yield return new WaitForSeconds(0.1f); // Assuming the transition happens quickly
        Assert.AreEqual(ActionType.idle, zombieControl.myact, "Zombie did not transition to idle state.");

        // Simulate more time to allow transition to walk
        yield return new WaitForSeconds(1.6f); // Assuming it takes 1.5 seconds to transition to walk
        Assert.AreEqual(ActionType.walk, zombieControl.myact, "Zombie did not transition to walk state.");

        // Cleanup
        Object.Destroy(zombieGameObject);
    }
    public IEnumerator TestZombieMovement()
    {
        // Create a GameObject and add the ZombieControl component
        var zombieGameObject = new GameObject("TestZombie");
        var zombieControl = zombieGameObject.AddComponent<ZombieControl>();

        // Set zombie to walk state directly for testing purposes
        zombieControl.myact = ActionType.walk;

        Vector3 initialPosition = zombieGameObject.transform.position;

        // Simulate time to allow the zombie to move
        yield return new WaitForSeconds(1); // Wait a second to ensure movement

        Vector3 newPosition = zombieGameObject.transform.position;

        // Check if the zombie has moved from its initial position
        Assert.AreNotEqual(initialPosition, newPosition, "Zombie did not move.");

        // Cleanup
        Object.Destroy(zombieGameObject);
    }
}
