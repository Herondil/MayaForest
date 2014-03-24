using UnityEngine;
using System.Collections;

public class ForestBuilder : MonoBehaviour {
		
	public byte StartingZoneRows,StartingZoneColums;
	public float StartingZoneDensity, EndOfForestDensity;
	public GameObject forestTile;
	void Init(){
		//tiles = new ForestTile[10];
	}

	void ComputeMap(){

		//GameObject firstTile = new ForestTile(StartingZoneRows,StartingZoneColums,StartingZoneDensity);
		GameObject firstTile = Instantiate(this.forestTile, new Vector3(0,0,0), Quaternion.identity) as GameObject;
		firstTile.name = "Starting Zone";
		firstTile.transform.parent = this.transform;
		ForestTile ft = firstTile.GetComponent<ForestTile>();
		ft.ForestTileInit(StartingZoneRows,StartingZoneColums,StartingZoneDensity);
		ft.type = TileType.StartingZone;
		ft.ComputeTile();
		ft.DrawMap();

		GameObject NorthTile = Instantiate(this.forestTile, new Vector3(0,10,0), Quaternion.identity) as GameObject;
		NorthTile.name = "North Dead End Zone";
		NorthTile.transform.parent = this.transform;
		ft = NorthTile.GetComponent<ForestTile>();
		ft.ForestTileInit(StartingZoneRows,StartingZoneColums,EndOfForestDensity);
		ft.type = TileType.NothEndOfForestTile;
		ft.ComputeTile();
		ft.DrawMap();

		GameObject SouthTile = Instantiate(this.forestTile, new Vector3(0,-10,0), Quaternion.identity) as GameObject;
		SouthTile.name = "South Dead End Zone";
		SouthTile.transform.parent = this.transform;
		ft = SouthTile.GetComponent<ForestTile>();
		ft.ForestTileInit(StartingZoneRows,StartingZoneColums,EndOfForestDensity);
		ft.type = TileType.SouthEndOfForestTile;
		ft.ComputeTile();
		ft.DrawMap();

		GameObject EastTile = Instantiate(this.forestTile, new Vector3(10,0,0), Quaternion.identity) as GameObject;
		EastTile.name = "East Dead End Zone";
		EastTile.transform.parent = this.transform;
		ft = EastTile.GetComponent<ForestTile>();
		ft.ForestTileInit(StartingZoneRows,StartingZoneColums,EndOfForestDensity);
		ft.type = TileType.EastEndOfForestTile;
		ft.ComputeTile();
		ft.DrawMap();

		GameObject WestTile = Instantiate(this.forestTile, new Vector3(-10,0,0), Quaternion.identity) as GameObject;
		WestTile.name = "West Dead End Zone";
		WestTile.transform.parent = this.transform;
		ft = WestTile.GetComponent<ForestTile>();
		ft.ForestTileInit(StartingZoneRows,StartingZoneColums,EndOfForestDensity);
		ft.type = TileType.WestEndOfForestTile;
		ft.ComputeTile();
		ft.DrawMap();

		GameObject Tree1 = Instantiate(this.forestTile, new Vector3(10,10,0), Quaternion.identity) as GameObject;
		Tree1.name = "Trees";
		Tree1.transform.parent = this.transform;
		ft = Tree1.GetComponent<ForestTile>();
		ft.ForestTileInit(StartingZoneRows,StartingZoneColums,EndOfForestDensity);
		ft.type = TileType.TreeTile;
		ft.ComputeTile();
		ft.DrawMap();

		GameObject Tree2 = Instantiate(this.forestTile, new Vector3(-10,10,0), Quaternion.identity) as GameObject;
		Tree2.name = "Trees";
		Tree2.transform.parent = this.transform;
		ft = Tree2.GetComponent<ForestTile>();
		ft.ForestTileInit(StartingZoneRows,StartingZoneColums,EndOfForestDensity);
		ft.type = TileType.TreeTile;
		ft.ComputeTile();
		ft.DrawMap();

		GameObject Tree3 = Instantiate(this.forestTile, new Vector3(10,-10,0), Quaternion.identity) as GameObject;
		Tree3.name = "Trees";
		Tree3.transform.parent = this.transform;
		ft = Tree3.GetComponent<ForestTile>();
		ft.ForestTileInit(StartingZoneRows,StartingZoneColums,EndOfForestDensity);
		ft.type = TileType.TreeTile;
		ft.ComputeTile();
		ft.DrawMap();

		GameObject Tree4 = Instantiate(this.forestTile, new Vector3(-10,-10,0), Quaternion.identity) as GameObject;
		Tree4.name = "Trees";
		Tree4.transform.parent = this.transform;
		ft = Tree4.GetComponent<ForestTile>();
		ft.ForestTileInit(StartingZoneRows,StartingZoneColums,EndOfForestDensity);
		ft.type = TileType.TreeTile;
		ft.ComputeTile();
		ft.DrawMap();
	}



	void OnGUI () {
		
		if (GUI.Button (new Rect (10,10,120,50), "Generate map")) {
			this.ComputeMap();
		}
		
		if (GUI.Button (new Rect (10,70,120,50), "Reset")) {
			Application.LoadLevel("main");
		}

		GUI.Label(new Rect(20, 130, 120, 50),"Mouse Scrool to zoom/dezoom keyboard arrows to move");
	}
}
