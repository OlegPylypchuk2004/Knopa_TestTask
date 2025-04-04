using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private PlanetarySystemManager _gameManager;
    [SerializeField] private Button _generateButton;

    private void OnEnable()
    {
        _generateButton.onClick.AddListener(OnGenerateButtonClicked);
    }

    private void OnDisable()
    {
        _generateButton.onClick.RemoveListener(OnGenerateButtonClicked);
    }

    private void OnGenerateButtonClicked()
    {
        _gameManager.GeneratePlanetarySystem();
    }
}