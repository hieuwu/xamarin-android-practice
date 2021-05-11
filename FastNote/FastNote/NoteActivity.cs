using System;
using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Widget;
using FastNote.Adapter;
using FastNote.ViewModel;
using ReactiveUI;


namespace FastNote
{
    [Activity(Label = "Note Activity")]
    public class NoteActivity : ReactiveActivity<NoteViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            ViewModel = new NoteViewModel();
            SetContentView(Resource.Layout.NoteActivityLayout);
            this.WireUpControls();
            SetUpRecyclerView();
            this.WhenActivated(Binding);
        }

        private void Binding(Action<IDisposable> d)
        {
            d(this.BindCommand(ViewModel, vm => vm.ResetNoteListCommand, v => v.ResetButton));
            d(this.BindCommand(ViewModel, vm => vm.AddNoteCommand, v => v.AddButton));

            d(this.Bind(ViewModel, vm => vm.Text, v => v.NoteEditText.Text,
                data => data,
                data => data.Trim()));
            d(this.WhenAnyObservable(v => v.ViewModel.AddNoteCommand).Subscribe(_ =>
            {
                _noteItemAdapter.NotifyDataSetChanged();
            }));
        }
        private void SetUpRecyclerView()
        {
            NotesRecyclerView.SetLayoutManager(new LinearLayoutManager(this));
            _noteItemAdapter = new NoteItemAdapter(ViewModel.Notes);
            NotesRecyclerView.SetAdapter(_noteItemAdapter);
        }

        public EditText NoteEditText { get; set; }
        public Button AddButton { get; set; }
        public Button ResetButton { get; set; }
        public RecyclerView NotesRecyclerView { get; set; }
        private NoteItemAdapter _noteItemAdapter;
    }
}