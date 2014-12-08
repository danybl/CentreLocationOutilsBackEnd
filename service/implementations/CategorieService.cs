using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CentreLocationOutils.dao.implementations;
using CentreLocationOutils.dao.interfaces;
using CentreLocationOutils.exception.dao;
using CentreLocationOutils.exception.dto;
using CentreLocationOutils.exception.service;
using CentreLocationOutils.exception.db;
using CentreLocationOutils.db;
using CentreLocationOutils.dto;
using System.Data.Common;

namespace CentreLocationOutils.service.implementations
{
    class CategorieService
    {

        private ICategorieDAO categorieDAO;

        public CategorieService(ICategorieDAO categorieDAO) {

                if (categorieDAO == null)
                {
                    throw new InvalidDAOException("Le DAO de categorie ne peut être null");
                }
                setCategorieDAO(categorieDAO);
        }

        //set et get
        private ICategorieDAO getCategorieDAO()
        {
            return this.categorieDAO;
        }
        private void setCategorieDAO(ICategorieDAO categorieDAO)
        {
            this.categorieDAO = categorieDAO;
        }

        //Ajout d'une catégorie
        public   void add(Connection connection, CategorieDTO categorieDTO) {
            try {
                getCategorieDAO().add(connection,
                    categorieDTO);
            }
            catch (DbException dbException)
            {
                throw new DAOException(dbException);
            }
        }
        //Lecture des catégories
        public   CategorieDTO get(Connection connection, String idCategorie) {
            try {
                return (CategorieDTO) getCategorieDAO().get(connection,
                    idCategorie);
            } catch(DbException dbException) {
                throw new DAOException(dbException);
            }
        }

        //Mise à jour d'une catégorie
        public   void update(Connection connection,
        CategorieDTO categorieDTO) 
         {
            try {
                getCategorieDAO().update(connection,
                    categorieDTO);
            }
            catch (DbException dbException)
            {
                throw new DAOException(dbException);
            }
        }
        //Suppression d'une catégorie
        public   void delete(Connection connection,
        CategorieDTO categorieDTO){
            try {
                getCategorieDAO().delete(connection,
                    categorieDTO);
            }
            catch (DbException dbException)
            {
                throw new DAOException(dbException);
            }
        }
        //Lecture de toutes les catégories
        public   List<CategorieDTO> getAll(Connection connection,
        String sortByPropertyName){
            try {
                return (List<CategorieDTO>)getCategorieDAO().getAll(connection,
                    sortByPropertyName);
            }
            catch (DbException dbException)
            {
                throw new DAOException(dbException);
            }
        }
        //Trouver une catégorie par son nom
        public   List<CategorieDTO> findByNom(Connection connection,
        String nom,
        String sortByPropertyName){
        try {
            return getCategorieDAO().findByNom(connection,
                nom,
                sortByPropertyName);
        }
        catch (DbException dbException)
        {
            throw new DAOException(dbException);
        }
    }

    }
}