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
            DbContext context = new RiceContext(@"Filename=G:\Code\CS_Team_MP\SQL\Rice.db");
            UnitOfWork unitOfWork = new UnitOfWork(context);

            IAnnotationService annotationService = new AnnotationService(unitOfWork);
            IDataPropertyService dataService = new DataPropertyService(unitOfWork);
            IEntityService entityService = new EntityService(unitOfWork);

            TestServices(entityService);

            //string xmlString = File.ReadAllText(@"G:\Code\CS_Team_MP\OWL\RiceOntology.owl");
            //OwlToOntologyConverter converter = new OwlToOntologyConverter();
            //Ontology ontology = converter.Convert(xmlString);
        }

        private static bool TestServices(IEntityService entityService)
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

                // Update entity
                disease.Name = "Disease!";
                entityService.Update(disease);

                // Get entities by names
                Entity existedEntity = entityService.Get("Disease!");
                Entity notExistedEntity = entityService.Get("Pencil");

                // Delete entity by name, with cascade deletion
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