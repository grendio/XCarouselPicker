namespace XCarousel.Droid.Interfaces
{
    public interface PickerItem
    {
        string Text { get; set; }
        int Drawable { get; set; }
        bool HasDrawable { get; set; }
    }
}
