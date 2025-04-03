using UnityEngine;
using System.Collections.Generic;

public class PlanetaryFactory
{
    private MassSpecificationData[] _massSpecificationDatas;

    public PlanetaryFactory()
    {
        _massSpecificationDatas = Resources.LoadAll<MassSpecificationData>("Data/MassSpecifications");
    }

    public PlanetarySystem Generate(float totalMass, Transform parent)
    {
        PlanetarySystem system = new PlanetarySystem();
        float remainingMass = totalMass;
        int planetCount = Random.Range(3, 10);

        for (int i = 0; i < planetCount; i++)
        {
            float planetMass = Random.Range(remainingMass * 0.1f, remainingMass * 0.4f);
            remainingMass -= planetMass;
            system.AddPlanet(CreatePlanetaryObject(planetMass, parent));
            if (remainingMass <= 0) break;
        }

        return system;
    }

    private PlanetaryObject CreatePlanetaryObject(float mass, Transform parent)
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