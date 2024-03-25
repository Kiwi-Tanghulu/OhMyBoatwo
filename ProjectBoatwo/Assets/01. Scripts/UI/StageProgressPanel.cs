using UnityEngine;
using UnityEngine.UI;

public class StageProgressPanel : MonoBehaviour
{
	private Slider progressBar = null;

    private void Awake()
    {
        progressBar = transform.Find("ProgressBar").GetComponent<Slider>();
    }

    public void SetProgress(float ratio)
    {
        progressBar.value = ratio;
    }
}
