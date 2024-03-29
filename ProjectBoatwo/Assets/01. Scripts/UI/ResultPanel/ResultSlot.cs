using TMPro;
using UnityEngine;
using UnityEngine.UI;

public partial class ResultSlot : MonoBehaviour
{
    [SerializeField] TweenOptOption tweenOption = null; 

    private TMP_Text nameText = null;
    private TMP_Text contentText = null;
    private RawImage characterImage = null;

    private void Awake()
    {
        nameText = transform.Find("NameTag/NameText").GetComponent<TMP_Text>();
        contentText = transform.Find("ContentPanel/ContentText").GetComponent<TMP_Text>();
        characterImage = transform.Find("CharacterImage").GetComponent<RawImage>();

        tweenOption.Init(transform);
    }

	public void Init(PlayerInfo info)
    {
        nameText.text = string.Format(NameFormat, info.Nickname);
        contentText.text = string.Format(ContentFormat, info.InflictedDamage, info.ReviveCount, info.FaintCount);
        characterImage.texture = info.CharacterImage;
    }

    public void Display(bool active, bool immediately = false)
    {
        if(immediately)
        {
            gameObject.SetActive(active);
            return;
        }

        tweenOption.GetOption(active).PlayTween();
    }
}
