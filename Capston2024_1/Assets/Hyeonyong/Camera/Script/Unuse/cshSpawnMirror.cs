using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshSpawnMirror : MonoBehaviour
{
    public Transform Parent;
    public Transform Mirror;
    public Transform MirrorPos;
    public float Pos = -3f;

   // private int pngNum = 1;
    // Start is called before the first frame update
    public void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            /* Transform newMirror = Instantiate(Mirror, MirrorPos.position + new Vector3(Pos, 0f, 0f), MirrorPos.rotation);
             newMirror.SetParent(Parent);
             Pos=Pos - 3f;*/
            Create();
        }
    }

    public void Create() {
        Transform newMirror = Instantiate(Mirror, MirrorPos.position + new Vector3(Pos, 0f, 0f), MirrorPos.rotation);
        newMirror.SetParent(Parent);
        Pos = Pos - 3f;
    }
}
