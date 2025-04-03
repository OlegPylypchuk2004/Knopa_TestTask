using UnityEngine;

public class PlanetaryObjectData
{
    public MassSpecificationData MassSpecification { get; private set; }
    public Vector3 OrbitCenter { get; private set; }
    public float OrbitSpeed { get; private set; }
    public float OrbitRadius { get; private set; }
    public Transform ViewTransform { get; private set; }

    public PlanetaryObjectData(MassSpecificationData massSpecification, Vector3 orbitCenter, float orbitSpeed, float orbitRadius, Transform viewTransform)
    {
        MassSpecification = massSpecification;
        OrbitCenter = orbitCenter;
        OrbitSpeed = orbitSpeed;
        OrbitRadius = orbitRadius;
        ViewTransform = viewTransform;
    }
}