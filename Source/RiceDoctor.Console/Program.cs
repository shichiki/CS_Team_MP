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
                Entity disease = new Entity
                {
                    Name = "Disease",
                    VietnameseName = "Bệnh"
                };
                entityService.Add(disease);

                IEnumerable<Entity> entities = entityService.GetAll();

                disease.Definition = "A disease is a particular abnormal condition," +
                                     " a disorder of a structure or function," +
                                     " that affects part or all of an organism.";
                entityService.Update(disease);

                Entity existedEntity = entityService.Get("Disease");
                Entity notExistedEntity = entityService.Get("Pencil");

                entityService.Delete("Disease");

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