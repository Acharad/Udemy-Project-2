using System.Collections;
using System.Collections.Generic;
using UdemyProje.Enums;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UdemyProje.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] int score;

        private const string PLAYER_SCORE = "Player_Score";

        public static GameManager Instance { get; private set; }

        public int Score => score;

        public event System.Action<SceneTypeEnum> OnSceneChanged;
        public event System.Action<int> OnScoreChanged;

        private void Awake()
        {
            SingletonThisObject();
        }

        private IEnumerator Start()
        {
            yield return SceneManager.LoadSceneAsync("Menu", LoadSceneMode.Additive);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("Menu"));

            if (PlayerPrefs.HasKey(PLAYER_SCORE))
            {
                score = PlayerPrefs.GetInt(PLAYER_SCORE);
            }
        }

        private void SingletonThisObject()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
        
        public void SplashScreen(string sceneName)
        {
            SceneTypeEnum sceneType;
            switch (sceneName)
            {
                case "Game":
                    sceneType = SceneTypeEnum.Game;
                    break;
                case "SplashScreen":
                    sceneType = SceneTypeEnum.SplashScreen;
                    break;
                default:
                    sceneType = SceneTypeEnum.Menu;
                    break;
            }
            
            StartCoroutine(SplashScreenAsync(sceneName, sceneType));
        }

        private IEnumerator SplashScreenAsync(string sceneName,SceneTypeEnum sceneType)
        {
            yield return SceneManager.LoadSceneAsync(SceneTypeEnum.SplashScreen.ToString(), LoadSceneMode.Additive);
            OnSceneChanged?.Invoke(SceneTypeEnum.SplashScreen);

            yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());

            SceneManager.SetActiveScene(SceneManager.GetSceneByName("SplashScreen"));

            yield return new WaitForSeconds(5f);

            yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
            yield return SceneManager.LoadSceneAsync(sceneType.ToString(), LoadSceneMode.Additive);

            OnSceneChanged.Invoke(sceneType);

            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneType.ToString()));
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        public void IncreaseScore(int scorePoint)
        {
            score += scorePoint;
            OnScoreChanged?.Invoke(score);
        }

        public void DecreaseScore(int scorePoint)
        {
            score -= scorePoint;
            OnScoreChanged?.Invoke(score);
        }

        public void SaveScore()
        {
            PlayerPrefs.SetInt(PLAYER_SCORE, score);
        }
    }
}