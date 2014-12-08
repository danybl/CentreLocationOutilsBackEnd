using CentreLocationOutils.db;
using CentreLocationOutils.dto;
using CentreLocationOutils.exception.facade;
using CentreLocationOutils.exception.service;
using CentreLocationOutils.facade.interfaces;
using CentreLocationOutils.service.interfaces;

namespace CentreLocationOutils.facade.implementations
{
   public class ReservationFacade : Facade, IReservationFacade
    {
       private IReservationService reservationService;

       public ReservationFacade(IReservationService reservationService)
           : base()
       {
           if (reservationService == null)
           {
               throw new InvalidServiceException("Le service de réservation ne peut être null");
           }
           setReservationService(reservationService);
       }

       private IReservationService getReservationService()
       {
           return this.reservationService;
       }
       private void setReservationService(IReservationService reservationService)
       {
           this.reservationService = reservationService;
       }

       public   void placerReservation(Connection connection, ReservationDTO reservationDTO)
       {
           try
           {
               getReservationService().placerReservation(connection, reservationDTO);
           }
           catch (ServiceException serviceException)
           {
               throw new FacadeException("", serviceException);
           }
       }

       public   void utiliserReservation(Connection connection, ReservationDTO reservationDTO)
       {
           try
           {
               getReservationService().utiliserReservation(connection, reservationDTO);
           }
           catch (ServiceException serviceException)
           {
               throw new FacadeException("", serviceException);
           }
       }

       public   void annulerReservation(Connection connection, ReservationDTO reservationDTO)
       {
           try
           {
               getReservationService().annulerReservation(connection, reservationDTO);
           }
           catch (ServiceException serviceException)
           {
               throw new FacadeException("", serviceException);
           }
       }

       //TODO intégrer les findByXXXXX

    }
}
