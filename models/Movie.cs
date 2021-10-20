using System;

/*
    Class Movie object that generates instances
     of movies to be watched.
*/
public class Movie
    {
        private string description;
        public string Description { get => description; set => description = value; }           
        private string year;
        public string Year { get => year; set => year = value; }
        private Guid id;
        public Guid Id { get => id; set => id = value; }

        public Movie() { }

        public Movie(
            string description,
            string year)
        {
            this.Description = description;
            this.Year = year;
            this.id = Guid.NewGuid();
        }

        public override string ToString()
        {
            return " Description: " + this.Description
                 + ", Year: " + this.Year;
        }

        public override bool Equals(object other)
        {
            if (other.GetType() == this.GetType())
            {
                var otherBike = other as Movie;
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

            var otherBike = other as Movie;

            if (this.Equals(otherBike))
                return 0;
            if (this.description.CompareTo(otherBike.description) < 0)
                return -1;
            if (this.description.CompareTo(otherBike.description) > 0)
                return 1;
            return this.Year.CompareTo(otherBike.Year);
        }

    }
