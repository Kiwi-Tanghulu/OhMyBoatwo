using UnityEngine;

public static class DEFINE
{
	private static FadeImage fadeImage = null;
    public static FadeImage FadeImage {
        get {
            if(fadeImage == null)
                fadeImage = GameObject.Find("StaticCanvas/FadeImage").GetComponent<FadeImage>();

            return fadeImage;
        }
    }
}
