using System;
using Microsoft.Xna.Framework;
using BananaTheGame.Controllers;

namespace BananaTheGame.Utilty
{
    public class SelectionTool
    {
        private TileHighlight highLight;

        public Vector2Int Location { get; private set; }
        public bool HasTarget { get; private set; }

        public SelectionTool()
        {
            highLight = new TileHighlight();
        }

        public void Select(Vector2Int location)
        {
            Location = location;
            HasTarget = true;
            highLight.Load(location.asVector2(), Color.Blue);
        }

        public void SelectByMouse()
        {
            Vector2 mouseWorldPosition = GameMouseState.WorldPosition();
            Select(new Vector2Int(mouseWorldPosition));
        }
    }
}
