using UnityEngine;

public class PlanetaryObject
{
    public float Mass { get; private set; }
    public MassSpecificationData MassSpecificationData { get; private set; }
    public float Radius { get; private set; }


    private PlanetaryObjectData _data;

    private float _orbitAngle;

    public PlanetaryObject(float mass, MassSpecificationData massSpecificationData, PlanetaryObjectData planetaryObjectData)
    {
        Mass = mass;
        MassSpecificationData = massSpecificationData;
        Radius = CalculateRadius(mass);
        _data = planetaryObjectData;
        _data.ViewTransform.localScale = Vector3.one * Radius;
    }

    public void UpdatePosition(float deltaTime)
    {
        _orbitAngle += _data.OrbitSpeed * deltaTime;
        float x = _data.OrbitCenter.x + Mathf.Cos(_orbitAngle) * _data.OrbitRadius;
        float z = _data.OrbitCenter.z + Mathf.Sin(_orbitAngle) * _data.OrbitRadius;
        _data.ViewTransform.localPosition = new Vector3(x, 0, z);
    }

    private float CalculateRadius(float mass)
    {
        return Random.Range(MassSpecificationData.MinRadius, MassSpecificationData.MaxRadius);
    }
}