using UnityEngine;
using System.Collections;

/*
 * A room is a part of the dungeon
 */


/*
public class ByteMatrix{
	byte rows, columns;
}
*/

public class Generation : MonoBehaviour {

	public GameObject   ground, 
						wall,
						startZone;

	public byte         rows,colums;
	
	byte[,] 			map, mapGen;

	public float 		forestDensity;


	void Start(){
		map    = new byte[rows, colums];
		mapGen = new byte[rows, colums];

		//map initialize to 1
		for(int i = 0; i < rows; i++){
			for(int j = 0; j < colums; j++){
				map[i,j]    = 1;
				mapGen[i,j] = 0;
			}
		}
	}


	//Fill the map
	void ComputeMap(){



		//starting area
		for(int i = rows/2 - 3; i < (colums/2 + 3); i++){
			for(int j = rows/2 - 3; j < (colums/2 + 3); j++){
				map[i,j] = 0;
				makePath(i,j);
			}
		}

		startZone.transform.position = new Vector3(rows/2,2,colums/2);

		DrawMap();
	}

	//Instanciate the map
	void DrawMap(){

		for(int i = 0; i < rows; i++){
			for(int j = 0; j < colums; j++){
				
				switch(map[i,j]){
					// 1 == wall
				case 1:
					Instantiate(this.wall, new Vector3(i, 0.5f, j), Quaternion.identity);
					break;
					// 0 ground
				case 0 : 
					Instantiate(this.ground, new Vector3(i, 0, j), Quaternion.identity);
					break;
				}
			}
		}
	}
			
			
	//generate forest
	int makePath(int i, int j){

		if( (i >= (rows - 1) ) || ( j >= (colums-1) ) || (i < 1) || (j < 1) || (mapGen[i,j] == 1) ){
			//print("stop");
			return 0;
		}else{

			//we dealt this case
			mapGen[i,j] = 1;
			
			//proba pour sol
			if(Random.value < forestDensity){
				map[i,j] = 0;

				//on continue le chemin
				//print("ground");
								
				//haut
				makePath(i+1,j);
				//droite
				makePath(i,j+1);
				//bas
				makePath(i-1,j);
				//gauche
				makePath(i,j-1);

			}else{
				return 0;
			}



			return 1;
		}
	}

	void OnGUI () {

		if (GUI.Button (new Rect (10,10,120,50), "Generate map")) {
			this.ComputeMap();
		}

		if (GUI.Button (new Rect (10,70,120,110), "Reset")) {
			Application.LoadLevel("main");
		}
	}
}
