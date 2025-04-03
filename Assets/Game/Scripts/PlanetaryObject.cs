using UnityEngine;

public class PlanetaryObject
{
    public float Mass { get; private set; }
    public MassSpecificationData MassSpecificationData { get; private set; }
    public float Radius { get; private set; }
    public Vector3 OrbitCenter { get; private set; }
    public float OrbitRadius { get; private set; }
    public float OrbitSpeed { get; private set; }
    private float _orbitAngle;
    private Transform _transform;

    public PlanetaryObject(float mass, MassSpecificationData massSpecificationData, Vector3 orbitCenter, float orbitRadius, float orbitSpeed, Transform transform)
    {
        Mass = mass;
        MassSpecificationData = massSpecificationData;
        Radius = CalculateRadius(mass);
        OrbitCenter = orbitCenter;
        OrbitRadius = orbitRadius;
        OrbitSpeed = orbitSpeed;
        _transform = transform;
        _transform.localScale = Vector3.one * Radius;
    }

    public void UpdatePosition(float deltaTime)
    {
        _orbitAngle += OrbitSpeed * deltaTime;
        float x = OrbitCenter.x + Mathf.Cos(_orbitAngle) * OrbitRadius;
        float z = OrbitCenter.z + Mathf.Sin(_orbitAngle) * OrbitRadius;
        _transform.position = new Vector3(x, 0, z);
    }

    private float CalculateRadius(float mass)
    {
        return Random.Range(MassSpecificationData.MinRadius, MassSpecificationData.MaxRadius);
    }
}