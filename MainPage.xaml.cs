namespace MauiAppMinhasCompras

using System.Collections.ObjectModel;


public partial class MainPage : ContentPage
{
    private ObservableCollection<Product> allProducts;       // Lista original
    private ObservableCollection<Product> filteredProducts;  // Lista filtrada

    public MainPage()
    {
        InitializeComponent();

        allProducts = new ObservableCollection<Product>
        {
            new Product { Name = "Celular", Price = 1500 },
            new Product { Name = "Notebook", Price = 3500 },
            new Product { Name = "Tablet", Price = 1200 },
            new Product { Name = "Fone de Ouvido", Price = 200 },
            new Product { Name = "Monitor", Price = 900 }
        };

        filteredProducts = new ObservableCollection<Product>(allProducts);
        productCollectionView.ItemsSource = filteredProducts;
    }

    private void OnSearchBarTextChanged(object sender, TextChangedEventArgs e)
    {
        string searchTerm = e.NewTextValue?.ToLower() ?? string.Empty;

        filteredProducts.Clear();

        foreach (var product in allProducts)
        {
            if (product.Name.ToLower().Contains(searchTerm))
            {
                filteredProducts.Add(product);
            }
        }
    }
}
