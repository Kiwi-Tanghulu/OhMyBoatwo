using UnityEngine;

public class WaterManager : MonoBehaviour
{
    public static WaterManager Instance { get; private set; }

    [SerializeField] private GameObject waterPrefab;
    private Material oceanMat;

    [Space]
    [SerializeField] private int samplingCount = 3;

    [Space]
    [SerializeField] private int waveCount = 4;

    private Vector4 waveA;
    private Vector4 waveB;
    private Vector4 waveC;
    //private Vector4 waveD;

    [Space]
    [SerializeField] private Vector3 waterSize;
    [SerializeField] private Vector2 waterCount;
    [SerializeField] private bool generateOcenaOnAwake;

    private void Awake()
    {
        Instance = this;

        oceanMat = waterPrefab.GetComponent<MeshRenderer>().sharedMaterial;

        waveA = oceanMat.GetVector("_WaveA");
        waveB = oceanMat.GetVector("_WaveB");
        waveC = oceanMat.GetVector("_WaveC");
        //waveD = oceanMat.GetVector("_WaveD");
    }

    private void Start()
    {
        if (generateOcenaOnAwake)
            GenerateOcean();
    }

    public float GetWaveHeight(Vector3 pos)
    {
        Vector3 w1 = Vector3.zero;
        Vector3 w2 = Vector3.zero;
        Vector3 w3 = Vector3.zero;
        //Vector3 w4 = Vector3.zero;

        w1 = GerstnerWave(waveA, pos);
        w1 = GerstnerWave(waveA, pos - w1);
        w1 = GerstnerWave(waveA, pos - w1);
        w1 = GerstnerWave(waveA, pos - w1);

        w2 = GerstnerWave(waveB, pos);
        w2 = GerstnerWave(waveB, pos - w2);
        w2 = GerstnerWave(waveB, pos - w2);
        w2 = GerstnerWave(waveB, pos - w2);

        w3 = GerstnerWave(waveC, pos);
        w3 = GerstnerWave(waveC, pos - w3);
        w3 = GerstnerWave(waveC, pos - w3);
        w3 = GerstnerWave(waveC, pos - w3);

        //w4 = GerstnerWave(waveD, pos);
        //w4 = GerstnerWave(waveD, pos - w4);
        //w4 = GerstnerWave(waveD, pos - w4);
        //w4 = GerstnerWave(waveD, pos - w4);

        return ((w1 + w2 + w3) / waveCount).y + transform.position.y;
    }

    private Vector3 GerstnerWave(Vector4 wave, Vector3 p)
    {
        Vector3 pos = p;
        Vector3 diff = Vector3.zero;
        Vector3 result = Vector3.zero;

        float steepness = wave.z;
        float wavelength = wave.w;
        float k = 2 * Mathf.PI / wavelength;
        float c = Mathf.Sqrt(9.8f / k);
        Vector2 d = new Vector2(wave.x, wave.y).normalized;
        float f = k * (Vector2.Dot(d, new Vector2(pos.x, pos.z)) - c * Time.time);
        float a = steepness / k;

        result = new Vector3(
            d.x * (a * Mathf.Cos(f)),
            a * Mathf.Sin(f),
            d.y * (a * Mathf.Cos(f)));

        return result;
    }

    private void GenerateOcean()
    {
        Vector3 pos;
        Vector3 startPoint = new Vector3(-(waterCount.x / 2f * waterSize.x), 0f, -(waterCount.y / 2f * waterSize.z));
        GameObject water;

        for (int i = 0; i < waterCount.x; i++)
        {
            for (int j = 0; j < waterCount.y; j++)
            {
                pos = new Vector3(startPoint.x + waterSize.x * j, startPoint.y, startPoint.z + waterSize.z * i);
                water = Instantiate(waterPrefab, transform);
                water.transform.localPosition = pos;
            }
        }
    }
}
