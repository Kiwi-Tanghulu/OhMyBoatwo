using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Audio/AudioLibrary")]
public class AudioLibrarySO : ScriptableObject
{
	[SerializeField] List<AudioDictionaryTable> audioTables;
    public Dictionary<string, AudioDictionaryTable> Library = null;
    public AudioClip this[string key] => Library[key].Audio;

    private void OnEnable()
    {
        //RefreshAudioAssetAsync();
        RefreshAudioAsset();
    }

    private void OnValidate()
    {
        //RefreshAudioAssetAsync();
        RefreshAudioAsset();
    }

    [ContextMenu("Refresh")]
    private void Refresh()
    {
        //RefreshAudioAssetAsync();
        RefreshAudioAsset();
    }

    private void RefreshAudioAsset()
    {
        if (Library != null)
            Library.Clear();
        else
            Library = new Dictionary<string, AudioDictionaryTable>();

        for (int i = 0; i < audioTables.Count; ++i)
        {
            AudioDictionaryTable table = audioTables[i];
            if (Library.ContainsKey(table.Key))
                continue;

            Library.Add(table.Key, table);
        }
    }

    private async void RefreshAudioAssetAsync()
    {
        try {
            await Task.Run(() => {
                if (Library != null)
                    Library.Clear();
                else
                    Library = new Dictionary<string, AudioDictionaryTable>();

                for (int i = 0; i < audioTables.Count; ++i)
                {
                    AudioDictionaryTable table = audioTables[i];
                    if (Library.ContainsKey(table.Key))
                        continue;

                    Library.Add(table.Key, table);
                }
            });

            Debug.Log("Audio Library Refreshed");
        } catch {}
    }
}
