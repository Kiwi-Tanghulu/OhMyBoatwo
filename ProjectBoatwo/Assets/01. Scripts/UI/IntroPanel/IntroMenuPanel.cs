using UnityEngine;

public class MenuPanel : MonoBehaviour
{
    private FadeImage fadeImage = null;

    private void Awake()
    {
        fadeImage = DEFINE.FadeImage;
    }

	public void ClickSinglePlay()
    {
        Debug.Log("Play Single");
        fadeImage.FadeInHorizontal(-1, 1f, () => {
            SceneLoader.LoadSceneAsync("StageScene", false, () => {
                fadeImage.FadeOutHorizontal(1);
            });
        });
    }

    public void ClickCOOPPlay()
    {
        Debug.Log("Play CO-OP");
    }

    public void ClickSetting()
    {
        Debug.Log("Pop Up Setting");
    }

    public void ClickQuit()
    {
        Application.Quit();
    }
}
