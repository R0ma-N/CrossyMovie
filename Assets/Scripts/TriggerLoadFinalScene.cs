using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerLoadFinalScene : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        print(999);
        SceneManager.LoadScene(1);
    }
}
