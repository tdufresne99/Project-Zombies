using Api.GameManager;
using Api.Inputs;
using Api.InteractableTool;
using Game.Inputs;
using UnityEngine;

namespace Api
{
    public class GameApi : MonoBehaviour
    {
        public static IInputManager InputManager { get; private set; }
        public static IGameManager GameManager { get; private set; }
        public static Camera MainCamera { get; private set; }
        public static IInteractableTool InteractableTool { get; private set; }
        
        private static GameApi _gameApi;
        
        private void Awake()
        {
            if (_gameApi == null) _gameApi = this;
            else Destroy(gameObject);

            var go = gameObject;
            
            InputManager = go.AddComponent<InputManager>();
            GameManager = go.GetComponent<Game.GameManager.GameManager>();
            if(GameManager == null) Debug.LogWarning("Don't forget to attach GameManager component to GameApi GameObject.");
            
            MainCamera = Camera.main;
            
            InteractableTool = new Game.InteractableTool.InteractableTool();
            
            DontDestroyOnLoad(go);
        }
    }
}