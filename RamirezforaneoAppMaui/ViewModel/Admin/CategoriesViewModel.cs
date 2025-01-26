using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using RamirezforaneoAppMaui.Models.Admin;
using RamirezforaneoAppMaui.Services;
using CommunityToolkit.Mvvm.Input;

namespace RamirezforaneoAppMaui.ViewModel.Admin
{
    public partial class CategoriesViewModel : ObservableObject
    {
        private readonly CategoriesService _categoriesService;

        [ObservableProperty]
        private ObservableCollection<Category> categories;

        public CategoriesViewModel()
        {
            _categoriesService = new CategoriesService();
        }

        [RelayCommand]
        public async Task LoadCategoriesAsync()
        {
            var categoriesList = await _categoriesService.GetCategoriesAsync();
            categories = new ObservableCollection<Category>(categoriesList);
        }
    }
}
