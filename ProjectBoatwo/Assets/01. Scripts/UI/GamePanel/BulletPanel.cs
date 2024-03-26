using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletPanel : MonoBehaviour
{
	[SerializeField] Image bulletPrefab = null;
    private Transform container = null;

    private List<Image> bullets = new List<Image>();

    private void Awake()
    {
        container = transform.Find("Container");
        Clear();
    }

    public void Display(int index, bool active)
    {
        bullets[index].color = new Color(1, 1, 1, active ? 1 : 0f);
    }

    public void Display(bool active)
    {
        gameObject.SetActive(active);
    }

    public void Init(int count)
    {
        bullets.AddRange(new Image[count]);
        for(int i = 0; i < count; ++i)
            bullets[i] = Instantiate(bulletPrefab, container);
    }

    public void Clear()
    {
        foreach(Transform bullet in container)
            Destroy(bullet.gameObject);
        bullets.Clear();
    }
}
