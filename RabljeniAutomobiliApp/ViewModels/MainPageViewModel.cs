using System.Collections.ObjectModel;
using System.Windows.Input;
using RabljeniAutomobiliApp.Models;

namespace RabljeniAutomobiliApp.ViewModels;

public class MainPageViewModel : BindableObject
{
    public ObservableCollection<Car> Cars { get; set; }

    public ObservableCollection<Car> FilteredCars { get; set; }

    private string searchText = "";

    public string SearchText
    {
        get => searchText;
        set
        {
            searchText = value;
            OnPropertyChanged();
            FilterCars();
        }
    }

    public ICommand SortAscendingCommand { get; }

    public ICommand SortDescendingCommand { get; }

    public MainPageViewModel()
    {
        Cars = new ObservableCollection<Car>
        {
            new Car
            {
                Name = "Audi A6",
                Description = "Odličan Audi A6 automatik.",
                Price = 22000,
                Image = "audi.jpg"
            },

            new Car
            {
                Name = "BMW Serija 3",
                Description = "Sportski BMW sa M paketom.",
                Price = 26000,
                Image = "bmw.jpg"
            },

            new Car
            {
                Name = "Mercedes C220",
                Description = "Luksuzni Mercedes.",
                Price = 30000,
                Image = "mercedes.jpg"
            }
        };

        FilteredCars = new ObservableCollection<Car>(Cars);

        SortAscendingCommand = new Command(SortAscending);

        SortDescendingCommand = new Command(SortDescending);
    }

    private void FilterCars()
    {
        FilteredCars.Clear();

        var filtered = Cars.Where(x =>
            x.Name != null &&
            x.Name.ToLower().Contains(SearchText.ToLower()));

        foreach (var car in filtered)
        {
            FilteredCars.Add(car);
        }
    }

    private void SortAscending()
    {
        var sorted = FilteredCars.OrderBy(x => x.Price).ToList();

        FilteredCars.Clear();

        foreach (var car in sorted)
        {
            FilteredCars.Add(car);
        }
    }

    private void SortDescending()
    {
        var sorted = FilteredCars.OrderByDescending(x => x.Price).ToList();

        FilteredCars.Clear();

        foreach (var car in sorted)
        {
            FilteredCars.Add(car);
        }
    }
}