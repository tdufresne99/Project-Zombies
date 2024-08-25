using System;
using System.Collections;
using Api.Navigation;
using NavMeshPlus.Components;
using UnityEngine;

namespace Game.Navigation
{
    public class NavigationSurfaceManagerManager : MonoBehaviour, INavigationSurfaceManager
    {
        [SerializeField] private NavMeshSurface navMeshSurface;

        public void BakeSurface()
        {
            navMeshSurface.BuildNavMesh();
        }
    }
}