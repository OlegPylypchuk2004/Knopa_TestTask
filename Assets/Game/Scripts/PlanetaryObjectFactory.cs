using UnityEngine;

public class PlanetaryObjectFactory
{
    private MassSpecificationData[] _massSpecificationDatas;

    public PlanetaryObjectFactory(MassSpecificationData[] massSpecificationDatas)
    {
        _massSpecificationDatas = massSpecificationDatas;
    }

    public PlanetaryObject Create(float mass, Transform parent)
    {
        GameObject planetGO = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        planetGO.transform.SetParent(parent);

        Vector3 orbitCenter = Vector3.zero;
        float orbitRadius = Random.Range(5f, 50f);
        float orbitSpeed = Random.Range(0.1f, 2f);

        return new PlanetaryObject(mass, DetermineMassSpecificationData(mass), orbitCenter, orbitRadius, orbitSpeed, planetGO.transform);
    }

    public MassSpecificationData DetermineMassSpecificationData(float mass)
    {
        for (int i = 0; i < _massSpecificationDatas.Length; i++)
        {
            if (_massSpecificationDatas[i].MinMass <= mass && _massSpecificationDatas[i].MaxMass >= mass)
            {
                return _massSpecificationDatas[i];
            }
        }

        return null;
    }
}