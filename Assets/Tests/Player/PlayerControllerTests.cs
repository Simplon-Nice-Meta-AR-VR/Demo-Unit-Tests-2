using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using NSubstitute;

public class PlayerControllerTests
{
    private GameObject player;
    private PlayerController playerController;
    private IMove movementMechanic;
    private IJump jumpMechanic;

    [SetUp]
    public void Setup()
    {
        // Arrange
        player = new GameObject();
        playerController = player.AddComponent<PlayerController>();
        movementMechanic = Substitute.For<IMove>();
        jumpMechanic = Substitute.For<IJump>();
        playerController.Initialize(movementMechanic, jumpMechanic);
    }

    [TearDown]
    public void Teardown()
    {
        Object.Destroy(player);
    }

    [Test]
    public void ControllerMoveCallsMoveMechanic()
    {
        // Act
        playerController.Move(1f);

        // Assert
        movementMechanic.Received(1).Move(1f);
    }

    [Test]
    public void ControllerJumpCallsJumpMechanic()
    {
        // Act
        playerController.Jump();

        // Assert
        jumpMechanic.Received(1).Jump();
    }
}
