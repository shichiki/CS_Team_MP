using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using RiceDoctor.OntologyManager.Models;
using RiceDoctor.OntologyManager.OntologyModels;
using RiceDoctor.OntologyManager.Repositories;
using RiceDoctor.OntologyManager.Services;

namespace RiceDoctor.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DbContext context = new RiceContext();
            UnitOfWork unitOfWork = new UnitOfWork(context);

            IDataPropertyService dataService = new DataPropertyService(unitOfWork);
            IEntityService entityService = new EntityService(unitOfWork);

            TestEntityService(entityService);

            //string xmlString = File.ReadAllText(@"G:\Code\CS_Team_MP\OWL\RiceOntology.owl");
            //OwlToOntologyConverter converter = new OwlToOntologyConverter();
            //Ontology ontology = converter.Convert(xmlString);
        }

        private static bool TestEntityService(IEntityService entityService)
        {
            try
            {
                // Add new entity
                Entity disease = new Entity
                {
                    Name = "Disease"
                };
                entityService.Add(disease);

                // Get all entities
                IEnumerable<Entity> entities = entityService.GetAll();

                // Update entity, if updating new name must require old name
                disease.Name = "Disease!";
                entityService.Update(disease, "Disease");

                // Get entities by names
                Entity existedEntity = entityService.Get("Disease!");
                Entity notExistedEntity = entityService.Get("Pencil");

                // Delete entity by name
                entityService.Delete("Disease!");

                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);

                return false;
            }
        }
    }
}