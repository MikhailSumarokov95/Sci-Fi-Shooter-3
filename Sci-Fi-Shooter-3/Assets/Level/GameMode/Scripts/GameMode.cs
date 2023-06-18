using UnityEngine;
using System;
using System.Collections;
using static Spawner;
using static StateGameManager;

public abstract class GameMode : MonoBehaviour
{
    public static GameMode Instance;
    public static Action<Life[]> OnSpawnedEnemies;
    public static Action OnGameWin;
    [SerializeField] private GameObject waveEndPanel;
    [Title(label: "Generals")]
    [SerializeField] protected SpawnBot[] spawnBots;
    [SerializeField] protected SpawnBot[] spawnBoss;
    [SerializeField] protected int delayAfterEndWave = 2;
    [SerializeField] protected int countWave = int.MaxValue;
    protected Life[] _currentEnemyLife;
    protected bool _waveEnd;
    protected LevelManager _levelManager;

    protected int _countKilledEnemyForWave;
    public int CountKilledEnemyForWave { get { return _countKilledEnemyForWave; } }

    private int _numberWave = 0;
    public int NumberWave { get { return _numberWave; } protected set { _numberWave = value; } }

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);
    }

    private void Start()
    {
        _levelManager = FindObjectOfType<LevelManager>();
        StartNewWave();
    }

    private void Update()
    {
        if (_countKilledEnemyForWave == _currentEnemyLife.Length && !_waveEnd)
        {
            if (NumberWave < countWave) StartCoroutine(WaitAndOnWaveEnd());
            else StartCoroutine(WaitAndOnWavesOver());
            _waveEnd = true;
            UnsubscribeOnKillEventEnemy();
        }
    }

    public abstract void StartNewWave();

    protected abstract void IncrementCountKilled();

    protected void SignOnKillEventEnemy(Life[] enemies)
    {
        _currentEnemyLife = enemies;
        foreach (Life enemy in _currentEnemyLife)
            enemy.OnDid += IncrementCountKilled;
    }

    protected void UnsubscribeOnKillEventEnemy()
    {
        foreach (Life enemy in _currentEnemyLife)
            enemy.OnDid -= IncrementCountKilled;
    }

    private void EndWave()
    {
        GSConnect.ShowMidgameAd();
        _levelManager.SetActivePausePanel(false);
        SetActiveWaveEndPanel(true);
    }

    public void SetActiveWaveEndPanel(bool value)
    {
        StateGame = value ? State.WaveEnd : State.Game;
        waveEndPanel.SetActive(value);
        _levelManager.OnPause(value);
        if (!value) StartNewWave();
    }

    private IEnumerator WaitAndOnWaveEnd()
    {
        yield return new WaitForSeconds(delayAfterEndWave);
        EndWave();
    }

    private IEnumerator WaitAndOnWavesOver()
    {
        yield return new WaitForSeconds(delayAfterEndWave);
        _levelManager.WinGame();
    }
}
