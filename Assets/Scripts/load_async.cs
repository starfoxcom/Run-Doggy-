using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class load_async : MonoBehaviour
{

  private AsyncOperation async; //Async operation

  [SerializeField]
  private int level = 0; //Scene number

  [SerializeField]
  private float timeLeft = 5; //Time for animation

  //Coroutine to load the main/game scene on loading scene
  IEnumerator LoadLevelWithBar(int level)
  {

    //while theres still time left
    while (timeLeft > 0)
    {

      yield return null;
    }

    //Assign async op as the scene to load in an async method
    async = SceneManager.LoadSceneAsync(level);
  }

  // Start is called before the first frame update
  private void Start()
  {

    //Start the coroutine
    StartCoroutine(LoadLevelWithBar(level));
  }

  private void Update()
  {

    timeLeft -= Time.deltaTime;
    Debug.Log(timeLeft);
  }
}
