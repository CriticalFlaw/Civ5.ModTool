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
        public byte Alpha;
        public byte Blue;
        public byte Green;
        public byte Red;
        public string Type;
    }
}