
using Xamarin.Forms;

namespace NoteTaking
{
    public class NoteDetailsVM 
    {
        public string Note { get; }

        public NoteDetailsVM()
        {
            DismissCommand = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PopAsync();
            });
        }

        public NoteDetailsVM(string note)
        {
            Note = note;

            DismissCommand = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PopModalAsync();
            });
        }

        public Command DismissCommand { get; }
    }
}