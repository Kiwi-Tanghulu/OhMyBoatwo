using TMPro;
using UnityEngine;
using UnityEngine.UI;

public partial class ResultSlot : MonoBehaviour
{
    private TMP_Text nameText = null;
    private TMP_Text contentText = null;
    private RawImage characterImage = null;

	public void Init(PlayerInfo info)
    {
        nameText.text = string.Format(NameFormat, info.Nickname);
        contentText.text = string.Format(ContentFormat, info.InflictedDamage, info.ReviveCount, info.FaintCount);
        characterImage.texture = info.CharacterImage;
    }

    public void Display(bool active)
    {
        gameObject.SetActive(active);
    }
}
