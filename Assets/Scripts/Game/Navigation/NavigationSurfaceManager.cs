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
        private Coroutine _waitAnimationCor;

        private void OnDestroy()
        {
            StopAllCoroutines();
            _waitAnimationCor = null;
        }

        public void BakeSurface()
        {
            navMeshSurface.BuildNavMeshAsync();
            // if(_waitAnimationCor != null) StopCoroutine(_waitAnimationCor);
            // _waitAnimationCor = StartCoroutine(WaitAnimationDelay(1.0f));
        }

        private void DoBakeSurface()
        {
            navMeshSurface.BuildNavMeshAsync();
        }

        private IEnumerator WaitAnimationDelay(float delay)
        {
            yield return new WaitForSecondsRealtime(delay);
            DoBakeSurface();
        }
    }
}