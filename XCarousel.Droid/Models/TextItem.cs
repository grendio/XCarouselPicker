using XCarousel.Droid.Interfaces;

namespace XCarousel.Droid.Models
{
	public class TextItem : PickerItem
    {
        public string Text { get; set; }
        public int TextSize { get; set; }

        public int Drawable { get => 0; set => throw new System.NotImplementedException(); }
        public bool HasDrawable { get => false; set => throw new System.NotImplementedException(); }

        public TextItem(string text, int textSize, int id)
        {
            Text = text;
            TextSize = textSize;
        }
    }
}
