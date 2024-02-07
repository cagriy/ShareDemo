namespace ShareDemo;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnCounterClicked(object sender, EventArgs e)
    {
        await using Stream inputStream = await FileSystem.Current.OpenAppPackageFileAsync("dotnet_bot.png");
        string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, "dotnet_bot.png");

        using FileStream outputStream = File.Create(targetFile);
        await inputStream.CopyToAsync(outputStream);
        outputStream.Close();
        await Share.Default.RequestAsync(new ShareFileRequest
        {
            Title = "Share Image",
            File = new ShareFile(targetFile)
        });
    }
}