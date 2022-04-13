using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCharacter : NonPlayerCharacter {
    [SerializeField] private Animator monsterAnim;
    private static readonly int IsMoving = Animator.StringToHash("isMoving");
    private static readonly int IsDown = Animator.StringToHash("isDown");

    private void Update() {
        if (PathfindingAI.desiredVelocity != Vector3.zero) {
            monsterAnim.SetBool(IsMoving, true);
            if (PathfindingAI.desiredVelocity.y >= 0.01f) {
                monsterAnim.SetBool(IsDown, false);
            }
            else {
                monsterAnim.SetBool(IsDown, true);
            }
        }
        else {
            monsterAnim.SetBool(IsMoving, false);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            Debug.Log("Ouch!");
        }
    }
}