using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using NSubstitute;
using UnityEngine;
using UnityEngine.TestTools;
using NSubstitute.ReceivedExtensions;

public class PlayerJumpTests
{
    private GameObject player;
    private Rigidbody2D rb2d;
    private PlayerJump playerJump;
    private IGrounded grounded;

    [SetUp]
    public void Setup()
    {
        // Arrange
        player = new GameObject();
        rb2d = player.AddComponent<Rigidbody2D>();
        playerJump = player.AddComponent<PlayerJump>();
        grounded = Substitute.For<IGrounded>();
        playerJump.Initialize(rb2d, grounded);
    }

    [TearDown]
    public void Teardown()
    {
        Object.Destroy(player);
    }

    [Test]
    public void JumpFunctionCallsGroundedCheck()
    {
        // Act
        playerJump.Jump();

        // Assert
        _ = grounded.Received(1).IsGrounded;
    }

    [UnityTest]
    public IEnumerator PlayerJumpsWhenGrounded()
    {
        // Arrange
        grounded.IsGrounded.Returns(true);

        // Act
        playerJump.Jump();
        yield return new WaitForSeconds(0.1f);

        // Assert
        Assert.IsTrue(rb2d.velocity.y > 0f);
        Assert.That(rb2d.velocity.y, Is.GreaterThan(0f));
    }

    [UnityTest]
    public IEnumerator PlayerDoesntJumpWhenNotGrounded()
    {
        // Arrange
        grounded.IsGrounded.Returns(false);

        // Act
        playerJump.Jump();
        yield return new WaitForSeconds(0.1f);

        // Assert
        Assert.IsTrue(rb2d.velocity.y <= 0f);
        Assert.That(rb2d.velocity.y, Is.LessThanOrEqualTo(0f));
    }
}
