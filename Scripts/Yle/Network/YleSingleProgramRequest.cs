using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Server;

namespace Yle.Network
{
    [Serializable]
    public class YleSingleProgramRequest : BaseRequest
    {
        private string id;

        private string appKey;
        private string appId;

        public YleSingleProgramRequest(string appKey, string appId)
        {
            this.appKey = appKey;
            this.appId = appId;
        }

        public YleSingleProgramRequest SetId(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                this.id = id;
            }
            return this;
        }

        public void Build()
        {
            path = YleNetworkConstants.PATH_PROGRAM_ITEM;
            StringBuilder builder = new StringBuilder();
            if (!string.IsNullOrEmpty(id)) builder.AppendFormat(path, id);
            builder.Append($"appKey={appKey}&");
            builder.Append($"appId={appId}");

            path = builder.ToString();
        }
    }
}