using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wokarol.InputSystem;

namespace Wokarol.MovementSystem
{
    [RequireComponent(typeof(IMovementController2D))]
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] InputData input = null;
        [SerializeField] float movingSpeed = 10;

        IMovementController2D movementController2D;

        private void OnValidate() {
            if (!input) input = GetComponent<InputData>();
        }

        private void Awake() {
            movementController2D = GetComponent<IMovementController2D>();
        }

        private void FixedUpdate() {
            movementController2D.SetVelocity(input.Movement * movingSpeed);
        }
    } 
}
