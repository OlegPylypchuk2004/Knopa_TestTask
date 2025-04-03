using System.Collections.Generic;
using UnityEngine;

public class PlanetarySystem
{
    private List<PlanetaryObject> _planets = new List<PlanetaryObject>();

    public void AddPlanet(PlanetaryObject planet)
    {
        _planets.Add(planet);
    }

    public IEnumerable<PlanetaryObject> GetPlanets()
    {
        return _planets;
    }

    public void UpdateSystem(float deltaTime)
    {
        foreach (var planet in _planets)
        {
            planet.UpdatePosition(deltaTime);
        }
    }
}