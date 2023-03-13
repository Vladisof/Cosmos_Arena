using Core.Factory;
using Core.InputController;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private TMP_Text _textKillEnemy;
    
    public void Restart()
    {
        ActiveUnitsSingleton.Instance.Reset();
        ReactDeadEnemySingleton.Instance.Reset();
        SceneManager.LoadScene("Scenes/SampleScene");
    }
    
    private void Start()
    {
        _textKillEnemy.text = $"Enemies killed {ReactDeadEnemySingleton.Instance.SumDeadEnemy}";
    }
}
