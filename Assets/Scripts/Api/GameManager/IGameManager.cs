using System;
using UnityEngine;

namespace Api.GameManager
{
    public interface IGameManager
    {
        Transform GetPlayerTransform();
        event Action<Transform> OnPlayerTransformChanged;
    }
}