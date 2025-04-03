using UnityEngine;

public class PlanetaryObjectFactory
{
    private MassSpecificationData[] _massSpecificationDatas;
    private PlanetaryObjectView _planetaryObjectViewPrefab;

    public PlanetaryObjectFactory()
    {
        _massSpecificationDatas = Resources.LoadAll<MassSpecificationData>("Data/MassSpecifications");
        _planetaryObjectViewPrefab = Resources.Load<PlanetaryObjectView>("Prefabs/PlanetaryObjectView");
    }

    public PlanetaryObject Create(float mass, Transform parent)
    {
        Vector3 orbitCenter = Vector3.zero;
        float orbitRadius = Random.Range(5f, 50f);
        float orbitSpeed = Random.Range(0.1f, 2f);

        PlanetaryObjectView planetaryObjectView = SpawnPlanetaryObjectView(parent);
        PlanetaryObjectData planetaryObjectData = new PlanetaryObjectData(orbitCenter, orbitRadius, orbitSpeed, planetaryObjectView.transform);
        PlanetaryObject planetaryObject = new PlanetaryObject(mass, DetermineMassSpecificationData(mass), planetaryObjectData);

        planetaryObjectView.Initialize(planetaryObject);

        return planetaryObject;
    }

    public MassSpecificationData DetermineMassSpecificationData(float mass)
    {
        for (int i = 0; i < _massSpecificationDatas.Length; i++)
        {
            if (_massSpecificationDatas[i].MinMass <= mass && _massSpecificationDatas[i].MaxMass >= mass)
            {
                return _massSpecificationDatas[i];
            }
        }

        return null;
    }

    private PlanetaryObjectView SpawnPlanetaryObjectView(Transform parent)
    {
        return GameObject.Instantiate(_planetaryObjectViewPrefab, parent);
    }
}