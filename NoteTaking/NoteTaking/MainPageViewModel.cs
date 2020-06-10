using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace NoteTaking
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public MainPageViewModel()
        {
            AllNotes = new ObservableCollection<string>();

            SaveCommand = new Command(() =>
            {
                Note = Note.Trim();
                if (!string.IsNullOrEmpty(Note))
                {
                    AllNotes.Add(Note);
                }
                TheNote = string.Empty;
            });

            CancelCommand = new Command(() =>
            {
                TheNote = string.Empty;
            });

            DeleteAllCommand = new Command(() =>{
                AllNotes.Clear();
            });

            SelectionChangedCommad = new Command( async() =>
            {
                NoteDetailsVM detailsVm = new NoteDetailsVM(SelectedNote);

                NoteDetails noteDetailsView = new NoteDetails();

                noteDetailsView.BindingContext = detailsVm;

               await Application.Current.MainPage.Navigation.PushAsync(noteDetailsView);
            });
        }

        public string TheNote
        {
            get => Note;
            set
            {
                Note = value;
                var args = new PropertyChangedEventArgs(nameof(TheNote));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        
        public ObservableCollection<string> AllNotes { get; }

        public string SelectedNote { get; set; }

        public Command SaveCommand { get; }

        public Command CancelCommand { get; }

        public Command DeleteAllCommand { get; }

        public Command SelectionChangedCommad { get; }

        string Note;


    }
}
