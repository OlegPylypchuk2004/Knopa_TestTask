using UnityEngine;

public class PlanetaryObject : IPlaneteryObject
{
    private float _orbitAngle;

    public MassClass MassClassEnum { get; private set; }
    public double Mass { get; private set; }

    public PlanetaryObject(double mass)
    {
        MassClassEnum = DetermineMassClass(mass);
    }

    public void UpdatePosition(float deltaTime)
    {
        //_orbitAngle += Data.OrbitSpeed * deltaTime;
        //float x = Data.OrbitCenter.x + Mathf.Cos(_orbitAngle) * Data.OrbitRadius;
        //float z = Data.OrbitCenter.z + Mathf.Sin(_orbitAngle) * Data.OrbitRadius;
        //Data.ViewTransform.localPosition = new Vector3(x, 0, z);
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
}