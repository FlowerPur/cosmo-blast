using System;

namespace CosmoBlast.Data
{
    // TODO: прописать настройки
    [Serializable]
    public struct SettingsData
    {
        public static SettingsData GetDefault() =>
            new()
            {

            };
    }
}
