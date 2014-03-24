using UnityEngine;
using System.Collections;

/*
 * the Forest is a puzzle of tiles
 */

public enum TileType { StartingZone, ForestTile, TreeTile,
	NothEndOfForestTile, SouthEndOfForestTile, EastEndOfForestTile, WestEndOfForestTile };


public class ForestTile : MonoBehaviour {

	public GameObject   ground, 
						wall,
						startZone;

	public byte         rows,colums;
	
	public byte[,] 		map, mapGen;

	public TileType		type;

	public float 		forestDensity;

	public ForestTile   northNeighbour,SouthNeighbour,eastNeighbour,westNeighbour;

	public void ForestTileInit(byte _rows, byte _columns, float _density){
		this.rows          = _rows;
		this.colums        = _columns;
		this.forestDensity = _density;

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

	//Instanciate the map
	public void DrawMap(){
		for(int i = 0; i < rows; i++){
			for(int j = 0; j < colums; j++){
				
				switch(map[i,j]){
					// 1 == wall
				case 1:
					GameObject w = Instantiate(this.wall, new Vector3(i, j,0.5f), Quaternion.identity) as GameObject;

					w.transform.parent = this.transform;
					w.transform.localPosition = new Vector3(i, j,0.5f);

					break;
					// 0 ground
				case 0 : 
					GameObject g = Instantiate(this.ground, new Vector3(i, j,0.5f), Quaternion.identity) as GameObject;

					g.transform.parent = this.transform;
					g.transform.localPosition = new Vector3(i, j,0.5f);

					break;
				}
			}
		}
	}

	//Fill the map
	public void ComputeTile(){

		switch (this.type){
		case TileType.StartingZone :
			//starting area
			for(int i = rows/2 - 3; i < (rows/2 + 3); i++){
				for(int j = colums/2 - 3; j < (colums/2 + 3); j++){
					map[i,j] = 0;
					makePath(i,j);
				}
			}
			break;
		case TileType.NothEndOfForestTile:
			//starting area
			for(int i = 1; i < (rows - 1); i++){
				map[i,0] = 0;
				makePath(i,0);
			}
			break;
		case TileType.SouthEndOfForestTile:
			//starting area
			for(int i = 1; i < (rows - 1); i++){
				map[i,colums -1] = 0;
				makePath(i,colums -1);
			}
			break;
		case TileType.EastEndOfForestTile:
			//starting area
			for(int i = 1; i < (colums - 1); i++){
				map[0,i] = 0;
				makePath(0,i);
			}
			break;
		case TileType.WestEndOfForestTile:
			//starting area
			for(int i = 1; i < (colums - 1); i++){
				map[colums - 1,i] = 0;
				makePath(colums - 1,i);
			}
			break;
		case TileType.TreeTile:
			//nothing
			break;
		}




		//we move the payer to the starting zone
		if( this.type == TileType.StartingZone)
			GameObject.Find("Startzone").transform.position = new Vector3(rows/2,colums/2,0);

	}
		
	//generate forest
	int makePath(int i, int j){

		//0 => no border
		//1 => border
		byte northBorder, southBorder, eastBorder, westBorder;

		northBorder = 0;
		southBorder = 0;
		eastBorder  = 0;
		westBorder  = 0;

		switch(this.type){

		case TileType.StartingZone:
		case TileType.ForestTile:
			break;
		case TileType.NothEndOfForestTile:
			northBorder = 1;
			eastBorder  = 1;
			westBorder  = 1;
			break;
		case TileType.SouthEndOfForestTile:
			southBorder = 1;
			eastBorder  = 1;
			westBorder  = 1;
			break;
		case TileType.EastEndOfForestTile:
			northBorder = 1;
			southBorder = 1;
			eastBorder  = 1;
			break;
		case TileType.WestEndOfForestTile:
			northBorder = 1;
			southBorder = 1;
			westBorder  = 1;
			break;
		}

		if( (i >= (rows - eastBorder) ) || ( j >= (colums-northBorder) ) || (i < westBorder) || (j < southBorder) || (mapGen[i,j] == 1) ){
			//end of the road
			return 0;
		}else{
			//we dealt this case
			mapGen[i,j] = 1;
			//proba pour sol
			if(Random.value < forestDensity){
				map[i,j] = 0;
				//haut
				makePath(i+1,j);
				//droite
				makePath(i,j+1);
				//bas
				makePath(i-1,j);
				//gauche
				makePath(i,j-1);
				return 1;
			}else{
				return 0;
			}
		}
	}
}
