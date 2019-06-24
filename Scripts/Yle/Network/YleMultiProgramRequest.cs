using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Server;
using Utils;
namespace Yle.Network
{
    [Serializable]
    public class YleMultiProgramRequest : BaseRequest
    {
        private string id = string.Empty;
        private string type = string.Empty;
        private string q = string.Empty;
        private string mediaobject = string.Empty;
        private string[] category = null;
        private string[] series = null;
        private string availability = string.Empty;
        private bool downloadable = false;
        private string language = string.Empty;
        private string region = string.Empty;
        private string service = string.Empty;
        private string publisher = string.Empty;
        private string[] contentprotection = null;
        private string order = string.Empty;
        private int limit = -1;
        private int offset = -1;

        private string appKey;
        private string appId;

        public YleMultiProgramRequest(string appKey, string appId)
        {
            this.appKey = appKey;
            this.appId = appId;
        }

        public YleMultiProgramRequest SetId(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                this.id = id;
            }
            return this;
        }

        public YleMultiProgramRequest SetType(string type)
        {
            if (YleType.IsValid(type))
            {
                this.type = type;
            }
            return this;
        }

        public YleMultiProgramRequest SetQ(string q)
        {
            if (!string.IsNullOrEmpty(q))
            {
                this.q = q;
            }
            return this;
        }

        public YleMultiProgramRequest SetMediaObject(string mediaobject)
        {
            if (YleMediaObjectType.IsValid(mediaobject))
            {
                this.mediaobject = mediaobject;
            }
            return this;
        }

        public YleMultiProgramRequest SetCategory(string[] category)
        {
            this.category = category;
            return this;
        }

        public YleMultiProgramRequest SetSeries(string[] series)
        {
            this.series = series;
            return this;
        }

        public YleMultiProgramRequest SetAvailability(string availability)
        {
            if (YleAvailabilityType.IsValid(availability))
            {
                this.availability = availability;
            }
            return this;
        }

        public YleMultiProgramRequest SetDownloadable(bool downloadable)
        {
            if (downloadable)
            {
                this.downloadable = downloadable;
            }
            return this;
        }

        public YleMultiProgramRequest SetLanguage(string language)
        {
            if (YleLanguage.IsValid(language))
            {
                this.language = language;
            }
            return this;
        }

        public YleMultiProgramRequest SetRegion(string region)
        {
            if (YleLanguage.IsValid(region))
            {
                this.region = region;
            }
            return this;
        }

        public YleMultiProgramRequest SetService(string service)
        {
            this.service = service;
            return this;
        }

        public YleMultiProgramRequest SetPublisher(string publisher)
        {
            this.publisher = publisher;
            return this;
        }

        public YleMultiProgramRequest SetContentProtection(string[] contentprotection)
        {
            this.contentprotection = contentprotection;
            return this;
        }

        public YleMultiProgramRequest SetOrder(string order)
        {
            if (YleOrder.IsValid(order))
            {
                this.order = order;
            }
            return this;
        }

        public YleMultiProgramRequest SetLimit(int limit)
        {
            if (limit > 0)
            {
                this.limit = limit;
            }
            return this;
        }

        public YleMultiProgramRequest SetOffset(int offset)
        {
            if (offset > 0)
            {
                this.offset = offset;
            }
            return this;
        }

        public void Build()
        {
            path = YleNetworkConstants.PATH_PROGRAM_ITEMS;
            StringBuilder builder = new StringBuilder();
            builder.Append(path);
            if (!string.IsNullOrEmpty(id)) builder.Append($"id={id}&");
            if (!string.IsNullOrEmpty(type)) builder.Append($"type={type}&");
            if (!string.IsNullOrEmpty(q)) builder.Append($"q={q}&");
            if (!string.IsNullOrEmpty(mediaobject)) builder.Append($"mediaobject={mediaobject}&");
            if (!string.IsNullOrEmpty(availability)) builder.Append($"availability={availability}&");
            if (downloadable) builder.Append($"downloadable={downloadable}&");
            if (!string.IsNullOrEmpty(language)) builder.Append($"language={language}&");
            if (!string.IsNullOrEmpty(region)) builder.Append($"region={region}&");
            if (!string.IsNullOrEmpty(service)) builder.Append($"service={service}&");
            if (!string.IsNullOrEmpty(publisher)) builder.Append($"publisher={publisher}&");
            if (!string.IsNullOrEmpty(order)) builder.Append($"order={order}&");
            if (limit != -1) builder.Append($"limit={limit}&");
            if (offset != -1) builder.Append($"offset={offset}&");
            if (category.TryConcatArray(",", out string categoryStr)) builder.Append($"category={categoryStr}&");
            if (series.TryConcatArray(",", out string seriesStr)) builder.Append($"series={seriesStr}&");
            if (contentprotection.TryConcatArray(",", out string contentprotectionStr)) builder.Append($"contentprotection={contentprotectionStr}&");

            builder.Append($"app_key={appKey}&");
            builder.Append($"app_id={appId}");

            path = builder.ToString();
        }
    }
}