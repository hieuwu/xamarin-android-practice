using KittenView.Core.Services;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KittenView.Core.ViewModels
{
    class FirstViewModel : MvxViewModel
    {
        readonly IKittenGenesisService _kittenGenesisService;
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
        public FirstViewModel(IKittenGenesisService kittenGenesisService)
        {
            _kittenGenesisService = kittenGenesisService;

    
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


    }
}
