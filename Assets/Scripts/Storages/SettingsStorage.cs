using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

// TODO: Сделать более серьезную защиту и проверку данных
public static class SettingsStorage
{
    private static readonly string _path = Path.Combine(Application.persistentDataPath, "Settings.json");

    private static readonly JsonSerializerSettings _options = new()
    {
        Formatting = Formatting.Indented
    };

    public static event Action<SettingsData> SettingsChanged;

    public static SettingsData Load() => JsonConvert.DeserializeObject<SettingsData>(File.ReadAllText(_path), _options);

    public static void Save(SettingsData settings)
    {
        File.WriteAllText(_path, JsonConvert.SerializeObject(settings, _options));

        SettingsChanged?.Invoke(settings);
    }

    public static void EnsureFileExists()
    {
        if (File.Exists(_path)) return;

        Save(SettingsData.GetDefault());
    }
}