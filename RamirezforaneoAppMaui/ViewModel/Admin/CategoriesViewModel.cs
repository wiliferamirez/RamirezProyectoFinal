using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using RamirezforaneoAppMaui.Models.Admin;
using RamirezforaneoAppMaui.Services;
using CommunityToolkit.Mvvm.Input;
using RamirezforaneoAppMaui.Views.Admin.CategoriesManagement;
using System;

namespace RamirezforaneoAppMaui.ViewModel.Admin
{
    public partial class CategoriesViewModel : ObservableObject
    {
        private readonly CategoriesService _categoriesService;

        [ObservableProperty]
        private ObservableCollection<Category> categories;

        [ObservableProperty]
        private string newCategoryName;


        [ObservableProperty]
        private Category selectedCategory; 

        public CategoriesViewModel()
        {
            _categoriesService = new CategoriesService();
            Categories = new ObservableCollection<Category>();
        }

        [RelayCommand]
        private async Task NavigateToCreateCategoryAsync()
        {
            await Shell.Current.GoToAsync("///CreateCategoryPage");
        }

        [RelayCommand]
        private async Task NavigateToActionsPageAsync(Category selectedCategory)
        {
            SelectedCategory = selectedCategory;
            Console.WriteLine("Selected Category: " + SelectedCategory.CategoryId);
            if (selectedCategory != null)
            {
                var route = $"///ActionsCategoriesPage?CategoryId={selectedCategory.CategoryId}";
                await Shell.Current.GoToAsync(route);
            }
        }


        [RelayCommand]
        public async Task LoadCategoriesAsync()
        {
            var categoriesList = await _categoriesService.GetCategoriesAsync();
            Categories = new ObservableCollection<Category>(categoriesList);
        }

        [RelayCommand]
        public async Task ViewCategoryDetailsAsync(int categoryId)
        {
            var category = await _categoriesService.GetCategoryDetailsAsync(categoryId);
            if (category != null)
            {
                SelectedCategory = category;
            }
        }


        [RelayCommand]
        private async Task CreateCategoryAsync()
        {
            if (!string.IsNullOrWhiteSpace(newCategoryName))
            {
                var newCategory = new Category
                {
                    CategoryName = NewCategoryName,
                };

                var success = await _categoriesService.AddCategoryAsync(newCategory);
                if (success)
                {
                    await Shell.Current.DisplayAlert("Success", "Category created successfully!", "OK");
                    await Shell.Current.GoToAsync("..");
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "Failed to create category.", "OK");
                }
            }
            else
            {
                await Shell.Current.DisplayAlert("Validation Error", "All fields are required.", "OK");
            }
        }

        [RelayCommand]
        private async Task CancelCreateCategoryAsync()
        {
            await Shell.Current.GoToAsync("///IndexCategoryPage");
        }

        [RelayCommand]
        public async Task UpdateCategoryAsync()
        {
            if (SelectedCategory != null && await _categoriesService.UpdateCategoryAsync(SelectedCategory))
            {
               
                var category = Categories.FirstOrDefault(c => c.CategoryId == SelectedCategory.CategoryId);
                if (category != null)
                {
                    category.CategoryName = SelectedCategory.CategoryName;
                    OnPropertyChanged(nameof(Categories));
                }
            }
        }


        [RelayCommand]
        public async Task DeleteCategoryAsync(int categoryId)
        {
            if (await _categoriesService.DeleteCategoryAsync(categoryId))
            {
                var categoryToRemove = Categories.FirstOrDefault(c => c.CategoryId == categoryId);
                if (categoryToRemove != null)
                {
                    Categories.Remove(categoryToRemove); 
                }
            }
        }
    }
}
