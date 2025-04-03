using UnityEngine;

public class PlanetaryObjectView : MonoBehaviour
{
    private PlanetaryObject _planetaryObject;

    public void Initialize(PlanetaryObject planetaryObject)
    {
        _planetaryObject = planetaryObject;
    }
}