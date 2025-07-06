using UnityEngine;

public class AlarmPopUp : MonoBehaviour
{
    [SerializeField] private AlarmSystem alarmSystem;
    [SerializeField]private Sprite[] signSprites;
    
    private SpriteRenderer spriteRenderer;
    private Sprite signSprite;
    private AlarmLevel alarmLevel;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    private void Update()
    {
        alarmLevel = alarmSystem.AlertLevel;
        
        if ((int)alarmLevel == 0)
        {
            signSprite = null;
        }
        if ((int)alarmLevel == 1)
        {
            signSprite = signSprites[0];
        }
        if ((int)alarmLevel == 3)
        {
            signSprite = signSprites[1];
        }
        if ((int)alarmLevel == 7)
        {
            signSprite = signSprites[2];
        }
        
        spriteRenderer.sprite = signSprite;
        
    }

}
