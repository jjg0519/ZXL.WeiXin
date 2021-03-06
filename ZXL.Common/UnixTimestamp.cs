﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZXL.Common
{
    /// <summary>
    /// Unix 时间戳
    /// </summary>
    public class UnixTimestamp
    {
        private static readonly DateTime unixBase = new DateTime(1970, 1, 1, 0, 0, 0);

        private long value;

        public UnixTimestamp(long value)
        {
            this.value = value;
        }

        /// <summary>
        /// 现在时刻的 Unix 时间戳
        /// </summary>
        public static UnixTimestamp Now
        {
            get
            {
                return new UnixTimestamp(Parse(DateTime.UtcNow));
            }
        }

        /// <summary>
        /// 把时间转换为时间戳
        /// </summary>
        /// <param name="utc"></param>
        /// <returns></returns>
        private static long Parse(DateTime utc)
        {
            return (utc.Ticks - unixBase.Ticks) / 10000000;
        }

        /// <summary>
        /// 到当地时间的隐式转换
        /// </summary>
        /// <param name="timestamp"></param>
        /// <returns></returns>
        public static implicit operator DateTime(UnixTimestamp timestamp)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(ConvertToUtc(timestamp.value), TimeZoneInfo.Local);
        }

        /// <summary>
        /// 把 Unix时间戳 转换为 UTC 时间
        /// </summary>
        /// <param name="timestamp"></param>
        /// <returns></returns>
        public static DateTime ConvertToUtc(long timestamp)
        {
            return unixBase.AddSeconds(timestamp);
        }

        public long ToNumeric()
        {
            return value;
        }
    }
}
