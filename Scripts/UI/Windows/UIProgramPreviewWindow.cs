using System;
using System.Xml;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Server;
using Yle.Network;

namespace Yle.UI
{
    public class UIProgramPreviewWindow : UIBaseWindow, IUIItem<ProgramItem>
    {
        private ProgramItem source;
        public ProgramItem Source
        {
            get { return source; }
            set { source = value; }
        }

        [SerializeField]
        private Image defaultIcon;
        [SerializeField]
        private RawImage mainIcon;
        [SerializeField]
        private TMP_Text titleText;
        [SerializeField]
        private TMP_Text creatorText;
        [SerializeField]
        private TMP_Text descriptionText;
        [SerializeField]
        private TMP_Text durationText;

        public override void OpenWindow()
        {
            if (source == null)
                return;

            StringBuilder builder = new StringBuilder();
            foreach (var title in source.Titles)
            {
                builder.AppendLine($"[{title.Key}]: {title.Value}");
            }
            titleText.text = builder.ToString();
            builder.Clear();

            foreach (var description in source.Descriptions)
            {
                builder.AppendLine($"[{description.Key}]: {description.Value}");
            }
            descriptionText.text = builder.ToString();
            builder.Clear();

            for(int i = 0; i < source.Creators.Length;i++)
            {
                builder.Append(source.Creators[i]);
                if(i < source.Creators.Length - 1)
                {
                    builder.Append(", ");
                }
            }
            creatorText.text = builder.ToString();
            builder.Clear();

            var durationSpan = XmlConvert.ToTimeSpan(source.Duration);
            durationText.text = $"{durationSpan.Hours}h {durationSpan.Minutes}m {durationSpan.Seconds}s";

            var path = string.Format(YleNetworkConstants.PATH_PROGRAM_IMAGE_WITH_TRANSFORMATION,
                                    mainIcon.rectTransform.sizeDelta.x,
                                    mainIcon.rectTransform.sizeDelta.y,
                                    source.ImageId,
                                    YleImageFormat.FORMAT_JPG);
            ServerAPI.Instance.GetImage(path, texture => OnIconLoaded(texture));
            base.OpenWindow();
        }

        public void OnIconLoaded(Texture2D texture)
        {
            if (texture)
            {
                defaultIcon.gameObject.SetActive(false);
                mainIcon.texture = texture;
                mainIcon.gameObject.SetActive(true);
            }
        }

        public override void CloseWindow()
        {
            base.CloseWindow();
            Destroy(mainIcon.texture);
            mainIcon.gameObject.SetActive(false);
            defaultIcon.gameObject.SetActive(true);
            titleText.text = string.Empty;
            descriptionText.text = string.Empty;
            creatorText.text = string.Empty;
            durationText.text = string.Empty;
            source = null;
        }
    }
}