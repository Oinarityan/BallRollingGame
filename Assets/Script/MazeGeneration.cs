using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGeneration : MonoBehaviour
{
    public int Large;

    int[,] Maze;
    public GameObject wall;
    public GameObject gorund;
    public GameObject Goal;



    void Start()
    {
        Maze = new int[Large,Large];


        for(int i = 0; i < Large; i++){
            for(int j = 0; j < Large; j++){
                if(i == 0 || i == Large - 1 || j == 0 || j == Large - 1){
                    Maze[i,j] = 1;
                }
                else if(i % 2 == 0 && j % 2 == 0 && i != 0 && j != 0){
                    Maze[i,j] = 2;
                }
                /*
                else if(i == 2 && j == 2){
                    Maze[i,j] = 2;
                }
                */
                else{
                    Maze[i,j] = 0;
                }
            }
        }

        /*
         1
        4#2
         3
        */

        for(int i = 0;i < Large; i++){
            for(int j = 0; j < Large; j++){
                int index = 0;
                if(Maze[i,j] == 2){
                    if(i == 2){
                        index = Random.Range(1,5);
                    }
                    //最後の壁の設定　2か3にする
                    else if(i == Large - 3 && j == Large -3){
                        index = Random.Range(2,4);
                    }
                    else{
                        index = Random.Range(2,5);
                    }
                    
                    if(index == 1){
                        Maze[i-1,j] = 1;
                    }

                    if(index == 4){
                        if(Maze[i,j-1] == 1){
                            index = Random.Range(2,4);
                        }
                        else{
                            Maze[i,j-1] = 1;
                        }
                    }

                    if(index == 2){
                        Maze[i,j+1] = 1;
                    }

                    if(index == 3){
                        Maze[i+1,j] = 1;
                    }
                    //2を1に戻す
                    Maze[i,j] = 1;
                }

            }
        }

        for(int i = 0;i < Large; i++){
            for(int j = 0; j < Large; j++){
                if(Maze[i,j] == 1){
                    Instantiate(wall, new Vector3(i,0,j), Quaternion.identity);
                }
            }
        }
        for(int i = 0;i < Large; i++){
            for(int j = 0; j < Large; j++){
                if(i == Large - 2 && j == Large -2){
                    Instantiate(Goal, new Vector3(i,-1,j), Quaternion.identity);
                }
                else{
                    Instantiate(gorund, new Vector3(i,-1,j), Quaternion.identity);
                }
            }
        }
    }

    void Update()
    {

    }
}
