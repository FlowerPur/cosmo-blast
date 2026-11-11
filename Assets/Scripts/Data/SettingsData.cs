using System;

// TODO: прописать настройки
[Serializable]
public struct SettingsData
{
    public static SettingsData GetDefault() =>
        new()
        {

        };
}
