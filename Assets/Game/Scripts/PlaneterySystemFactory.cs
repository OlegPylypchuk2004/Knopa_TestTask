using System.Collections.Generic;
using UnityEngine;

public class PlaneterySystemFactory : IPlaneterySystemFactory
{
    private PlaneteryObjectFactory _planeteryObjectFactory;

    public PlaneterySystemFactory(PlaneteryObjectFactory planeteryObjectFactory)
    {
        _planeteryObjectFactory = planeteryObjectFactory;
    }

    public IPlaneterySystem Create(double totalMass)
    {
        int planetsCount = Random.Range(5, 15);
        double remainingMass = totalMass;
        List<double> planetMasses = new List<double>();

        double minMass = 0.001f;

        for (int i = 0; i < planetsCount - 1; i++)
        {
            double maxMass = remainingMass - (planetsCount - i - 1) * minMass;
            double planetMass = minMass + (maxMass - minMass) * new System.Random().NextDouble();

            planetMasses.Add(planetMass);
            remainingMass -= planetMass;
        }

        planetMasses.Add(remainingMass);

        List<IPlaneteryObject> planeteryObjects = new List<IPlaneteryObject>();

        for (int i = 0; i < planetsCount; i++)
        {
            IPlaneteryObject planeteryObject = _planeteryObjectFactory.CreateObject(planetMasses[i]);
            planeteryObjects.Add(planeteryObject);
        }

        IPlaneterySystem planeterySystem = new PlaneterySystem(planeteryObjects);

        return planeterySystem;
    }
}