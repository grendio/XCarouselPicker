# XCarousel

## Preview
![](carouselPicker.gif)

### iOS

#### Standard

Note that this UICollectionView customization was designed to work with one row and horizontal scrolling. If you have a different case, create a pull request to see if we can addapt the component to more general needs.

1. Add a new UICollectionView to your view. Within Widget properties, select "XCarouselView" as you CollectionViewType.

2. Create your UICollectionViewCell. There is no known restriction on what can be in here.

3. Create your UICollectionViewDataSource.

4. Wire everything together:

```
    customCollectionView.RegisterNibForCell(CustomCollectionViewCell.Nib, CustomCollectionViewCell.Key);
    customCollectionView.DataSource = new CustomDataSource();
```

Now your project should have a UICollectionView that resembles the behaviour from the Preview gif.
