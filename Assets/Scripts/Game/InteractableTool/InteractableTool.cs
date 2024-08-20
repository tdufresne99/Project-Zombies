using System;
using Api;
using Api.InteractableTool;
using UnityEngine;

namespace Game.InteractableTool
{
    public class InteractableTool : IInteractableTool
    {
        private readonly Camera _mainCamera;

        public InteractableTool()
        {
            GameApi.InputManager.OnMouseLeftClick += Interact;
            _mainCamera = GameApi.MainCamera;
        }

        private void Interact()
        {
            Vector2 mousePos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            var hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider == null) return;

            if (hit.collider.gameObject.TryGetComponent<IInteractableComponent>(out var interactableComponent))
            {
                interactableComponent.OnInteract();
            }
        }
    }
}