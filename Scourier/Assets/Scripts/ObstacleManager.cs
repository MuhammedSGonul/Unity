using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

#if UNITY_EDITOR
[CustomEditor(typeof(ObstacleManager)), CanEditMultipleObjects]
public class PropertyHolderEditor : Editor
{

    public SerializedProperty
        classState,
        typeState;



    void OnEnable()
    {
        classState = serializedObject.FindProperty("obstacleClass");
        typeState = serializedObject.FindProperty("obstacleType");
    }

    public override void OnInspectorGUI()
    {

        var script = (ObstacleManager)target;

        serializedObject.Update();

        EditorGUILayout.PropertyField(classState);
        ObstacleManager.Class cst = (ObstacleManager.Class)classState.enumValueIndex;


        switch (cst)
        {
            case ObstacleManager.Class.existingObstacle:

                script.PlayerFollower = (GameObject)EditorGUILayout.ObjectField("Player Follower", script.PlayerFollower, typeof(GameObject), true);

                EditorGUILayout.Space();
                EditorGUILayout.Space();

                EditorGUILayout.PropertyField(typeState);
                ObstacleManager.Type tst = (ObstacleManager.Type)typeState.enumValueIndex;


                switch (tst)
                {
                    case ObstacleManager.Type.OpenBridge:
                        script.ObstacleOpenBridge_Front = (GameObject)EditorGUILayout.ObjectField("Front", script.ObstacleOpenBridge_Front, typeof(GameObject), true);
                        script.ObstacleOpenBridge_Back = (GameObject)EditorGUILayout.ObjectField("Back", script.ObstacleOpenBridge_Back, typeof(GameObject), true);

                        break;

                    case ObstacleManager.Type.Train:
                        script.ObstacleTrain_Train = (GameObject)EditorGUILayout.ObjectField("Train", script.ObstacleTrain_Train, typeof(GameObject), true);
                        script.ObstacleTrain_FrontBar = (GameObject)EditorGUILayout.ObjectField("Front Bar", script.ObstacleTrain_FrontBar, typeof(GameObject), true);
                        script.ObstacleTrain_BackBar = (GameObject)EditorGUILayout.ObjectField("Back Bar", script.ObstacleTrain_BackBar, typeof(GameObject), true);

                        break;
                }

                break;
        }


        serializedObject.ApplyModifiedProperties();
    }
}
#endif





public class ObstacleManager : MonoBehaviour
{



    public enum Class { spawnedObstacle, existingObstacle }
    public Class obstacleClass;

    public enum Type { Train, OpenBridge };
    public Type obstacleType;

    [HideInInspector] public GameObject PlayerFollower;
    [HideInInspector] public GameObject ObstacleTrain_Train, ObstacleTrain_FrontBar, ObstacleTrain_BackBar, ObstacleOpenBridge_Front, ObstacleOpenBridge_Back;

    [HideInInspector] public float speed, destroyDistance;
    [HideInInspector] public bool[] obstacleDirection = new bool[4];

    private Vector3 zeroPoint;
    private Rigidbody[] ragdollRigidbodies;





    void Start()
    {

        if (obstacleClass == Class.spawnedObstacle)
        {
            zeroPoint = this.transform.position;

            if (transform.tag == "HumanClone")
            {
                ragdollRigidbodies = GetComponentsInChildren<Rigidbody>();
                DisableRagdoll();
            }
        }


    }


    void Update()
    {
        if (obstacleClass == Class.spawnedObstacle)
        {
            MoveOnDirection();
            DestroyFar();
        }
        else
        {
            TriggerObstacle();
        }



    }


    //FOR EXISTING OBSTACLES


    void TriggerObstacle()
    {
        float distance = Vector3.Distance(PlayerFollower.transform.position, transform.position);


        if (distance < 10)
        {

            switch (obstacleType)
            {
                case Type.OpenBridge:
                    ObstacleOpenBridge_Front.transform.rotation = Quaternion.Lerp(ObstacleOpenBridge_Front.transform.rotation, Quaternion.Euler(0, ObstacleOpenBridge_Front.transform.rotation.y, ObstacleOpenBridge_Front.transform.rotation.z), Time.deltaTime * 0.1f * 25);
                    ObstacleOpenBridge_Back.transform.rotation = Quaternion.Lerp(ObstacleOpenBridge_Back.transform.rotation, Quaternion.Euler(0, ObstacleOpenBridge_Back.transform.rotation.y, ObstacleOpenBridge_Back.transform.rotation.z), Time.deltaTime * 0.1f * 25);

                    if(ObstacleOpenBridge_Back.transform.rotation.eulerAngles.x < 5)
                    {
                        transform.GetComponent<BoxCollider>().enabled = false;
                    }

                    break;


                case Type.Train:
                    ObstacleTrain_Train.transform.position = new Vector3(ObstacleTrain_Train.transform.position.x - Time.deltaTime * 50, ObstacleTrain_Train.transform.position.y, ObstacleTrain_Train.transform.position.z);
                    
                    float dist = Vector3.Distance(ObstacleTrain_Train.transform.position, ObstacleTrain_FrontBar.transform.position);
                    if(dist > 50)
                    {
                        ObstacleTrain_FrontBar.transform.rotation = Quaternion.Lerp(ObstacleTrain_FrontBar.transform.rotation, Quaternion.Euler(ObstacleTrain_FrontBar.transform.rotation.x, ObstacleTrain_FrontBar.transform.rotation.y, -90), Time.deltaTime * 0.1f * 25);
                        ObstacleTrain_BackBar.transform.rotation = Quaternion.Lerp(ObstacleTrain_BackBar.transform.rotation, Quaternion.Euler(ObstacleTrain_BackBar.transform.rotation.x, ObstacleTrain_BackBar.transform.rotation.y, -90), Time.deltaTime * 0.1f * 25);
                    }

                    if(ObstacleTrain_FrontBar.transform.rotation.eulerAngles.z < 330 && ObstacleTrain_FrontBar.transform.rotation.eulerAngles.z > 250)
                    {
                        transform.GetComponent<BoxCollider>().enabled = false;
                    }

                    break;
            }
        }
    }


    //FOR EXISTING OBSTACLES



    // FOR SPAWNED OBSTACLES
    void EnableRagdoll()
    {
        foreach (var rigidbody in ragdollRigidbodies)
        {
            rigidbody.isKinematic = false;
        }
    }

    void DisableRagdoll()
    {
        foreach (var rigidbody in ragdollRigidbodies)
        {
            rigidbody.isKinematic = true;
        }
    }


    void DestroyFar()
    {
        float distance = Vector3.Distance(zeroPoint, transform.position);
        if (distance > destroyDistance)
        {
            Destroy(this.gameObject);
        }
    }


    void MoveOnDirection()
    {
        if (obstacleDirection[0] == true)
        {
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
        }
        if (obstacleDirection[1] == true)
        {
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
        }
        if (obstacleDirection[2] == true)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed * Time.deltaTime);
        }
        if (obstacleDirection[3] == true)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed * Time.deltaTime);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "PlayerFollower" || other.tag == "CarClone" || other.tag == "Player" || other.tag == "Scooter") && transform.tag == "CarClone" && obstacleClass == Class.spawnedObstacle)
        {
            speed = 0;
        }
        else if (other.tag == "PlayerFollower" && transform.tag == "HumanClone" && obstacleClass == Class.spawnedObstacle)           //Normal character disable and ragdoll character enable
        {
            speed = 0;

            GetComponent<Animator>().enabled = false;
            EnableRagdoll();
        }

    }
    // FOR SPAWNED OBSTACLES

}
