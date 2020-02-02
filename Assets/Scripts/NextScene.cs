using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour {

    public SpriteRenderer cameraOverlay;
    public float fadeDuration;

    private bool loaded = false;
    private float t;

    // Start is called before the first frame update
    void Start() { 
        t = 0;
    }

    // Update is called once per frame
    void Update() {
        if(t < fadeDuration && loaded) {
            t += Time.deltaTime;
            Debug.Log(t);
            float blend = Mathf.Clamp01(t / fadeDuration);
            cameraOverlay.color = Color.Lerp(Color.clear, Color.black, blend);
        } else if(loaded) {
            SceneManager.LoadScene("Level", LoadSceneMode.Single);
        }
        
    }

    void OnTriggerEnter2D(Collider2D coll) {
        loaded = true;
    }
}
