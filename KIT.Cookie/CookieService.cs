using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;


namespace KIT.Cookie
{
    /// <summary>
    ///     Scoped-life-time Cookie
    /// </summary>
    public class CookieService
    {
        /// <summary>
        ///     Checks cookie existance in request.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Contains(HttpContext context, string key)
        {
            return context.Request.Cookies.ContainsKey(key);
        }
        // add based on minute

        /// <summary>
        ///     Setting-up cookie with configs
        /// </summary>
        /// <param name="context"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="seconds"></param>
        public void SetCookie(HttpContext context, string key, string value, int? seconds)
        {
            var cookieOptions = new CookieOptions();

            if (!seconds.HasValue)
            {
                cookieOptions.Expires = DateTimeOffset.UtcNow.AddDays(1);
            }
            cookieOptions.Expires = DateTimeOffset.UtcNow.AddSeconds((int)seconds);
            cookieOptions.Secure = true;
            cookieOptions.Path = context.Request.Path.ToUriComponent();

            context.Response.Cookies.Append(key, value, cookieOptions);
        }

        /// <summary>
        ///     Retrieves specified cookie, based on key
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="context"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public TResult GetCookie<TResult>(HttpContext context, string key)
        {
            context.Request.Cookies.TryGetValue(key, out string value);
            return (TResult)Convert.ChangeType(value, typeof(TResult));
        }

        /// <summary>
        ///     Removes cookie with specified key
        /// </summary>
        /// <param name="context"></param>
        /// <param name="key"></param>
        public void RemoveCookie(HttpContext context, string key)
        {
            context.Response.Cookies.Delete(key);
        }
    }
}