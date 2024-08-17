using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class SwingingDecor : MonoBehaviour
{
    public float angleFrom = 0;
    public float angleTo = 45;
    public float animationDuration = 3;
    public float pauseDuration = 0.5f;
    private float _angleFrom = 0;
    private float _angleTo = 45;
    private float time = 0;
    private bool dirForward = true;
    private bool isPaused = false;
    void OnDrawGizmosSelected()
    {
        Vector3 fromPoint = transform.position + Quaternion.AngleAxis(angleFrom, Vector3.forward) * Vector3.right;
        Vector3 toPoint = transform.position + Quaternion.AngleAxis(angleTo, Vector3.forward) * Vector3.right;
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, fromPoint);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, toPoint);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(fromPoint, toPoint);
    }

    void Awake() {
        time = Random.Range(0, Mathf.Max(animationDuration, pauseDuration));
    }

    void rotateToAngle(float angle) {
        this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    void OnValidate() {
        if(angleTo != _angleTo) {
            _angleTo = angleTo;
            rotateToAngle(_angleTo);
        }
        if(angleFrom != _angleFrom) {
            _angleFrom = angleFrom;
            rotateToAngle(_angleFrom);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(EditorApplication.isPlaying) {
            time += Time.deltaTime;
            if(isPaused) {
                if(time > pauseDuration) {
                    isPaused = false;
                    time = 0;
                }
            } else {
                
                float angle;
                if(dirForward) {
                    angle = Mathf.LerpAngle(_angleFrom, _angleTo, time / animationDuration);
                } else {
                    angle = Mathf.LerpAngle(_angleTo, _angleFrom, time / animationDuration);
                }
                rotateToAngle(angle);
                if(time > animationDuration) {
                    time = 0;
                    isPaused = true;
                    dirForward = !dirForward;
                }
            }
        }
    }
}
