using System;

/*
    Class Movie object that generates instances
     of movies to be watched.
*/
public class Movie
    {
        private string description;
        public string Description { get => description; set => description = value; }           
        private Guid id;
        public Guid Id { get => id; set => id = value; }
        private Queue<Screenings> screenings;
        public Queue<Screenings> Screenings { get => screenings; set => screenings = value; }

        public Movie() { 
            this.Screenings = new Queue<Screenings>();
        }

        public Movie(string description)
        {
            this.Description = description;
            this.id = Guid.NewGuid();
        }

        public override string ToString()
        {
            string movie = " Description: " + this.Description;

            movie = movie + "\n      Screenings "; 

            foreach(Screenings s in this.Screenings) {
                movie = movie + "\n         Screenings Id: " + s.Id;
                movie = movie + ", Seats available: " + s.NumSeats;
            }

            return movie;
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

            return this.description.CompareTo(otherBike.description);
        }

    }
