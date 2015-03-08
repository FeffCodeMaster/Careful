using UnityEngine;
using System.Collections;

public class LevelCompleteResultBoard : MonoBehaviour {

    public bool backgroundFinished,menyActive;
    public Vector2 scaleToGo;
    SpriteRenderer spriteRender;

    Transform transformOfCompleteLevelBackground;
    LevelCompleteBackGround levelCompleteBackground;

	void Start () {
        spriteRender = gameObject.GetComponent<SpriteRenderer>();
        transformOfCompleteLevelBackground = GameObject.Find("CompleteBackground").transform;
        levelCompleteBackground = transformOfCompleteLevelBackground.GetComponent<LevelCompleteBackGround>();
	}
	
	// Update is called once per frame
	void Update () {
         
            setSizeOfBackGround();
        
	}

    private void setSizeOfBackGround()
    {
        if (this.levelCompleteBackground.backgroundFinished)
        {
            this.menyActive = true;
            if (!spriteRender.isVisible)
            {
                spriteRender.enabled = true;
            }
            var scale = transform.localScale;
            if (scale.x < this.scaleToGo.x)
            {
                transform.localScale += transform.right * 0.75f;
            }
            if (scale.x >= this.scaleToGo.x && scale.y < this.scaleToGo.y)
            {
                transform.localScale += transform.up * 0.75f;
            }
            if (scale.y >= this.scaleToGo.y)
            {
                this.backgroundFinished = true;
            }

        }
    }
}
