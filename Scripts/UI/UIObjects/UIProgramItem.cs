using System;
using System.Xml;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
using Utils;
using Yle.Network;
using Server;

namespace Yle.UI
{
    public class UIProgramItem : MonoBehaviour,IUIItem<ProgramItem>, IUIPoolObject
    {
        private ProgramItem source;
        public ProgramItem Source
        {
            get { return source; }
            set
            {
                source = value;
                OnSourceChanged();
            }
        }

        [SerializeField]
        private TMP_Text titleText;
        [SerializeField]
        private TMP_Text durationText;
        [SerializeField]
        private Image defaultIcon;
        [SerializeField]
        private RawImage mainIcon;

        public Image DefaultIcon
        {
            get { return defaultIcon; }
        }
        public RawImage MainIcon
        {
            get { return mainIcon; }
        }

        protected virtual void OnSourceChanged()
        {
            if (source == null)
                return;

            StringBuilder builder = new StringBuilder();
            foreach (var title in source.Titles)
            {
                builder.AppendLine($"[{title.Key}]: {title.Value}");
            }

            titleText.text = builder.ToString();
            if (!string.IsNullOrEmpty(source.Duration))
            {
                var durationSpan = XmlConvert.ToTimeSpan(source.Duration);
                durationText.text = $"{durationSpan.Hours}h {durationSpan.Minutes}m {durationSpan.Seconds}s";
            }
            durationText.gameObject.SetActive(!string.IsNullOrEmpty(source.Duration));
        }

        public virtual void OnIconLoaded(Texture2D texture)
        {
            if (texture)
            {
                defaultIcon.gameObject.SetActive(false);
                mainIcon.texture = texture;
                mainIcon.gameObject.SetActive(true);
            }
        }

        public virtual void ResetObject()
        {
            source = null;
            titleText.text = string.Empty;
            durationText.text = string.Empty;
            Destroy(mainIcon.texture);
            defaultIcon.gameObject.SetActive(true);
            mainIcon.gameObject.SetActive(false);
        }

        public virtual void OnPress()
        {
            var programPreviewWindow = UIMainController.Instance.GetWindow<UIProgramPreviewWindow>(UIConstants.WINDOW_PROGRAM_PREVIEW);
            if (programPreviewWindow)
            {
                programPreviewWindow.Source = Source;
                programPreviewWindow.OpenWindow();
            }
        }
    }
}