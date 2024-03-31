using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProfilePanel : MonoBehaviour
{
    private TMP_Text nicknameText = null;
    private RawImage profileImage = null;
    private Image hpSlider = null;

    private void Awake()
    {
        nicknameText = transform.Find("NicknamePanel/NicknameText").GetComponent<TMP_Text>();
        profileImage = transform.Find("ProfileImagePanel/Mask/ProfileImage").GetComponent<RawImage>();
        hpSlider = transform.Find("HPBar/Mask/Slider").GetComponent<Image>();
    }

    public void Init(PlayerInfo info)
    {
        nicknameText.text = info.Nickname;
        profileImage.texture = info.CharacterImage;
    }

    public void SetHP(float ratio) 
    {
        hpSlider.fillAmount = ratio;
    }
}
