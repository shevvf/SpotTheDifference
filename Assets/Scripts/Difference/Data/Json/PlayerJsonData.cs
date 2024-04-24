using Newtonsoft.Json.Linq;
using System;
using System.IO;
using UnityEditor;
using UnityEngine;
using Difference.Data.Path;

namespace Difference.Data.Json
{
    [Serializable]
    public class PlayerJsonData : JsonData<PlayerJsonData>
    {
        public JToken PlayerMaxLevel => Data[DataPath.PLAYER_DATA][DataPath.PLAYER_MAX_LEVEL];

        #region EditorOnly

#if UNITY_EDITOR
        [MenuItem("Data/Reset")]
        public static void ResetDataEditor()
        {
            string path = $"{Application.persistentDataPath}/Json";
            foreach (string directory in Directory.GetDirectories(path))
            {
                try
                {
                    Directory.Delete(directory, true);
                }
                catch (IOException)
                {
                    Directory.Delete(directory, true);
                }
                catch (UnauthorizedAccessException)
                {
                    Directory.Delete(directory, true);
                }
            }
            try
            {
                Directory.Delete(path, true);
            }
            catch (IOException)
            {
                Directory.Delete(path, true);
            }
            catch (UnauthorizedAccessException)
            {
                Directory.Delete(path, true);
            }
        }
#endif

        #endregion
    }
}
