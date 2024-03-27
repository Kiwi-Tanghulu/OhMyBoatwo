using UnityEngine;

public interface IGrabbable
{
    public IHolder CurrentHolder { get; }
    public GameObject GrabObject { get; }

	public bool Grab(IHolder holder, Vector3 point = default);
    public void Release();
}
