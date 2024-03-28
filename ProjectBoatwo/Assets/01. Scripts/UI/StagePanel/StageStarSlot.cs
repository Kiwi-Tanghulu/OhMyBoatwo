using UnityEngine;
using UnityEngine.UI;

public class StageStarSlot : MonoBehaviour
{
    private Image starImage = null;

    private void Awake()
    {
        starImage = transform.Find("StarIcon").GetComponent<Image>();
    }

    private void Start()
    {
        Display(false);
    }

    public void Display(bool active)
    {
        starImage.gameObject.SetActive(active);
    }
}
