using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public class CoroutineManager : MonoBehaviour
    {
        [SerializeField]
        private int activeCoroutinesMaxCount;

        private List<IEnumerator> waitingRoutines = new List<IEnumerator>();
        private List<IEnumerator> activeRoutines = new List<IEnumerator>();

        private bool isRunning = false;
        private Coroutine mainCoroutine;
        private List<Coroutine> runningRoutines = new List<Coroutine>();

        public void AddCoroutine(IEnumerator routine)
        {
            waitingRoutines.Add(routine);
        }

        public void Run(int activeCoroutinesMaxCount = -1)
        {
            this.activeCoroutinesMaxCount = activeCoroutinesMaxCount == -1 ? this.activeCoroutinesMaxCount : activeCoroutinesMaxCount;
            if (!isRunning)
            {
                isRunning = true;
                mainCoroutine = StartCoroutine(RunRoutine());
            }
        }

        public void Stop()
        {
            if (isRunning)
            {
                StopCoroutine(mainCoroutine);
                for(int i = 0; i < runningRoutines.Count; i++)
                {
                    StopCoroutine(runningRoutines[i]);
                }
                waitingRoutines.Clear();
                activeRoutines.Clear();
                runningRoutines.Clear();
                isRunning = false;
            }
        }

        private IEnumerator DoRoutine(IEnumerator routine)
        {
            activeRoutines.Add(routine);
            yield return StartCoroutine(routine);
            activeRoutines.Remove(routine);
        }

        private IEnumerator RunRoutine()
        {
            while (true)
            {
                while (activeRoutines.Count == activeCoroutinesMaxCount)
                    yield return null;

                if (waitingRoutines.Count > 0)
                {
                    var waitingRoutine = waitingRoutines[waitingRoutines.Count - 1];
                    waitingRoutines.RemoveAt(waitingRoutines.Count - 1);
                    runningRoutines.Add(StartCoroutine(DoRoutine(waitingRoutine)));
                }
                yield return null;
            }
        }
    }
}