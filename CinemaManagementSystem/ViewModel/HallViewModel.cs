using CinemaManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.ViewModel
{
    public class HallViewModel : INotifyPropertyChanged
    {
        public Halls SelectedHall { get; set; }

        public ObservableCollection<Seats> Seats { get; set; }

        public int ColumnsCount => SelectedHall.RowsCount > 0
            ? (int)Math.Ceiling((double)SelectedHall.SeatsCount / SelectedHall.RowsCount)
            : 1;

        public HallViewModel(Halls hall)
        {
            SelectedHall = hall;
            Seats = new ObservableCollection<Seats>(
                hall.Seats.OrderBy(s => s.RowNumber).ThenBy(s => s.SeatNumber)
            );
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
