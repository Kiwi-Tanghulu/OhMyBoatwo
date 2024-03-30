using UnityEngine;

public class GamePanel : MonoBehaviour
{
    private NoticePanel noticePanel = null;
    public NoticePanel NoticePanel {
        get {
            if(noticePanel == null)
                noticePanel = transform.Find("NoticePanel").GetComponent<NoticePanel>();
            return noticePanel;
        }
    }

    private WeaponPanel weaponPanel = null;
    public WeaponPanel WeaponPanel {
        get {
            if(weaponPanel == null)
                weaponPanel = transform.Find("WeaponPanel").GetComponent<WeaponPanel>();
            return weaponPanel;
        }
    }

    private ProfilePanel profilePanel = null;
    public ProfilePanel ProfilePanel {
        get {
            if(profilePanel == null)
                profilePanel = transform.Find("ProfilePanel").GetComponent<ProfilePanel>();
            return profilePanel;
        }
    }

    private StageProgressPanel stageProgressPanel = null;
    public StageProgressPanel StageProgressPanel {
        get {
            if(stageProgressPanel == null)
                stageProgressPanel = transform.Find("StageProgressPanel").GetComponent<StageProgressPanel>();
            return stageProgressPanel;
        }
    }
}
