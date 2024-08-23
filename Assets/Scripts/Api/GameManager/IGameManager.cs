using System;
using UnityEngine;

namespace Api.GameManager
{
    public interface IGameManager
    {
        Vector2 PlayerPosition { get; }
    }
}