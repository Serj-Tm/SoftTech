﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MetaTech.Library;
//using System.Net.Json;

namespace SoftTech.Wui
{
  public class JsonData
  {
    public JsonData(object data)
    {
      this.Data = data;
    }
    public readonly object Data;

    public object JPath(params string[] path)
    {
      return JsonDataHlp.JPath(Data, path);
    }

    public string ToText()
    {
      return JsonDataHlp.JsonObjectToString(Data);
    }
    public override string ToString()
    {
      return ToText();
    }
  }
  public static class JsonDataHlp
  {
    public static string JsonObjectToString(object jsonData, string prefix = "")
    {
      if (true)
      {
        var index = jsonData.As<Dictionary<string, object>>();
        if (index != null)
        {
          return index.Select(pair => string.Format("{0}{1}:{2}", prefix, pair.Key, JsonObjectToString(pair.Value, prefix + "  "))).JoinToString("\n");
        }
      }
      //if (true)
      //{
      //  var index = jsonData.As<JsonObjectCollection>();
      //  if (index != null)
      //  {
      //    return index.Select(pair => string.Format("{0}{1}:{2}", prefix, pair.Name, JsonObjectToString(pair.Value(), prefix + "  "))).JoinToString("\n");
      //  }
      //}
      if (true)
      {
        var array = jsonData.As<object[]>();
        if (array != null)
          return string.Format("{0}[\n{1}\n{0}]\n", prefix, array.Select(item => JsonObjectToString(item, prefix + "  ")).JoinToString("\n"));
      }
      //if (true)
      //{
      //  var array = jsonData.As<IEnumerable<JsonObject>>();
      //  if (array != null)
      //    return string.Format("{0}[\n{1}\n{0}]\n", prefix, array.Select(item => JsonObjectToString(item, prefix + "  ")).JoinToString("\n"));
      //}
      return jsonData.ToString_Fair();
    }
    public static object JPath(object jsonData, params string[] path)
    {
      foreach (var _entry in path)
      {
        var entry = _entry;
        string camelEntry = null;
        if (entry.Contains('-'))
        {
          var ss = entry.Split('-');
          camelEntry = ss.Take(1).Concat(ss.Skip(1).Select(s => s.Substring(0, 1).ToUpper() + s.Substring(1))).JoinToString(null);
        }

        if (true)
        {
          var index = jsonData.As<Dictionary<string, object>>();
          if (index != null)
          {
            jsonData = index.Find(camelEntry) ?? index.Find(entry);
            continue;
          }
        }
        if (true)
        {
          var index = jsonData.As<Newtonsoft.Json.Linq.JObject>();
          if (index != null)
          {
            jsonData = index.Find(camelEntry) ?? index.Find(entry);
            continue;
          }
        }
        //if (true)
        //{
        //  var index = jsonData.As<List<JsonObject>>();
        //  if (index != null)
        //    jsonData = index.FirstOrDefault();
        //}
        //if (true)
        //{
        //  var index = jsonData.As<JsonObjectCollection>();
        //  if (index != null)
        //  {
        //    jsonData = (index.FirstOrDefault(_obj => _obj.Name == camelEntry) ?? index.FirstOrDefault(_obj => _obj.Name == entry)).Value();
        //    continue;
        //  }
        //}
        break;
      }
      return jsonData;
    }
    //public static object Value(this JsonObject obj)
    //{
    //  if (obj == null)
    //    return null;
    //  if (obj is JsonObjectCollection)
    //    return obj;
    //  return obj.GetValue();
    //}
  }

  
}
