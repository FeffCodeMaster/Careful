using UnityEngine;
using System.Collections;

public class LevelCompleteBackGround : MonoBehaviour
{

    public Vector2 scaleToGo;
    public bool activateMeny, backgroundFinished, parent;
    SpriteRenderer spriteRender;

    LevelCompleteResultBoard levelCompleteResultBoard;
    

    void Start()
    {
        spriteRender = gameObject.GetComponent<SpriteRenderer>();
        spriteRender.enabled = false;
    }


    void Update()
    {
            setSizeOfBackGround();
    }

    private void setSizeOfBackGround()
    {
        if (activateMeny)
        {
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
