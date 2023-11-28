using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerMovementTests
{
    private GameObject player;
    private Rigidbody2D rb2d;
    private PlayerMovement playerMovement;
    private float initialPosition;

    [SetUp]
    public void Setup()
    {
        // Arrange
        player = new GameObject();
        rb2d = player.AddComponent<Rigidbody2D>();
        playerMovement = player.AddComponent<PlayerMovement>();
        playerMovement.Initialize(rb2d);
        initialPosition = player.transform.position.x;
    }

    [TearDown]
    public void Teardown()
    {
        Object.Destroy(player);
    }

    [UnityTest]
    public IEnumerator PlayerMovesToTheLeftWithNegativeDirection()
    {
        // Act
        playerMovement.Move(-1f);
        yield return new WaitForSeconds(0.1f);

        // Assert
        Assert.IsTrue(player.transform.position.x < initialPosition);
        Assert.That(player.transform.position.x, Is.LessThan(initialPosition));
    }

    [UnityTest]
    public IEnumerator PlayerDoesntMoveWithZeroDirection()
    {
        // Act
        playerMovement.Move(0f);
        yield return new WaitForSeconds(0.1f);

        // Assert
        Assert.AreEqual(initialPosition, player.transform.position.x);
        Assert.That(player.transform.position.x, Is.EqualTo(initialPosition));
    }

    [UnityTest]
    public IEnumerator PlayerMovesToTheRightWithPositiveDirection()
    {
        // Act
        playerMovement.Move(1f);
        yield return new WaitForSeconds(0.1f);

        // Assert
        Assert.IsTrue(player.transform.position.x > initialPosition);
        Assert.That(player.transform.position.x, Is.GreaterThan(initialPosition));
    }
}
