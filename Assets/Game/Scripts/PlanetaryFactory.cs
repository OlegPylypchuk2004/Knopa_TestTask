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

        for (int i = 0; i < planetsCount; i++)
        {
            float planetMass = Random.Range(remainingMass * 0.1f, remainingMass * 0.4f);
            remainingMass -= planetMass;

            PlanetaryObject planetaryObject = _planetaryObjectFactory.CreateObject(planetMass, parent);
            planetarySystem.AddPlanet(planetaryObject);

            if (remainingMass <= 0)
            {
                break;
            }
        }

        return planetarySystem;
    }
}