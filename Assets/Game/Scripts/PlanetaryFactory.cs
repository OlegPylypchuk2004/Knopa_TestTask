using System.Collections.Generic;
using UnityEngine;

public class PlanetaryFactory
{
    private PlanetaryObjectFactory _planetaryObjectFactory;

    public PlanetaryFactory(PlanetaryObjectFactory planetaryObjectFactory)
    {
        _planetaryObjectFactory = planetaryObjectFactory;
    }

    public PlanetarySystem Generate(float totalMass, Transform parent, int planetsCount)
    {
        PlanetarySystem planetarySystem = new PlanetarySystem();

        float remainingMass = totalMass;
        List<float> planetMasses = new List<float>();

        float minMass = 0.001f;

        for (int i = 0; i < planetsCount - 1; i++)
        {
            float maxMass = remainingMass - (planetsCount - i - 1) * minMass;
            float planetMass = Random.Range(minMass, maxMass);
            planetMasses.Add(planetMass);
            remainingMass -= planetMass;
        }

        planetMasses.Add(remainingMass);

        for (int i = 0; i < planetsCount; i++)
        {
            PlanetaryObject planetaryObject = _planetaryObjectFactory.CreateObject(planetMasses[i], parent);
            planetarySystem.AddPlanet(planetaryObject);
        }

        return planetarySystem;
    }
}