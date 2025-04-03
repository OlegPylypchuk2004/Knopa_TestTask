using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float _totalSystemMass;
    [SerializeField] private int _planetsCount;

    private PlanetarySystem _planetarySystem;
    private PlanetaryObjectFactory _planetaryObjectFactory;
    private PlanetaryFactory _planetaryFactory;

    private void Start()
    {
        _planetaryObjectFactory = new PlanetaryObjectFactory();
        _planetaryFactory = new PlanetaryFactory(_planetaryObjectFactory);

        CreatePlanetarySystem();
    }

    private void Update()
    {
        if (_planetarySystem != null)
        {
            _planetarySystem.UpdateSystem(Time.deltaTime);
        }
    }

    private void CreatePlanetarySystem()
    {
        Transform parent = new GameObject("PlanetarySystem").transform;
        _planetarySystem = _planetaryFactory.Generate(_totalSystemMass, parent, _planetsCount);
    }
}