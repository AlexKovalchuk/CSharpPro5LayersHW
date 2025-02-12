using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Animals.Core.Domain.Owners.Models;

namespace Animals.Core.Domain.Animals.Models
{
    public class AnimalOwner
    {
        private AnimalOwner(){}

        private AnimalOwner(Guid animalId, Guid ownerId)
        {
            AnimalId = animalId;
            OwnerId = ownerId;
        }

        public Guid AnimalId { get; private set; }

        public Animal Animal { get; private set; }

        public Guid OwnerId { get; private set; }

        public Owner Owner { get; private set; }

        public static AnimalOwner Create(Guid animalId, Guid ownerId)
        {
            return new AnimalOwner(animalId, ownerId);
        }
    }
}
