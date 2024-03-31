using UnityEngine;

public class MenuPanel : MonoBehaviour
{
	public void ClickSinglePlay()
    {
        Debug.Log("Play Single");
        SceneLoader.LoadSceneAsync("StageScene", false);
    }

    public void ClickCOOPPlay()
    {
        Debug.Log("Play CO-OP");
    }

    public void ClickSetting()
    {
        Debug.Log("Pop Up Setting");
    }
}
