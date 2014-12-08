using CentreLocationOutils.db;
using CentreLocationOutils.dto;

namespace CentreLocationOutils.facade.interfaces
{
    public interface IReservationFacade : IFacade
    {
        void placerReservation(Connection connection, ReservationDTO reservationDTO);
        void utiliserReservation(Connection connection, ReservationDTO reservationDTO);
        void annulerReservation(Connection connection, ReservationDTO reservationDTO);

    }
}
