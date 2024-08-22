using System.Collections.Generic;
using Api;
using Api.Inputs;
using Api.Inputs.InputUsers;
using Api.InteractableComponents;
using UnityEngine;

namespace Game.Inputs.InputHandlers
{
    public class LeftClickHandler : ILeftClickHandler
    {
        public void HandleInput()
        {
            Vector2 mousePos = GameApi.MainCamera.ScreenToWorldPoint(Input.mousePosition);
            var hits = Physics2D.RaycastAll(mousePos, Vector2.zero);

            foreach (var hit in hits)
            {
                if (hit.collider == null) continue;
                if (hit.collider.gameObject.TryGetComponent<IInteractable>(out var interactable))
                {
                    if (interactable.OnInteract()) continue;
                }
                
                // if (hit.collider.gameObject.TryGetComponent<IMova>(out var interactable))
                // {
                //     if (interactable.OnInteract()) continue;
                // }
            }
        }
    }
}