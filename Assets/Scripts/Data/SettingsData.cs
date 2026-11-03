using System;

[Serializable]
public struct SettingsData
{
    public static SettingsData GetDefault() =>
        new()
        {

        };
}
