using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace TodoApp
{
    public static class UriHelper
    {
        public const string GoBackSegment = "..";

        const string GoBackQueryParameterName = "__GOBACK__";
        const string DataQueryParameterName = "__DATA__";

        public static string EnsureUri(string target, object args = default)
        {
            if (string.IsNullOrWhiteSpace(target)) return target;

            var normalizedTarget = target.StartsWith("http://") || target.StartsWith("https://")
                ? target
                : "https://app-navigator/" + target;

            var uriBuilder = new UriBuilder(normalizedTarget);

            if (args != null)
            {
                var argsInJson = JsonSerializer.Serialize(args);
                var argsQueryParameter =
                    $"{DataQueryParameterName}=" + Uri.EscapeUriString(argsInJson);
                uriBuilder.Query = string.IsNullOrWhiteSpace(uriBuilder.Query)
                    ? argsQueryParameter
                    : uriBuilder.Query + "&" + argsQueryParameter;
            }

            var uri = uriBuilder.Uri;
            return target == GoBackSegment
                ? GoBackSegment + (string.IsNullOrWhiteSpace(uri.Query)
                    ? $"?{GoBackQueryParameterName}=true"
                    : uri.Query + $"&{GoBackQueryParameterName}=true")
                : uri.PathAndQuery.Trim('/');
        }

        public static bool IsGoingBack(this IDictionary<string, string> query)
        {
            if (query == null) return false;

            return query.ContainsKey(GoBackQueryParameterName);
        }

        public static T GetData<T>(this IDictionary<string, string> query)
        {
            if (query == null) return default;

            var hasData = query.TryGetValue(DataQueryParameterName, out var argsInString);

            if (!hasData) return default;

            var argsInJson = Uri.UnescapeDataString(argsInString);
            return JsonSerializer.Deserialize<T>(argsInJson);
        }
    }
}