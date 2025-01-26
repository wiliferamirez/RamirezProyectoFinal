using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using RamirezforaneoAppMaui.Services;
using RamirezforaneoAppMaui.Models.Admin;


namespace RamirezforaneoAppMaui.ViewModel.Admin
{
    public partial class EventsViewModel : ObservableObject
    {
        private readonly EventsService _eventsService;

        [ObservableProperty]
        private ObservableCollection<Category> categories;

        [ObservableProperty]
        private ObservableCollection<Event> events;

        [ObservableProperty]
        private string newEventTitle;

        [ObservableProperty]
        private string newEventDescription;

        [ObservableProperty]
        private int selectedCategoryId;

        [ObservableProperty]
        private string newEventLocation;

        [ObservableProperty]
        private DateTime eventStartDate;

        [ObservableProperty]
        private DateTime eventEndDate;

        [ObservableProperty]
        private Category selectedCategory;



        public EventsViewModel()
        {
            _eventsService = new EventsService();
            Events = new ObservableCollection<Event>();
            Categories = new ObservableCollection<Category>();
            LoadCategoriesAsync();
        }


        [RelayCommand]
        private async Task LoadCategoriesAsync()
        {
            try
            {
                var categoryList = await _eventsService.GetCategoriesAsync();
                Categories = new ObservableCollection<Category>(categoryList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading categories: {ex.Message}");
            }
        }


        [RelayCommand]
        public async Task LoadEventsAsync()
        {
            var eventsList = await _eventsService.GetEventsAsync();
            Events = new ObservableCollection<Event>(eventsList);
        }

        [RelayCommand]
        private async Task NavigateToCreateEventAsync()
        {
            await Shell.Current.GoToAsync("///CreateEventPage");
        }
        [RelayCommand]
        private async Task CancelCreateEventAsync()
        {
            await Shell.Current.GoToAsync("///IndexEventsPage");
        }

        [RelayCommand]
        public async Task CreateEventAsync()
        {
            if (!string.IsNullOrWhiteSpace(newEventTitle) &&
                !string.IsNullOrWhiteSpace(newEventDescription) &&
                !string.IsNullOrWhiteSpace(newEventLocation) &&
                eventStartDate != default &&
                eventEndDate != default &&
                selectedCategory != null)
            {
                var newEvent = new Event
                {
                    EventTitle = newEventTitle,
                    EventDescription = newEventDescription,
                    CategoryId = selectedCategory.CategoryId,
                    EventLocation = newEventLocation,
                    EventStartDate = eventStartDate,
                    EventEndDate = eventEndDate
                };

                var success = await _eventsService.AddEventAsync(newEvent);
                if (success)
                {
                    await App.Current.MainPage.DisplayAlert("Success", "Event Created Succesfully", "OK");
                    await Shell.Current.GoToAsync("///IndexEventsPage");
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Error", "Failed at creating Event. Please try again.", "OK");
                }
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "Please fill all fields", "OK");
            }
        }
    }
}

