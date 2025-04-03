using UnityEngine;

public class PlanetaryObjectData
{
    public Vector3 OrbitCenter { get; private set; }
    public float OrbitSpeed { get; private set; }
    public float OrbitRadius { get; private set; }
    public Transform ViewTransform { get; private set; }

    public PlanetaryObjectData(Vector3 orbitCenter, float orbitSpeed, float orbitRadius, Transform viewTransform)
    {
        OrbitCenter = orbitCenter;
        OrbitSpeed = orbitSpeed;
        OrbitRadius = orbitRadius;
        ViewTransform = viewTransform;
    }
}