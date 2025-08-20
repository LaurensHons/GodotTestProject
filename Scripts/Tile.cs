using Godot;
using System;

public partial class Tile : Node
{
    public int xCoord { get; set; }
    public int yCoord { get; set; }

    public Tile() {}
    public Tile(Tile tile) {
        xCoord = tile.xCoord;
        yCoord = tile.yCoord;
    }
}
