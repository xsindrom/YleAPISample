using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Server
{
    public enum Status
    {
        Error = -1,
        OK = 200,
        BadRequest = 400,
        NotFound = 404
    }

    [Serializable]
    public class BaseResponse: IJsonSerializeObject<BaseResponse>
    {
        public Status status;

        public virtual string ToJson()
        {
            return JsonUtility.ToJson(this);
        }

        public BaseResponse FromJson(string json)
        {
            return JsonUtility.FromJson<BaseResponse>(json);
        }
    }
}