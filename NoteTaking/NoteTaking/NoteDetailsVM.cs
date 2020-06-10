
using Xamarin.Forms;

namespace NoteTaking
{
    public class NoteDetailsVM 
    {
        public string Note { get; }

        public NoteDetailsVM(string note)
        {
            Note = note;
        }
    }
}