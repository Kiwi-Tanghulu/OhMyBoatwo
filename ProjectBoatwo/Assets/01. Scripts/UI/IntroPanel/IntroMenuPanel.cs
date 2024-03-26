using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPanel : MonoBehaviour
{
	public void ClickSinglePlay()
    {
        Debug.Log("Play Single");
        SceneManager.LoadScene("GameScene");
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
