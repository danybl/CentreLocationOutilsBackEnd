﻿using CentreLocationOutils.db;
using CentreLocationOutils.dto;
using CentreLocationOutils.exception.facade;
using CentreLocationOutils.exception.service;
using CentreLocationOutils.facade.interfaces;
using CentreLocationOutils.service.interfaces;
using System.Collections.Generic;

namespace CentreLocationOutils.facade.implementations
{
    /// <summary>
    /// Facade pour interagir avec le service de reservation.
    /// </summary>
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

       #region Getters and Setters

       /// <summary>
       /// Getter de la variable d'instance <code>this.reservationService</code>.
       /// </summary>
       /// <returns>La variable d'instance <code>this.reservationService</code></returns>
       private IReservationService getReservationService()
       {
           return this.reservationService;
       }

       /// <summary>
       /// Setter de la variable d'instance <code>this.reservationService</code>.
       /// </summary>
       /// <param name="reservationService">La valeur à utiliser pour la variable d'instance <code>this.reservationService</code></param>
       private void setReservationService(IReservationService reservationService)
       {
           this.reservationService = reservationService;
       }

       #endregion
       #region CRUD
       /// <inheritdoc />
       public void placerReservation(Connection connection, ReservationDTO reservationDTO)
       {
           try
           {
               getReservationService().placerReservation(connection, reservationDTO);
           }
           catch (ServiceException serviceException)
           {
               throw new FacadeException("Un erreur s'est produit : " + serviceException);
           }
       }

       /// <inheritdoc />
       public void utiliserReservation(Connection connection, ReservationDTO reservationDTO)
       {
           try
           {
               getReservationService().utiliserReservation(connection, reservationDTO);
           }
           catch (ServiceException serviceException)
           {
               throw new FacadeException("Un erreur s'est produit : " + serviceException);
           }
       }

       /// <inheritdoc />
       public void annulerReservation(Connection connection, ReservationDTO reservationDTO)
       {
           try
           {
               getReservationService().annulerReservation(connection, reservationDTO);
           }
           catch (ServiceException serviceException)
           {
               throw new FacadeException("Un erreur s'est produit : " + serviceException);
           }
       }
       /// <inheritdoc />
       public ReservationDTO getReservation(Connection connection, string idReservation)
       {
           try
           {
               return getReservationService().getReservation(connection, idReservation);
           }
           catch (ServiceException serviceException)
           {
               throw new FacadeException("Un erreur s'est produit : " + serviceException);
           }
       }
       /// <inheritdoc />
       public List<ReservationDTO> getAllReservations(Connection connection, string sortByPropertyName)
       {
           try
           {
               return getReservationService().getAllReservations(connection, sortByPropertyName);
           }
           catch (ServiceException serviceException)
           {
               throw new FacadeException("Un erreur s'est produit : " + serviceException);
           }
       }

       /// <inheritdoc />
       public List<ReservationDTO> findByOutil(Connection connection, ReservationDTO reservationDTO)
       {
           try
           {
               return getReservationService().findByOutil(connection, reservationDTO);
           }
           catch (ServiceException serviceException)
           {
               throw new FacadeException("Un erreur s'est produit : " + serviceException);
           }
       }
       #endregion
    }
}
