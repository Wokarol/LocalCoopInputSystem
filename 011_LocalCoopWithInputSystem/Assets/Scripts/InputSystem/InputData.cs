using UnityEngine;

namespace Wokarol.InputSystem
{
    public abstract class InputData : MonoBehaviour
    {
        public Vector2 Movement { get; protected set; } = Vector2.zero;
    }
}