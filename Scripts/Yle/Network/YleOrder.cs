using System;
using System.Collections;
using System.Collections.Generic;
namespace Yle.Network
{
    public class YleOrder
    {
        public const string ORDER_PLAYCOUNT_6H_ASC              = "playcount.6h:asc";
        public const string ORDER_PLAYCOUNT_6H_DESC             = "playcount.6h:desc";
        public const string ORDER_PLAYCOUNT_24H_ASC             = "playcount.24h:asc";
        public const string ORDER_PLAYCOUNT_24H_DESC            = "playcount.24h:desc";
        public const string ORDER_PLAYCOUNT_WEEK_ASC            = "playcount.week:asc";
        public const string ORDER_PLAYCOUNT_WEEK_DESC           = "playcount.week:desc";
        public const string ORDER_PLAYCOUNT_MONTH_ASC           = "playcount.month:asc";
        public const string ORDER_PLAYCOUNT_MONTH_DESC          = "playcount.month:desc";
        public const string ORDER_PUBLICATION_STARTTIME_ASC     = "publication.starttime:asc";
        public const string ORDER_PUBLICATION_STARTTIME_DESC    = "publication.starttime:desc";
        public const string ORDER_PUBLICATION_ENDTTIME_ASC      = "publication.endtime:asc";
        public const string ORDER_PUBLICATION_ENDTIME_DESC      = "publication.endtime:desc";
        public const string ORDER_UPDATED_ASC                   = "updated:asc";
        public const string ORDER_UPDATED_DESC                  = "updated:desc";

        private static readonly string[] orders = new string[]
        {
            ORDER_PLAYCOUNT_6H_ASC,
            ORDER_PLAYCOUNT_6H_DESC,
            ORDER_PLAYCOUNT_24H_ASC,
            ORDER_PLAYCOUNT_24H_DESC,
            ORDER_PLAYCOUNT_WEEK_ASC,
            ORDER_PLAYCOUNT_WEEK_DESC,
            ORDER_PLAYCOUNT_MONTH_ASC,
            ORDER_PLAYCOUNT_MONTH_DESC,
            ORDER_PUBLICATION_STARTTIME_ASC,
            ORDER_PUBLICATION_STARTTIME_DESC,
            ORDER_PUBLICATION_ENDTTIME_ASC,
            ORDER_PUBLICATION_ENDTIME_DESC,
            ORDER_UPDATED_ASC,
            ORDER_UPDATED_DESC
        };

        public static bool IsValid(string order)
        {
            return Array.Exists(orders, x => x == order);
        }
    }
}