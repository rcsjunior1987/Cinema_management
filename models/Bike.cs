using System;

/*
    Class Bike object that generates instances
     of bikes to be hired.
*/
public class Bike
    {
        private string description;
        public string Description { get => description; set => description = value; }       
        private string brandDescription;
        public string BrandDescription { get => brandDescription; set => brandDescription = value; }
        private string yearMade;
        public string YearMade { get => yearMade; set => yearMade = value; }
        private int code;
        public int Code { get => code; set => code = value; }
        private Guid id;
        public Guid Id { get => id; set => id = value; }

        public Bike() { }

        public Bike(
            string description,
            string brandDescription,
            string yearMade)
        {
            this.Description = description;
            this.BrandDescription = brandDescription;
            this.YearMade = yearMade;
            this.id = Guid.NewGuid();
        }

        public override string ToString()
        {
            return "Code: " + this.Code
                 + ", Description: " + this.Description
                 + ", Brand: " + this.BrandDescription
                 + ", Made in: " + this.YearMade;
        }

        public override bool Equals(object other)
        {
            if (other.GetType() == this.GetType())
            {
                var otherBike = other as Bike;
                return otherBike.Id == this.Id;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int CompareTo(object other)
        {
            if (other == null)
                return 1;

            var otherBike = other as Bike;

            if (this.Equals(otherBike))
                return 0;
            if (this.description.CompareTo(otherBike.description) < 0)
                return -1;
            if (this.description.CompareTo(otherBike.description) > 0)
                return 1;
            if (this.brandDescription.CompareTo(otherBike.brandDescription) == 0)
                return -1;
            return this.brandDescription.CompareTo(otherBike.brandDescription);
        }

    }
