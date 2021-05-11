using System.Collections.Generic;
using System.Reactive;
using ReactiveUI;

namespace FastNote.ViewModel
{
    public class NoteViewModel : ReactiveObject
    {
        public NoteViewModel()
        {
            Notes = new List<string>();
            AddNoteCommand = ReactiveCommand.Create(AddNote);
            ResetNoteListCommand = ReactiveCommand.Create(ResetNoteList);
        }
        
        private void AddNote()
        {
            if (Text.Length == 0) return;
            Notes.Add(Text);
            Text = string.Empty;
        }

        private void ResetNoteList()
        {
            Notes.Clear();
        }
        
        private string _text;
        public string Text
        {
            get => _text;
            set => this.RaiseAndSetIfChanged(ref _text, value);
        }
        
        private List<string> _notes;
        public List<string> Notes
        {
            get => _notes;
            set => this.RaiseAndSetIfChanged(ref _notes, value);
        }
        
        public ReactiveCommand<Unit, Unit> AddNoteCommand { get; }
        public ReactiveCommand<Unit, Unit> ResetNoteListCommand { get; }
    }
}