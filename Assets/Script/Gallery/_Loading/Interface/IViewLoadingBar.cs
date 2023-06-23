using System;
using System.Collections;
using UnityEngine;

namespace Assets.Script.Gallery._Loading
{
    public interface IViewLoadingBar
    {
        public void Update();
        public void StartLoadingBallastCoroutine(IEnumerator ballastLoad);
    }
}