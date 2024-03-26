using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoSlot : MonoBehaviour
{
	private Image iconImage = null;
    private Image hpBar = null;
    private TMP_Text numberText = null;
    private TMP_Text nameText = null;

    private void Awake()
    {
        iconImage = transform.Find("Icon").GetComponent<Image>();
        hpBar = transform.Find("HPBar/Slider").GetComponent<Image>();
        numberText = iconImage.transform.Find("NumberText").GetComponent<TMP_Text>();
        nameText = transform.Find("NameText").GetComponent<TMP_Text>();
    }

    public void Init(PlayerInfo info)
    {
        iconImage.color = info.PlayerColor;
        numberText.text = (info.PlayerNumber + 1).ToString();
        nameText.text = info.Nickname;

        hpBar.fillAmount = 1f;
    }

    public void SetHP(float ratio)
    {
        hpBar.fillAmount = ratio;
    }
}
