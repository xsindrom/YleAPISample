using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Utils;
using Yle.Network;

namespace Yle.UI
{
    public class UISearchWindow : UIBaseWindow
    {
        [SerializeField]
        private TMP_InputField queryInput;
        [SerializeField]
        private int uiProgramsDisplayCount;
        [SerializeField]
        private ScrollRect uiProgramsScroll;
        [SerializeField]
        private UIProgramItemsPool programItemsPool;
       
        private string cachedQuery = string.Empty;
        private bool lockGetProgramItems = false;
        [SerializeField]
        private CoroutineManager iconLoadManager;

        public override void Init()
        {
            uiProgramsScroll.onValueChanged.AddListener(OnProgramsScroll);
            YleController.Instance.OnProgramItemsReady += OnProgramsReady;
        }

        public void OnSearchButtonClick()
        {
            programItemsPool.Clear();
            if(uiProgramsScroll.vertical)
                uiProgramsScroll.verticalNormalizedPosition = 1.0f;

            if (uiProgramsScroll.horizontal)
                uiProgramsScroll.horizontalNormalizedPosition = 0.0f;

            iconLoadManager.Stop();
            iconLoadManager.Run(uiProgramsDisplayCount);

            cachedQuery = queryInput.text;
            lockGetProgramItems = true;
            YleController.Instance.GetProgramItems(queryInput.text, uiProgramsDisplayCount, 0);
        }

        public void OnProgramsScroll(Vector2 position)
        {
            if (lockGetProgramItems)
                return;

            var roundVerticalPosition = -1.0f;
            var roundHorizontalPosition = -1.0f;

            if (uiProgramsScroll.vertical)
                roundVerticalPosition = Mathf.Round(position.y * 10) / 10;

            if (uiProgramsScroll.horizontal)
                roundHorizontalPosition = Mathf.Round(position.x * 10) / 10;


            if (roundVerticalPosition == 0 || roundHorizontalPosition == 1 && programItemsPool.BusyCount >= uiProgramsDisplayCount)
            {
                lockGetProgramItems = true;
                YleController.Instance.GetProgramItems(cachedQuery, uiProgramsDisplayCount, programItemsPool.BusyCount+1);
            }
        }

        public void OnProgramsReady(List<ProgramItem> programItems)
        {
            if (lockGetProgramItems)
            {
                for (int i = 0; i < programItems.Count; i++)
                {
                    var programItem = programItems[i];
                    var uiProgramItem = programItemsPool.GetOrInstantiateObject();
                    uiProgramItem.Source = programItem;
                    var path = string.Format(YleNetworkConstants.PATH_PROGRAM_IMAGE_WITH_TRANSFORMATION,
                                             uiProgramItem.MainIcon.rectTransform.sizeDelta.x,
                                             uiProgramItem.MainIcon.rectTransform.sizeDelta.y,
                                             uiProgramItem.Source.ImageId, YleImageFormat.FORMAT_PNG);
                    iconLoadManager.AddCoroutine(Server.ServerAPI.Instance.GetImageRoutine(path, texture => uiProgramItem.OnIconLoaded(texture)));
                }
                LayoutRebuilder.ForceRebuildLayoutImmediate(uiProgramsScroll.content);
                lockGetProgramItems = false;
            }
            
        }
    }
}