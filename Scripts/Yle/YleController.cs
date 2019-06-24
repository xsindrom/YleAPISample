using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Yle.Network;
using Server;
namespace Yle
{
    public class YleController : MonoSingleton<YleController>
    {
        private YleSettings settings;
        public YleSettings Settings
        {
            get
            {
                if (!settings)
                {
                    settings = ResourceManager.GetResource<YleSettings>(YleConstants.PATH_SETTINGS);
                }
                return settings;
            }
        }

        private List<ProgramItem> cachedProgramItems = new List<ProgramItem>();
        public List<ProgramItem> CachedProgramItems
        {
            get { return cachedProgramItems; }
        }

        public event Action<List<ProgramItem>> OnProgramItemsReady;

        public void GetProgramItems(string query, int limit, int offset)
        {
            if (string.IsNullOrEmpty(query))
                return;

            var request = new YleMultiProgramRequest(Settings.AppKey, Settings.AppId)
                            .SetQ(query)
                            .SetType(YleType.TYPE_PROGRAM)
                            .SetLimit(limit)
                            .SetOffset(offset);
            request.Build();
            ServerAPI.Instance.Post<YleMultiProgramRequest, YleMultiProgramResponse>(request, OnGetProgramItems, UnityWebRequest.kHttpVerbGET);
        }

        private void OnGetProgramItems(YleMultiProgramResponse response)
        {
            if (response.status == Status.OK)
            {
                CachedProgramItems.Clear();
                var programsData = response.data;
                for (int i = 0; i < programsData.Length; i++)
                {
                    var programData = programsData[i];
                    var programItem = new ProgramItem()
                    {
                        Id = programData.id,
                        Titles = programData.title,
                        Duration = programData.duration,
                        Descriptions = programData.description,
                        ImageId = programData.image.available ? programData.image.id : string.Empty,
                        Creators = programData.creator.Select(x => $"{x.name}({x.type})").ToArray()
                    };
                    CachedProgramItems.Add(programItem);
                }
                OnProgramItemsReady?.Invoke(CachedProgramItems);
            }
        }
    }
}