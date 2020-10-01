using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze_Diggingmethod : MonoBehaviour
{
    public int Large;

    int[,] Maze;
    public GameObject box;

    void Start()
    {
        Maze = new int[Large,Large];

        //初期設定
        for(int i = 0; i < Large; i++){
            for(int j = 0; j < Large; j++){
                //外側を通路にする
                if(i == 0 || i == Large - 1 || j == 0 || j == Large - 1){
                    Maze[i,j] = 0;
                }
                /*
                else if(i == 2 && j == 2){
                    Maze[i,j] = 2;
                }
                */
                //それ以外を壁に
                else{
                    Maze[i,j] = 1;
                }
            }
        }

        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
