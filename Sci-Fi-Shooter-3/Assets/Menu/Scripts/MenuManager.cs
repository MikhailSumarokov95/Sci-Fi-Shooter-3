using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private SceneAsset[] scenesStoryLevels;

    private void Awake()
    {
        if (!Progress.IsSetDefaultWeapons())
        {
            FindObjectOfType<ShopAttachment>(true).SetDefaultSetting();
            FindObjectOfType<AmmunitionShop>(true).ReplenishAmmunition();
        }
        FindObjectOfType<SkinsShop>(true).Start();
    }

    public void StartSurvivalGame() => SceneManager.LoadScene(2);

    public void StartStory()
    {
        if (scenesStoryLevels.Length < Level.CurrentLevel) StartSurvivalGame();
        else SceneManager.LoadScene(scenesStoryLevels[Level.CurrentLevel - 1].name);
    }
}
