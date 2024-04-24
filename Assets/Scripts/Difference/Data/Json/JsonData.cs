using Framework.Extensions;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Difference.Data.Json
{
    [Serializable]
    public class JsonData<T> where T : JsonData<T>
    {
        [SerializeField] protected string path = "Json";
        [SerializeField] private TextAsset[] jsons;
        public Dictionary<string, JObject> Data { get; private set; }

        public void SaveData()
        {
            Data.ForEach(kvp => { File.WriteAllText($"{Application.persistentDataPath}/{path}/{kvp.Key}.json", kvp.Value.ToString()); });
        }

        public void LoadData(params string[] keys)
        {
            if (!Directory.Exists($"{Application.persistentDataPath}/{path}")) InitData();

            Data = new Dictionary<string, JObject>();
            keys.ForEach(key =>
            {
                string json = File.ReadAllText($"{Application.persistentDataPath}/{path}/{key}.json");
                if (!string.IsNullOrEmpty(json))
                {
                    Data[key] = JObject.Parse(json);
                }
            });
        }

        void InitData()
        {
            Directory.CreateDirectory($"{Application.persistentDataPath}/{path}");
            jsons.ForEach(json =>
            {
                string key = json.name;
                string path = $"{Application.persistentDataPath}/{this.path}/{key}.json";

                File.WriteAllText(path, json.text);
            });
        }
    }
}