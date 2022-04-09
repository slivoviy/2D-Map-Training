using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private PlayerMovement playerMovementInput;
    private Vector2 playerVelocity;
    [SerializeField]
    private float playerSpeed = 2.0f;


    private void Awake() {
        playerMovementInput = new PlayerMovement();
    }

    private void OnEnable() {
        playerMovementInput.Enable();
    }

    private void OnDisable() {
        playerMovementInput.Disable();
    }

    void Update() {
        Vector2 movementInput = playerMovementInput.Player.Movement.ReadValue<Vector2>();
        transform.Translate(movementInput * (Time.deltaTime * playerSpeed));
    }
}