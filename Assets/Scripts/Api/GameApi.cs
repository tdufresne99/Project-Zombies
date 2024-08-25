using Api.GameManager;
using Api.Inputs;
using Api.InteractableComponents;
using Api.Navigation;
using Game.Inputs;
using Game.InteractableComponents;
using UnityEngine;

namespace Api
{
    public class GameApi : MonoBehaviour
    {
        public static IInputManager InputManager { get; private set; }
        public static INavigationSurfaceManager NavigationSurfaceManager { get; private set; }
        public static IGameManager GameManager { get; private set; }
        public static Camera MainCamera { get; private set; }
        public static IInteractableTool InteractableTool { get; private set; }
        private string _interactableLayer;
        
        private static GameApi _gameApi;
        
        private void Awake()
        {
            if (_gameApi == null) _gameApi = this;
            else Destroy(gameObject);

            var go = gameObject;
            MainCamera = Camera.main;
            
            InputManager = go.GetComponentInChildren<IInputManager>();
            NavigationSurfaceManager = go.GetComponentInChildren<INavigationSurfaceManager>();
            if(NavigationSurfaceManager == null) Debug.LogWarning("Don't forget to add NavigationSurface in GameApi children.");
            GameManager = go.GetComponent<IGameManager>();
            if(GameManager == null) Debug.LogWarning("Don't forget to attach GameManager component to GameApi GameObject.");
            InteractableTool = go.AddComponent<InteractableTool>();
            
            DontDestroyOnLoad(go);
        }
    }
}