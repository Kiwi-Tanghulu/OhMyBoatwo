using UnityEngine;

public interface IHolder
{
    public Transform HoldingParent { get; }
    public IGrabbable HoldingObject { get; }

    public bool IsEmpty { get; }

    public bool Grab(IGrabbable target, Vector3 point = default);

    /// <summary>
    /// release the holding object
    /// </summary>
    public void Release();
}
