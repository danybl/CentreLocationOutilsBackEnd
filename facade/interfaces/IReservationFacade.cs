using CentreLocationOutils.db;
using CentreLocationOutils.dto;
using System.Collections.Generic;

namespace CentreLocationOutils.facade.interfaces
{
    /// <summary>
    /// Interface de façade pour manipuler les réservations dans la base de données.
    /// </summary>
    public interface IReservationFacade : IFacade
    {
        /// <summary>
        /// Placer une reservation.
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="reservationDTO">La reservation à acquerir</param>
        void placerReservation(Connection connection, ReservationDTO reservationDTO);

        /// <summary>
        /// Utiliser une reservation.
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="reservationDTO">La reservation à utiliser</param>
        void utiliserReservation(Connection connection, ReservationDTO reservationDTO);

        /// <summary>
        /// Annuler une reservation.
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="reservationDTO">La reservation à annuler</param>
        void annulerReservation(Connection connection, ReservationDTO reservationDTO);

        /// <summary>
        /// Obtient une reservation
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="idReservation"></param>
        /// <returns></returns>
        ReservationDTO getReservation(Connection connection, string idReservation);

        /// <summary>
        /// Obtient toutes les reservations
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="sortByPropertyName"></param>
        /// <returns></returns>
        List<ReservationDTO> getAllReservations(Connection connection, string sortByPropertyName);

        /// <summary>
        /// Trouve les reservations à partir d'un outil. 
        /// Si aucune reservation n'est trouvé, une liste vide est retournée.  
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="reservationDTO"></param>
        /// <param name="sortByPropertyName">L'outil de la propriété à utiliser pour classer la liste</param>
        /// <returns>Si aucune reservation n'est trouvée, une liste vide est retournée.</returns>
        List<ReservationDTO> findByOutil(Connection connection, ReservationDTO reservationDTO);

    }
}
