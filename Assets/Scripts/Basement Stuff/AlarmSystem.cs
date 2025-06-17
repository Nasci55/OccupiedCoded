using System;
using Unity.VisualScripting;
using UnityEngine;

public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private bool showGizmos;
    [SerializeField, Range(0, 150)] private float safeZoneRadius;
    [SerializeField, Range(0, 150)] private float alertZoneRadius;
    [SerializeField, Range(0, 150)] private float dangerZoneRadius;
    [SerializeField] private LayerMask layerMask;

    public AlarmLevel AlertLevel { get; private set; }
    
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        AlarmLevel newAlarmLevel = AlarmLevel.none;

        
        RaycastHit2D hitSafeZone = Physics2D.CircleCast(transform.position, safeZoneRadius, Vector2.zero, 0, layerMask);
        RaycastHit2D hitAlertZone = Physics2D.CircleCast(transform.position, alertZoneRadius, Vector2.zero, 0, layerMask);
        RaycastHit2D hitDangerZone = Physics2D.CircleCast(transform.position, dangerZoneRadius, Vector2.zero, 0, layerMask);

        if(hitSafeZone.collider != null)
            newAlarmLevel |= AlarmLevel.safeZone;
        if(hitAlertZone.collider != null)
            newAlarmLevel |= AlarmLevel.alertZone;
        if(hitDangerZone.collider != null)
            newAlarmLevel |= AlarmLevel.dangerZone;
        
        AlertLevel = newAlarmLevel;
        
    }

    private void OnDrawGizmos()
    {
        if (showGizmos)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, safeZoneRadius);
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, alertZoneRadius);
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, dangerZoneRadius);
        }
    }
}

[Flags]
public enum AlarmLevel
{
    none = 0,
    safeZone = 1,
    alertZone = 2,
    dangerZone = 4,
}
