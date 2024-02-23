using Mopups.Services;

namespace MainThreadCrash
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            mopupFunction();
        }

        private async void mopupFunction()
        {
            // Doesnt work #1
            await MopupService.Instance.PushAsync(new HelloMopup());

            // Doesnt work #2
            //MainThread.BeginInvokeOnMainThread(async () =>
            //{
            //    await MopupService.Instance.PushAsync(new HelloMopup());
            //});

            // Works
            //Device.BeginInvokeOnMainThread(async () =>
            //{
            //    await MopupService.Instance.PushAsync(new HelloMopup());
            //});
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
