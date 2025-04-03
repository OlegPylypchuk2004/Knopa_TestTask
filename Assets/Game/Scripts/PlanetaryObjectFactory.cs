using UnityEngine;

public class PlanetaryObjectFactory
{
    private MassSpecificationData[] _massSpecificationDatas;

    public PlanetaryObjectFactory(MassSpecificationData[] massSpecificationDatas)
    {
        _massSpecificationDatas = massSpecificationDatas;
    }

    internal PlanetaryObject Create(float mass, Transform parent)
    {
        GameObject planetGO = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        planetGO.transform.SetParent(parent);

        MassSpecificationData massSpecificationData = null;

        for (int i = 0; i < _massSpecificationDatas.Length; i++)
        {
            if (_massSpecificationDatas[i].MinMass <= mass && _massSpecificationDatas[i].MaxMass >= mass)
            {
                massSpecificationData = _massSpecificationDatas[i];

                break;
            }
        }

        Vector3 orbitCenter = Vector3.zero;
        float orbitRadius = Random.Range(5f, 50f);
        float orbitSpeed = Random.Range(0.1f, 2f);

        return new PlanetaryObject(mass, massSpecificationData, orbitCenter, orbitRadius, orbitSpeed, planetGO.transform);
    }
}