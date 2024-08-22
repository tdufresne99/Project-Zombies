using System;
using Api;
using Api.Inputs.InputUsers;
using Api.InteractableComponents;
using Game.Inputs;
using UnityEngine;

namespace Game.InteractableTool
{
    public class InteractableTool : MonoBehaviour, IInteractableTool, IInputUser
    {
        private void Update()
        {
            if (InputManager.Instance.InteractInput) UseInput();
        }

        public bool UseInput()
        {
            Vector2 mousePos = GameApi.MainCamera.ScreenToWorldPoint(Input.mousePosition);
            var hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (!hit.collider) return false;

            if (hit.collider.gameObject.TryGetComponent<IInteractable>(out var interactableComponent))
            {
                interactableComponent.OnInteract();
            }

            return true;
        }
    }
}