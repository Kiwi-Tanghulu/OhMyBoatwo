using UnityEngine;

public static class DEFINE
{
    public const float StageReadyCount = 3f;

	private static FadeImage fadeImage = null;
    public static FadeImage FadeImage {
        get {
            if(fadeImage == null)
                fadeImage = GameObject.Find("StaticCanvas/FadeImage").GetComponent<FadeImage>();

            return fadeImage;
        }
    }

    private static Transform mainCanvas = null;
	public static Transform MainCanvas {
		get {
			if(mainCanvas == null)
				mainCanvas = GameObject.Find("MainCanvas")?.transform;
			return mainCanvas;
		}
	}

    private static AudioSource globalAudioPlayer = null;
    public static AudioSource GlobalAudioPlayer
    {
        get
        {
            if (globalAudioPlayer == null)
                globalAudioPlayer = GameObject.Find("GlobalAudioPlayer")?.GetComponent<AudioSource>();
            return globalAudioPlayer;
        }
    }
}
