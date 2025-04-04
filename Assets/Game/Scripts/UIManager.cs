using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private PlaneterySystemManager _gameManager;
    [SerializeField] private Button _generateButton;
    [SerializeField] private Button _pauseButton;
    [SerializeField] private TextMeshProUGUI _pauseButtonTextMesh;

    private void OnEnable()
    {
        _generateButton.onClick.AddListener(OnGenerateButtonClicked);
        _pauseButton.onClick.AddListener(OnPauseButtonClicked);
    }

    private void OnDisable()
    {
        _generateButton.onClick.RemoveListener(OnGenerateButtonClicked);
        _pauseButton.onClick.RemoveListener(OnPauseButtonClicked);
    }

    private void OnGenerateButtonClicked()
    {
        _gameManager.GeneratePlaneterySystem();
    }

    private void OnPauseButtonClicked()
    {
        Time.timeScale = Mathf.Abs(Time.timeScale - 1f);

        if (Time.timeScale == 0f)
        {
            _pauseButtonTextMesh.text = "Play";
        }
        else
        {
            _pauseButtonTextMesh.text = "Pause";
        }
    }
}