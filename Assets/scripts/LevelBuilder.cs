using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{

    [SerializeField] GameObject paddle;
    [SerializeField] Transform paddleLocation;
    [SerializeField] GameObject block;
    [SerializeField] GameObject[] blockList;
    float boxW, boxH, xgap, ygap;
    int boxinrow;
    Vector2 spawnPoint;




    private void Awake()
    {
        BoxCollider2D bCol = block.GetComponent<BoxCollider2D>();
        boxW = bCol.size.x;
        boxH = bCol.size.y;
        xgap = boxW / 2;
        ygap = boxH / 2;
        float screenWidth = ScreenUtils.ScreenRight-ScreenUtils.ScreenLeft-xgap;
        
        float di = boxW + xgap;
        boxinrow = (int)(screenWidth / di);

        //Debug.Log("ScreenWidth: " + screenWidth);
        //Debug.Log("boxes: " + boxinrow);
        //Debug.Log("di: " + di);
        //Debug.Log("xgap: " + xgap);
        //Debug.Log("ScreenLeft: " + ScreenUtils.ScreenLeft);
        //Debug.Log("ScreenRight: " + ScreenUtils.ScreenRight);
        //Debug.Log("boxW: " + boxW);






    }

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(paddle, paddleLocation.position, Quaternion.identity);

        buildLevel();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void buildLevel()
    {
        spawnPoint = new Vector2(ScreenUtils.ScreenLeft + 2 * xgap, ScreenUtils.ScreenTop - 2 * ygap);
        for(int i=0;i<3;i++)
        {
            for(int j=0;j<boxinrow;j++)
            {
                float x = spawnPoint.x + j * 3 * xgap;
                float y = spawnPoint.y;
                Instantiate(randomBlock(), new Vector3(x, y, 0),Quaternion.identity);
                
            }
            spawnPoint.y = spawnPoint.y - 3 * ygap;
        }
    }

    GameObject randomBlock()
    {
        GameObject ob = new GameObject();
        int r = Random.Range(0, 10);
        if(r<5)
        {
            return blockList[0];
        }
        else if(r<8)
        {
            return blockList[1];
        }
        else
        {
            return blockList[2];
        }

        return ob;
    }
            
}
