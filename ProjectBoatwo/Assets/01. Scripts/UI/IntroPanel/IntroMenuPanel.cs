using UnityEngine;

public class MenuPanel : MonoBehaviour
{
	public void ClickSinglePlay()
    {
        Debug.Log("Play Single");
        SceneLoader.LoadSceneAsync("StageScene");
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
