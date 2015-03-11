using UnityEngine;
using System.Collections;

public class CheckPointButtons : MonoBehaviour
{

    LevelCompleteResultBoard levelCompleteResultBoard;
    Transform transformLevelCompleteResultBoard;
    SpriteRenderer spriteRender;
    int scenesThatsNotIncludedInTheLevelCollection = 0;
    void Start()
    {
        this.transformLevelCompleteResultBoard = GameObject.Find("ResultBoard").transform;
        this.levelCompleteResultBoard = this.transformLevelCompleteResultBoard.GetComponent<LevelCompleteResultBoard>();
        this.spriteRender = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {

		//REFACTOR THIS SHIIT! MAKE METHODES!
        if (this.levelCompleteResultBoard.menyActive)
        {
            if (!this.spriteRender.isVisible)
            {
                this.spriteRender.enabled = true;
            }
        }
        if (transform.name == "NextLevel")
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Collider2D hitCollider = Physics2D.OverlapPoint(mousePosition);

                if (hitCollider)
                {
                    if (hitCollider.transform.name == "NextLevel")
                    {

                        var applicationName = this.NextLevel(Application.loadedLevel);
                        Application.LoadLevel(applicationName);
                    }
                }
            }
        }
        if (transform.name == "ResetLevel")
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Collider2D hitCollider = Physics2D.OverlapPoint(mousePosition);

                if (hitCollider)
                {
                    if (hitCollider.transform.name == "ResetLevel")
                    {
                        var applicationName = Application.loadedLevel;
                        Application.LoadLevel(applicationName);
                    }
                }
            }
        }
    }
    private string NextLevel(int loadedLevelNumber)
    {
        var levelCount = Application.levelCount - scenesThatsNotIncludedInTheLevelCollection;
        loadedLevelNumber = loadedLevelNumber + 1;
        Debug.Log(levelCount + "/" + loadedLevelNumber);
        if (loadedLevelNumber == 0)
        {
            return "Level" + 2;

        }
        if (levelCount != loadedLevelNumber)
        {
            return "Level" + (loadedLevelNumber + 1);
        }
        else
        {
            Debug.Log("INSERT LAST LEVEL LOGIC");
            return Application.loadedLevelName;
        }

    }
}
