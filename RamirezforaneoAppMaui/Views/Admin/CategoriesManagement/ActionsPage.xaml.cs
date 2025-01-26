using RamirezforaneoAppMaui.ViewModel.Admin;
namespace RamirezforaneoAppMaui.Views.Admin.CategoriesManagement;

[QueryProperty(nameof(CategoryId), "CategoryId")]
public partial class ActionsPage : ContentPage
{
    private readonly CategoriesViewModel _viewModel;

    public int CategoryId { get; set; }

    public ActionsPage()
	{
		InitializeComponent();
	}
    public ActionsPage(CategoriesViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;

        BindingContext = _viewModel;
    }
    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        await _viewModel.ViewCategoryDetailsAsync(CategoryId);
    }
}