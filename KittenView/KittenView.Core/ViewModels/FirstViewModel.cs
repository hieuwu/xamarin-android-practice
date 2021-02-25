using KittenView.Core.Services;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KittenView.Core.ViewModels
{
    class FirstViewModel : MvxViewModel
    {
        readonly IKittenGenesisService _kittenGenesisService;
        private readonly IMvxNavigationService _navigationService;

        private string _convertString;
        public string ConvertString
        {
            get { return _convertString; }
            set
            {
                _convertString = value;
                RaisePropertyChanged(() => ConvertString);
            }
        }

        private List<Kitten> _kittens;
        public List<Kitten> Kittens
        {
            get { return _kittens; }
            set
            {
                _kittens = value;
                RaisePropertyChanged(() => Kittens);
            }
        }
        public FirstViewModel(IKittenGenesisService kittenGenesisService, IMvxNavigationService navigationService)
        {
            _kittenGenesisService = kittenGenesisService;
            _navigationService = navigationService;
        }

        public override async Task Initialize()
        {
            await base.Initialize();
            var newKittenList = new List<Kitten>();
            for (var i = 0; i < 13; i++)
            {
                var newKitten = _kittenGenesisService.CreatNewKitten(i.ToString());
                newKittenList.Add(newKitten);
            }
            Kittens = newKittenList;
        }

        public async Task SomeMethod()
        {
            await _navigationService.Navigate<SecondViewModel, Kitten>(new Kitten { Name="Hieu vu", Price=12, ImageUrl="123"});
        }

        private MvxAsyncCommand _goSecondViewCommand;
        public ICommand GoToSecondViewCommand
        {
            get { _goSecondViewCommand = _goSecondViewCommand ?? new MvxAsyncCommand(SomeMethod); return _goSecondViewCommand; }

        }

        private MvxCommand<Kitten> _itemClickedCommand;
        public ICommand ItemClickedCommand
        {
            get
            {
                return _itemClickedCommand = _itemClickedCommand ??
                    new MvxCommand<Kitten>(memory => {
                        _navigationService.Navigate<SecondViewModel, Kitten>(memory);
                    });
            }
        }

    }
}
