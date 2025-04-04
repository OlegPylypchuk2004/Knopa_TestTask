using System.Collections.Generic;

public class PlaneterySystem : IPlaneterySystem
{
    private List<IPlaneteryObject> _planeteryObjects;

    public PlaneterySystem(List<IPlaneteryObject> planeteryObjects)
    {
        _planeteryObjects = planeteryObjects;
    }

    public IEnumerable<IPlaneteryObject> PlaneteryObjects => _planeteryObjects;

    public void Update(float deltaTime)
    {
        foreach (PlaneteryObject planeteryObject in _planeteryObjects)
        {
            planeteryObject.UpdatePosition(deltaTime);
        }
    }
}