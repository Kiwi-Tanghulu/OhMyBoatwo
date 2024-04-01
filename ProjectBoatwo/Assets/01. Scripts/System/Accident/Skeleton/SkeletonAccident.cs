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

        for(int i = 0; i < accidentData.SpawnPositions.Length; ++i)
        {
            if(accidentData.Container.childCount > 0)
                return;

            int index = i;
            float delay = 0f;
            for(int j = 0; j < accidentData.SkeletonCount; ++j)
            {
                StartCoroutine(this.DelayCoroutine(delay, () => SpawnSkeleton(index)));
                delay += accidentData.SpawnRate;
            }
        }
    }

    public override void UpdateAccident()
    {
        
    }

    private void SpawnSkeleton(int index)
    {
        Skeleton instance = Instantiate(accidentData.SkeletonPrefab, accidentData.Container);
        instance.OnSkeletonDestroyEvent += HandleSkeletonDestroy;
        instance.transform.position = accidentData.GetSpawnPosition(index);
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
