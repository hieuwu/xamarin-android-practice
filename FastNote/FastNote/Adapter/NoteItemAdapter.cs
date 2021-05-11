using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;
using FastNote.ViewHolder;

namespace FastNote.Adapter
{
    public class NoteItemAdapter : RecyclerView.Adapter
    {
        private readonly List<string> _notes;

        public NoteItemAdapter(List<string> notes)
        {
            _notes = notes;
        }
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var vh = holder as NoteItemViewHolder;
            vh.NoteTextView.Text = _notes[position];
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.NoteItemLayout, parent, false);
            var vh = new NoteItemViewHolder(view);
            return vh;
        }

        public override int ItemCount => _notes.Count;
    }
}