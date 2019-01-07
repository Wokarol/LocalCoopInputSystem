using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol.MovementSystem
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class MovementController2D : MonoBehaviour, IMovementController2D
    {
        new Rigidbody2D rigidbody;
        private void Awake() {
            rigidbody = GetComponent<Rigidbody2D>();
        }

        public void SetVelocity(Vector2 movement) {
            rigidbody.velocity = movement;
        }
    }
}
