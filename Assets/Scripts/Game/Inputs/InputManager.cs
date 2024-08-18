using System;
using Api.Inputs;
using UnityEngine;

namespace Game.Inputs
{
    public class InputManager : MonoBehaviour, IInputManager
    {
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnMouseLeftClick?.Invoke();
            }
            if (Input.GetMouseButton(0))
            {
                OnMouseLeftClick?.Invoke();
            }
        }

        public event Action OnMouseLeftClick;
    }
}