using System.Collections.Generic;
using UnityEngine;

public class PlanetarySystemFactory : IPlanetarySystemFactory
{
    private PlanetaryObjectFactory _planetaryObjectFactory;

    public PlanetarySystemFactory(PlanetaryObjectFactory planetaryObjectFactory)
    {
        _planetaryObjectFactory = planetaryObjectFactory;
    }

    public IPlaneterySystem Create(double totalMass)
    {
        IPlaneterySystem planetarySystem = new PlanetarySystem();

        int planetsCount = Random.Range(5, 15);
        double remainingMass = totalMass;
        List<double> planetMasses = new List<double>();

        double minMass = 0.001f;

        for (int i = 0; i < planetsCount - 1; i++)
        {
            double maxMass = remainingMass - (planetsCount - i - 1) * minMass;

            System.Random random = new System.Random();
            double planetMass = minMass + (maxMass - minMass) * random.NextDouble();

            planetMasses.Add(planetMass);
            remainingMass -= planetMass;
        }

        planetMasses.Add(remainingMass);

        for (int i = 0; i < planetsCount; i++)
        {
            IPlaneteryObject planetaryObject = _planetaryObjectFactory.CreateObject(planetMasses[i]);
            planetarySystem.AddPlaneteryObject(planetaryObject);
        }

        return planetarySystem;
    }
}