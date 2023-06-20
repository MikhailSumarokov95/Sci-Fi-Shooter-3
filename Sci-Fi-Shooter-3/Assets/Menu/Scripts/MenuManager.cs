using InfimaGames.LowPolyShooterPack;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private SceneAsset[] scenesStoryLevels;
    [SerializeField] private Character player;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject gameUI;

    private void Awake()
    {
        if (!Progress.IsSetDefaultWeapons())
        {
            FindObjectOfType<ShopAttachment>(true).SetDefaultSetting();
            FindObjectOfType<AmmunitionShop>(true).ReplenishAmmunition();
        }
        FindObjectOfType<SkinsShop>(true).Start();
        player.gameObject.SetActive(true);
    }

    private void Start()
    {
        OnPause(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && StateGameManager.StateGame == StateGameManager.State.Game)
            SetActivePausePanel(true);
    }

    public void StartSurvivalGame() => SceneManager.LoadScene(2);

    public void StartStory()
    {
        if (scenesStoryLevels.Length < Level.CurrentLevel) StartSurvivalGame();
        else SceneManager.LoadScene(scenesStoryLevels[Level.CurrentLevel - 1].name);
    }

    public void SetActivePausePanel(bool value)
    {
        OnPause(value);
        pausePanel.SetActive(value);
    }

    public void OnPause(bool value)
    {
        if (!PlatformManager.IsMobile) Cursor.lockState = value ? CursorLockMode.None : CursorLockMode.Locked;
        StateGameManager.StateGame = value ? StateGameManager.State.Pause : StateGameManager.State.Game;
        gameUI.SetActive(!value);
    }
}
