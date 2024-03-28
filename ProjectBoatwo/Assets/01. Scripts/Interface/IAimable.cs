using UnityEngine;
using UnityEngine.Animations.Rigging;
public interface IAimable
{
    public float AimDuration { get; }
    public Rig AimRig { get; }
    public bool IsAim { get; }
    public void Aim(bool value);
}
