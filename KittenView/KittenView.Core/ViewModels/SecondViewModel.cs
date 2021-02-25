using KittenView.Core.Services;
using MvvmCross.Core.ViewModels;

namespace KittenView.Core.ViewModels
{
    class SecondViewModel : MvxViewModel<Kitten>
    {
        private Kitten _initialParameter;


        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged(() => Name);
            }
        }

        private int _price;
        public int Price
        {
            get { return _price; }
            set
            {
                _price = value;
                RaisePropertyChanged(() => Price);
            }
        }

        public override void Prepare(Kitten parameter)
        {
            Name = parameter.Name;
            Price = parameter.Price;
        }

       
    }
}
