using UnityEngine;

public class PlanetaryObject
{
    public float Mass { get; private set; }
    public MassSpecification Type { get; private set; }
    public float Radius { get; private set; }
    public Vector3 OrbitCenter { get; private set; }
    public float OrbitRadius { get; private set; }
    public float OrbitSpeed { get; private set; }
    private float _orbitAngle;
    private Transform _transform;

    public PlanetaryObject(float mass, Vector3 orbitCenter, float orbitRadius, float orbitSpeed, Transform transform)
    {
        Mass = mass;
        Type = DetermineMassClass(mass);
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

    private MassSpecification DetermineMassClass(float mass)
    {
        if (mass < 0.00001f) return MassSpecification.Asteroidan;
        if (mass < 0.1f) return MassSpecification.Mercurian;
        if (mass < 0.5f) return MassSpecification.Subterran;
        if (mass < 2f) return MassSpecification.Terran;
        if (mass < 10f) return MassSpecification.Superterran;
        if (mass < 50f) return MassSpecification.Neptunian;
        return MassSpecification.Jovian;
    }

    private float CalculateRadius(float mass)
    {
        switch (DetermineMassClass(mass))
        {
            case MassSpecification.Asteroidan: return Random.Range(0f, 0.03f);
            case MassSpecification.Mercurian: return Random.Range(0.03f, 0.7f);
            case MassSpecification.Subterran: return Random.Range(0.5f, 1.2f);
            case MassSpecification.Terran: return Random.Range(0.8f, 1.9f);
            case MassSpecification.Superterran: return Random.Range(1.3f, 3.3f);
            case MassSpecification.Neptunian: return Random.Range(2.1f, 5.7f);
            case MassSpecification.Jovian: return Random.Range(3.5f, 27f);
            default: return 1f;
        }
    }
}