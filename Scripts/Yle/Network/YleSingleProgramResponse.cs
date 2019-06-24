using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Server;
using Newtonsoft.Json;
using Utils;
namespace Yle.Network
{
    [Serializable]
    public class YleSingleProgramResponse : BaseResponse, IJsonSerializeObject<YleSingleProgramResponse>
    {
        [Serializable]
        public class YleMetaData
        {
            public string id;
        }

        public string apiVersion;
        public YleProgramData data;
        public YleMetaData meta;

        public override string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public new YleSingleProgramResponse FromJson(string json)
        {
            return JsonConvert.DeserializeObject<YleSingleProgramResponse>(json);
        }
    }
}