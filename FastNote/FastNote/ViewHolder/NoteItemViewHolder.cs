using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace FastNote.ViewHolder
{
    public class NoteItemViewHolder: RecyclerView.ViewHolder
    {
        public NoteItemViewHolder(View itemView) : base(itemView)
        {
            NoteTextView = itemView.FindViewById<TextView>(Resource.Id.NoteItemTextView);
          
        }
        public TextView NoteTextView { get; set; }
    }
}