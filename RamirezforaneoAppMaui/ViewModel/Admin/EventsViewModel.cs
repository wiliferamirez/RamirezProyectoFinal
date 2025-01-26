using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using RamirezforaneoAppMaui.Services;
using RamirezforaneoAppMaui.Models.Admin;
using System.Threading.Tasks;


namespace RamirezforaneoAppMaui.ViewModel.Admin
{
    public partial class EventsViewModel : ObservableObject
    {
        private readonly EventsService _eventsService;

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


        public EventsViewModel()
        {

            _eventsService = new EventsService();
            Events = new ObservableCollection<Event>();
        }

        // Command to load events
        [RelayCommand]
        public async Task LoadEventsAsync()
        {
            var eventsList = await _eventsService.GetEventsAsync();
            Events = new ObservableCollection<Event>(eventsList);
        }

        // Command to create a new event
        [RelayCommand]
        public async Task CreateEventAsync()
        {
            if (!string.IsNullOrWhiteSpace(newEventTitle) &&
                !string.IsNullOrWhiteSpace(newEventDescription) &&
                !string.IsNullOrWhiteSpace(newEventLocation) &&
                eventStartDate != default &&
                eventEndDate != default)
            {
                var newEvent = new Event
                {
                    EventTitle = newEventTitle,
                    EventDescription = newEventDescription,
                    CategoryId = selectedCategoryId,  // Assuming category is selected
                    EventLocation = newEventLocation,
                    EventStartDate = eventStartDate,
                    EventEndDate = eventEndDate
                };

                var success = await _eventsService.AddEventAsync(newEvent);
                if (success)
                {
                    // Handle success (e.g., navigate back, show success message)
                }
                else
                {
                    // Handle failure (e.g., show error message)
                }
            }
            else
            {
                // Handle validation errors (e.g., show validation error messages)
            }
        }
    }
}

