using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CentreLocationOutils.dao.interfaces;
using CentreLocationOutils.db;
using CentreLocationOutils.dto;


namespace CentreLocationOutils.service.interfaces
{
    /// <summary>
    /// Interface de base pour les services.<br/>
    /// Toutes les interfaces de service devrait en hériter.
    /// </summary>
    public interface IReservationService : IService
    {

        /// <summary>
        /// Ajoute un nouvelle reservation dans la base de données.
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="reservationDTO">L'outil à ajouter</param>
        void addReservation(Connection connection,
        ReservationDTO reservationDTO);

        /// <summary>
        /// Met à jour une reservation dans la base de données.
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="reservationDTO">La reservation à mettre à jour</param>
        void updateReservation(Connection connection,
        ReservationDTO reservationDTO);

        /// <summary>
        /// Supprime une reservation de la base de données.
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="reservationDTO">La reservation à enlever</param>
        void deleteReservation(Connection connection,
        ReservationDTO reservationDTO);

        /// <summary>
        /// Obtient une reservation
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="idReservation"></param>
        /// <returns></returns>
        ReservationDTO getReservation(Connection connection, string idReservation);

        /// <summary>
        /// Trouve tous les reservations de la base de données. 
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="sortByPropertyName">La liste est classée par ordre croissant sur <code>sortByPropertyName</code>.</param>
        /// <returns>Si aucune reservation n'est trouvée, une liste vide est retournée.</returns>
        List<ReservationDTO> getAllReservations(Connection connection,
        string sortByPropertyName);


        /// <summary>
        /// Placer une reservation.
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="reservationDTO">La reservation à acquerir</param>
        void placerReservation(Connection connection,
        ReservationDTO reservationDTO);

        /// <summary>
        /// Utiliser une reservation.
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="reservationDTO">La reservation à utiliser</param>
        void utiliserReservation(Connection connection,
        ReservationDTO reservationDTO);

        /// <summary>
        /// Annuler une reservation.
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="reservationDTO">La reservation à annuler</param>
        void annulerReservation(Connection connection,
        ReservationDTO reservationDTO);

        /// <summary>
        /// Trouve les reservations à partir d'un client. 
        /// Si aucune reservation n'est trouvé, une liste vide est retournée.  
        /// </summary>
        /// <param name="connection">La connexion à utiliser</param>
        /// <param name="reservationDTO"></param>
        /// <param name="sortByPropertyName">Le client de la propriété à utiliser pour classer la liste</param>
        /// <returns>Si aucune reservation n'est trouvée, une liste vide est retournée.</returns>
        List<ReservationDTO> findByClient(Connection connection, ReservationDTO reservationDTO);

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
