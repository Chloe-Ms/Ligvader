using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderEnemies : MonoBehaviour
{
    private static LoaderEnemies instance;
    [SerializeField] List<GameObject> _mobileEnemies;
    [SerializeField] float _secBeforeRespawnMobile = 10;
    [SerializeField] float _secBeforeFirstSpawnMobile = 1;
    [SerializeField] List<GameObject> _ufoEnemies;
    [SerializeField] float _secBeforeRespawnUFO = 40;
    [SerializeField] float _secBeforeFirstSpawnUFO = 2;
    [SerializeField] List<GameObject> _staticEnemies;
    [SerializeField] float[] _timerChangeLevelEnemies;

    float _timer;
    int _indexArrayLevelEnemies = 0;
    int _numberOfEnemies = 0;
    int _numberOfWaves = 1;
    int _numberOfWavesLeft;
    bool isLoadingEnemies = false;
    bool isLoadingMobileEnemies = false;
    bool isLoadingUFOEnemies = false;
    bool loadNewEnemies = false;
    bool loadNewMobileEnemies = false;
    bool loadNewUFOEnemies = false;
    public bool LoadNewEnemies
    {
        get { return loadNewEnemies; }
        set { loadNewEnemies = value; }
    }
    public static LoaderEnemies Instance {
        get { return instance; }
        private set { instance = value; }
    }

    void Awake()
    {
        Debug.Log("Awake");
        if (instance != null && instance != this)
            Destroy(gameObject);  

        instance = this;
        LoadNewStaticEnemies();
    }

    public void Start()
    {
        Debug.Log("start");
        StartCoroutine(SpawnMobileEnemy(_secBeforeFirstSpawnMobile));
        StartCoroutine(SpawnUFOEnemy(_secBeforeFirstSpawnUFO));
        _numberOfWavesLeft = _numberOfWaves;
        _timer = 0f;
    }

    public void CheckLoadMobileEnemies(GameObject go)
    {
        FollowPath followScript = go.GetComponent<FollowPath>();
        if (followScript != null) //If the enemy move, it has the follow enemy script
        {
            if (followScript.Loop)
            {
                loadNewMobileEnemies = true;
                //Mobile
                //(SpawnMobileEnemy(_secBeforeRespawnMobile));
            } else
            {
                //UFO
                loadNewUFOEnemies = true;
            }
        }
    }

    public void DecreaseNumberOfWaves()
    {
        _numberOfWavesLeft--;
        if (_numberOfWavesLeft <= 0)
        {
            loadNewEnemies = true;
        }

    }

    private IEnumerator SpawnMobileEnemy(float secToWait)
    {
        /*if (!isLoadingMobileEnemies)
        {
            isLoadingMobileEnemies = true;*/
            //Debug.Log("Before spawn Mobile");
            yield return new WaitForSeconds(secToWait);
            //Debug.Log("After spawn Mobile");
            if (_mobileEnemies.Count != 0)
            {
                int index = Random.Range(0, _mobileEnemies.Count);

                Instantiate(_mobileEnemies[index]);
            }
          /*  isLoadingMobileEnemies = false;
        }*/
    }

    private IEnumerator SpawnUFOEnemy(float secToWait)
    {
       /* if (!isLoadingUFOEnemies)
        {
            isLoadingUFOEnemies = true;*/
            //Debug.Log("Before spawn UFO");
            yield return new WaitForSeconds(secToWait);
            //Debug.Log("After spawn UFO");
            if (_ufoEnemies.Count != 0)
            {
                int index = Random.Range(0, _ufoEnemies.Count);

                Instantiate(_ufoEnemies[index]);
            }
          //  isLoadingUFOEnemies = false;
        //}
    }

    public void LoadNewStaticEnemies()
    {

        for(int i = 0; i < _numberOfWaves; i++)
        {
            if (_staticEnemies.Count == 0)
                return;
            int index = Random.Range(0, _staticEnemies.Count);

            Instantiate(_staticEnemies[index]);
        }
        _numberOfWavesLeft = _numberOfWaves;
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_indexArrayLevelEnemies < _timerChangeLevelEnemies.Length && _timer > _timerChangeLevelEnemies[_indexArrayLevelEnemies])
        {
            _numberOfWaves++;
            _indexArrayLevelEnemies++;
        }
        if (loadNewEnemies && !isLoadingEnemies)
        {
            isLoadingEnemies = true;
            LoadNewStaticEnemies();
            loadNewEnemies = false;
            isLoadingEnemies = false;
        }

        if (loadNewMobileEnemies && !isLoadingMobileEnemies)
        {
            isLoadingMobileEnemies = true;
            StartCoroutine(SpawnMobileEnemy(_secBeforeRespawnMobile));
            loadNewMobileEnemies = false;
            isLoadingMobileEnemies = false;
        }

        if (loadNewUFOEnemies && !isLoadingUFOEnemies)
        {
            isLoadingUFOEnemies= true;
            StartCoroutine(SpawnUFOEnemy(_secBeforeRespawnUFO));
            loadNewUFOEnemies = false;
            isLoadingUFOEnemies = false;
        }
    }

    public void Restart()
    {
        _numberOfWaves = 1;
        _numberOfWavesLeft = _numberOfWaves;
    }
}
