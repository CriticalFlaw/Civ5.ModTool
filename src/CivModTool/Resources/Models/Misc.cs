using System.Windows.Media;

namespace CivModTool.Models
{
    internal class GameText
    {
        public string Tag;
        public string Text;
    }

    internal class IconAtlas
    {
        public string Atlas;
        public string Filename;
        public int IconSize;
        public int IconsPerColumn;
        public int IconsPerRow;
    }

    internal class PlayerColor
    {
        public string Type;
        public Color Color;
    }
}