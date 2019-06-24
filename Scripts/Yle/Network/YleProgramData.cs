using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yle.Network
{
    [Serializable]
    public class YleFormatData
    {
        public string inScheme;
        public string key;
        public string type;
    }
    [Serializable]
    public class YleAudioData
    {
        public YleFormatData[] format;
        public string[] language;
        public string type;
    }

    [Serializable]
    public class YleContentRaitingData
    {
        public string[] reason;
        public Dictionary<string, string> title;
    }
    [Serializable]
    public class YleImageData
    {
        public bool available;
        public string id;
        public string type;
    }
    [Serializable]
    public class YleInteractionData
    {
        public Dictionary<string, string> title;
        public string type;
        public string url;
    }

    [Serializable]
    public class YleBroaderData
    {
        public string id;
    }
    [Serializable]
    public class YleNotationData
    {
        public string value;
        public string valueType;
    }

    [Serializable]
    public class YleSubjectData
    {
        public YleBroaderData broader;
        public string id;
        public string inScheme;
        public string key;
        public Dictionary<string, string> title;
        public string type;
        public YleNotationData[] notation;
    }
    [Serializable]
    public class YleCreatorData
    {
        public string name;
        public string type;
    }
    [Serializable]
    public class YlePartOfSeriesData
    {
        public Dictionary<string, string> availabilityDescription;
        public string[] countryOfOrigin;
        public YleImageData coverImage;
        public YleCreatorData[] creator;
        public Dictionary<string, string> description;
        public string id;
        public YleImageData image;
        public YleInteractionData[] interactions;
        public YleSubjectData[] subject;
        public Dictionary<string, string> title;
        public string type;
    }

    [Serializable]
    public class YleProtectionContentData
    {
        public string id;
        public string type;
    }

    [Serializable]
    public class YleMediaData
    {
        public bool available;
        public YleProtectionContentData[] contentProtection;
        public bool downloadable;
        public string duration;
        public string id;
        public string type;

    }
    [Serializable]
    public class YleServiceData
    {
        public string id;
    }
    [Serializable]
    public class YlePublisherData
    {
        public string id;
    }
    [Serializable]
    public class YlePublicationEventData
    {
        public string duration;
        public string endTime;
        public string id;
        public YleMediaData media;
        public YlePublisherData[] publisher;
        public string region;
        public YleServiceData service;
        public string startTime;
        public string temporalStatus;
        public string type;
    }
    [Serializable]
    public class YleVideoData
    {
        public YleFormatData[] format;
        public string[] language;
        public string type;
    }
    [Serializable]
    public class YleSubtitleData
    {
        public string[] language;
        public string type;
    }
    [Serializable]
    public class YleProgramData
    {
        public string[] alternativeId;
        public YleAudioData[] audio;
        public string collection;
        public YleContentRaitingData contentRaiting;
        public string[] countryOfOrigin;
        public YleCreatorData[] creator;
        public Dictionary<string, string> description;
        public string duration;
        public string id;
        public YleImageData image;
        public string indexDataModified;
        public Dictionary<string, string> itemTitle;
        public Dictionary<string, string> originalTitle;
        public YlePartOfSeriesData partOfSeries;
        public YlePublicationEventData[] publicationEvent;
        public YleSubjectData[] subject;
        public YleSubtitleData[] subtitling;
        public Dictionary<string, string> title;
        public string type;
        public string typeCreative;
        public string typeMedia;
        public YleVideoData video;
    }
}