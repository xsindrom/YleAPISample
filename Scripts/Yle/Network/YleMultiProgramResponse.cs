using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Server;
using Utils;
using Newtonsoft.Json;

namespace Yle.Network
{
    [Serializable]
    public class YleMultiProgramResponse : BaseResponse, IJsonSerializeObject<YleMultiProgramResponse>
    {
        [Serializable]
        public class YleMetaData
        {
            public int clip;
            public int count;
            public string limit;
            public string offset;
            public int program;
            public string q;
        }

        public string apiVersion;
        public YleProgramData[] data;
        public YleMetaData meta;

        public override string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public new YleMultiProgramResponse FromJson(string json)
        {
            return JsonConvert.DeserializeObject<YleMultiProgramResponse>(json);
        }
    }
}