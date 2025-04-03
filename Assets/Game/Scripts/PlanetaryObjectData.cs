using UnityEngine;

public class PlanetaryObjectData
{
    public Vector3 OrbitCenter { get; private set; }
    public float OrbitRadius { get; private set; }
    public float OrbitSpeed { get; private set; }
    public Transform ViewTransform { get; private set; }

    public PlanetaryObjectData(Vector3 orbitCenter, float orbitRadius, float orbitSpeed, Transform viewTransform)
    {
        OrbitCenter = orbitCenter;
        OrbitRadius = orbitRadius;
        OrbitSpeed = orbitSpeed;
        ViewTransform = viewTransform;
    }
}