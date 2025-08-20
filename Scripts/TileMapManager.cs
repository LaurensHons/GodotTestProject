using Godot;
using System;
using System.Collections.Generic;

public struct Coord
{
	public int X;
	public int Y;

	public Coord(int x, int y)
	{
		X = x;
		Y = y;
	}
}

public partial class TileMapLayer : Godot.TileMapLayer
{
	[Export] private int MapSize { get; set; } = 20;
	public Dictionary<Coord, Tile> _tiles { get; set; }

	public override void _Ready() {
		base._Ready();
		FillWithTileCopy();
	}

	private void FillWithTileCopy() {
		var tileset = new TileSet();
		for (int x = 0; x < MapSize; x++)
		{
			for (int y = 0; y < MapSize; y++)
			{
				_tiles[new Coord(x, y)] = new Tile() { xCoord = x, yCoord = y };
			}
		}
	}

}
