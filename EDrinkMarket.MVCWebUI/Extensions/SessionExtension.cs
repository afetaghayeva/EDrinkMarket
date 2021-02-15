using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace EDrinkMarket.MVCWebUI.Extensions
{
    public static class SessionExtension
    {
        public static void SetObject(this ISession session, string key, object value)
        {
            var stringValue = JsonConvert.SerializeObject(value);
            session.SetString(key,stringValue);
        }

        public static T GetObject<T>(this ISession session, string key) where T:class
        {
            var stringValue = session.GetString(key);
            if (stringValue==null)
            {
                return null;
            }
            else
            {
                var value = JsonConvert.DeserializeObject<T>(stringValue);
                return value;
            }
        }
    }
}
