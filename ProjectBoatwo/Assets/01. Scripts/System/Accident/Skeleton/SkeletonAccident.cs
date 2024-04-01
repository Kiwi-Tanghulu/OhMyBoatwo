using UnityEngine;

public class SkeletonAccident : Accident
{
    [SerializeField] SkeletonAccidentSO accidentData = null;

    public override void InitAccident()
    {
    }

    public override void StartAccident()
    {
        base.StartAccident();

        if(accidentData.Container.childCount > 0)
            return;

        float delay = 0f;
        for(int i = 0; i < accidentData.SkeletonCount; ++i)
        {
            StartCoroutine(this.DelayCoroutine(delay, SpawnSkeleton));
            delay += accidentData.SpawnRate;
        }
    }

    public override void UpdateAccident()
    {
        
    }

    private void SpawnSkeleton()
    {
        Skeleton instance = Instantiate(accidentData.SkeletonPrefab, accidentData.Container);
        instance.OnSkeletonDestroyEvent += HandleSkeletonDestroy;
        instance.transform.position = accidentData.GetSpawnPosition();
        instance.FitToGround();
        instance.transform.position += new Vector3(0f, accidentData.SpawnYOffset, 0f);
        // Debug.Break();
    }

    public void HandleSkeletonDestroy(Skeleton skeleton)
    {
        skeleton.OnSkeletonDestroyEvent -= HandleSkeletonDestroy;
        if(accidentData.Container.childCount <= 1)
            EndAccident();
    }
}
