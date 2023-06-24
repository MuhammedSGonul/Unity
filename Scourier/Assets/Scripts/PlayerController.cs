using UnityEngine;
using PathCreation;

public class PlayerController : MonoBehaviour
{

    

    [SerializeField] private GameObject PlayerFollow;
    [SerializeField] private GameObject Camera;

    [SerializeField] private PlayerColliderManager crashManager;
    [SerializeField] private PathCreation.Examples.PathFollower PathFollower;
    [SerializeField] private GameObject[] Paths;

    private int pathNum = 0;
    private float maxSpeed = 100f, accSpeed = 1f, slwdwnSpeed = 1.3f;
    private bool crashed, pathFinished, finished, isDragging = false;


    float dokunmaOrijin = 0, karakterOrijin = 0, hedefKarakter, esik;

    

    void Start()
    {

        PathFollower.pathCreator = Paths[pathNum].GetComponent<PathCreator>();
    }


    void Update()
    {
        Movement();
        ChangePath();
        DragMovement();
    }





    void ChangePath()
    {
        if (PathFollower.isPathChanged == true && pathNum < Paths.Length - 1)
        {
            pathNum = pathNum + 1;
            PathFollower.pathCreator = Paths[pathNum].GetComponent<PathCreator>();

            PathFollower.isPathChanged = false;
            PathFollower.distanceTravelled = 0;
        }
        else if (PathFollower.isPathChanged == true && pathNum >= Paths.Length - 1)
        {
            PathFollower.speed = 0;
            pathFinished = true;
            PathFollower.pathCreator = null;
        }

    }

    void Movement()
    {
        crashed = crashManager.crashed;


        if (Input.GetMouseButton(0) && !crashed && !finished)
        {

            PathFollower.speed += accSpeed;
            if (PathFollower.speed > maxSpeed)
            {
                PathFollower.speed = maxSpeed;
            }
        }
        else if (!Input.GetMouseButton(0) && PathFollower.speed != 0 && !crashed && !finished)
        {

            PathFollower.speed -= slwdwnSpeed;
            if (PathFollower.speed < 1f)
            {
                PathFollower.speed = 0f;
            }
        }
        if (crashed == true)
        {
            PathFollower.speed = 0f;
        }

    }

    void DragMovement()
    {
        if (pathFinished && !isDragging)
        {
            dokunmaOrijin = Input.mousePosition.x;
            karakterOrijin = PlayerFollow.transform.position.x;
            esik = PlayerFollow.transform.position.x;
            isDragging = true;

        }
        
        
        if (pathFinished && isDragging)
        {
            PlayerFollow.transform.position = new Vector3(PlayerFollow.transform.position.x, 0, PlayerFollow.transform.position.z + 20 * Time.deltaTime);
            PlayerFollow.transform.rotation = Quaternion.Euler(0, 0, 0);

            if (Input.GetMouseButtonDown(0))
            {
                dokunmaOrijin = Input.mousePosition.x;
                karakterOrijin = PlayerFollow.transform.position.x;
            }

            if (Input.GetMouseButton(0))
            {
                hedefKarakter = karakterOrijin + ((Input.mousePosition.x - dokunmaOrijin) * 0.01f);

                if (hedefKarakter > esik + 3) hedefKarakter = esik + 3;
                if (hedefKarakter < esik - 3) hedefKarakter = esik - 3;

                PlayerFollow.transform.position = Vector3.Lerp(PlayerFollow.transform.position, new Vector3(hedefKarakter, 0, PlayerFollow.transform.position.z), 0.5f);
            }
            

        }

        







    }



}
