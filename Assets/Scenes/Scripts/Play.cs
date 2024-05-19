using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{   
    [SerializeField] Canvas start;
    [SerializeField] Canvas mid;
    [SerializeField] Canvas end;
    [SerializeField] MoveToFood fish;
    
    private void Start() {
        PauseGame();
    }

    private void Update() {
        if(fish.point <= 0){
            PauseGame();
            end.gameObject.SetActive(true);
        }
    }
    
    void PauseGame ()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame ()
    {
        Time.timeScale = 1;
    }
}
