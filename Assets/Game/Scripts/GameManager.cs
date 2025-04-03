using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float totalSystemMass = 10f;
    private PlanetarySystem _planetarySystem;
    private PlanetaryFactory _factory;

    private void Start()
    {
        _factory = new PlanetaryFactory();
        Transform parent = new GameObject("PlanetarySystem").transform;
        _planetarySystem = _factory.Generate(totalSystemMass, parent);
    }

    private void Update()
    {
        _planetarySystem.UpdateSystem(Time.deltaTime);
    }
}