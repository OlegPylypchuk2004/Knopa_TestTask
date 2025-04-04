using UnityEngine;

public class PlanetaryObject : IPlaneteryObject
{
    private float _orbitAngle;
    private Vector3 _orbitCenter;
    private float _orbitSpeed;
    private float _orbitRadius;
    private Transform _transform;

    public MassClass MassClassEnum { get; private set; }
    public double Mass { get; private set; }
    public float Radius { get; private set; }

    public PlanetaryObject(double mass, Transform transform)
    {
        Mass = mass;
        Radius = CalculateRadius(mass);
        MassClassEnum = DetermineMassClass(mass);
        _orbitCenter = Vector3.zero;
        _orbitSpeed = Random.Range(0.25f, 1f);
        _orbitRadius = Mathf.Lerp(0.25f, 1f * 25f, _orbitSpeed);
        _transform = transform;
    }

    public void UpdatePosition(float deltaTime)
    {
        _orbitAngle += _orbitSpeed * deltaTime;
        float x = _orbitCenter.x + Mathf.Cos(_orbitAngle) * _orbitRadius;
        float z = _orbitCenter.z + Mathf.Sin(_orbitAngle) * _orbitRadius;
        _transform.localPosition = new Vector3(x, 0, z);
    }

    private MassClass DetermineMassClass(double mass)
    {
        if (mass < 0.00001f) return MassClass.Asteroidan;
        if (mass < 0.1f) return MassClass.Mercurian;
        if (mass < 0.5f) return MassClass.Subterran;
        if (mass < 2f) return MassClass.Terran;
        if (mass < 10f) return MassClass.Superterran;
        if (mass < 50f) return MassClass.Neptunian;

        return MassClass.Jovian;
    }

    private float CalculateRadius(double mass)
    {
        switch (DetermineMassClass(mass))
        {
            case MassClass.Asteroidan: return Random.Range(0f, 0.03f);
            case MassClass.Mercurian: return Random.Range(0.03f, 0.7f);
            case MassClass.Subterran: return Random.Range(0.5f, 1.2f);
            case MassClass.Terran: return Random.Range(0.8f, 1.9f);
            case MassClass.Superterran: return Random.Range(1.3f, 3.3f);
            case MassClass.Neptunian: return Random.Range(2.1f, 5.7f);
            case MassClass.Jovian: return Random.Range(3.5f, 27f);

            default: return 1f;
        }
    }
}